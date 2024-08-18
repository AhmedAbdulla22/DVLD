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
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }

        clsUser()
        {
            UserName = "";
            Password = "";
            isActive = false;
        }

        clsUser(string _UserName, string _Password,bool _isActive)
        {
            UserName = _UserName;
            Password = _Password;
            isActive = _isActive;
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
