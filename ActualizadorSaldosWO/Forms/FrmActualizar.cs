/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 27/12/2017
 * Hora: 7:46 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using ActualizadorSaldosWO.Class;
using System.Diagnostics;

namespace ActualizadorSaldosWO.Forms
{
	/// <summary>
	/// Description of FrmActualizar.
	/// </summary>
	public partial class FrmActualizar : Form
	{
		public FrmActualizar()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void EscribirLog(string mensaje)
		{
			txtLog.AppendText(mensaje + Environment.NewLine);
		}
		void FrmActualizarLoad(object sender, EventArgs e)
		{
			Util.SetLookupBinding(cboConexiones, Util.Conexiones,"Nombre", "Nombre");
			cboConexiones.SelectedIndex = -1;
		}
		void BtnCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void BtnUpdateClick(object sender, EventArgs e)
		{
			if(cboConexiones.SelectedItem != null)
			{
				Info.Text = string.Empty;
				var watch = Stopwatch.StartNew();
				DateTime inicio = DateTime.Now;
				Info.Text = string.Format("inicio : {0} Hora fin : {1} Duracion del proceso : {2}", inicio.ToString("H:mm:ss"), "00:00:00", "00:00:00");
				Refresh();
				
				txtLog.Text = string.Empty;
				var db = new DataBaseUtils();
				db.Conexion = cboConexiones.SelectedItem as Conexion;
				db.MiEvento += EscribirLog;
				db.Procesar();
				
				Refresh();
				watch.Stop();
				Info.Text = string.Format("Inicio : {0} Fin : {1} Tiempo : {2}", inicio.ToString("H:mm:ss"), DateTime.Now.ToString("H:mm:ss"), Util.ElapsedTime(watch));
				EscribirLog(string.Format("Inicio : {0} Fin : {1} Tiempo : {2}", inicio.ToString("H:mm:ss"), DateTime.Now.ToString("H:mm:ss"), Util.ElapsedTime(watch)));
			}
		}
	}
}
