namespace KeyAuthGUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblLicenseKey;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtLicenseKey;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblLicenseKey = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtLicenseKey = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblUsername
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(99, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Uživatelské jméno:";

            // lblLicenseKey
            this.lblLicenseKey.AutoSize = true;
            this.lblLicenseKey.Location = new System.Drawing.Point(12, 55);
            this.lblLicenseKey.Name = "lblLicenseKey";
            this.lblLicenseKey.Size = new System.Drawing.Size(78, 13);
            this.lblLicenseKey.TabIndex = 1;
            this.lblLicenseKey.Text = "Licenční klíč:";

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(120, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 20);
            this.txtUsername.TabIndex = 2;

            // txtLicenseKey
            this.txtLicenseKey.Location = new System.Drawing.Point(120, 52);
            this.txtLicenseKey.Name = "txtLicenseKey";
            this.txtLicenseKey.Size = new System.Drawing.Size(200, 20);
            this.txtLicenseKey.TabIndex = 3;

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(120, 90);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(95, 30);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Přihlásit se";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnRegister
            this.btnRegister.Location = new System.Drawing.Point(225, 90);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(95, 30);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Registrovat";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(340, 140);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtLicenseKey);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblLicenseKey);
            this.Controls.Add(this.lblUsername);
            this.Name = "MainForm";
            this.Text = "DF Auth";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}