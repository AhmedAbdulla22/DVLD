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

namespace DVLD.License.InternationalDrivingLicense
{
    public partial class uctrlFindLDLicense : UserControl
    {
        public uctrlFindLDLicense()
        {
            InitializeComponent();
        }

        public Action<int> OnFilterSucceded;

        protected virtual void FilterSucceded(int LicenseID)
        {
            Action<int> handler = OnFilterSucceded;

            handler?.Invoke(LicenseID);
        }

        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilter.Text))
            {
                errorProvider1.SetError(tbFilter, "Write LicenseID First!");
                return;
            }
            else
            {
                errorProvider1.SetError(tbFilter, "");
            }

            Find();
        }

        private bool Find()
        {
            bool Founded = false;
            int LicenseID = clsLicense.GetLicenseByLicenseID(Int32.Parse(tbFilter.Text))?.LicenseID ?? -1;

            if (LicenseID != -1)
            {
                FilterSucceded(LicenseID);
                Founded = true;
            }
            else
            {
                    MessageBox.Show("Unable To Find This License", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return Founded;
        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            //if shift pressed handle it
            if((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
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
                e.Handled= true;
                e.SuppressKeyPress= true;
            }
        }

        public void FindLicenseID(int LicenseID)
        {
            if (LicenseID != -1)
            {
                tbFilter.Text = LicenseID.ToString();
            
                if(Find())
                {
                    tbFilter.Enabled = false;
                }

            }

        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
