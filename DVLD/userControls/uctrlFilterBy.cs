using BusinessLayer;
using DVLD.PeopleForm;
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
    public partial class uctrlFilterBy : UserControl
    {
        public uctrlFilterBy()
        {
            InitializeComponent();

            cbFilter.SelectedIndex = 0;

        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                tbFilter.Enabled = false;
            }
            else
            {
                tbFilter.Enabled = true;
            }
        }


        public Action<int> OnFilterSucceded;

        protected virtual void FilterSucceded(int PersonID)
        {
            Action<int> handler = OnFilterSucceded;

            handler?.Invoke(PersonID);
        }

        

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            var filterTxt = tbFilter.Text;
            if (string.IsNullOrEmpty(filterTxt))
            {
                FilterSucceded(-1);
                return;
            }

            switch (cbFilter.SelectedItem.ToString())
            {
                case "None":
                    return;
                case "PersonID":
                    {
                        if (int.TryParse(tbFilter.Text, out int value))
                        {
                            clsPerson Person;
                            Person = clsPerson.Find(value);

                            if (Person != null)
                            {
                                FilterSucceded(Person.PersonID);
                            }
                            else
                            {
                                FilterSucceded(-1);
                            }
                        }
                        break;
                    }
                case "National No.":
                    {
                        clsPerson Person;
                        Person = clsPerson.Find(tbFilter.Text);

                        if (Person != null)
                        {
                            FilterSucceded(Person.PersonID);
                        }
                        else
                        {
                            FilterSucceded(-1);
                        }
                        break;
                    }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (frmAddPerson frmAdd = new frmAddPerson())
            {
                frmAdd.ShowDialog();
            }
        }

        //private void tbFilter_TextChanged(object sender, EventArgs e)
        //{
        //    var filterTxt = tbFilter.Text;
        //    if (string.IsNullOrEmpty(filterTxt))
        //    {
        //        return;
        //    }

        //    switch (cbFilter.SelectedItem.ToString())
        //    {
        //        case "PersonID":
        //            {
        //                if (int.TryParse(tbFilter.Text, out int value))
        //                {
        //                    dgvPeople.DataSource = clsPerson.getPeopleByPersonID(value);
        //                }
        //                break;
        //            }
        //        case "National No.":
        //            {
        //                dgvPeople.DataSource = clsPerson.getPeopleByNationalNo(tbFilter.Text);
        //                break;
        //            }
        //    }
        //}
    }
}
