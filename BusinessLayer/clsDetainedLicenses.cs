﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
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
    }
}
