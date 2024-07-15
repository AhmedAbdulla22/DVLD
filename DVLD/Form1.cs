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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //resize button icons
            btnAccSettings.Image = Utilites.ResizeImage(Properties.Resources.Password_Window,40,40);
            btnUsers.Image = Utilites.ResizeImage(Properties.Resources.Admin_Settings_Male, 40, 40);
            btnApplication.Image = Utilites.ResizeImage(Properties.Resources.Document, 40, 40);
            btnDrivers.Image = Utilites.ResizeImage(Properties.Resources.Driver_License, 40, 40);
            btnPeople.Image = Utilites.ResizeImage(Properties.Resources.People100x, 40, 40);
            //Resize Background
            this.BackgroundImage = Utilites.ResizeImage(Properties.Resources._87f519db_8efe_46d1_8881_9e7d58b3e705, 300, 300);



        }

        private void btnManagePeople_Click(object sender, EventArgs e)
        {
            frmPeople frmPeople = new frmPeople();
            frmPeople.ShowDialog();


        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Still in Work",string.Empty,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //disable active controls like button TabIndex 0
            this.ActiveControl = null;
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Still in Work", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Still in Work", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void btnAccSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Still in Work", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        

    }
}
