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

namespace DVLD.userControls
{
    public partial class uctrlLoginInformation : UserControl
    {
        private clsUser _User = new clsUser();
        public int PersonID = -1;

        public uctrlLoginInformation()
        {
            InitializeComponent();
        }

        public void UpdateControl()
        {
            if (PersonID != -1)
            {
            _User = clsUser.GetUser(PersonID);
            }

            if (_User != null)
            {
                lblUserID2.Text = _User.UserID.ToString();
                lblUserName2.Text = _User.UserName.ToString();
                lblisActive2.Text = (_User.isActive) ? "Yes" : "No";
            }
        }
    }
}
