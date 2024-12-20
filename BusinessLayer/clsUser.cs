﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUser
    {
        
        public int UserID { get; set; }
        public int PersonID { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public bool isActive { get; set; }

        public enum mode { Add, Update };
        mode enMode;

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            isActive = false;
            enMode = mode.Add;
        }

        public clsUser(int UserID,int PersonID, string UserName, string Password,bool isActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.isActive = isActive;
            enMode = mode.Update;
        }

        public bool Delete()
        {
            return ClsUserDataAccess.DeleteUser(this.PersonID);
        }

        public static bool Delete(int UserID)
        {
            return ClsUserDataAccess.DeleteUser(UserID);
        }

        private bool _AddNewUser()
        {
            this.UserID = ClsUserDataAccess.AddNewUser(PersonID,UserName,Password,isActive);

            return (this.UserID != -1);
        }
        private bool _Update()
        {
            //Update User
            return ClsUserDataAccess.UpdateUser(this.UserID,this.PersonID,this.UserName,this.Password,this.isActive);

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
                        if (_AddNewUser())
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
        public static clsUser GetUser(string UserName,string Password)
        {
            bool isActive = false;
            int UserID = -1,PersonID = -1;

            if(ClsUserDataAccess.GetUserByUserNameAndPassword(UserName, Password,ref UserID,ref PersonID,ref isActive))
            {
                return new clsUser(UserID,PersonID,UserName, Password, isActive);
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
            int UserID = -1, PersonID = -1;


            if (ClsUserDataAccess.GetUserByUserName(UserName,ref UserID,ref PersonID,ref Password, ref isActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
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
            int UserID = -1;


            if (ClsUserDataAccess.GetUserByPersonID(PersonID,ref UserID,ref UserName,ref Password, ref isActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
            }
            else
            {
                return null;
            }
        }
        public static clsUser Find(int UserID)
        {
            bool isActive = false;
            string UserName = string.Empty, Password = string.Empty;
            int PersonID = -1;


            if (ClsUserDataAccess.GetUserByUserID(UserID, ref UserName, ref Password, ref PersonID, ref isActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, isActive);
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

        public static DataTable getUsersByPersonID(int PersonID)
        {
            return ClsUserDataAccess.GetUsersByPersonID(PersonID);
        }

        public static DataTable getUsersByUserID(int UserID)
        {
            return ClsUserDataAccess.GetUsersByUserID(UserID);
        }

        public static DataTable getUsersByFullName(string FullName)
        {
            return ClsUserDataAccess.GetUsersByFullName(FullName);
        }

        public static DataTable getUsersByUserName(string UserName)
        {
            return ClsUserDataAccess.GetUsersByUserName(UserName);
        }

        public static DataTable getUsersByIsActive(bool IsActive)
        {
            return ClsUserDataAccess.GetUsersByIsActive(IsActive);
        }
        public static int TotalUserNum(bool OnlyActive = false)
        {
            return ClsUserDataAccess.TotalUserNumber(OnlyActive);
        }
    }
}
