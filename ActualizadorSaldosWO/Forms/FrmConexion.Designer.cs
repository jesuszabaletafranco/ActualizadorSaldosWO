/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 28/12/2017
 * Hora: 10:53 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ActualizadorSaldosWO.Forms
{
	partial class FrmConexion
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.TextBox txtServidor;
		private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.TextBox txtClave;
		private System.Windows.Forms.TextBox txtCatalogo;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button btnCerrar;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker dtpFechaInicial;
		private System.Windows.Forms.CheckBox chkEsNiif;
		private System.Windows.Forms.NumericUpDown txtNivelCuenta;
		private System.Windows.Forms.Button btnProgramar;
		private System.Windows.Forms.Label label9;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConexion));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.txtServidor = new System.Windows.Forms.TextBox();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.txtClave = new System.Windows.Forms.TextBox();
			this.txtCatalogo = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
			this.chkEsNiif = new System.Windows.Forms.CheckBox();
			this.txtNivelCuenta = new System.Windows.Forms.NumericUpDown();
			this.btnProgramar = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.btnGuardar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtNivelCuenta)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
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
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
			this.splitContainer1.Size = new System.Drawing.Size(385, 201);
			this.splitContainer1.SplitterDistance = 160;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel3);
			this.splitContainer2.Size = new System.Drawing.Size(385, 160);
			this.splitContainer2.SplitterDistance = 216;
			this.splitContainer2.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.9375F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.0625F));
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.txtServidor, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtUsuario, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.txtClave, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtCatalogo, 1, 4);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(216, 160);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Location = new System.Drawing.Point(3, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 32);
			this.label4.TabIndex = 3;
			this.label4.Text = "Base Datos";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Location = new System.Drawing.Point(3, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 32);
			this.label3.TabIndex = 2;
			this.label3.Text = "Contraseña";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Location = new System.Drawing.Point(3, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 32);
			this.label2.TabIndex = 1;
			this.label2.Text = "Usuario";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(3, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Servidor";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Location = new System.Drawing.Point(3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 32);
			this.label5.TabIndex = 4;
			this.label5.Text = "Nombre";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNombre
			// 
			this.txtNombre.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNombre.Location = new System.Drawing.Point(80, 3);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(133, 22);
			this.txtNombre.TabIndex = 5;
			// 
			// txtServidor
			// 
			this.txtServidor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtServidor.Location = new System.Drawing.Point(80, 35);
			this.txtServidor.Name = "txtServidor";
			this.txtServidor.Size = new System.Drawing.Size(133, 22);
			this.txtServidor.TabIndex = 6;
			// 
			// txtUsuario
			// 
			this.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUsuario.Location = new System.Drawing.Point(80, 67);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(133, 22);
			this.txtUsuario.TabIndex = 7;
			// 
			// txtClave
			// 
			this.txtClave.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtClave.Location = new System.Drawing.Point(80, 99);
			this.txtClave.Name = "txtClave";
			this.txtClave.Size = new System.Drawing.Size(133, 22);
			this.txtClave.TabIndex = 8;
			this.txtClave.UseSystemPasswordChar = true;
			// 
			// txtCatalogo
			// 
			this.txtCatalogo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCatalogo.Location = new System.Drawing.Point(80, 131);
			this.txtCatalogo.Name = "txtCatalogo";
			this.txtCatalogo.Size = new System.Drawing.Size(133, 22);
			this.txtCatalogo.TabIndex = 9;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.65327F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.34673F));
			this.tableLayoutPanel3.Controls.Add(this.label6, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.label7, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.label8, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.dtpFechaInicial, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.chkEsNiif, 1, 1);
			this.tableLayoutPanel3.Controls.Add(this.txtNivelCuenta, 1, 2);
			this.tableLayoutPanel3.Controls.Add(this.btnProgramar, 1, 3);
			this.tableLayoutPanel3.Controls.Add(this.label9, 0, 3);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 5;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(165, 160);
			this.tableLayoutPanel3.TabIndex = 0;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label6.Location = new System.Drawing.Point(3, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 32);
			this.label6.TabIndex = 0;
			this.label6.Text = "Fecha Inicial";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label7.Location = new System.Drawing.Point(3, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(44, 32);
			this.label7.TabIndex = 1;
			this.label7.Text = "Es NIIF";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label8.Location = new System.Drawing.Point(3, 64);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(44, 32);
			this.label8.TabIndex = 2;
			this.label8.Text = "Nivel Cuenta";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dtpFechaInicial
			// 
			this.dtpFechaInicial.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaInicial.Location = new System.Drawing.Point(53, 9);
			this.dtpFechaInicial.Name = "dtpFechaInicial";
			this.dtpFechaInicial.Size = new System.Drawing.Size(109, 20);
			this.dtpFechaInicial.TabIndex = 3;
			// 
			// chkEsNiif
			// 
			this.chkEsNiif.Location = new System.Drawing.Point(53, 35);
			this.chkEsNiif.Name = "chkEsNiif";
			this.chkEsNiif.Size = new System.Drawing.Size(104, 24);
			this.chkEsNiif.TabIndex = 4;
			this.chkEsNiif.UseVisualStyleBackColor = true;
			// 
			// txtNivelCuenta
			// 
			this.txtNivelCuenta.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtNivelCuenta.Increment = new decimal(new int[] {
			2,
			0,
			0,
			0});
			this.txtNivelCuenta.Location = new System.Drawing.Point(53, 73);
			this.txtNivelCuenta.Maximum = new decimal(new int[] {
			8,
			0,
			0,
			0});
			this.txtNivelCuenta.Minimum = new decimal(new int[] {
			6,
			0,
			0,
			0});
			this.txtNivelCuenta.Name = "txtNivelCuenta";
			this.txtNivelCuenta.Size = new System.Drawing.Size(109, 20);
			this.txtNivelCuenta.TabIndex = 5;
			this.txtNivelCuenta.Value = new decimal(new int[] {
			6,
			0,
			0,
			0});
			// 
			// btnProgramar
			// 
			this.btnProgramar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnProgramar.Location = new System.Drawing.Point(53, 99);
			this.btnProgramar.Name = "btnProgramar";
			this.btnProgramar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.btnProgramar.Size = new System.Drawing.Size(109, 26);
			this.btnProgramar.TabIndex = 6;
			this.btnProgramar.UseVisualStyleBackColor = true;
			this.btnProgramar.Click += new System.EventHandler(this.BtnProgramarClick);
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label9.Location = new System.Drawing.Point(3, 96);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(44, 32);
			this.label9.TabIndex = 7;
			this.label9.Text = "Act. Automatica";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.Controls.Add(this.btnCerrar, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnGuardar, 2, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(385, 37);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// btnCerrar
			// 
			this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
			this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCerrar.Location = new System.Drawing.Point(291, 3);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(91, 31);
			this.btnCerrar.TabIndex = 0;
			this.btnCerrar.Text = "&Cerrar";
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.BtnCerrarClick);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
			this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnGuardar.Location = new System.Drawing.Point(195, 3);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(90, 31);
			this.btnGuardar.TabIndex = 2;
			this.btnGuardar.Text = "&Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.BtnGuardarClick);
			// 
			// FrmConexion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(385, 201);
			this.ControlBox = false;
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FrmConexion";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FrmConexion";
			this.Load += new System.EventHandler(this.FrmConexionLoad);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.txtNivelCuenta)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
