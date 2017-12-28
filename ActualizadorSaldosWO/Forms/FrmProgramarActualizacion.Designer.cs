/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 28/12/2017
 * Hora: 2:10 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ActualizadorSaldosWO.Forms
{
	partial class FrmProgramarActualizacion
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lstDias;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpHora;
		private System.Windows.Forms.Button btnCerrar;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProgramarActualizacion));
			this.label1 = new System.Windows.Forms.Label();
			this.lstDias = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpHora = new System.Windows.Forms.DateTimePicker();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(28, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Dias";
			// 
			// lstDias
			// 
			this.lstDias.FormattingEnabled = true;
			this.lstDias.Location = new System.Drawing.Point(4, 25);
			this.lstDias.Name = "lstDias";
			this.lstDias.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstDias.Size = new System.Drawing.Size(120, 95);
			this.lstDias.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 127);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Hora";
			// 
			// dtpHora
			// 
			this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtpHora.Location = new System.Drawing.Point(43, 123);
			this.dtpHora.Name = "dtpHora";
			this.dtpHora.Size = new System.Drawing.Size(81, 20);
			this.dtpHora.TabIndex = 3;
			// 
			// btnCerrar
			// 
			this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
			this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCerrar.Location = new System.Drawing.Point(27, 149);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(75, 23);
			this.btnCerrar.TabIndex = 4;
			this.btnCerrar.Text = "&Cerrar";
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.BtnCerrarClick);
			// 
			// FrmProgramarActualizacion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(128, 177);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.dtpHora);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lstDias);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmProgramarActualizacion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Programar Actualizacion";
			this.Load += new System.EventHandler(this.FrmProgramarActualizacionLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
