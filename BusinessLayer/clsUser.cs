using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUser
    {
        
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string FullName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public bool isActive { get; set; }

        public enum mode { Add, Update };
        mode enMode;

        clsUser()
        {
            UserID = -1;
            PersonID = -1;
            FullName = "";
            UserName = "";
            Password = "";
            isActive = false;
            enMode = mode.Add;
        }

        clsUser(int UserID,int PersonID,string FullName, string UserName, string Password,bool isActive)
        {
            this.UserID = -1;
            this.PersonID = PersonID;
            this.FullName = FullName;
            this.UserName = UserName;
            this.Password = Password;
            this.isActive = isActive;
            enMode = mode.Update;
        }


        public static clsUser GetUser(string UserName,string Password)
        {
            bool isActive = false;

            if(ClsUserDataAccess.GetUserByUserNameAndPassword(UserName, Password,ref isActive))
            {
                return new clsUser(UserName,Password,isActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser GetUser(string UserName)
        {
            bool isActive = false;
            string Password = string.Empty;

            if (ClsUserDataAccess.GetUserByUserName(UserName,ref Password, ref isActive))
            {
                return new clsUser(UserName, Password, isActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser GetUser(int PersonID)
        {
            bool isActive = false;
            string UserName = string.Empty, Password= string.Empty;

            if (ClsUserDataAccess.GetUserByPersonID(PersonID,ref UserName,ref Password, ref isActive))
            {
                return new clsUser(UserName, Password, isActive);
            }
            else
            {
                return null;
            }
        }

        public static DataTable getAllUsers()
        {
            return ClsUserDataAccess.GetAllUsers();
        }
    }
}
