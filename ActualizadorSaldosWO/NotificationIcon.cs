/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 22/12/2017
 * Hora: 12:51 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ActualizadorSaldosWO.Forms;
using ActualizadorSaldosWO.Class;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace ActualizadorSaldosWO
{
	public sealed class NotificationIcon
	{
		private NotifyIcon notifyIcon;
		private ContextMenu notificationMenu;
		System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
		
		#region Initialize icon and menu
		public NotificationIcon()
		{
			Util.Conexiones = Util.DeserializeConexiones();
			notifyIcon = new NotifyIcon();
			notificationMenu = new ContextMenu(InitializeMenu());
			
			notifyIcon.DoubleClick += IconDoubleClick;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationIcon));
			notifyIcon.Icon = (Icon)resources.GetObject("$this.Icon");
			notifyIcon.ContextMenu = notificationMenu;
			
			timer1.Tick += timer1_Tick;
			timer1.Interval = 1000;
			timer1.Enabled = true;
			timer1.Start();
		}
		
		private MenuItem[] InitializeMenu()
		{
			
			List<MenuItem> menu = new List<MenuItem>();
			foreach (var element in Util.Conexiones) {
				var m = new MenuItem(string.Format("Actualizar {0}", element.Nombre), menuActualizarConexionClick);
				m.Tag = element;
				menu.Add(m);
			}
			menu.Add(new MenuItem("Actualizar", menuActualizarClick));
			//menu.Add(new MenuItem("Programación", menuProgramacionClick));
			menu.Add(new MenuItem("Conexiones", menuConexionesClick));
			menu.Add(new MenuItem("Opciones", menuOpcionesClick));
			menu.Add(new MenuItem("Acerca de ...", menuAboutClick));
			menu.Add(new MenuItem("Salir", menuExitClick));
			return menu.ToArray();
		}
		#endregion
		
		#region Main - Program entry point
		/// <summary>Program entry point.</summary>
		/// <param name="args">Command Line Arguments</param>
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			bool isFirstInstance;
			// Please use a unique name for the mutex to prevent conflicts with other programs
			using (Mutex mtx = new Mutex(true, "ActualizadorSaldosWO", out isFirstInstance)) {
				if (isFirstInstance) {
					NotificationIcon notificationIcon = new NotificationIcon();
					notificationIcon.notifyIcon.Visible = true;
					Application.Run();
					notificationIcon.notifyIcon.Dispose();
				} else {
					// The application is already running
					// TODO: Display message box or change focus to existing application instance
				}
			} // releases the Mutex
		}
		#endregion
		
		#region Event Handlers
		private void menuAboutClick(object sender, EventArgs e)
		{
			MessageBox.Show("About This Application");
		}
		
		private void menuExitClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		private void IconDoubleClick(object sender, EventArgs e)
		{
			menuActualizarClick(null, null);
		}
		
		private void menuOpcionesClick(object sender, EventArgs e)
		{
			var frmOpciones = new ShellLinks.FrmOpciones();
			frmOpciones.StartPosition = FormStartPosition.CenterScreen;
			frmOpciones.ShowDialog();
		}
		
		private void menuConexionesClick(object sender, EventArgs e)
		{
			var frmConexiones = new FrmPanelConexiones();
			frmConexiones.StartPosition = FormStartPosition.CenterScreen;
			frmConexiones.ShowDialog();
		}
		
		private void menuActualizarClick(object sender, EventArgs e)
		{
			var frmActualizar = new FrmActualizar();
			frmActualizar.StartPosition = FormStartPosition.CenterScreen;
			frmActualizar.ShowDialog();
		}
		
		void EscribirLog(string mensaje)
		{
			notifyIcon.Icon = SystemIcons.Information;
			notifyIcon.Visible = true; 
			notifyIcon.ShowBalloonTip(5000, Application.ProductName, DateTime.Now.ToString() + " " +  mensaje, ToolTipIcon.Info);
		}
		
		private void menuActualizarConexionClick(object sender, EventArgs e)
		{
			if(MessageBox.Show("Desea actualizar los saldos?", "Actualizacion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
				var watch = Stopwatch.StartNew();
				DateTime inicio = DateTime.Now;
				
				Conexion conexion = (sender as MenuItem).Tag as Conexion;
				EscribirLog("Actualizando " + conexion.Nombre);
				
				var db = new DataBaseUtils();
				db.Conexion = conexion;
				db.MiEvento += EscribirLog;
				db.Procesar();
				
				watch.Stop();
				EscribirLog(string.Format("Hora inicio : {0} Hora fin : {1} Duracion del proceso : {2}", inicio.ToString("H:mm:ss"), DateTime.Now.ToString("H:mm:ss"), Util.ElapsedTime(watch)));
			}
		}
		
		private void timer1_Tick(object sender, EventArgs e)
		{
			foreach (var conexion in Util.Conexiones) {
				if(conexion.Tarea != null){
					Tarea tarea = conexion.Tarea;
					if(DateTime.Now.Hour == tarea.Hora.Hour && DateTime.Now.Minute == tarea.Hora.Minute && DateTime.Now.Second == tarea.Hora.Second){
						int day = (int)DateTime.Now.DayOfWeek;
						bool ejecutarProceso = false;
						
						foreach (var dia in tarea.Dias)
							if(dia.Codigo == day) { 
								ejecutarProceso = true;
							}
						
						if(ejecutarProceso){
							var watch = Stopwatch.StartNew();
							DateTime inicio = DateTime.Now;
							
							EscribirLog("Actualizando " + conexion.Nombre);
							
							var db = new DataBaseUtils();
							db.Conexion = conexion;
							db.MiEvento += new DataBaseUtils.DelegadoLog(EscribirLog);
							db.Procesar();
							
							watch.Stop();
							EscribirLog(string.Format("Hora inicio : {0} Hora fin : {1} Duracion del proceso : {2}", inicio.ToString("H:mm:ss"), DateTime.Now.ToString("H:mm:ss"), Util.ElapsedTime(watch)));
						}
					}
				}
			}
		}
		#endregion
	}
}
