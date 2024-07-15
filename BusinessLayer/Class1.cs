using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public static class PeopleBusinessLayer
    {
        public static DataTable getAllPeople()
        {

            return DataAccessPeopleLayer.getAllPeople();
        }
    }
}
