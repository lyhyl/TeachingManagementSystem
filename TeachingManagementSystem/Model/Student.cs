using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingManagementSystem.Common;

namespace TeachingManagementSystem.Model
{
    public class Student : User
    {
        public string College { private set; get; }

        public Student(SqlConnection conn,
            int id,
            string name,
            string college,
            SexType sex,
            string phone) : base(conn, id, name, sex, phone)
        {
            College = college;
        }
    }
}
