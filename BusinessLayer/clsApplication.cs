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
        public double PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public enum mode { Add, Update };
        mode enMode;


        public clsApplication()
        {
            this.ApplicantPersonID = this.ApplicationID = this.CreatedByUserID = this.ApplicationTypeID = -1;
            this.ApplicationDate = this.LastStatusDate = DateTime.Now;
            this.ApplicationStatus = 0; //new
            this.PaidFees = 0;
            this.enMode = mode.Add;
        }

        public clsApplication(int applicationID, int applicantPersonID, DateTime applicationDate, int applicationTypeID, byte applicationStatus, DateTime lastStatusDate, double paidFees, int createdByUserID)
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

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationDataAccess.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, ApplicationTypeID, ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID);

            return (this.ApplicationID != -1);
        }
        private bool _Update()
        {
            //Update User
            return clsApplicationDataAccess.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

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

        public static clsApplication GetApplication(int ApplicantPersonID)
        {
            int ApplicationID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            double PaidFees = 0;
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
    }
}
