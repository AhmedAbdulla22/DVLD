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
    public partial class AddLocalDLA : Form
    {
        //Get Classees from DB 
        Dictionary<string, int> ClassDict = clsClass.GetAllClasses();

        enum ctrlMode { Add = 1, Update = 2 };
        ctrlMode _ctrlMode = ctrlMode.Add;
        private clsApplication _App;

        public AddLocalDLA(int LDLAppID = -1)
        {
            InitializeComponent();

            uctrlFilterBy1.OnFilterSucceded += GettingPersonIDWhenFilterSucceded;
            //fill Classes combobox
            if (ClassDict.Count != 0)
            {
                foreach (var Class in ClassDict)
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
                DataRow row = clsLocalDLA.getLocalDLA_ByLDLAppID(LDLAppID).Rows[0];
                
                lblDLApplicationID2.Text = row["L.D.L.AppID"].ToString();
                lblApplicationDate2.Text = row["Application Date"].ToString();
                ClassDict.TryGetValue(row["Driving Class"].ToString(),out int ClassIndex);
                cbLicenseClasses.SelectedIndex = ClassIndex - 1;//Because Combobox index start from Zero so Class 1 would be 1-1 = 0 :)

                //uctrPersonDetails1.PersonID = row[""];
                uctrPersonDetails1.UpdateControl();

                
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
    }
}
