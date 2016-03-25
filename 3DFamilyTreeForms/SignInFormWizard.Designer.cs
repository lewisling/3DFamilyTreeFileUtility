using System.Drawing;
using System.Windows.Forms;

namespace _3DFamilyTreeFileUtility
{
    partial class SignInFormWizard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignInFormWizard));
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabWizard = new System.Windows.Forms.TabControl();
            this.tabSignIn = new System.Windows.Forms.TabPage();
            this.lblSandbox = new System.Windows.Forms.Label();
            this.txtInstructions = new System.Windows.Forms.TextBox();
            this.tabStartingID = new System.Windows.Forms.TabPage();
            this.treAncestorPicker = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.txtStartingID = new System.Windows.Forms.TextBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.lblLoginSuccess = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCollection = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numGenerations = new System.Windows.Forms.NumericUpDown();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnBoth = new System.Windows.Forms.RadioButton();
            this.rbtnDecendants = new System.Windows.Forms.RadioButton();
            this.rbtnAncestors = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLoggedInAs = new System.Windows.Forms.TextBox();
            this.txtMyID = new System.Windows.Forms.TextBox();
            this.grpAncestorPicker = new System.Windows.Forms.GroupBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabWizard.SuspendLayout();
            this.tabSignIn.SuspendLayout();
            this.tabStartingID.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGenerations)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(218, 71);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(181, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(218, 115);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(181, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(387, 315);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnSignIn.TabIndex = 2;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(6, 344);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(595, 20);
            this.txtStatus.TabIndex = 0;
            this.txtStatus.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(185, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 26);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sign in to FamilySearch";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(162, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabWizard
            // 
            this.tabWizard.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabWizard.Controls.Add(this.tabSignIn);
            this.tabWizard.Controls.Add(this.tabStartingID);
            this.tabWizard.ItemSize = new System.Drawing.Size(58, 18);
            this.tabWizard.Location = new System.Drawing.Point(2, 1);
            this.tabWizard.Name = "tabWizard";
            this.tabWizard.SelectedIndex = 0;
            this.tabWizard.Size = new System.Drawing.Size(615, 398);
            this.tabWizard.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabWizard.TabIndex = 10;
            // 
            // tabSignIn
            // 
            this.tabSignIn.Controls.Add(this.lblSandbox);
            this.tabSignIn.Controls.Add(this.txtInstructions);
            this.tabSignIn.Controls.Add(this.txtStatus);
            this.tabSignIn.Controls.Add(this.label3);
            this.tabSignIn.Controls.Add(this.btnCancel);
            this.tabSignIn.Controls.Add(this.txtUsername);
            this.tabSignIn.Controls.Add(this.txtPassword);
            this.tabSignIn.Controls.Add(this.label1);
            this.tabSignIn.Controls.Add(this.label2);
            this.tabSignIn.Controls.Add(this.btnSignIn);
            this.tabSignIn.Location = new System.Drawing.Point(4, 22);
            this.tabSignIn.Name = "tabSignIn";
            this.tabSignIn.Padding = new System.Windows.Forms.Padding(3);
            this.tabSignIn.Size = new System.Drawing.Size(607, 372);
            this.tabSignIn.TabIndex = 0;
            this.tabSignIn.Text = "Sign In";
            this.tabSignIn.UseVisualStyleBackColor = true;
            // 
            // lblSandbox
            // 
            this.lblSandbox.AutoSize = true;
            this.lblSandbox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSandbox.Location = new System.Drawing.Point(520, 19);
            this.lblSandbox.Name = "lblSandbox";
            this.lblSandbox.Size = new System.Drawing.Size(71, 16);
            this.lblSandbox.TabIndex = 9;
            this.lblSandbox.Text = "Sandbox";
            // 
            // txtInstructions
            // 
            this.txtInstructions.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtInstructions.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstructions.Location = new System.Drawing.Point(103, 151);
            this.txtInstructions.Multiline = true;
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.ReadOnly = true;
            this.txtInstructions.Size = new System.Drawing.Size(438, 141);
            this.txtInstructions.TabIndex = 0;
            this.txtInstructions.TabStop = false;
            this.txtInstructions.Text = resources.GetString("txtInstructions.Text");
            // 
            // tabStartingID
            // 
            this.tabStartingID.Controls.Add(this.textBox1);
            this.tabStartingID.Controls.Add(this.treAncestorPicker);
            this.tabStartingID.Controls.Add(this.groupBox3);
            this.tabStartingID.Controls.Add(this.btnPrevious);
            this.tabStartingID.Controls.Add(this.btnDone);
            this.tabStartingID.Controls.Add(this.lblLoginSuccess);
            this.tabStartingID.Controls.Add(this.txtClient);
            this.tabStartingID.Controls.Add(this.label6);
            this.tabStartingID.Controls.Add(this.txtCollection);
            this.tabStartingID.Controls.Add(this.groupBox2);
            this.tabStartingID.Controls.Add(this.txtResults);
            this.tabStartingID.Controls.Add(this.groupBox1);
            this.tabStartingID.Controls.Add(this.label4);
            this.tabStartingID.Controls.Add(this.label5);
            this.tabStartingID.Controls.Add(this.panel2);
            this.tabStartingID.Controls.Add(this.grpAncestorPicker);
            this.tabStartingID.Location = new System.Drawing.Point(4, 22);
            this.tabStartingID.Name = "tabStartingID";
            this.tabStartingID.Padding = new System.Windows.Forms.Padding(3);
            this.tabStartingID.Size = new System.Drawing.Size(607, 372);
            this.tabStartingID.TabIndex = 1;
            this.tabStartingID.Text = "Starting ID";
            this.tabStartingID.UseVisualStyleBackColor = true;
            // 
            // treAncestorPicker
            // 
            this.treAncestorPicker.Location = new System.Drawing.Point(294, 44);
            this.treAncestorPicker.Name = "treAncestorPicker";
            this.treAncestorPicker.Size = new System.Drawing.Size(292, 178);
            this.treAncestorPicker.TabIndex = 36;
            this.treAncestorPicker.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treAncestorPicker_AfterSelect);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnVerify);
            this.groupBox3.Controls.Add(this.txtStartingID);
            this.groupBox3.Location = new System.Drawing.Point(294, 294);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(211, 44);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Starting FamilySearch ID:";
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(123, 15);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 36;
            this.btnVerify.Text = "Verify ID";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // txtStartingID
            // 
            this.txtStartingID.Location = new System.Drawing.Point(14, 18);
            this.txtStartingID.Name = "txtStartingID";
            this.txtStartingID.Size = new System.Drawing.Size(88, 20);
            this.txtStartingID.TabIndex = 4;
            this.txtStartingID.TextChanged += new System.EventHandler(this.txtStartingID_TextChanged);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(25, 310);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 5;
            this.btnPrevious.Text = "<< Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(511, 309);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 6;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lblLoginSuccess
            // 
            this.lblLoginSuccess.AutoSize = true;
            this.lblLoginSuccess.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginSuccess.Location = new System.Drawing.Point(33, 9);
            this.lblLoginSuccess.Name = "lblLoginSuccess";
            this.lblLoginSuccess.Size = new System.Drawing.Size(203, 26);
            this.lblLoginSuccess.TabIndex = 33;
            this.lblLoginSuccess.Text = "Sign In Successful";
            // 
            // txtClient
            // 
            this.txtClient.BackColor = System.Drawing.SystemColors.Control;
            this.txtClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClient.Location = new System.Drawing.Point(91, 128);
            this.txtClient.Name = "txtClient";
            this.txtClient.ReadOnly = true;
            this.txtClient.Size = new System.Drawing.Size(219, 13);
            this.txtClient.TabIndex = 0;
            this.txtClient.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(49, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Client:";
            // 
            // txtCollection
            // 
            this.txtCollection.BackColor = System.Drawing.SystemColors.Control;
            this.txtCollection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCollection.Location = new System.Drawing.Point(91, 109);
            this.txtCollection.Name = "txtCollection";
            this.txtCollection.ReadOnly = true;
            this.txtCollection.Size = new System.Drawing.Size(219, 13);
            this.txtCollection.TabIndex = 0;
            this.txtCollection.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numGenerations);
            this.groupBox2.Location = new System.Drawing.Point(184, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(89, 94);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generations:";
            // 
            // numGenerations
            // 
            this.numGenerations.BackColor = System.Drawing.SystemColors.Control;
            this.numGenerations.Location = new System.Drawing.Point(21, 23);
            this.numGenerations.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numGenerations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGenerations.Name = "numGenerations";
            this.numGenerations.Size = new System.Drawing.Size(44, 20);
            this.numGenerations.TabIndex = 3;
            this.numGenerations.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // txtResults
            // 
            this.txtResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResults.Location = new System.Drawing.Point(6, 344);
            this.txtResults.Name = "txtResults";
            this.txtResults.ReadOnly = true;
            this.txtResults.Size = new System.Drawing.Size(595, 20);
            this.txtResults.TabIndex = 0;
            this.txtResults.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnBoth);
            this.groupBox1.Controls.Add(this.rbtnDecendants);
            this.groupBox1.Controls.Add(this.rbtnAncestors);
            this.groupBox1.Location = new System.Drawing.Point(37, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 94);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "What to read:";
            // 
            // rbtnBoth
            // 
            this.rbtnBoth.AutoSize = true;
            this.rbtnBoth.Enabled = false;
            this.rbtnBoth.Location = new System.Drawing.Point(18, 69);
            this.rbtnBoth.Name = "rbtnBoth";
            this.rbtnBoth.Size = new System.Drawing.Size(47, 17);
            this.rbtnBoth.TabIndex = 2;
            this.rbtnBoth.TabStop = true;
            this.rbtnBoth.Text = "Both";
            this.rbtnBoth.UseVisualStyleBackColor = true;
            // 
            // rbtnDecendants
            // 
            this.rbtnDecendants.AutoSize = true;
            this.rbtnDecendants.Location = new System.Drawing.Point(18, 46);
            this.rbtnDecendants.Name = "rbtnDecendants";
            this.rbtnDecendants.Size = new System.Drawing.Size(88, 17);
            this.rbtnDecendants.TabIndex = 1;
            this.rbtnDecendants.TabStop = true;
            this.rbtnDecendants.Text = "Descendants";
            this.rbtnDecendants.UseVisualStyleBackColor = true;
            // 
            // rbtnAncestors
            // 
            this.rbtnAncestors.AutoSize = true;
            this.rbtnAncestors.Enabled = false;
            this.rbtnAncestors.Location = new System.Drawing.Point(18, 23);
            this.rbtnAncestors.Name = "rbtnAncestors";
            this.rbtnAncestors.Size = new System.Drawing.Size(72, 17);
            this.rbtnAncestors.TabIndex = 0;
            this.rbtnAncestors.TabStop = true;
            this.rbtnAncestors.Text = "Ancestors";
            this.rbtnAncestors.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(30, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Collection:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtLoggedInAs);
            this.panel2.Controls.Add(this.txtMyID);
            this.panel2.Location = new System.Drawing.Point(26, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(247, 53);
            this.panel2.TabIndex = 34;
            // 
            // txtLoggedInAs
            // 
            this.txtLoggedInAs.AllowDrop = true;
            this.txtLoggedInAs.BackColor = System.Drawing.SystemColors.Window;
            this.txtLoggedInAs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoggedInAs.CausesValidation = false;
            this.txtLoggedInAs.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoggedInAs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(148)))), ((int)(((byte)(196)))));
            this.txtLoggedInAs.Location = new System.Drawing.Point(10, 4);
            this.txtLoggedInAs.Name = "txtLoggedInAs";
            this.txtLoggedInAs.ReadOnly = true;
            this.txtLoggedInAs.Size = new System.Drawing.Size(230, 19);
            this.txtLoggedInAs.TabIndex = 0;
            this.txtLoggedInAs.TabStop = false;
            // 
            // txtMyID
            // 
            this.txtMyID.BackColor = System.Drawing.SystemColors.Window;
            this.txtMyID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMyID.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMyID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtMyID.Location = new System.Drawing.Point(63, 29);
            this.txtMyID.Name = "txtMyID";
            this.txtMyID.ReadOnly = true;
            this.txtMyID.Size = new System.Drawing.Size(101, 14);
            this.txtMyID.TabIndex = 0;
            this.txtMyID.TabStop = false;
            // 
            // grpAncestorPicker
            // 
            this.grpAncestorPicker.Location = new System.Drawing.Point(279, 22);
            this.grpAncestorPicker.Name = "grpAncestorPicker";
            this.grpAncestorPicker.Size = new System.Drawing.Size(322, 215);
            this.grpAncestorPicker.TabIndex = 37;
            this.grpAncestorPicker.TabStop = false;
            this.grpAncestorPicker.Text = "Ancestor Picker";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "3dft";
            this.saveFileDialog1.FileName = "FamilyTree";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox1.Location = new System.Drawing.Point(294, 245);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 43);
            this.textBox1.TabIndex = 38;
            this.textBox1.Text = "Click to select a name above to use their FamilySearch ID.  Or enter an ID by typ" +
    "ing it below. ";
            // 
            // SignInFormWizard
            // 
            this.AcceptButton = this.btnSignIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(629, 403);
            this.ControlBox = false;
            this.Controls.Add(this.tabWizard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignInFormWizard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FamilySearch Sign In";
            this.tabWizard.ResumeLayout(false);
            this.tabSignIn.ResumeLayout(false);
            this.tabSignIn.PerformLayout();
            this.tabStartingID.ResumeLayout(false);
            this.tabStartingID.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numGenerations)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabWizard;
        private System.Windows.Forms.TabPage tabSignIn;
        private System.Windows.Forms.TabPage tabStartingID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtStartingID;
        private System.Windows.Forms.Label lblLoginSuccess;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCollection;
        private System.Windows.Forms.TextBox txtLoggedInAs;
        private System.Windows.Forms.TextBox txtMyID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numGenerations;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnBoth;
        private System.Windows.Forms.RadioButton rbtnDecendants;
        private System.Windows.Forms.RadioButton rbtnAncestors;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private TextBox txtInstructions;
        private Button btnVerify;
        private SaveFileDialog saveFileDialog1;
        private Label lblSandbox;
        private TreeView treAncestorPicker;
        private GroupBox grpAncestorPicker;
        private TextBox textBox1;
    }
}