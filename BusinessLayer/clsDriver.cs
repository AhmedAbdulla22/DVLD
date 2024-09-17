using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDriver
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }
        //public enum mode { Add, Update };
        //mode enMode;

        public clsDriver()
        {
            DriverID = PersonID = DriverID = CreatedByUserID = -1;
        }

        public clsDriver(int DriverID, int PersonID,  DateTime CreatedDate, int CreatedByUserID)
        {
            this.PersonID = PersonID;
            this.DriverID = DriverID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
        }

        private bool _AddNewDriver()
        {
            this.DriverID = clsDriver_DataAccess.AddNewDriver(PersonID, CreatedDate, CreatedByUserID);

            return (this.DriverID != -1);
        }

        public bool Save()
        {
            return _AddNewDriver();
        }

        public static clsDriver GetDriverByDriverID(int DriverID)
        {
            int PersonID = -1; int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;


            if (clsDriver_DataAccess.GeDriverByDriverID(DriverID, ref PersonID,  ref CreatedDate,ref CreatedByUserID))
            {
                return new clsDriver(DriverID, PersonID, CreatedDate,CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static clsDriver GetDriverByPersonID(int PersonID)
        {
            int DriverID = -1; int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;


            if (clsDriver_DataAccess.GeDriverByPersonID(PersonID, ref DriverID, ref CreatedDate, ref CreatedByUserID))
            {
                return new clsDriver(DriverID, PersonID, CreatedDate, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
    }
}
