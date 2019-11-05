using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OLiOSoft.OWINKatana.WinformTest
{
    using OLiOSoft.OSystem.Helpers;
    using OLiOSoft.OWINKatana.OHosted.OManager;
    using OLiOSoft.OWINKatana.TestHost;
    using OLiOSoft.OWINKatana.TestHost1;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            centre = OLiOHostedCentre.CreateSingletonMaster;
        }

        OLiOHostedCentre centre = null;
        private void StartTestHost_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

			button.Enabled = false;

            centre.Run<TestHosted>();
        }

        private void StopTestHost_Click(object sender, EventArgs e)
        {
            this.StartTestHost.Enabled = true;

            centre.Stop<TestHosted>();
        }

        private void StartTestHost1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            button.Enabled = false;

            centre.Run<TestHosted1>();
        }

        private void StopTestHost1_Click(object sender, EventArgs e)
        {
            this.StartTestHost1.Enabled = true;

            centre.Stop<TestHosted1>();
        }

        private void ReleaseHost_Click(object sender, EventArgs e)
        {
            centre.Release();
        }

        private void LogSomething_Click(object sender, EventArgs e)
        {
            centre.Inspect(this, new OLiOEventArgs<Action<string[]>>(Log));
        }

        #region -- Private APIMethods --
        private void Log(params string[] message)
        {
            int length = message.Length;
            for (int i = 0; i < length; i++)
                this.LogMessage.Items.Add(message[i]);
        }


        #endregion
    }
}
