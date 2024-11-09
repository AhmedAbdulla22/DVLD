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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadStatistics();

            //Load USer Infos
            uctrlLoginInformation1.PersonID = uctrPersonDetails1.PersonID = clsLog.User.PersonID;
            uctrlLoginInformation1.UpdateControl();
            uctrPersonDetails1.UpdateControl();

            
        }

        private void LoadStatistics()
        {
            int TempTotal = 0;
            int TempTotal2 = 0;
            //People
            TempTotal = clsPerson.TotalPeopleNum();
            lblPeopleTotal.Text = TempTotal.ToString();
            TempTotal2 =  clsPerson.TotalPeopleNum(true);
            lblPeopleMales.Text = TempTotal2.ToString();
            lblPeopleFemales.Text = (TempTotal - TempTotal2).ToString();

            //Drivers
            TempTotal = clsDriver.TotalDriverNum();
            lblDriversTotal.Text = TempTotal.ToString();
            TempTotal2 = clsDriver.TotalDriverNum(true);
            lblDriverMales.Text = TempTotal2.ToString();
            lblDriversFemales.Text = (TempTotal - TempTotal2).ToString();

            //Users
            TempTotal = clsUser.TotalUserNum();
            lblUsersTotal.Text = TempTotal.ToString();
            TempTotal2 = clsUser.TotalUserNum(true);
            lblUsersActive.Text = TempTotal2.ToString();
            lblUsersInActive.Text = (TempTotal - TempTotal2).ToString();


            //License
            TempTotal = (clsLicense.TotalI_LicenseNum() + clsInternationalLicense.TotalLicenseNum());
            lblLicensesTotal.Text = TempTotal.ToString();
            TempTotal2 = clsLicense.TotalI_LicenseNum(true) + clsInternationalLicense.TotalLicenseNum(true);
            lblLicensesActive.Text = TempTotal2.ToString();
            lblLicensesInActive.Text = (TempTotal - TempTotal2).ToString();




        }
    }
}
