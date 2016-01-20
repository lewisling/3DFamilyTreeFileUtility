using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FamilySearch.Api;
using FamilySearch.Api.Ft;
using Gx.Rs.Api;
using Newtonsoft.Json.Linq;

namespace _3DFamilyTreeFileUtility
{
    public partial class SignInFormWizard : Form
    {
        private string _username = "";
        private string _password = "";
        private string _developerKey = "";
        private FamilySearchFamilyTree _ft;
        private FamilyHistorySource _fhs;

        public SignInFormWizard(FamilyHistorySource fhs, FamilySearchFamilyTree ft, string username, string password,
            string developerKey)
        {
            _fhs = fhs;
            _username = username;
            _password = password;
            _developerKey = developerKey;
            _ft = ft;
            InitializeComponent();
            lblSandbox.Visible = _fhs.isSandBox;
            txtUsername.Text = _username;
            txtPassword.Text = _password;
        }


        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if ((txtUsername.Text == "") || (txtPassword.Text == ""))
            {
                txtStatus.Text = "A username and password are required.";
                return;
            }

            HELPER_updateTextBox(txtStatus, "Authenticating...");

            using (new WaitCursor())
            {
                btnSignIn.Enabled = false;
                try
                {
                    //and authenticate to the collection
                    _ft.AuthenticateViaOAuth2Password(txtUsername.Text, txtPassword.Text, _developerKey);

                    if (_ft.Response.StatusCode != HttpStatusCode.OK)
                        txtStatus.Text =
                            String.Format(
                                "Unexpected HTTP status returned from Family Search Authentication Request.  Got {0}, description {1}",
                                _ft.Response.StatusCode, _ft.Response.StatusDescription);
                }
                catch (GedcomxApplicationException Ex)
                {
                    var objects = JObject.Parse(Ex.Response.Content);
                    txtStatus.Text = objects.SelectToken("error_description").Value<string>();
                    btnSignIn.Enabled = true;
                    return;
                }


                if (!_ft.IsAuthenticated)
                {
                    txtStatus.Text = "The username or password was incorrect.";
                    btnSignIn.Enabled = true;

                    return;
                }
                else
                {
                    //DialogResult = DialogResult.OK;
                    // Just move on to next tab in the Wizard
                    // btnPage2Next.Enabled = false;  // styart off disabled until Starting ID is verified
                    txtResults.Text = "Starting ID not verified yet.";
                    txtStartingID.Focus();

                    txtCollection.Text = _ft.Collection.Title;
                    txtClient.Text = _ft.Client.BaseUrl;
                    UserState userState = _ft.ReadCurrentUser();
                    txtLoggedInAs.Text = userState.User.DisplayName;
                    txtMyID.Text = userState.User.PersonId;

                    txtStartingID.Text = _fhs.startingID;
                    rbtnAncestors.Checked = _fhs.isAncestry;
                    rbtnDecendants.Checked = _fhs.isDescendancy;
                    rbtnBoth.Checked = _fhs.isBoth;
                    numGenerations.Value = _fhs.numberOfGenerations;

                    btnSignIn.Enabled = true;

                    tabWizard.SelectedIndex = (tabWizard.SelectedIndex + 1 < tabWizard.TabCount)
                        ? tabWizard.SelectedIndex + 1
                        : tabWizard.SelectedIndex;
                }
            }
        }
        private void btnDone_Click(object sender, EventArgs e)
        {

            if (VerifyID())
            {
                _fhs.startingID = txtStartingID.Text;
                _fhs.isAncestry = rbtnAncestors.Checked;
                _fhs.isDescendancy = rbtnDecendants.Checked;
                _fhs.isBoth = rbtnBoth.Checked;                 
                _fhs.numberOfGenerations = (int)numGenerations.Value;
                DialogResult = DialogResult.OK;
            }

        }


        private bool VerifyID()
        {
            bool retStatus = false;

            btnDone.Enabled = false;
            btnVerify.Enabled = false;

            HELPER_updateTextBox(txtResults, "Verifying...");
            
            using (new WaitCursor())
            {
                try
                {
                    FamilyTreePersonState personState = _ft.ReadPersonById(txtStartingID.Text);

                    personState.IfSuccessful(); // Throw an exception if there is an error                    

                    txtResults.Text = string.Format("Verified, this ID is '{0}'",
                        personState.Person.DisplayExtension.Name);
                    retStatus = true;
                }
                catch (Exception Ex)
                {
                    txtResults.Text = "Invalid ID, Try again.";
                    retStatus = false;
                }
            }

            btnDone.Enabled = true;
          
            return retStatus;
        }


        private void btnPrevious_Click(object sender, EventArgs e)
        {
            tabWizard.SelectedIndex = (tabWizard.SelectedIndex - 1 >= 0) ?
                            tabWizard.SelectedIndex - 1 : tabWizard.SelectedIndex;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            VerifyID();
        }

        #region HELPERS
        /// <summary>
        /// Will update Text in a Text Box when the UI thread is still busy
        /// </summary>
        /// <param name="myTextBox">The TextBox control to update</param>
        /// <param name="myText">The Text to update</param>
        private void HELPER_updateTextBox(TextBox myTextBox, string myText)
        {
            myTextBox.Text = myText;
            myTextBox.Invalidate();
            myTextBox.Update();
            myTextBox.Refresh();
            Application.DoEvents();
        }

        #endregion

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Get file name.
            _fhs.fileName = saveFileDialog1.FileName;
            _fhs.isSaveToFile = true;
            DialogResult = DialogResult.OK;
        }

        private void txtStartingID_TextChanged(object sender, EventArgs e)
        {
            btnVerify.Enabled = true;
        }

    }
}
