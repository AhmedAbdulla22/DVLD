using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLocalDLA
    {
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID {  get; set; }
        public enum mode { Add, Update };
        mode enMode;

        public clsLocalDLA()
        {
            this.LocalDrivingLicenseApplicationID = this.ApplicationID = this.LicenseClassID = -1;
            enMode = mode.Add;
        }

        public clsLocalDLA(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            enMode = mode.Update;
        }
        public static clsLocalDLA GetLocalDLAppByLocalDLAppID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1, LicenseClassID = -1;


            if (clsLocalDLA_DataAccess.GetApplicationByLDLAppID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID))
            {
                return new clsLocalDLA(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID);
            }
            else
            {
                return null;
            }
        }
        public bool Delete()
        {
            return clsLocalDLA_DataAccess.DeleteLDLApp(this.LocalDrivingLicenseApplicationID);
        }
        public int passedTest(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDLA_DataAccess.getPassedTests(LocalDrivingLicenseApplicationID);
        }

        public int passedTest()
        {
            return clsLocalDLA_DataAccess.getPassedTests(this.LocalDrivingLicenseApplicationID);
        }
        public static bool Delete(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDLA_DataAccess.DeleteLDLApp(LocalDrivingLicenseApplicationID);
        }

        private bool _AddNewLocalDLA()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDLA_DataAccess.AddNewLDLApp(this.ApplicationID,this.LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);
        }
        private bool _Update()
        {
            //Update User
            return clsLocalDLA_DataAccess.UpdateLDLApp(this.LocalDrivingLicenseApplicationID,this.ApplicationID,this.LicenseClassID);

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
                        if (_AddNewLocalDLA())
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

        public static DataTable getAllLocalDLA()
        {

            return clsLocalDLA_DataAccess.getAllLocalDLA();
        }

        public static DataTable getLocalDLA_ByStatus(byte ApplicationStatus)
        {
            return clsLocalDLA_DataAccess.GetLDLA_ByStatus(ApplicationStatus);
        }

        public static DataTable getLocalDLA_ByLDLAppID(int LDLAppID)
        {
            return clsLocalDLA_DataAccess.GetLDLA_ByLDLAppID(LDLAppID);
        }
        public static DataTable getLocalDLA_ByNationalNo(string NationalNo)
        {
            return clsLocalDLA_DataAccess.GetLDLA_ByNationalNo(NationalNo);
        }
        public static DataTable getLocalDLA_ByFullName(string FullName)
        {
            return clsLocalDLA_DataAccess.GetLDLA_ByFullName(FullName);
        }

        public string ClassName()
        {
            return clsLocalDLA_DataAccess.getClassName(this.LicenseClassID);
        }
    }
}
