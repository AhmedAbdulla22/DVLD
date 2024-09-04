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

namespace DVLD.TestType
{
    public partial class UpdateTestType : Form
    {
        clsTestType _Test;
        public UpdateTestType(int iD = -1)
            {
                InitializeComponent();

                if (iD != -1)
                {
                _Test = clsTestType.GetTestType(iD);

                    lblID2.Text = iD.ToString();
                    tbTitle.Text = _Test.Title;
                    tbDescription.Text = _Test.Description;
                    tbFees.Text = _Test.Fees.ToString("0.0000");


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
            Control[] controls = { tbTitle, tbFees,tbDescription };



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
            if (_Test != null)
            {
                //Update Information of the object
                _Test.Title = tbTitle.Text;
                _Test.Description = tbDescription.Text;
                _Test.Fees = Convert.ToDecimal(tbFees.Text);

                if (_Test.Update())
                {
                    MessageBox.Show("Test Type Successfuly Updated", "Test Type Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Test Type Can't Be Updated", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
