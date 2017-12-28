/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 22/12/2017
 * Hora: 6:08 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Globalization;
using System.Threading;
using System.Resources;
using System.Reflection;

namespace ActualizadorSaldosWO.Class
{
	/// <summary>
	/// Description of DataaBaseUtils.
	/// </summary>
	public class DataBaseUtils
	{
		
		public Conexion Conexion {set; get;}
		
		DataTable TableCuentas = new DataTable();
		
		SqlConnection sqlConn;
		
		SqlCommand cm;
		
		bool conectado = false;		
		
		readonly string TABLA_NIFF = "vw_ca_saldos";
		
		readonly string TABLA_COLGAAP = "vw_ca_saldos_cg";
		
		decimal saldoCuentautilidadDelEjercicio = 0, SaldosAcumuladosMesGrupo4 = 0, SaldosAcumuladosMesGrupo5 = 0,  SaldosAcumuladosMesGrupo6 = 0, SaldosAcumuladosMesGrupo7 = 0;
		
		int filaActual = 0;
		
		int filaSaldoNegativo = 0, filaSaldoPositivo = 0; //, filaUtilidadDelEjercicio = 0;
		
		// Delegado
		public delegate void DelegadoLog(string mensaje);
		//Evento
		public event DelegadoLog MiEvento;
		
		public DataBaseUtils()
		{
		}
		
		void SetupDataTable()
		{
			TableCuentas = new DataTable();
			TableCuentas.Columns.Add("ano", typeof(int));
			TableCuentas.Columns.Add("mes", typeof(int));
			TableCuentas.Columns.Add("codigo", typeof(string));
			TableCuentas.Columns.Add("descripcion", typeof(string));
			TableCuentas.Columns.Add("efecto", typeof(decimal));
			TableCuentas.Columns.Add("saldo_inicial", typeof(decimal));
			TableCuentas.Columns.Add("debito", typeof(decimal));
			TableCuentas.Columns.Add("credito", typeof(decimal));
			TableCuentas.Columns.Add("saldo_final", typeof(decimal));
		}
		
		void Conectar()
		{
			try {
				string strCon = Conexion.ToString();
				sqlConn = new SqlConnection(strCon);
				sqlConn.Open();
				cm = new SqlCommand();
				cm.CommandTimeout = 30000;
				conectado = true;
				this.MiEvento(string.Format("Conectado a : {0}", Conexion.Nombre));
			} catch (Exception ex) {
				conectado = false;
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				this.MiEvento(string.Format("Error al conectar a : {0}", Conexion.Nombre));
			}
		}
		
		void Desconectar()
		{
			try {
				sqlConn.Close();
				this.MiEvento(string.Format("Cerrando conexcion a : {0}", Conexion.Nombre));
			} catch (Exception) {
			}
		}
		
		void CargarFechas()
		{
			if(conectado)
			{
				cm.Connection = sqlConn;
				cm.CommandText = "SELECT MIN(Fecha), MAX(Fecha) FROM [CuentasContables - Asientos]";
				cm.CommandType = CommandType.Text;
				using (SqlDataReader dr = cm.ExecuteReader())
	            {
	                if(dr.Read())
	                {
	                	//Conexion.FechaInicial = new DateTime(dr.GetDateTime(0).Year, dr.GetDateTime(0).Month, 1) ;
	                	Conexion.FechaFinal = new DateTime(dr.GetDateTime(1).Year, dr.GetDateTime(1).Month, DateTime.DaysInMonth(dr.GetDateTime(1).Year, dr.GetDateTime(1).Month)) ;
	                	this.MiEvento(string.Format("Procesando movimientos desde {0} hasta {1}", Conexion.FechaInicial.ToShortDateString(), Conexion.FechaFinal.ToShortDateString()));
	                }                
	            }
				cm.CommandText = string.Format("SELECT MAX(ano) FROM {0}",  Conexion.EsNiif ? "vw_ca_saldos" : "vw_ca_saldos_cg" );
				using (SqlDataReader dr = cm.ExecuteReader())
	            {
	                if(dr.Read())
	                {
	                	Conexion.FechaInicial = new DateTime(dr.GetInt32(0),1,1);
	                	Conexion.NumeroCuentas = dr.GetInt32(0);
	                	this.MiEvento(string.Format("Numero de cuentas a procesar : {0}", Conexion.NumeroCuentas));
	                }                
	            }
				
				cm.CommandText = string.Format("SELECT COUNT(*) FROM CuentasContables WHERE LEN(CódigoCuentaContable) = {0}  ",  Conexion.NivelCuenta );
				using (SqlDataReader dr = cm.ExecuteReader())
	            {
	                if(dr.Read())
	                {
	                	//Conexion.FechaInicial = new DateTime(dr.GetDateTime(0).Year, dr.GetDateTime(0).Month, 1) ;
	                	Conexion.NumeroCuentas = dr.GetInt32(0);
	                	this.MiEvento(string.Format("Numero de cuentas a procesar : {0}", Conexion.NumeroCuentas));
	                }                
	            }
				
				DateTime fechaInicio = Conexion.FechaInicial;
				while (fechaInicio <= Conexion.FechaFinal) {
					Conexion.NumeroMeses ++;
					fechaInicio = fechaInicio.AddMonths(1);
				}
				this.MiEvento(string.Format("Numero de meses a procesar : {0}", Conexion.NumeroMeses));
			}
		}
		
