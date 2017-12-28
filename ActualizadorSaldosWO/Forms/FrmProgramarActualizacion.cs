/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 28/12/2017
 * Hora: 2:10 p. m.
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
	/// Description of FrmProgramarActualizacion.
	/// </summary>
	public partial class FrmProgramarActualizacion : Form
	{
		public Tarea Tarea { set; get; }
		
		public FrmProgramarActualizacion()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
		}
		void Form2Tarea()
		{
			Tarea.Hora = dtpHora.Value;
			Tarea.Dias.Clear();
			foreach (var d in lstDias.SelectedItems) {
				var dia = d as DiasSemana;
				//MessageBox.Show(dia.Nombre);
				Tarea.Dias.Add(dia);
			}
		}
		void Tarea2Form()
		{
			dtpHora.Value = Tarea.Hora;
			foreach (var dia in Tarea.Dias) {
				//MessageBox.Show(dia.Codigo.ToString() + " " + dia.Nombre);
				for (int i = 0; i < lstDias.Items.Count; i++) {
					var d = lstDias.Items[i] as DiasSemana;
					if(d.Codigo == dia.Codigo) { 
						lstDias.SetSelected(i, true);
						break;
					}
				}
			}
			
		}
		void FrmProgramarActualizacionLoad(object sender, EventArgs e)
		{
			Util.SetLookupBinding(lstDias, Util.Dias(),"Nombre", "Codigo");
			lstDias.SelectedIndex = -1;
			if(Tarea != null)
				Tarea2Form();			
			else 
				Tarea = new Tarea();
		}
		void BtnCerrarClick(object sender, EventArgs e)
		{
			Form2Tarea();
			DialogResult = Tarea.Dias.Count > 0 ? DialogResult.Yes :  DialogResult.No;
			Close();
		}
	}
}
