using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ApplicationForms
{
    public partial class AddLocalDLA : Form
    {
        clsApplication _App;
        clsLocalDLA _LDLA_App;
        //Get Classees from DB 
        Dictionary<string, int> ClassesIndex = clsClass.GetAllClasses();
        Dictionary<int,decimal> ClassesFees = clsClass.GetAllClassFees();

        enum ctrlMode { Add = 1, Update = 2 };
        ctrlMode _ctrlMode = ctrlMode.Add;

        public AddLocalDLA(int LDLAppID = -1)
        {
            InitializeComponent();

            uctrlFilterBy1.OnFilterSucceded += GettingPersonIDWhenFilterSucceded;
            //fill Classes combobox
            if (ClassesIndex.Count != 0)
            {
                foreach (var Class in ClassesIndex)
                {
                    cbLicenseClasses.Items.Add(Class.Key);
                }

                
            }


            if (LDLAppID == -1)
            {
                _ctrlMode = ctrlMode.Add;
            }
            else
            {
                _ctrlMode = ctrlMode.Update;
                SetFormForUpdateMode();
            }
                FillInformations(LDLAppID);
        }

        private void SetFormForUpdateMode()
        {
            _ctrlMode = ctrlMode.Update;
            uctrlFilterBy1.Enabled = false;
            lblFormLabel.Text = "Update Local Driving License Application";
        }

        private void FillInformations(int LDLAppID = -1)
        {
            
            if (_ctrlMode == ctrlMode.Add)
            {
                //set cb to zero index
                cbLicenseClasses.SelectedIndex = 0;
                lblApplicationDate2.Text = DateTime.Now.ToShortDateString();

            }
            else
            {
                _LDLA_App = clsLocalDLA.GetLocalDLAppByLocalDLAppID(LDLAppID);
                
                if (_LDLA_App != null)
                {
                    _App = clsApplication.GetApplicationByApplicationID(_LDLA_App.ApplicationID);
                }

                DataRow row = clsLocalDLA.getLocalDLA_ByLDLAppID(LDLAppID).Rows[0];
                lblDLApplicationID2.Text = row["L.D.L.AppID"].ToString();
                if (DateTime.TryParse(row["Application Date"].ToString(), out DateTime date))
                {
                    lblApplicationDate2.Text = date.ToShortDateString();
                }
                ClassesIndex.TryGetValue(row["Driving Class"].ToString(), out int ClassIndex);
                cbLicenseClasses.SelectedIndex = ClassIndex - 1;//Because Combobox index start from Zero so Class 1 would be 1-1 = 0 :)

                uctrlFilterBy1.FindPersonByNationalNo(row["NationalNo"].ToString());

            }

            lblCreatedBy2.Text = clsLog.User.UserName;
            lblApplicationFees2.Text = clsApplicationType.GetApplicationType(1).Fees.ToString("0.00");//LDLApplication Fee

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

        private bool DuplicateApplicationExist()
        {
            bool res = false;
            //which is new
            if (clsApplication.GetApplicationByPersonIDWithSpecificClass(uctrPersonDetails1.PersonID,1,cbLicenseClasses.SelectedIndex+1) != null)
            {
                res = true;
            }

            return res;
        }

        private bool GoingForApplicationTab()
        {
            bool GoingForNextTab = false;
            if (uctrPersonDetails1.PersonID == -1)
            {
                MessageBox.Show("First Find A Person Or Add A Person", "Find/Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                GoingForNextTab = true;
            }
            return GoingForNextTab;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(GoingForApplicationTab())
            {
                tabControl1.SelectTab(tabApplication);
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!GoingForApplicationTab())
            {
                e.Cancel = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (uctrPersonDetails1.PersonID != -1)
            {
                if (!(_ctrlMode == ctrlMode.Update && cbLicenseClasses.SelectedIndex+1 == _LDLA_App.LicenseClassID) && DuplicateApplicationExist())
                {
                    MessageBox.Show($"Duplicate Application With Same Class Exist For This Person With ID = {uctrPersonDetails1.PersonID}, Can't Have Same Class Twice!", "This Application Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string ModeStr = (_ctrlMode == ctrlMode.Add)? "Save":"Update";

                if (MessageBox.Show($"Are You Sure You Want To {ModeStr} This Application?", "Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save();
                }
            }
            else
            {
                MessageBox.Show("First Find A Person Or Add A Person", "Find/Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Save()
        {
            if (_ctrlMode == ctrlMode.Add)
            {
                _App = new clsApplication();
                _App.ApplicantPersonID = uctrPersonDetails1.PersonID;
                _App.ApplicationDate = DateTime.Now;
                _App.LastStatusDate = DateTime.Now;
                _App.ApplicationStatus = (byte)clsApplication.Status.New;//new
                _App.CreatedByUserID = clsLog.User.UserID;
                _App.ApplicationTypeID = 1; //LocalDLA Type
                _App.PaidFees = decimal.Parse(lblApplicationFees2.Text);
            }
            else
            {
                _App = new clsApplication(_App.ApplicationID,uctrPersonDetails1.PersonID,DateTime.Now,1, (byte)clsApplication.Status.New, DateTime.Now, decimal.Parse(lblApplicationFees2.Text), _App.CreatedByUserID);//With Update CreatedByUser not Change!
            }


            if (_App.Save())
            {
                string ModeStr;

                if (_ctrlMode == ctrlMode.Add)
                {
                    _LDLA_App = new clsLocalDLA();
                    _LDLA_App.ApplicationID = _App.ApplicationID;
                    _LDLA_App.LicenseClassID = cbLicenseClasses.SelectedIndex + 1;//fixing index
                }
                else
                {
                    _LDLA_App = new clsLocalDLA(_LDLA_App.LocalDrivingLicenseApplicationID, _LDLA_App.ApplicationID, _LDLA_App.LicenseClassID);
                }

                if (_LDLA_App.Save())
                {
                    if (_ctrlMode == ctrlMode.Add)
                    {
                        ModeStr = "Saved";
                        _ctrlMode = ctrlMode.Update;
                        lblDLApplicationID2.Text = _App.ApplicationID.ToString();
                        SetFormForUpdateMode();
                    }
                    else
                    {
                        ModeStr = "Updated";
                    }

                    MessageBox.Show($"Application {ModeStr} Succesfully.", ModeStr, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Local Driving License Application Not Saved.", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Application Not Saved.", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
