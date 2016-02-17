using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityTreeScripts;

namespace _3DFamilyTreeFileUtility
{
    public partial class SimulationFormWizard : Form
    {


        public int StartYear
        {
            get; set;
        }

        public int NumberOfYears
        {
            get; set;
        }

        public SimulationFormWizard()
        {
            InitializeComponent();
        }

        private void btnRunSimulation_Click(object sender, EventArgs e)
        {
            //    var result = _matchMaker.getAllFamiliesText(lastYear);
            StartYear = (int)numStartYear.Value;
            NumberOfYears = (int)numNumerOfYears.Value;

            DialogResult = DialogResult.Yes;

        }

    }
}

        
 

