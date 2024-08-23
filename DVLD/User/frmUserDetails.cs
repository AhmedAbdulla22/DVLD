using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.UserForm
{
    public partial class frmUserDetails : Form
    {
        public frmUserDetails(int PersonID = -1)
        {
            InitializeComponent();

            uctrPersonDetails1.PersonID = uctrlLoginInformation1.PersonID = PersonID;
            uctrPersonDetails1.UpdateControl();
            uctrlLoginInformation1.UpdateControl();
        }
    }
}
