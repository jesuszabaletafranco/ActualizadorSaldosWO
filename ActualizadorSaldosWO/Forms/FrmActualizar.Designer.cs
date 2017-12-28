/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 27/12/2017
 * Hora: 7:46 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ActualizadorSaldosWO.Forms
{
	partial class FrmActualizar
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cboConexiones;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel Info;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.cboConexiones = new System.Windows.Forms.ComboBox();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.Info = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Conexion";
			// 
			// cboConexiones
			// 
			this.cboConexiones.FormattingEnabled = true;
			this.cboConexiones.Location = new System.Drawing.Point(69, 6);
			this.cboConexiones.Name = "cboConexiones";
			this.cboConexiones.Size = new System.Drawing.Size(419, 21);
			this.cboConexiones.TabIndex = 1;
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(4, 33);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(485, 395);
			this.txtLog.TabIndex = 2;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(414, 434);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Cerrar";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(333, 434);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(75, 23);
			this.btnUpdate.TabIndex = 4;
			this.btnUpdate.Text = "Actualizar";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.BtnUpdateClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.Info});
			this.statusStrip1.Location = new System.Drawing.Point(0, 462);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(495, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// Info
			// 
			this.Info.Name = "Info";
			this.Info.Size = new System.Drawing.Size(0, 17);
			// 
			// FrmActualizar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(495, 484);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.cboConexiones);
			this.Controls.Add(this.label1);
			this.Name = "FrmActualizar";
			this.Text = "Actualizar";
			this.Load += new System.EventHandler(this.FrmActualizarLoad);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
