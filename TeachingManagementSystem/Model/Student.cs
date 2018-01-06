using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingManagementSystem.Common;

namespace TeachingManagementSystem.Model
{
    public class Student
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public SexType Sex { set; get; }
        public string College { set; get; }
        public string Phone { set; get; }
    }
}
