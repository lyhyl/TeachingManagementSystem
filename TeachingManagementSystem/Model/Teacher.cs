using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingManagementSystem.Common;

namespace TeachingManagementSystem.Model
{
    public class Teacher : User
    {
        public string Brand { private set; get; }

        public Teacher(SqlConnection conn,
            string id,
            string name,
            string brand,
            SexType sex,
            string phone) : base(conn, id, name, sex, phone)
        {
            Brand = brand;
        }
    }
}
