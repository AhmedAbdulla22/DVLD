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
        //private clsLocalDLA ;

        public AddLocalDLA()
        {
            InitializeComponent();

            uctrlFilterBy1.OnFilterSucceded += GettingPersonIDWhenFilterSucceded;


            //fill Classes combobox
            if (ClassDict.Count != 0)
            {
                foreach(var Class in ClassDict)
                {
                    cbLicenseClasses.Items.Add(Class.Key);
                }

                //set cb to zero index
                cbLicenseClasses.SelectedIndex = 0;
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
