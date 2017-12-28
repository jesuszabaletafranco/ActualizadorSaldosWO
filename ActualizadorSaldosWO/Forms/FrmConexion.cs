/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 28/12/2017
 * Hora: 10:53 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using ActualizadorSaldosWO.Class;

namespace ActualizadorSaldosWO.Forms
{
	/// <summary>
	/// Description of FrmConexion.
	/// </summary>
	public partial class FrmConexion : Form
	{
		public Conexion Conexion { set; get; }
		
		public FrmConexion()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			Text = "Crear Conexion";
		}
		
		public FrmConexion(Conexion con)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.Conexion = con;
			Text = "Modificar Conexion";
			btnProgramar.Text = "No Programada";
		}
		void FrmConexionLoad(object sender, EventArgs e)
		{
			if(this.Conexion != null)
			{
				txtNombre.Text = Conexion.Nombre;
				txtServidor.Text = Conexion.Servidor;
				txtUsuario.Text = Conexion.Usuario;
				txtClave.Text = Conexion.Clave;
				txtCatalogo.Text = Conexion.BaseDeDatos;
				
				dtpFechaInicial.Value = Conexion.FechaInicial;
				chkEsNiif.Checked = Conexion.EsNiif;
				txtNivelCuenta.Value = Conexion.NivelCuenta;				
			}
			else {
				this.Conexion = new Conexion();
			}
			btnProgramar.Text = Conexion.Tarea != null ? "Programada" : "No Programada";
		}
		void BtnCerrarClick(object sender, EventArgs e)
		{
			Close();
		}
		void BtnGuardarClick(object sender, EventArgs e)
		{
			Conexion.Nombre = txtNombre.Text;
			Conexion.Servidor = txtServidor.Text;
			Conexion.Usuario = txtUsuario.Text;
			Conexion.Clave = txtClave.Text;
			Conexion.BaseDeDatos = txtCatalogo.Text;
			
			Conexion.FechaInicial = dtpFechaInicial.Value;
			chkEsNiif.Checked = Conexion.EsNiif;
			Conexion.NivelCuenta = (int)txtNivelCuenta.Value;
				
			DialogResult = DialogResult.Yes;
			Close();
		}
		void BtnProgramarClick(object sender, EventArgs e)
		{
			var frmProgramacion = new FrmProgramarActualizacion();
			frmProgramacion.Tarea = Conexion.Tarea;
			frmProgramacion.StartPosition = FormStartPosition.CenterParent;
			if(frmProgramacion.ShowDialog() == DialogResult.Yes) {
				Conexion.Tarea = frmProgramacion.Tarea;
			}
		}
		
	}
}
