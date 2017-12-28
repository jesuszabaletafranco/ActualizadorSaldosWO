/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 28/12/2017
 * Hora: 10:38 a. m.
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
	/// Description of FrmPanelConexiones.
	/// </summary>
	public partial class FrmPanelConexiones : Form
	{
		public FrmPanelConexiones()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Bind()
		{
			Util.SetLookupBinding(lstConexiones, Util.Conexiones,"Nombre", "Nombre");
			lstConexiones.SelectedIndex = -1;
		}
		void FrmPanelConexionesLoad(object sender, EventArgs e)
		{
			Bind();
		}
		void BtnCerrarClick(object sender, EventArgs e)
		{
			Close();
		}
		void BtnEliminarClick(object sender, EventArgs e)
		{
			if(lstConexiones.SelectedItem != null)
			{
				var conexion = lstConexiones.SelectedItem as Conexion;
				if(MessageBox.Show(string.Format("Desea eliminar esta conexion {0}", conexion.Nombre), "Eliminar Conexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Util.DelConexion(conexion);
					Bind();
					Application.Restart();
				}
			}
		}
		void BtbCrearClick(object sender, EventArgs e)
		{
			var frmConexion = new FrmConexion();
			frmConexion.StartPosition = FormStartPosition.CenterParent;
			if(frmConexion.ShowDialog() == DialogResult.Yes) {
				Util.AddConexion(frmConexion.Conexion);
				Bind();
			}
		}
		void BtnModificarClick(object sender, EventArgs e)
		{
			if(lstConexiones.SelectedItem != null){
				var conexion = lstConexiones.SelectedItem as Conexion;
				var frmConexion = new FrmConexion(conexion);
				frmConexion.StartPosition = FormStartPosition.CenterParent;
				if(frmConexion.ShowDialog() == DialogResult.Yes) {
					Util.DelConexion(conexion);
					Util.AddConexion(frmConexion.Conexion);
					Bind();
				}
			}
		}
		void LstConexionesPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if((int)e.KeyCode == (int)Keys.F12){
				if(lstConexiones.SelectedItem != null)
				{
					Util.CrearEstructura(lstConexiones.SelectedItem as Conexion);
				}
			}
		}
	}
}
