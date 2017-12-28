/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 22/12/2017
 * Hora: 3:55 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace ActualizadorSaldosWO.Class
{
	/// <summary>
	/// Description of CadenaConexion.
	/// </summary>
	public class Conexion
	{
		public Conexion()
		{
		}
		
		public enum EnumTipoContabilidad {
			NIIF = 1,
			COLGAAP = 2
		}
		
		public string Nombre { set; get; }
		
		public string Servidor { set; get; }
		
		public string BaseDeDatos { set; get; }
		
		public string Usuario  { set; get; }
		
		public string Clave { set; get; }
		
		public int NumeroMeses { set; get; }
		
		public int NumeroCuentas { set; get; }
		
		public int NivelCuenta { set; get; }
		
		public DateTime FechaInicial { set; get; }
		
		public DateTime FechaFinal { set; get; }
		
		public bool EsNiif { set; get; }
		
		public Tarea Tarea { set; get; }
		
		
		public static string CuentaSaldoMesNegativo = "370505";
		public static string CuentaSaldoMesPositivo = "371005";
		public static string CuentaUtilidadDelEjercicio = "360505";
		
		
		public override string ToString()
		{
			return string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", this.Servidor, this.BaseDeDatos, this.Usuario, this.Clave );
		}

		
	}
}
