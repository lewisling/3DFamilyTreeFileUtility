using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FamilySearch.Api.Ft;
using FamilySearch.Api.Util;
using Gx.Conclusion;
using Gx.Links;
using Gx.Rs.Api;
using Gx.Rs.Api.Options;
using Gx.Rs.Api.Util;
using Gx.Types;
using UnityTreeScripts;


//TODO Collect Authentication information from user
//TODO Get This information from the Actual FamilySearch sight - not just the SandBox

namespace _3DFamilyTreeForms
{
    public partial class MainForm : Form
    {

        //private FamilySearchFamilyTree tree;
        private CourtHouse _courtHouse = null;
        private FamilyHistorySource _fhs = null;

        public MainForm()
        {
            InitializeComponent();

            _fhs = new FamilyHistorySource(FamilyHistorySource.SourceType.FamilySearchService);

            EnableOutputUI(false);
            txtOutput.Text = "Welcome to 3D Family Tree!  Click Start to get going.";
            btnStart.Focus();

        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            txtOutput.Text = "Let's get started!";
            EnableStartUI(false);
            StartFamilySearchConnection();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "Let's get started!";
            EnableStartUI(false);
            StartFamilySearchConnection();

        }

        public void StartFamilySearchConnection()
        {
            _courtHouse = new CourtHouse();
            txtOutput.Text = "Signing in.";

            if (_fhs.initializeConnection())
            {

                txtOutput.Text = "Collecting Results, please wait...";
                backgroundWorker1.RunWorkerAsync();
 

            }
            else
            {
                txtOutput.Text = "Canceled Sign in.";

                EnableStartUI(true);
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            
            //TODO Start at the account owner's person
            
            if (!_fhs.readCollection(_courtHouse, worker)) { e.Cancel = true; return; }

            e.Result = "Processing Complete!";
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            else
            {
                Application.Exit();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                txtOutput.Clear();
                txtOutput.AppendText("Background worker returned error: " + e.Error.Message);
                txtOutput.AppendText("Error Result:" + (string)e.Error.StackTrace);
                //MessageBox.Show(e.Error.Message);
            }
            else
            {
                if (e.Cancelled)
                {
                    txtOutput.Clear();
                    txtOutput.AppendText("Processing Cancelled");
                }
                else
                {
                    txtOutput.Clear();
                    txtOutput.AppendText("Background worker result: " + (string)e.Result);
                    EnableOutputUI(true);
                }
            }

            EnableStartUI(true);

        }

        private void EnableStartUI(bool enable)
        {
            this.btnStart.Enabled = enable;
            this.startToolStripMenuItem.Enabled = enable;
          //  this.btnCancel.Enabled = !enable;

        }
        private void EnableOutputUI(bool enable)
        {
            this.btnSaveAs.Enabled = enable;
            this.saveToolStripMenuItem.Enabled = enable;
            this.btnShowLog.Enabled = enable;
            //  this.btnCancel.Enabled = !enable;

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void about3DFamilyTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutBoxForm = new AboutBox1();
            aboutBoxForm.ShowDialog();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

            _fhs.fileName = saveFileDialog1.FileName;
            _fhs.isSaveToFile = true;
            // Write to the file name selected.

            File.WriteAllText(_fhs.fileName, _courtHouse.getAllFamiliesText(0));
        }

        private void btnShowLog_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            txtOutput.AppendText(_courtHouse.getAllFamiliesText(0));
        }
    }
}
