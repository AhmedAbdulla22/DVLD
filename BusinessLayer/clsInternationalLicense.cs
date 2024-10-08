using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsInternationalLicense
    {
        public static DataTable GetInternationalLicenseHistoryByPersonID(int PersonID)
        {
            return clsInternationalLicense_DataAccess.GetInternationalLicenseHistoryByPersonID(PersonID);
        }

        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public enum mode { Add, Update };
        mode enMode;

        public clsInternationalLicense()
        {
            InternationalLicenseID = ApplicationID = DriverID = CreatedByUserID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = ExpirationDate = DateTime.Now;            
            IsActive = false;
            enMode = mode.Add;
        }

        public clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive,int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.CreatedByUserID = CreatedByUserID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            enMode = mode.Update;
        }

        private bool _AddNewLicense()
        {
            this.InternationalLicenseID = clsInternationalLicense_DataAccess.AddNewInternationalLicense(ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate,IsActive, CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }
        private bool _Update()
        {
            //Update User
            return clsInternationalLicense_DataAccess.UpdateInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate,  IsActive,  CreatedByUserID);

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
                        if (_AddNewLicense())
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

        public static clsInternationalLicense GetInternationalLicenseByInternationalLicenseID(int InternationalLicenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int CreatedByUserID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;


            if (clsInternationalLicense_DataAccess.GetInternationalLicenseByInternationalLicenseID(InternationalLicenseID, ref ApplicationID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive,  ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate,  IsActive,  CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
        public static clsInternationalLicense GetInternationalLicenseByApplicationID(int ApplicationID)
        {
            int InternationalLicenseID = -1; int DriverID = -1; int CreatedByUserID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;


            if (clsInternationalLicense_DataAccess.GetInternationalLicenseByApplicationID(ApplicationID, ref InternationalLicenseID, ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive,  ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate,  IsActive,  CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static clsInternationalLicense GetInternationalLicenseByLocalDrivingLicenseID(int IssuedUsingLocalLicenseID)
        {
            int InternationalLicenseID = -1; int DriverID = -1; int CreatedByUserID = -1;
            int ApplicationID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;


            if (clsInternationalLicense_DataAccess.GetInternationalLicenseByLDLicenseID(IssuedUsingLocalLicenseID, ref InternationalLicenseID, ref DriverID, ref ApplicationID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }


        public bool isDetained()
        {
            return clsInternationalLicense_DataAccess.isDetained(this.InternationalLicenseID);
        }
        public static bool isDetained(int InternationalLicenseID)
        {
            return clsInternationalLicense_DataAccess.isDetained(InternationalLicenseID);
        }

        public static DataTable getAllInternationalLicense()
        {

            return clsInternationalLicense_DataAccess.getAllInternationalLicense();
        }
    }
}
