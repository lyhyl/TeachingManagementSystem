using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingManagementSystem.DAL;
using TeachingManagementSystem.Model;

namespace TeachingManagementSystem.BLL
{
    public class Manager
    {
        public static User Login(string id, string password)
        {
            var conn = SqlHelper.OpenDatabase(
                BLLConfig.AdminUserName,
                BLLConfig.AdminPassword,
                BLLConfig.DefaultSource);

            string cmd = "select name,brand,isStudent,sex,phone from Account where \"id\"=@u and \"password\"=@p";
            var result = SqlHelper.ExecuteDataTable(
                conn, cmd,
                parameters: new SqlParameter[] {
                    new SqlParameter("@u", SqlDbType.NVarChar, 50) { Value = id },
                    new SqlParameter("@p", SqlDbType.NVarChar, 50) { Value = password }
                });

            if (result.Rows.Count == 1 &&
                result.Rows[0].ItemArray.Length == 5)
            {
                var dat = result.Rows[0].ItemArray;
                return new User(conn, id,
                    dat[0] as string,
                    dat[1] as string,
                    (bool)dat[2],
                    (int)dat[3],
                    dat[4] as string);
            }
            else
                return null;
        }

        public static IEnumerable<Class> GetAssociatedClasses()
        {

            return Enumerable.Empty<Class>();
        }
    }
}
