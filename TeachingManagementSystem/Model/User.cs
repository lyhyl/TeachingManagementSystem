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
        public string Id { set; get; }
        public string Name { set; get; }
        public SexType Sex { set; get; }

        protected SqlConnection sqlConnection;

        public User(SqlConnection connection)
        {
            sqlConnection = connection;
        }

        public void Dispose()
        {
            sqlConnection?.Close();
        }
    }
}
