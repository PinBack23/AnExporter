namespace AnExporter
{
    partial class FrmExporter
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExporter));
            this.panBottom = new System.Windows.Forms.Panel();
            this.lblExportInProgress = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panTop = new System.Windows.Forms.Panel();
            this.lblExportName = new System.Windows.Forms.Label();
            this.txtExportName = new System.Windows.Forms.TextBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.txtSelect = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdLogin = new System.Windows.Forms.Button();
            this.lblDB = new System.Windows.Forms.Label();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lsbLog = new System.Windows.Forms.ListBox();
            this.cmdImport = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panBottom.SuspendLayout();
            this.panTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBottom
            // 
            this.panBottom.Controls.Add(this.lblExportInProgress);
            this.panBottom.Controls.Add(this.lblLogin);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 408);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(617, 35);
            this.panBottom.TabIndex = 0;
            // 
            // lblExportInProgress
            // 
            this.lblExportInProgress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblExportInProgress.Location = new System.Drawing.Point(80, 8);
            this.lblExportInProgress.Name = "lblExportInProgress";
            this.lblExportInProgress.Size = new System.Drawing.Size(248, 23);
            this.lblExportInProgress.TabIndex = 1;
            this.lblExportInProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLogin
            // 
            this.lblLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogin.ImageIndex = 1;
            this.lblLogin.ImageList = this.imageList;
            this.lblLogin.Location = new System.Drawing.Point(8, 8);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(56, 23);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Bullet-green_24.png");
            this.imageList.Images.SetKeyName(1, "Bullet-red_24.png");
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.lblExportName);
            this.panTop.Controls.Add(this.txtExportName);
            this.panTop.Controls.Add(this.lblSelect);
            this.panTop.Controls.Add(this.txtSelect);
            this.panTop.Controls.Add(this.panel1);
            this.panTop.Controls.Add(this.lblDB);
            this.panTop.Controls.Add(this.txtDB);
            this.panTop.Controls.Add(this.lblPassword);
            this.panTop.Controls.Add(this.txtPassword);
            this.panTop.Controls.Add(this.lblUser);
            this.panTop.Controls.Add(this.txtUser);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(617, 224);
            this.panTop.TabIndex = 1;
            // 
            // lblExportName
            // 
            this.lblExportName.AutoSize = true;
            this.lblExportName.Location = new System.Drawing.Point(16, 64);
            this.lblExportName.Name = "lblExportName";
            this.lblExportName.Size = new System.Drawing.Size(92, 13);
            this.lblExportName.TabIndex = 11;
            this.lblExportName.Text = "ExportTableName";
            // 
            // txtExportName
            // 
            this.txtExportName.Location = new System.Drawing.Point(16, 80);
            this.txtExportName.Name = "txtExportName";
            this.txtExportName.Size = new System.Drawing.Size(144, 20);
            this.txtExportName.TabIndex = 10;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Location = new System.Drawing.Point(16, 104);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(37, 13);
            this.lblSelect.TabIndex = 9;
            this.lblSelect.Text = "Select";
            // 
            // txtSelect
            // 
            this.txtSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelect.Location = new System.Drawing.Point(16, 120);
            this.txtSelect.Multiline = true;
            this.txtSelect.Name = "txtSelect";
            this.txtSelect.Size = new System.Drawing.Size(464, 96);
            this.txtSelect.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdImport);
            this.panel1.Controls.Add(this.cmdExport);
            this.panel1.Controls.Add(this.cmdLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(489, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 224);
            this.panel1.TabIndex = 7;
            // 
            // cmdExport
            // 
            this.cmdExport.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdExport.Enabled = false;
            this.cmdExport.Location = new System.Drawing.Point(0, 40);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(128, 40);
            this.cmdExport.TabIndex = 7;
            this.cmdExport.Text = "Export";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdLogin
            // 
            this.cmdLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdLogin.Location = new System.Drawing.Point(0, 0);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(128, 40);
            this.cmdLogin.TabIndex = 6;
            this.cmdLogin.Text = "Login";
            this.cmdLogin.UseVisualStyleBackColor = true;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.Location = new System.Drawing.Point(336, 16);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(22, 13);
            this.lblDB.TabIndex = 5;
            this.lblDB.Text = "DB";
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(336, 32);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(144, 20);
            this.txtDB.TabIndex = 4;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(176, 16);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(176, 32);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(144, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(16, 16);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(55, 13);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Username";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(16, 32);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(144, 20);
            this.txtUser.TabIndex = 0;
            // 
            // lsbLog
            // 
            this.lsbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbLog.FormattingEnabled = true;
            this.lsbLog.Location = new System.Drawing.Point(0, 224);
            this.lsbLog.Name = "lsbLog";
            this.lsbLog.Size = new System.Drawing.Size(617, 184);
            this.lsbLog.TabIndex = 2;
            // 
            // cmdImport
            // 
            this.cmdImport.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmdImport.Enabled = false;
            this.cmdImport.Location = new System.Drawing.Point(0, 80);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(128, 40);
            this.cmdImport.TabIndex = 8;
            this.cmdImport.Text = "Import";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Export File";
            // 
            // FrmExporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 443);
            this.Controls.Add(this.lsbLog);
            this.Controls.Add(this.panTop);
            this.Controls.Add(this.panBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmExporter";
            this.Text = "Exporter";
            this.panBottom.ResumeLayout(false);
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lblExportName;
        private System.Windows.Forms.TextBox txtExportName;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.TextBox txtSelect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdLogin;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.ListBox lsbLog;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Label lblExportInProgress;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

