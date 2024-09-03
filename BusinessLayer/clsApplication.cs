using DataAccessLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsApplication
    {
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public enum mode { Add, Update };
        mode enMode;
        public enum Status: byte { New = 1, Canceled =2 , Compledted = 3 };
        Status enStatus;


        public clsApplication()
        {
            this.ApplicantPersonID = this.ApplicationID = this.CreatedByUserID = this.ApplicationTypeID = -1;
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.ApplicationStatus = 0; //new
            this.PaidFees = 0;
            this.enMode = mode.Add;
        }

        public clsApplication(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserID)
        {
            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicationDate = applicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.enMode = mode.Update;
        }
        public bool Delete()
        {
            return clsApplicationDataAccess.DeleteApplication(this.ApplicationID);
        }

        public static bool Delete(int ApplicationID)
        {
            return clsApplicationDataAccess.DeleteApplication(ApplicationID);
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationDataAccess.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, ApplicationTypeID, ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID);

            return (this.ApplicationID != -1);
        }
        private bool _Update()
        {
            //Update User
            return clsApplicationDataAccess.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

        }
        public bool Save()
        {
            switch (enMode)
            {
                case mode.Update:
                    {
                        return _Update();

                    }
                case mode.Add:
                    {
                        if (_AddNewApplication())
                        {
                            enMode = mode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
            }
            return false;
        }

        public bool SetToCancel()
        {
            return _SetStatus((byte)clsApplication.Status.Canceled);
        }

        public bool SetToComplete()
        {
            return _SetStatus((byte)clsApplication.Status.Compledted);
        }

        private bool _SetStatus(byte Status = 1)
        {
            //1 for NEW
            //2 For Cancel
            //3 For Completed
            return clsApplicationDataAccess.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, Status, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public static clsApplication GetApplicationByApplicantPersonID(int ApplicantPersonID)
        {
            int ApplicationID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            decimal PaidFees = 0;
            byte ApplicationStatus = 1;
            DateTime LastStatusDate = DateTime.Now, ApplicationDate = DateTime.Now;


            if (clsApplicationDataAccess.GetApplicationByPersonID(ApplicantPersonID, ref  ApplicationID, ref ApplicationDate, ref  ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref  CreatedByUserID))
            {
                return new clsApplication(ApplicationID,ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
        public static clsApplication GetApplicationByPersonIDWithSpecificClass(int ApplicantPersonID,int ApplicationTypeID, int LicenseClassID)//NewApplications!
        {
            int ApplicationID = -1, CreatedByUserID = -1;
            decimal PaidFees = 0;
            byte ApplicationStatus = 1;
            DateTime LastStatusDate = DateTime.Now, ApplicationDate = DateTime.Now;

            
            if (clsApplicationDataAccess.GetApplicationByPersonIDWithSpecificClass(ApplicantPersonID,LicenseClassID, ref ApplicationID, ref ApplicationDate, ApplicationTypeID,ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
        public static clsApplication GetApplicationByApplicationID(int ApplicationID)
        {
            int ApplicantPersonID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            decimal PaidFees = 0;
            byte ApplicationStatus = 1;
            DateTime LastStatusDate = DateTime.Now, ApplicationDate = DateTime.Now;


            if (clsApplicationDataAccess.GetApplicationByApplicationID(ApplicationID,ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


    }
}
