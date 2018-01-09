using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TeachingManagementSystem.Common;
using TeachingManagementSystem.DAL;
using TeachingManagementSystem.Model;

namespace TeachingManagementSystem.BLL
{
    public class Manager
    {
        public static int Register(
            string password,
            string name,
            string brand,
            bool isStudent,
            SexType sex,
            string phone)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (brand == null)
                throw new ArgumentNullException(nameof(brand));

            var conn = SqlHelper.OpenDatabase(
                BLLConfig.AdminUserName,
                BLLConfig.AdminPassword,
                BLLConfig.DefaultSource);

            string cmd = @"INSERT INTO Account (password,name,brand,isStudent,sex,phone) OUTPUT Inserted.id VALUES (@pw,@n,@b,@i,@s,@p)";
            var result = SqlHelper.ExecuteScalar(conn, cmd, parameters: new SqlParameter[] {
                new SqlParameter("@pw", SqlDbType.NVarChar, 50) { Value = EncryptPassword(password) },
                new SqlParameter("@n", SqlDbType.NVarChar, 50) { Value = name },
                new SqlParameter("@b", SqlDbType.NVarChar, 50) { Value = brand },
                new SqlParameter("@i", SqlDbType.Bit) { Value = isStudent },
                new SqlParameter("@s", SqlDbType.Int) { Value = (int)sex },
                new SqlParameter("@p", SqlDbType.NVarChar, 50) { Value = phone }
            });

            return result != null ? (int)result : -1;
        }

        public static User Login(string id, string password)
        {
            var conn = SqlHelper.OpenDatabase(
                BLLConfig.AdminUserName,
                BLLConfig.AdminPassword,
                BLLConfig.DefaultSource);

            string cmd = "SELECT name,brand,isStudent,sex,phone FROM Account WHERE \"id\"=@u and \"password\"=@p";
            var result = SqlHelper.ExecuteDataTable(
                conn, cmd,
                parameters: new SqlParameter[] {
                    new SqlParameter("@u", SqlDbType.NVarChar, 50) { Value = id },
                    new SqlParameter("@p", SqlDbType.NVarChar, 50) { Value = EncryptPassword(password) }
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

        private static string EncryptPassword(string password)
        {
            MD5CryptoServiceProvider csp = new MD5CryptoServiceProvider();
            var epswb = csp.ComputeHash(Encoding.Unicode.GetBytes(password));
            return BitConverter.ToString(epswb).Replace("-", "");
        }
    }
}
