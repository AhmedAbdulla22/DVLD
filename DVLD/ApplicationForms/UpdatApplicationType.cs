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

namespace DVLD
{
    public partial class UpdatApplicationType : Form
    {
        clsApplicationType _App;
        public UpdatApplicationType(int iD = -1)
        {
            InitializeComponent();

            if (iD != -1)
            {
                _App = clsApplicationType.GetApplicationType(iD);
                
                lblID2.Text = iD.ToString();
                tbTitle.Text = _App.Title;
                tbFees.Text = _App.Fees.ToString("0.0000");


            }
        }

        private void tbFees_KeyDown(object sender, KeyEventArgs e)
        {
            if (char.IsDigit((char)e.KeyValue) || e.KeyCode == Keys.Back || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.SuppressKeyPress = false;
                e.Handled = false;
            }
            else
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty(tb.Text))
            {
                errorProvider1.SetError(tb, "Required!");
            }
            else
            {
                errorProvider1.SetError(tb, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Control[] controls = { tbTitle, tbFees};



            foreach (Control control in controls)
            {
                if (string.IsNullOrEmpty(control.Text))
                {

                    MessageBox.Show("There is Boxes You Need To Fill Before!", "Fill Boxes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            Update();

        }

        private new void Update()
        {
            if (_App != null)
            {
                //Update Information of the object
                _App.Title = tbTitle.Text;
                _App.Fees = Convert.ToDecimal(tbFees.Text);

                if (_App.Update())
                    {
                        MessageBox.Show("Application Type Successfuly Updated", "Application Type Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Application Type Can't Be Updated", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }
    }
}
