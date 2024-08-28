using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ApplicationForms
{
    public partial class AddLocalDLA : Form
    {
        //Get Classees from DB 
        Dictionary<string, int> ClassesIndex = clsClass.GetAllClasses();
        Dictionary<int,decimal> ClassesFees = clsClass.GetAllClassFees();

        enum ctrlMode { Add = 1, Update = 2 };
        ctrlMode _ctrlMode = ctrlMode.Add;

        public AddLocalDLA(int LDLAppID = -1)
        {
            InitializeComponent();

            uctrlFilterBy1.OnFilterSucceded += GettingPersonIDWhenFilterSucceded;
            //fill Classes combobox
            if (ClassesIndex.Count != 0)
            {
                foreach (var Class in ClassesIndex)
                {
                    cbLicenseClasses.Items.Add(Class.Key);
                }

                //set cb to zero index
                cbLicenseClasses.SelectedIndex = 0;
            }

            if (LDLAppID == -1)
            {
                _ctrlMode = ctrlMode.Add;
            }
            else
            {
                _ctrlMode = ctrlMode.Update;
                FillInformationsForEdit(LDLAppID);                
            }
        }

        private void FillInformationsForEdit(int LDLAppID)
        {
            DataRow row = clsLocalDLA.getLocalDLA_ByLDLAppID(LDLAppID).Rows[0];

            lblDLApplicationID2.Text = row["L.D.L.AppID"].ToString();
            if (DateTime.TryParse(row["Application Date"].ToString(), out DateTime date))
            {
                lblApplicationDate2.Text = date.ToShortDateString();
            }
            ClassesIndex.TryGetValue(row["Driving Class"].ToString(), out int ClassIndex);
            cbLicenseClasses.SelectedIndex = ClassIndex - 1;//Because Combobox index start from Zero so Class 1 would be 1-1 = 0 :)
            UpdateTotalFees();
            lblCreatedBy2.Text = clsLog.User.UserName;

            uctrPersonDetails1.UpdateControl();
        }
        private void UpdateTotalFees()
        {
            
            if (ClassesFees.TryGetValue(cbLicenseClasses.SelectedIndex + 1, out decimal ClassFee))
            {
                lblApplicationFees2.Text = (clsApplicationType.GetApplicationType(1).Fees + ClassFee).ToString("0.00");
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GettingPersonIDWhenFilterSucceded(int PersonID)
        {
            uctrPersonDetails1.PersonID = PersonID;
            uctrPersonDetails1.UpdateControl();
        }

        private void cbLicenseClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalFees();
        }

        private bool GoingForApplicationTab()
        {
            bool GoingForNextTab = false;
            if (uctrPersonDetails1.PersonID == -1)
            {
                MessageBox.Show("First Find A Person Or Add A Person", "Find/Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GoingForNextTab = true;
            }
            return GoingForNextTab;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(GoingForApplicationTab())
            {
                tabControl1.SelectTab(tabApplication);
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!GoingForApplicationTab())
            {
                e.Cancel = true;
            }
        }
    }
}
