// =====================================================================
//
// ShellLink - Using WSH to program shell links
//
// by Jim Hollenhorst, jwtk@ultrapico.com
// Copyright Ultrapico, April 2003
// http://www.ultrapico.com
//
// =====================================================================
using System;
using System.Windows.Forms;
using System.Drawing;

namespace ShellLinks
{
	/// <summary>
	/// This is the shell links demonstration application
	/// </summary>
	public class FrmOpciones : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button BtnExit;
		private bool Skip;
		private System.Windows.Forms.CheckBox chkRunOnStartup;
		private System.Windows.Forms.CheckBox chkSendToLink;
		private System.Windows.Forms.CheckBox chkQuickLaunch;
		private System.Windows.Forms.CheckBox chkDesktopLink;
		private string QuickLaunchDir;


		public FrmOpciones()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Set check buttons depending on whether shortcuts exist on the desktop and in the startup folder
			Skip=true;  // Don't run the CheckedChanged code
			chkRunOnStartup.Checked=Link.Exists(Environment.SpecialFolder.Startup,"CAUpdateSaldosWO");
			chkDesktopLink.Checked=Link.Exists(Environment.SpecialFolder.DesktopDirectory,"CAUpdateSaldosWO");
			chkSendToLink.Checked=Link.Exists(Environment.SpecialFolder.SendTo,"CAUpdateSaldosWO");
			QuickLaunchDir=Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
				+ "\\Microsoft\\Internet Explorer\\Quick Launch";
			chkQuickLaunch.Checked=Link.Exists(QuickLaunchDir,"CAUpdateSaldosWO");
			Skip=false;
		}

		public void Exit()
		{
			Application.Exit();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpciones));
			this.chkDesktopLink = new System.Windows.Forms.CheckBox();
			this.chkRunOnStartup = new System.Windows.Forms.CheckBox();
			this.chkQuickLaunch = new System.Windows.Forms.CheckBox();
			this.BtnExit = new System.Windows.Forms.Button();
			this.chkSendToLink = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// chkDesktopLink
			// 
			this.chkDesktopLink.Checked = true;
			this.chkDesktopLink.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkDesktopLink.Location = new System.Drawing.Point(8, 64);
			this.chkDesktopLink.Name = "chkDesktopLink";
			this.chkDesktopLink.Size = new System.Drawing.Size(184, 24);
			this.chkDesktopLink.TabIndex = 3;
			this.chkDesktopLink.Text = "Crear icono en el escritorio";
			this.chkDesktopLink.CheckedChanged += new System.EventHandler(this.chkDesktopLink_CheckedChanged);
			// 
			// chkRunOnStartup
			// 
			this.chkRunOnStartup.Checked = true;
			this.chkRunOnStartup.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkRunOnStartup.Location = new System.Drawing.Point(8, 40);
			this.chkRunOnStartup.Name = "chkRunOnStartup";
			this.chkRunOnStartup.Size = new System.Drawing.Size(176, 24);
			this.chkRunOnStartup.TabIndex = 2;
			this.chkRunOnStartup.Text = "Iniciar automaticamente";
			this.chkRunOnStartup.CheckedChanged += new System.EventHandler(this.chkRunOnStartup_CheckedChanged);
			// 
			// chkQuickLaunch
			// 
			this.chkQuickLaunch.Checked = true;
			this.chkQuickLaunch.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkQuickLaunch.Location = new System.Drawing.Point(8, 16);
			this.chkQuickLaunch.Name = "chkQuickLaunch";
			this.chkQuickLaunch.Size = new System.Drawing.Size(218, 24);
			this.chkQuickLaunch.TabIndex = 1;
			this.chkQuickLaunch.Text = "Mostar icono en la barra de tareas";
			this.chkQuickLaunch.CheckedChanged += new System.EventHandler(this.chkQuickLaunch_CheckedChanged);
			// 
			// BtnExit
			// 
			this.BtnExit.BackColor = System.Drawing.SystemColors.Control;
			this.BtnExit.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.BtnExit.DialogResult = System.Windows.Forms.DialogResult.Abort;
			this.BtnExit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnExit.Location = new System.Drawing.Point(192, 48);
			this.BtnExit.Name = "BtnExit";
			this.BtnExit.Size = new System.Drawing.Size(48, 23);
			this.BtnExit.TabIndex = 11;
			this.BtnExit.Text = "C&errar";
			this.BtnExit.UseVisualStyleBackColor = false;
			this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
			// 
			// chkSendToLink
			// 
			this.chkSendToLink.Checked = true;
			this.chkSendToLink.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSendToLink.Location = new System.Drawing.Point(8, 88);
			this.chkSendToLink.Name = "chkSendToLink";
			this.chkSendToLink.Size = new System.Drawing.Size(160, 24);
			this.chkSendToLink.TabIndex = 12;
			this.chkSendToLink.Text = "Agregar al menu enviar a ";
			this.chkSendToLink.CheckedChanged += new System.EventHandler(this.chkSendToLink_CheckedChanged);
			// 
			// FrmOpciones
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.BtnExit;
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(258, 127);
			this.Controls.Add(this.chkSendToLink);
			this.Controls.Add(this.BtnExit);
			this.Controls.Add(this.chkDesktopLink);
			this.Controls.Add(this.chkRunOnStartup);
			this.Controls.Add(this.chkQuickLaunch);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmOpciones";
			this.Text = "Opciones de Inicio";
			this.Load += new System.EventHandler(this.FrmOpcionesLoad);
			this.ResumeLayout(false);

		}
		#endregion
		
		public void BtnExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// This method checks the startup directory to see if there is a link to the executable file
		/// it modifies the directory accordingly depending on the setting of the RunOnStartup checkbox 
		/// </summary>
		private void chkRunOnStartup_CheckedChanged(object sender, System.EventArgs e)
		{
			if(Skip)return;
			Link.Update(Environment.SpecialFolder.Startup, Application.ExecutablePath, "CAUpdateSaldosWO", chkRunOnStartup.Checked);
		}

		// Update a link to the executable on the desktop depending on the setting of chkDesktopLink
		private void chkDesktopLink_CheckedChanged(object sender, System.EventArgs e)
		{
			if(Skip)return;
			Link.Update(Environment.SpecialFolder.DesktopDirectory,Application.ExecutablePath,"CAUpdateSaldosWO",chkDesktopLink.Checked);
		}

		private void chkSendToLink_CheckedChanged(object sender, System.EventArgs e)
		{
			if(Skip)return;
			Link.Update(Environment.SpecialFolder.SendTo,Application.ExecutablePath,"CAUpdateSaldosWO",chkSendToLink.Checked);
		}

		private void chkQuickLaunch_CheckedChanged(object sender, System.EventArgs e)
		{
			if(Skip)return;
			Link.Update(QuickLaunchDir,Application.ExecutablePath,"CAUpdateSaldosWO",chkQuickLaunch.Checked);
		}
		void FrmOpcionesLoad(object sender, EventArgs e)
		{
	
		}
	}
}
