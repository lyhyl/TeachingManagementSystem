using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TeachingManagementSystem.Common;
using TeachingManagementSystem.DAL;
using TeachingManagementSystem.Model;

namespace TeachingManagementSystem.BLL
{
    public class StudentManager
    {
        public static int Register(
            string password,
            string name,
            string college,
            SexType sex,
            string phone)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (college == null)
                throw new ArgumentNullException(nameof(college));

            using (var conn = SqlHelper.OpenDatabase(
                BLLConfig.AdminUserName,
                BLLConfig.AdminPassword,
                BLLConfig.DefaultSource,
                BLLConfig.DbName))
            {
                var cmd = @"INSERT INTO StudentAccount (password,name,college,sex,phone) OUTPUT Inserted.id VALUES (@pw,@n,@c,@s,@p)";
                var result = SqlHelper.ExecuteScalar(conn, cmd, new SqlParameter[] {
                    new SqlParameter("@pw", SqlDbType.NVarChar, 50) { Value = Utilities.EncryptPassword(password) },
                    new SqlParameter("@n", SqlDbType.NVarChar, 50) { Value = name },
                    new SqlParameter("@c", SqlDbType.NVarChar, 50) { Value = college },
                    new SqlParameter("@s", SqlDbType.Int) { Value = (int)sex },
                    new SqlParameter("@p", SqlDbType.NVarChar, 50) { Value = phone }
                });
                return result != null ? (int)result : -1;
            }
        }

        public static Student Login(int id, string password)
        {
            var conn = SqlHelper.OpenDatabase(
                BLLConfig.AdminUserName,
                BLLConfig.AdminPassword,
                BLLConfig.DefaultSource,
                BLLConfig.DbName);

            var cmd = "SELECT name,college,sex,phone FROM StudentAccount WHERE id=@u and password=@p";
            var result = SqlHelper.ExecuteDataTable(conn, cmd, new SqlParameter[] {
                    new SqlParameter("@u", SqlDbType.Int) {
                        Value = Utilities.StuIdConvertToDbId(id)
                    },
                    new SqlParameter("@p", SqlDbType.NVarChar, 50) {
                        Value = Utilities.EncryptPassword(password)
                    }
                });

            if (result.Rows.Count == 1 &&
                result.Rows[0].ItemArray.Length == 4)
            {
                var dat = result.Rows[0].ItemArray;
                return new Student(conn, id,
                    dat[0] as string,
                    dat[1] as string,
                    (SexType)(int)dat[2],
                    dat[3] as string);
            }
            else
            {
                conn.Close();
                return null;
            }
        }

        public static IEnumerable<Class> GetAssociatedClasses(Student user)
        {
            return Enumerable.Empty<Class>();
        }
    }
}
