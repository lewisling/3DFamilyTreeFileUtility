namespace _3DFamilyTreeFileUtility
{
    partial class SimulationFormWizard
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRunSimulation = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numNumerOfYears = new System.Windows.Forms.NumericUpDown();
            this.numStartYear = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumerOfYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartYear)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Years";
            // 
            // btnRunSimulation
            // 
            this.btnRunSimulation.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnRunSimulation.Location = new System.Drawing.Point(142, 215);
            this.btnRunSimulation.Name = "btnRunSimulation";
            this.btnRunSimulation.Size = new System.Drawing.Size(104, 23);
            this.btnRunSimulation.TabIndex = 4;
            this.btnRunSimulation.Text = "Run Simulation";
            this.btnRunSimulation.UseVisualStyleBackColor = true;
            this.btnRunSimulation.Click += new System.EventHandler(this.btnRunSimulation_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(32, 215);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numNumerOfYears);
            this.groupBox1.Controls.Add(this.numStartYear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 120);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Simulation Parameters";
            // 
            // numNumerOfYears
            // 
            this.numNumerOfYears.Location = new System.Drawing.Point(141, 69);
            this.numNumerOfYears.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numNumerOfYears.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numNumerOfYears.Name = "numNumerOfYears";
            this.numNumerOfYears.Size = new System.Drawing.Size(72, 20);
            this.numNumerOfYears.TabIndex = 8;
            this.numNumerOfYears.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // numStartYear
            // 
            this.numStartYear.Location = new System.Drawing.Point(141, 28);
            this.numStartYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numStartYear.Name = "numStartYear";
            this.numStartYear.Size = new System.Drawing.Size(72, 20);
            this.numStartYear.TabIndex = 7;
            this.numStartYear.Value = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            // 
            // SimulationFormWizard
            // 
            this.AcceptButton = this.btnRunSimulation;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRunSimulation);
            this.Name = "SimulationFormWizard";
            this.Text = "Simulation Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNumerOfYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRunSimulation;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numNumerOfYears;
        private System.Windows.Forms.NumericUpDown numStartYear;
    }
}