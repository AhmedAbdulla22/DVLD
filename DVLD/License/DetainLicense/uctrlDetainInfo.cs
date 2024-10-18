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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD.License.DetainLicense
{
    public partial class uctrlDetainInfo : UserControl
    {
        private int _LicenseID = -1;
        private int _DetainID = -1;
        clsLicense license = null;

        public int DetainID { get { return _DetainID; } set { _DetainID = value; } }
        public int LicenseID { get { return _LicenseID; } set { _LicenseID = value; _LoadIApplicationData(); } }
        public decimal FineFees { get { return GetFineFees(); } }
        public uctrlDetainInfo()
        {
            InitializeComponent();
        }

        private void tbFineFees_KeyDown(object sender, KeyEventArgs e)
        {
            //if shift pressed handle it
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if ((char.IsDigit((char)e.KeyCode) || e.KeyCode == Keys.Back || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right))
            {
                e.Handled = false;
                e.SuppressKeyPress = false;
            }
            else
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void _LoadIApplicationData()
        {
            if (LicenseID != -1)
            {
                license = clsLicense.GetLicenseByLicenseID(LicenseID);

                if (license == null)
                {
                    MessageBox.Show("Can't Find this License with ID of " + LicenseID + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;

                }



            }
            fillLabels();

        }

        private void fillLabels()
        {
            lblCreatedBy2.Text = clsLog.User?.UserName ?? "[???]";
            lbl_DetainDate2.Text = DateTime.Today.ToShortDateString();
            if (LicenseID != -1)
            {
                clsPerson Person = clsPerson.Find(clsApplication.GetApplicationByApplicationID(license.ApplicationID)?.ApplicantPersonID ?? -1);
                if (Person == null)
                {
                    return;
                }

                lbl_icenseID2.Text = license.LicenseID.ToString();
                lbl_DetainID2.Text = (DetainID == -1) ? @"N\A" : DetainID.ToString();


            }
            else
            {

                lbl_icenseID2.Text = lbl_DetainID2.Text = @"N\A";
            }
        }

        private decimal GetFineFees()
        {
            if(!string.IsNullOrEmpty(tbFineFees.Text) && Decimal.TryParse(tbFineFees.Text, out decimal FineFees))
            {
            return FineFees;
            }
            else
            {
                return 0;
            }
        }

        public void UpdateControl()
        {
            _LoadIApplicationData();
        }
    }
}
