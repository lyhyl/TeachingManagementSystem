using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingManagementSystem.DAL;
using TeachingManagementSystem.Model;

namespace TeachingManagementSystem.BLL
{
    public class Manager
    {
        public static Student StudentLogin(string name, string password)
        {
            //var conn = SqlHelper.OpenDatabase(
            //    BLLConfig.AdminUserName,
            //    BLLConfig.AdminPassword,
            //    BLLConfig.DefaultSource);

            // TODO : do some validation
            // e.g. :
            // var result = SqlHelper.ExecuteScalar(conn, "select ...")
            // if(valid) {
            //     return new Student(conn);
            // }

            // validate failed
            return new Student(null) { Name = "abc", Id = "123" }; // Just for test! **DO NOT** release!
        }

        public static Teacher TeacherLogin(string name, string password)
        {
            var conn = SqlHelper.OpenDatabase(
                BLLConfig.AdminUserName,
                BLLConfig.AdminPassword,
                BLLConfig.DefaultSource);

            // TODO : do some validation
            // e.g. :
            // var result = SqlHelper.ExecuteScalar(conn, "select ...")
            // if(valid) {
            //     return new Teacher(conn);
            // }

            // validate failed
            return null;
        }
    }
}
