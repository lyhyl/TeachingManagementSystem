using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingManagementSystem.Common;

namespace TeachingManagementSystem.Model
{
    public class User : IDisposable
    {
        public string Id { private set; get; }
        public string Name { private set; get; }
        public string Brand { private set; get; }
        public bool IsStudent { private set; get; }
        public SexType Sex { private set; get; }
        public string Phone { private set; get; }

        protected SqlConnection sqlConnection;

        public User(SqlConnection conn,
            string id,
            string name,
            string brand,
            bool isStudent,
            int sex,
            string phone)
        {
            sqlConnection = conn;
            Id = id;
            Name = name;
            Brand = brand;
            IsStudent = isStudent;
            Sex = (SexType)sex;
            Phone = phone;
        }

        public void Dispose()
        {
            sqlConnection?.Close();
        }
    }
}
