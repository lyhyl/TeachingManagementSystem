using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingManagementSystem.Common;

namespace TeachingManagementSystem.Model
{
    public abstract class User : IDisposable
    {
        public string Id { private set; get; }
        public string Name { private set; get; }
        public SexType Sex { private set; get; }
        public string Phone { private set; get; }

        public SqlConnection Connection { private set; get; }

        protected User(SqlConnection conn, string id, string name, SexType sex, string phone)
        {
            Connection = conn;
            Id = id;
            Name = name;
            Sex = sex;
            Phone = phone;
        }

        public void Dispose()
        {
            Connection?.Close();
        }
    }
}
