using System;
using System.Windows.Forms;

namespace KeyAuthGUI
{
    public partial class MainForm : Form
    {
        public static api KeyAuthApp = new api(
            name: "DFProject",
            ownerid: "kbWA2Nje7b",
            version: "1.0"
        );

        public MainForm()
        {
            InitializeComponent();
            KeyAuthApp.init();
            if (!KeyAuthApp.response.success)
            {
                MessageBox.Show("Chyba při připojení k API: " + KeyAuthApp.response.message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string hwid = GetHWID();
            string username = txtUsername.Text;
            string licenseKey = txtLicenseKey.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(licenseKey))
            {
                MessageBox.Show("Vyplňte všechna pole!", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KeyAuthApp.login(hwid, hwid);
            if (!KeyAuthApp.response.success)
            {
                MessageBox.Show("Přihlášení selhalo: " + KeyAuthApp.response.message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show($"Přihlášení úspěšné!\nUživatel: {KeyAuthApp.user_data.username}", "Úspěch", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string hwid = GetHWID();
            string username = txtUsername.Text;
            string licenseKey = txtLicenseKey.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(licenseKey))
            {
                MessageBox.Show("Vyplňte všechna pole!", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KeyAuthApp.register(username, hwid, licenseKey);
            if (!KeyAuthApp.response.success)
            {
                MessageBox.Show("Registrace selhala: " + KeyAuthApp.response.message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Registrace úspěšná! Nyní se můžete přihlásit.", "Úspěch", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetHWID()
        {
            string hwid = "";
            var searcher = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (var obj in searcher.Get())
            {
                hwid = obj["SerialNumber"].ToString();
                break;
            }
            return hwid;
        }
    }
}