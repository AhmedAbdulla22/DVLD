using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessLayer.clsApplicationType;

namespace BusinessLayer
{
    public class clsLicense
    {
      public int LicenseID { get; set; }
      public int ApplicationID {get;set;}
      public int DriverID {get;set;}
      public int LicenseClass {get;set;}
      public DateTime IssueDate {get;set;}
      public DateTime ExpirationDate {get;set;}
      public string Notes {get;set;}
      public decimal PaidFees {get;set;}
      public bool IsActive {get;set;}
      public byte IssueReason {get;set;}
      public int CreatedByUserID {get;set;}
        public enum mode { Add, Update };
        mode enMode;

        public clsLicense()
        {
            LicenseID = ApplicationID = DriverID = CreatedByUserID = -1;
            LicenseClass = -1;
            IssueReason = 0;
            IssueDate = ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            PaidFees = 0;
            IsActive = false;
            enMode = mode.Add;
        }

        public clsLicense(int LicenseID,int ApplicationID,int DriverID,int LicenseClass,DateTime IssueDate,DateTime ExpirationDate,string Notes,decimal PaidFees,bool IsActive,byte IssueReason,int CreatedByUserID)
        {
            this.LicenseID = LicenseID; 
            this.ApplicationID = ApplicationID; 
            this.DriverID = DriverID; 
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClass = LicenseClass;
            this.IssueReason = IssueReason;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            enMode = mode.Update;
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicense_DataAccess.AddNewLicense(ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserID);

            return (this.LicenseID != -1);
        }
        private bool _Update()
        {
            //Update User
            return clsLicense_DataAccess.UpdateLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);

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

        public static clsLicense GetApplicationByLicenseID(int LicenseID)
        {
            int ApplicationID =-1;int DriverID =-1;int CreatedByUserID =-1;
            int LicenseClass = -1;
            byte IssueReason = 0;
            DateTime IssueDate = DateTime.Now; 
            DateTime ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = false;


            if (clsLicense_DataAccess.GetLicenseByLicenseID(LicenseID, ref ApplicationID,ref DriverID,ref LicenseClass,ref  IssueDate,ref  ExpirationDate,ref  Notes,ref  PaidFees,ref IsActive,ref IssueReason,ref  CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
    }

}
