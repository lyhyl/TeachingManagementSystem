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
    public class TeacherManager
    {
        public static int Register(
            string password,
            string name,
            string brand,
            SexType sex,
            string phone)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (brand == null)
                throw new ArgumentNullException(nameof(brand));

            using (var conn = SqlHelper.OpenDatabase(
                BLLConfig.AdminUserName,
                BLLConfig.AdminPassword,
                BLLConfig.DefaultSource,
                BLLConfig.DbName))
            {
                var cmd = @"INSERT INTO TeacherAccount (password,name,brand,sex,phone) OUTPUT Inserted.id VALUES (@pw,@n,@b,@s,@p)";
                var result = SqlHelper.ExecuteScalar(conn, cmd, new SqlParameter[] {
                    new SqlParameter("@pw", SqlDbType.NVarChar, 50) { Value = Utilities.EncryptPassword(password) },
                    new SqlParameter("@n", SqlDbType.NVarChar, 50) { Value = name },
                    new SqlParameter("@b", SqlDbType.NVarChar, 50) { Value = brand },
                    new SqlParameter("@s", SqlDbType.Int) { Value = (int)sex },
                    new SqlParameter("@p", SqlDbType.NVarChar, 50) { Value = phone }
                });
                return result != null ? (int)result : -1;
            }
        }

        public static Teacher Login(int id, string password)
        {
            var conn = SqlHelper.OpenDatabase(
                BLLConfig.AdminUserName,
                BLLConfig.AdminPassword,
                BLLConfig.DefaultSource,
                BLLConfig.DbName);

            var cmd = "SELECT name,brand,sex,phone FROM TeacherAccount WHERE id=@u and password=@p";
            var result = SqlHelper.ExecuteDataTable(conn, cmd, new SqlParameter[] {
                    new SqlParameter("@u", SqlDbType.Int) {
                        Value = Utilities.TeaIdConvertToDbId(id)
                    },
                    new SqlParameter("@p", SqlDbType.NVarChar, 50) {
                        Value = Utilities.EncryptPassword(password)
                    }
                });

            if (result.Rows.Count == 1 &&
                result.Rows[0].ItemArray.Length == 4)
            {
                var dat = result.Rows[0].ItemArray;
                return new Teacher(conn, id,
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

        public static bool UpdateClass(Teacher user,
            int clsid,
            string name,
            string category,
            string time,
            string place,
            int capability,
            float usualProportion)
        {
            var cmd = "UPDATE Class SET name=@n,category=@c,time=@t,place=@p,capability=@ca,usualProportion=@u WHERE id=@i";
            var result = SqlHelper.ExecuteNonQuery(user.Connection, cmd, new SqlParameter[] {
                new SqlParameter("@n", SqlDbType.NVarChar, 50) { Value = name },
                new SqlParameter("@c", SqlDbType.NVarChar, 50) { Value = category },
                new SqlParameter("@t", SqlDbType.NVarChar, 50) { Value = time },
                new SqlParameter("@p", SqlDbType.NVarChar, 50) { Value = place },
                new SqlParameter("@ca", SqlDbType.Int) { Value = capability },
                new SqlParameter("@u", SqlDbType.Float) { Value = usualProportion },
                new SqlParameter("@i", SqlDbType.Int) { Value = clsid }
            });
            return result == 1;
        }

        public static bool DeleteClass(Teacher user, int clsid)
        {
            var cmd = "DELETE FROM Class WHERE id=@i";
            var result = SqlHelper.ExecuteNonQuery(user.Connection, cmd, new SqlParameter[] {
                new SqlParameter("@i", SqlDbType.Int) { Value = clsid }
            });
            return result == 1;
        }

        public static bool AddClass(Teacher user,
            string name,
            string category,
            string time,
            string place,
            int capability,
            float usualProportion)
        {
            var cmd = "INSERT INTO Class (name,tid,category,time,place,capability,usualProportion) VALUES (@n,@ti,@c,@t,@p,@ca,@u)";
            var result = SqlHelper.ExecuteNonQuery(user.Connection, cmd, new SqlParameter[] {
                new SqlParameter("@n", SqlDbType.NVarChar, 50) { Value = name },
                new SqlParameter("@ti", SqlDbType.Int) { Value = Utilities.TeaIdConvertToDbId(user.Id) },
                new SqlParameter("@c", SqlDbType.NVarChar, 50) { Value = category },
                new SqlParameter("@t", SqlDbType.NVarChar, 50) { Value = time },
                new SqlParameter("@p", SqlDbType.NVarChar, 50) { Value = place },
                new SqlParameter("@ca", SqlDbType.Int) { Value = capability },
                new SqlParameter("@u", SqlDbType.Float) { Value = usualProportion }
            });
            return result == 1;
        }

        public static IEnumerable<Class> GetAssociatedClasses(Teacher user)
        {
            var cmd = "SELECT id,name,category,time,place,capability,usualProportion FROM Class WHERE tid=@i";
            var result = SqlHelper.ExecuteDataTable(user.Connection, cmd, new SqlParameter[] {
                new SqlParameter("@i", SqlDbType.Int) { Value = Utilities.TeaIdConvertToDbId(user.Id) }
            });
            if (result == null)
                return Enumerable.Empty<Class>();
            return result.Rows.Cast<DataRow>().Select(row => new Class()
            {
                Id = (int)row.ItemArray[0],
                Name = row.ItemArray[1] as string,
                TeacherId = user.Id,
                Category = row.ItemArray[2] as string,
                Time = row.ItemArray[3] as string,
                Place = row.ItemArray[4] as string,
                Capability = (int)row.ItemArray[5],
                UsualGradeProportion = Convert.ToSingle(row.ItemArray[6])
            });
        }
    }
}
