using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using UnityTreeScripts;

//TODO Get This information from the Actual FamilySearch sight - not just the SandBox

namespace _3DFamilyTreeForms
{
    public partial class MainForm : Form
    {
        //private FamilySearchFamilyTree tree;
        private CourtHouse _courtHouse = null;
        //private Family History Source - can refer to several types of Family Histroy Sources
        private FamilyHistorySource _fhs = null;

        public MainForm()
        {
            InitializeComponent();

            _fhs = new FamilyHistorySource(FamilyHistorySource.SourceType.FamilySearchService);

            HELPER_EnableOutputUI(false);
            txtOutput.Text = "Welcome to the 3D Family Tree File Utility  This utility will help you create the Family History data file needed for 3D Family Tree.";
            btnStart.Focus();

        }

        #region Family Search 
        private void BtnStartClick(object sender, EventArgs e)
        {
            txtOutput.Text = "Let's get started!";
            HELPER_EnableStartUI(false);
            StartFamilySearchConnection();
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "Let's get started!";
            HELPER_EnableStartUI(false);
            StartFamilySearchConnection();

        }

        public void StartFamilySearchConnection()
        {
            _courtHouse = new CourtHouse();
            txtOutput.Text = "Signing in.";

            if (_fhs.initializeConnection())
            {

                txtOutput.Text = "Collecting Results, please wait...";
                _courtHouse.init();
                backgroundWorker1.RunWorkerAsync();


            }
            else
            {
                txtOutput.Text = "Canceled Sign in.";

                HELPER_EnableStartUI(true);
            }

        }
        #endregion

        #region Open File
        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        public void OpenFile()
        {
            _courtHouse = new CourtHouse();
            txtOutput.Text = "Lets go get that file, shall we?";

            openFileDialog1.Filter = "Xml Doc (*.xml)|*.xml|Text (*.txt)|*.txt";
            openFileDialog1.AddExtension = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Construct an instance of the XmlSerializer with the type
                // of object that is being deserialized.
                XmlSerializer serializer = new XmlSerializer(_courtHouse.GetType());
                // To read the file, create a FileStream.
                FileStream myFileStream = new FileStream(openFileDialog1.FileName, FileMode.Open);
                // Call the Deserialize method and cast to the object type.
                _courtHouse = (CourtHouse) serializer.Deserialize(myFileStream);

                myFileStream.Close();
                txtOutput.Clear();
                txtOutput.AppendText(string.Format("Read in {0} Families, and {1} Individuals",
                    _courtHouse.allFamilies.Count, _courtHouse.myPeople.allPeople.Count));
                HELPER_EnableOutputUI(true);
            }
            else
            {
                txtOutput.Clear();
                txtOutput.AppendText("Open File, Canceled.");

            }  

        }
        #endregion

        #region Save As
        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();

        }

        private void SaveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {

            saveFileDialog1.FileName = _fhs.username + " "
                                       + _fhs.startingID + " "
                                       + _fhs.numberOfGenerations + " generations";
            saveFileDialog1.Filter = "Xml Doc (*.xml)|*.xml|Text (*.txt)|*.txt";
            saveFileDialog1.AddExtension = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {


                _fhs.fileName = saveFileDialog1.FileName;
                var filetype = saveFileDialog1.DefaultExt;

                _fhs.isSaveToFile = true;
                // Write to the file name selected.

                XmlSerializer serializer = new XmlSerializer(_courtHouse.GetType());

                var ns = new System.Xml.Serialization.XmlSerializerNamespaces();
                ns.Add(String.Empty, String.Empty);

                var settings = new XmlWriterSettings { Indent = true, IndentChars = "\t", CloseOutput = true };

                using (var writer = XmlWriter.Create(File.Create(_fhs.fileName), settings))
                {

                    serializer.Serialize(writer, _courtHouse, ns);
                }
                txtOutput.Clear();
                txtOutput.AppendText(string.Format("Wrote to file {0} Families, and {1} Individuals",
                    _courtHouse.allFamilies.Count, _courtHouse.myPeople.allPeople.Count));
            }
            else
            {
                txtOutput.Clear();
                txtOutput.AppendText("Save to file canceled.");

            }
        }
        #endregion

        #region Other Quick/Simple Button Click Methods
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void About3DFamilyTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutBoxForm = new AboutBox1();
            aboutBoxForm.ShowDialog();
        }

        private void BtnShowLog_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
            txtOutput.AppendText(_courtHouse.getAllFamiliesText(0));
        }
        #endregion

        #region Backgroud Worker for long Family Search transactions
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
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

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    HELPER_EnableOutputUI(true);
                }
            }

            HELPER_EnableStartUI(true);

        }
        #endregion

        #region HELPERs
        private void HELPER_EnableStartUI(bool enable)
        {
            this.btnStart.Enabled = enable;
            this.btnOpenFile.Enabled = enable;
            this.startToolStripMenuItem.Enabled = enable;
            this.openToolStripMenuItem.Enabled = enable;
            //  this.btnCancel.Enabled = !enable;

        }

        private void HELPER_EnableOutputUI(bool enable)
        {
            this.btnSaveAs.Enabled = enable;
            this.saveToolStripMenuItem.Enabled = enable;
            this.btnShowLog.Enabled = enable;
            //  this.btnCancel.Enabled = !enable;

        }
        #endregion
    }
}
