using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDetainedLicenses
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }
        public DateTime DetainDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal FineFees { get; set; }
        public bool IsReleased { get; set; }
        public int CreatedByUserID { get; set; }
        public enum mode { Add, Update };
        mode enMode;

        public clsDetainedLicenses()
        {
            DetainID = LicenseID = ReleasedByUserID = ReleaseApplicationID = CreatedByUserID = -1;
            DetainDate = DateTime.Now;
            ReleaseDate = DateTime.MinValue;
            FineFees = 0;
            IsReleased = false;
            enMode = mode.Add;
        }

        public clsDetainedLicenses(int DetainID,int LicenseID, DateTime DetainDate, decimal FineFees, bool IsReleased, int CreatedByUserID , DateTime ReleaseDate, int ReleasedByUserID = -1, int ReleaseApplicationID = -1)
        {
            this.DetainID  = DetainID  ;
            this.LicenseID = LicenseID ;
            this.ReleasedByUserID = ReleasedByUserID ;
            this.ReleaseApplicationID = ReleaseApplicationID ;
            this.CreatedByUserID = CreatedByUserID ;
            this.DetainDate  = DetainDate  ;
            this.ReleaseDate  = ReleaseDate;
            this.FineFees = FineFees ;
            this.IsReleased = IsReleased;
            enMode = mode.Update;
        }

        private bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDetainedLicensesDataAccess.AddNewDetainedLicense(LicenseID,DetainDate, FineFees, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID, CreatedByUserID);

            return (this.DetainID != -1);
        }
        private bool _Update()
        {
            //Update User
            return clsDetainedLicensesDataAccess.UpdateDetainedLicense(DetainID,LicenseID, DetainDate, FineFees, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID, CreatedByUserID);

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
                        if (_AddNewDetainedLicense())
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

        public static clsDetainedLicenses GetDetainedLicenseByLicenseID(int LicenseID)
        {
            int DetainID = -1,CreatedByUserID = -1,  ReleasedByUserID = -1,  ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.MinValue, ReleaseDate = DateTime.MinValue;
            decimal FineFees = 0;
            bool IsReleased = false;

            if (clsDetainedLicensesDataAccess.GetDetainedLicenseByLicenseID(LicenseID,ref DetainID,ref DetainDate,ref FineFees,ref IsReleased,ref ReleaseDate,ref ReleasedByUserID,ref ReleaseApplicationID,ref CreatedByUserID))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, IsReleased, CreatedByUserID, ReleaseDate,ReleasedByUserID,ReleaseApplicationID);
            }
            else
            {
                return null;
            }
        }
        public static clsDetainedLicenses GetDetainedLicenseByDetainedID(int DetainID)
        {
            int LicenseID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;
            DateTime DetainDate = DateTime.MinValue, ReleaseDate = DateTime.MinValue;
            decimal FineFees = 0;
            bool IsReleased = false;

            if (clsDetainedLicensesDataAccess.GetDetainedLicenseByDetainID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID, ref CreatedByUserID))
            {
                return new clsDetainedLicenses(DetainID, LicenseID, DetainDate, FineFees, IsReleased, CreatedByUserID, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            else
            {
                return null;
            }
        }
        public static DataTable getAllDetainedLicense()
        {
            return clsDetainedLicensesDataAccess.getAllDetainedLicense();
        }
        public static DataTable getAllDetainedLicenseByIsReleased(bool IsReleased)
        {
            return clsDetainedLicensesDataAccess.getAllDetainedLicenseByIsReleased(IsReleased);
        }
        public static DataTable getAllDetainedLicenseByFullName(string FullName)
        {
            return clsDetainedLicensesDataAccess.getAllDetainedLicenseByFullName(FullName);
        }
        public static DataTable getAllDetainedLicenseByNationalNo(string NationalNo)
        {
            return clsDetainedLicensesDataAccess.getAllDetainedLicenseByNationalNo(NationalNo);
        }
        public static DataTable getAllDetainedLicenseByLicenseID(int LicenseID)
        {
            return clsDetainedLicensesDataAccess.getAllDetainedLicenseByLicenseID(LicenseID);
        }

    }
}