		void CargarPeriodo( DateTime fechaInicial, DateTime fechaFinal, bool cierre = false )
		{
			//System.Windows.Forms.MessageBox.Show(NIIF.ToString());
			 
			string sSQL = string.Format("SELECT " +
										"	[CódigoCuentaContable],  " +
										"	[CuentaContable],  " +
										"	[Efecto] ,  " +
										"	dbo.{3}([CódigoCuentaContable], '{0}', null, 1, null), " +
										"	dbo.{4}([CódigoCuentaContable], '{0}', '{1}', null, 1, null), " +
										"	dbo.{5}([CódigoCuentaContable], '{0}', '{1}', null, 1, null) " +
										"FROM [CuentasContables - Tipos] AS CCA_TIP   " +
										"INNER JOIN [CuentasContables - Naturaleza] AS CCA_NAT ON CCA_TIP.IdNaturalezaDeCuentaContable = CCA_NAT.IdNaturalezaDeCuentaContable   " +
										"INNER JOIN CuentasContables AS CC ON CCA_TIP.IdCuentasContablesTipos = CC.IdCuentasContablesTipos  " +
										"WHERE LEN(CódigoCuentaContable) = {2} ORDER BY [CódigoCuentaContable] ", 
										fechaInicial.ToString("dd/MM/yyy"), 
										fechaFinal.ToString("dd/MM/yyy"), 
										Conexion.NivelCuenta, 
										Conexion.EsNiif ? "UfnGetSaldoInicial": "UfnGetSaldoInicialCG", 
										Conexion.EsNiif ? "ufnGetDebito": "ufnGetDebitoCG", 
										Conexion.EsNiif ? "ufnGetCredito": "ufnGetCreditoCG" );
			
			//Debug.WriteLine(sSQL);
			cm.CommandText = sSQL;
			using (SqlDataReader dr = cm.ExecuteReader())
            {
                while(dr.Read())
                {
                	int digito = int.Parse(dr.GetString(0).Substring(0, 1));
                	decimal saldoInicial = dr.GetDecimal(3) * dr.GetDecimal(2);
                	decimal debito = dr.GetDecimal(4);
                	decimal credito = dr.GetDecimal(5);
                	decimal saldoFinal = ((dr.GetDecimal(3) * dr.GetDecimal(2)) + dr.GetDecimal(4)) - dr.GetDecimal(5);
                	
                	//Acumular los saldos de las cuentas del 4 al 7
                	if(fechaInicial.Month >= 1 && fechaInicial.Month <= 12) {
                		switch(digito) {
							case 4:
								SaldosAcumuladosMesGrupo4 = SaldosAcumuladosMesGrupo4 + (debito - credito);
			                	break;
			           		case 5:
			                	SaldosAcumuladosMesGrupo5 = SaldosAcumuladosMesGrupo5 + (debito - credito);
			                	break;
			             	case 6:
			                	SaldosAcumuladosMesGrupo6 = SaldosAcumuladosMesGrupo6 + (debito - credito);
			                	break;
			                case 7:
			                	SaldosAcumuladosMesGrupo7 = SaldosAcumuladosMesGrupo7 + (debito - credito);
			                	break;
						}
                	}
                	
                	//Colocar en 0 el saldo inicial del mes 1 de las cuentas el 4 al 7
                	if(filaActual < Conexion.NumeroCuentas && (digito >= 4 && digito <= 7))
						saldoInicial = 0;
                	else if(filaActual >= Conexion.NumeroCuentas){
                		int fila = filaActual - Conexion.NumeroCuentas;
						DataRow rowAnterior = TableCuentas.Rows[fila];
						if(dr.GetString(0).Equals(rowAnterior["codigo"].ToString())) {
							saldoInicial = decimal.Parse(rowAnterior["saldo_final"].ToString());
							Debug.WriteLine("filaActual : {0} i : {1} resultado {2}", filaActual, fila, filaActual - fila);
							//break;
						}
                	}
                	
                	//Buscar la posicion de la cuenta del saldo negativo 
                	if(cierre && dr.GetString(0).Equals(Conexion.CuentaSaldoMesNegativo))
                		filaSaldoNegativo = filaActual;
                	
                	//Buscar la posicion de la cuenta del saldo positivo 
                	if(cierre && dr.GetString(0).Equals(Conexion.CuentaSaldoMesPositivo))
                		filaSaldoPositivo = filaActual;
                	
                	//Buscar la posicion de la cuenta utilidad del ejercicio
                	if(dr.GetString(0).Equals(Conexion.CuentaUtilidadDelEjercicio))
                		saldoCuentautilidadDelEjercicio = saldoFinal;
                	
                	
                	if(cierre && digito >= 4 && digito <= 7) {
                		saldoInicial = 0;
                		debito = 0;
                		credito = 0;
                		saldoFinal = 0;
                	}
                	
                	saldoFinal = (saldoInicial * dr.GetDecimal(2)) + debito - credito;
                	
                	TableCuentas.Rows.Add(fechaInicial.Year /* año */, 
                	                      cierre ? 13: fechaInicial.Month /* mes */,
                	                      dr.GetString(0) /* Codigo */,
                	                      dr.GetString(1) /* Descripcion */,
                	                      dr.GetDecimal(2) /* Efecto */,
                	                      saldoInicial  /* Saldo inicial **/,
                	                      debito /* Debito */,
                	                      credito /* Credito */,
                	                      saldoFinal /* saldo final */
                	                     );
                	filaActual++;
                }                
            }			
		}
		
