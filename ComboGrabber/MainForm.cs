using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.IO;

namespace ComboGrabber
{
    public partial class MainForm : Form
    {
        const string Version = "[BETA] V1.0.0";

        private Thread GrabberThread;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = $"ComboGrabber {Version}";
            AccountGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #region ShowImportProxyDialog
        private void importProxiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportProxyDialog.ShowDialog();
        }
        #endregion

        #region LoadProxies
        private void ImportProxyDialog_FileOk(object sender, CancelEventArgs e)
        {
            if(!ProxyManager.LoadProxies(ImportProxyDialog.FileName))
            {
                ShowErrorMessage("Your proxy list had no proxies! Please check the list.");
            }
            else
            {
                btnGrab.Enabled = true;
            }
        }
        #endregion

        #region ShowErrorMessage
        private void ShowErrorMessage(string Content, string Type = "Error")
        {
            MessageBox.Show(
                Content,
                Type,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
        }
        #endregion

        private void btnGrab_Click(object sender, EventArgs e)
        {
            if(ProxyManager.Proxies.Count != 0)
            {
                try
                {
                    GrabberThread = new Thread(() =>
                    {
                        new Grabber(Decimal.ToInt32(MaxThreads.Value), this).Grab();
                    });

                    GrabberThread.Start();

                    btnGrab.Enabled = false;

                    CounterTimer.Start();

                    MessageBox.Show(
                        "Grabber has started. This can take a while... be patient!",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                }
                catch
                {
                    ShowErrorMessage("An unknown error occured. Contact Raghav.");
                }
            }
            else
            {
                ShowErrorMessage("You need to import your proxies! Press \"Config...\" on the top left.");
            }
        }

        public void UpdateGrid(DataTable ComboTable)
        {
            if(AccountGrid.InvokeRequired)
            {
                AccountGrid.Invoke((MethodInvoker)(() => AccountGrid.DataSource = ComboTable));
            }
            else
            {
                AccountGrid.DataSource = ComboTable;
            }
        }

        public void AddAccount(string[] Account)
        {
            if (AccountGrid.InvokeRequired)
            {
                AccountGrid.Invoke((MethodInvoker)(() => AccountGrid.Rows.Add(Account[0], Account[1])));
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(GrabberThread != null && GrabberThread.IsAlive)
            {
                ShowErrorMessage("Can't exit while the grabber is running. Please wait!");
                e.Cancel = true;
            }
        }

        private void CounterTimer_Tick(object sender, EventArgs e)
        {
            lblGrabbed.Text = AccountGrid.Rows.Count.ToString();
            if(!GrabberThread.IsAlive)
            {
                CounterTimer.Stop();

                MessageBox.Show(
                    "Finished grabbing!",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportGrabbedDialog.ShowDialog();
        }

        private void ExportGrabbedDialog_FileOk(object sender, CancelEventArgs e)
        {
            if (File.Exists(ExportGrabbedDialog.FileName)) File.Delete(ExportGrabbedDialog.FileName);

            int count = 0;

            using (StreamWriter sw = new StreamWriter(ExportGrabbedDialog.FileName, true))
            {
                foreach(DataGridViewRow Combo in AccountGrid.Rows)
                {
                    sw.WriteLine($"{Combo.Cells["Username"].Value.ToString()}:{Combo.Cells["Password"].Value.ToString()}");
                    count++;
                }
            }

            MessageBox.Show(
                $"Exported a total of {count.ToString()} accounts.",
                "Info",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }
    }
}
