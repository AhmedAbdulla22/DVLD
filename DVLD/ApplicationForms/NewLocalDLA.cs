using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ApplicationForms
{
    public partial class NewLocalDLA : Form
    {
        //Get Classees from DB 
        Dictionary<string, int> ClassDict = clsClass.GetAllClasses();
        public NewLocalDLA()
        {
            InitializeComponent();

            //fill Classes combobox
            if (ClassDict.Count != 0)
            {
                foreach(var Class in ClassDict)
                {
                    cbLicenseClasses.Items.Add(Class.Key);
                }

                //set cb to zero index
                cbLicenseClasses.SelectedIndex = 0;
            }
        }

        private void tabApplication_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