		void ProcesarCierre()
		{
			decimal saldoAnual = SaldosAcumuladosMesGrupo4 - SaldosAcumuladosMesGrupo5 - SaldosAcumuladosMesGrupo6 - SaldosAcumuladosMesGrupo7;
			saldoAnual += saldoCuentautilidadDelEjercicio;
			if(saldoAnual < 0){
				TableCuentas.Rows[filaSaldoNegativo]["debito"] = saldoAnual;
			}else if( saldoAnual > 0 ){
				TableCuentas.Rows[filaSaldoPositivo]["credito"] = saldoAnual;
			}
			
			filaSaldoNegativo = 0;
			filaSaldoPositivo = 0;
			SaldosAcumuladosMesGrupo4 = 0;
			SaldosAcumuladosMesGrupo5 = 0;
			SaldosAcumuladosMesGrupo6 = 0;
			SaldosAcumuladosMesGrupo7 = 0;
			saldoAnual = 0;
			saldoCuentautilidadDelEjercicio = 0; 
		}
		
		void LimpiarTablaSaldos()
		{
			cm.CommandText = Conexion.EsNiif ? "spEliminarSaldoCuentaPeriodo" : "spEliminarSaldoCuentaPeriodoCG";
			cm.CommandType = CommandType.StoredProcedure;
			cm.Parameters.Clear();
			cm.Parameters.AddWithValue("@Ano", Conexion.FechaInicial.Year);
			cm.ExecuteNonQuery();
		}
		
		void GuardarSaldosCuentas()
		{
			//System.Windows.Forms.MessageBox.Show(TableCuentas.Rows.Count.ToString());
	        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConn))
            {
	        	this.MiEvento("Guardando los datos");
	        	bulkCopy.DestinationTableName = Conexion.EsNiif ? "vw_ca_Saldos" : "vw_ca_Saldos_cg";
                bulkCopy.BatchSize = 10000;
                bulkCopy.BulkCopyTimeout = 10000;
                bulkCopy.WriteToServer(TableCuentas);
            }
		}
		
		public void Procesar()
		{
			SetupDataTable();
			Conectar();
			if(conectado){
				CargarFechas();
				this.MiEvento(string.Format("Procesando desde {0} hasta {1}", Conexion.FechaInicial.ToString("dd/MM/yyyy"), Conexion.FechaFinal.ToString("dd/MM/yyyy")));
				DateTime tmpFechaInicial = Conexion.FechaInicial;
				while (tmpFechaInicial <= Conexion.FechaFinal) {
					//if(tmpFechaInicial.Year == 2017) break;
					this.MiEvento(string.Format("Procesando {0} de {1}", tmpFechaInicial.ToString("MMMM"), tmpFechaInicial.Year));
					CargarPeriodo(tmpFechaInicial, tmpFechaInicial.AddMonths(1).AddDays(-1));
					if(tmpFechaInicial.Month == 12) 
					{
						this.MiEvento(string.Format("Procesando {0} de {1}", "CIERRE", tmpFechaInicial.Year));
						CargarPeriodo(tmpFechaInicial, tmpFechaInicial.AddMonths(1).AddDays(-1), true);
						
						this.MiEvento("Realizando proceso de cierre");
						ProcesarCierre();
					}
					tmpFechaInicial = tmpFechaInicial.AddMonths(1);
					
				}
				
				this.MiEvento(string.Format("Limpiando tabla de saldos"));
				LimpiarTablaSaldos();
			
				this.MiEvento(string.Format("Actualizando tabla de saldos"));
				GuardarSaldosCuentas();
				this.MiEvento(string.Format("Proceso finalizado con exito......."));
			}
			Desconectar();
		}
	}
}
