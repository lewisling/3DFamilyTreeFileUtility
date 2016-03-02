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
using Gedcomx.Support;
using Gx.Links;
using Gx.Rs.Api;
using Gx.Rs.Api.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using _3DFamilyTreeFileUtility.Properties;

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
            String access_token = null;
            FamilySearchFamilyTree ident;

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
                    #region Do it myself
                    // CRAZY LITTLE HACK - I would hope the API would do this correctly
                    // The ident.familysearch.org endpoint was not getting hit when I used the API
                    //_ft.AuthenticateViaOAuth2Password(txtUsername.Text, txtPassword.Text, _developerKey);

                    ident = new FamilySearchFamilyTree(new Uri("https://ident.familysearch.org/"));
                    //get our access token
                    IDictionary<String, String> formData = new Dictionary<String, String>();
                    formData.Add("grant_type", "password");
                    formData.Add("username", txtUsername.Text);
                    formData.Add("password", txtPassword.Text);
                    formData.Add("client_id", _developerKey);

                    IRestRequest request = new RestRequest()
                        .Accept(MediaTypes.APPLICATION_JSON_TYPE)
                        .ContentType(MediaTypes.APPLICATION_FORM_URLENCODED_TYPE)
                        .SetEntity(formData)
                        .Build("https://ident.familysearch.org/cis-web/oauth2/v3/token", Method.POST);

                    IRestResponse response = ident.Client.Handle(request);
                    var i = (int)response.StatusCode;

                    if (i >= 200 && i < 300)
                    {
                        var accessToken = JsonConvert.DeserializeObject<IDictionary<string, object>>(response.Content);
                        

                        if (accessToken.ContainsKey("access_token"))
                        {
                            access_token = accessToken["access_token"] as string;
                        }
                        if (access_token == null && accessToken.ContainsKey("token"))
                        {
                            //workaround to accommodate providers that were built on an older version of the oauth2 specification.
                            access_token = accessToken["token"] as string;
                        }

                        if (access_token == null)
                        {
                            throw new GedcomxApplicationException("Illegal access token response: no access_token provided.", response);
                        }

                    }
                    #endregion

                }
                catch (GedcomxApplicationException Ex)
                {
                    try
                    {  // if it is formatted with a Response, this will work
                        var objects = JObject.Parse(Ex.Response.Content);
                        txtStatus.Text = objects.SelectToken("error_description").Value<string>();
                    }
                    catch (Exception higherEx)
                    {   // Otherwise the above Parse will throw an exception, in this case, just read the Exception Message
                        txtStatus.Text = Ex.Message;
                    }
                    btnSignIn.Enabled = true;
                    return;
                }

                txtResults.Text = "Starting ID not verified yet.";
                txtStartingID.Focus();

                // Magic Handoff
                _ft.AuthenticateWithAccessToken(access_token);

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
