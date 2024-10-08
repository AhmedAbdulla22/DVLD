using BusinessLayer;
using DVLD.Properties;
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
    public partial class uctrl_IApplicationInfo : UserControl
    {
        private int _LDLicenseID = -1;
        private int _IApplicationID = -1;
        private int _ILicenseID = -1;
        clsLicense license = null;

        public int IApplicationID { get {return _IApplicationID; } set {_IApplicationID = value; } }
        public int ILicenseID { get { return _ILicenseID; } set {_ILicenseID = value; } }
        public int LDLicenseID        {
            get { return _LDLicenseID; }
            set { _LDLicenseID = value; _LoadIApplicationData(); }
        }
        public uctrl_IApplicationInfo()
        {
            InitializeComponent();
        }

        private void _LoadIApplicationData()
        {
            if (LDLicenseID != -1)
            {
                license = clsLicense.GetLicenseByLicenseID(LDLicenseID);

                if (license == null)
                {
                    MessageBox.Show("Can't Find this License with ID of " + LDLicenseID + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;

                }



            }
            fillLabels();

        }

        private void fillLabels()
        {
            lblCreatedBy2.Text = clsLog.User?.UserName ?? "[???]";
            lbl_Fees2.Text = clsApplicationType.GetApplicationType(6)?.Fees.ToString() ?? "[???]";//6 for international AppType in appTypes
            lbl_IssueDate2.Text = lbl_ApplicationDate2.Text = DateTime.Today.ToShortDateString();
            lbl_ExpDate2.Text = DateTime.Today.AddYears((int)clsClass.GetClassByClassID(3).DefaultValidityLength).ToShortDateString();//3 is Ordinary License Class

            if (LDLicenseID != -1)
            {
                clsPerson Person = clsPerson.Find(clsApplication.GetApplicationByApplicationID(license.ApplicationID)?.ApplicantPersonID ?? -1);
                if (Person == null)
                {
                    return;
                }
                
                lbl_LocalLicenseID2.Text = license.LicenseID.ToString();
                lbl_ILApplicationID2.Text =  (IApplicationID == -1)? @"N\A": IApplicationID.ToString();
                lbl_ILLicenseID2.Text = (ILicenseID == -1)? @"N\A":ILicenseID.ToString();
                

            }
            else
            {

                lbl_ILApplicationID2.Text = lbl_LocalLicenseID2.Text = lbl_ILLicenseID2.Text = @"N\A";
            }
        }
        public void UpdateControl()
        {
            _LoadIApplicationData();
        }
    }
}
