/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 28/12/2017
 * Hora: 10:38 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ActualizadorSaldosWO.Forms
{
	partial class FrmPanelConexiones
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel Info;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListBox lstConexiones;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.Button btnModificar;
		private System.Windows.Forms.Button btbCrear;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPanelConexiones));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.Info = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lstConexiones = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.btnModificar = new System.Windows.Forms.Button();
			this.btbCrear = new System.Windows.Forms.Button();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.Info});
			this.statusStrip1.Location = new System.Drawing.Point(0, 376);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(464, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// Info
			// 
			this.Info.Image = ((System.Drawing.Image)(resources.GetObject("Info.Image")));
			this.Info.Name = "Info";
			this.Info.Size = new System.Drawing.Size(16, 17);
			this.Info.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.lstConexiones);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
			this.splitContainer1.Size = new System.Drawing.Size(464, 376);
			this.splitContainer1.SplitterDistance = 334;
			this.splitContainer1.TabIndex = 1;
			// 
			// lstConexiones
			// 
			this.lstConexiones.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstConexiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstConexiones.FormattingEnabled = true;
			this.lstConexiones.ItemHeight = 16;
			this.lstConexiones.Location = new System.Drawing.Point(0, 0);
			this.lstConexiones.Name = "lstConexiones";
			this.lstConexiones.Size = new System.Drawing.Size(464, 334);
			this.lstConexiones.TabIndex = 0;
			this.lstConexiones.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.LstConexionesPreviewKeyDown);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.Controls.Add(this.btnEliminar, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnModificar, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.btbCrear, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnCerrar, 3, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 38);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// btnEliminar
			// 
			this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
			this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEliminar.Location = new System.Drawing.Point(235, 3);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(110, 32);
			this.btnEliminar.TabIndex = 3;
			this.btnEliminar.Text = "&Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = true;
			this.btnEliminar.Click += new System.EventHandler(this.BtnEliminarClick);
			// 
			// btnModificar
			// 
			this.btnModificar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
			this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnModificar.Location = new System.Drawing.Point(119, 3);
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.Size = new System.Drawing.Size(110, 32);
			this.btnModificar.TabIndex = 2;
			this.btnModificar.Text = "&Modificar";
			this.btnModificar.UseVisualStyleBackColor = true;
			this.btnModificar.Click += new System.EventHandler(this.BtnModificarClick);
			// 
			// btbCrear
			// 
			this.btbCrear.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btbCrear.Image = ((System.Drawing.Image)(resources.GetObject("btbCrear.Image")));
			this.btbCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btbCrear.Location = new System.Drawing.Point(3, 3);
			this.btbCrear.Name = "btbCrear";
			this.btbCrear.Size = new System.Drawing.Size(110, 32);
			this.btbCrear.TabIndex = 1;
			this.btbCrear.Text = "C&rear";
			this.btbCrear.UseVisualStyleBackColor = true;
			this.btbCrear.Click += new System.EventHandler(this.BtbCrearClick);
			// 
			// btnCerrar
			// 
			this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
			this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCerrar.Location = new System.Drawing.Point(351, 3);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(110, 32);
			this.btnCerrar.TabIndex = 0;
			this.btnCerrar.Text = "&Cerrar";
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.BtnCerrarClick);
			// 
			// FrmPanelConexiones
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(464, 398);
			this.ControlBox = false;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.statusStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FrmPanelConexiones";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Panel de Conexiones";
			this.Load += new System.EventHandler(this.FrmPanelConexionesLoad);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
