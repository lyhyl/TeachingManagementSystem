using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachingManagementSystem.Model;

namespace TeachingManagementSystem.UI
{
    public partial class StudentClient : Form
    {
        private Student student;

        public StudentClient(Student user)
        {
            student = user ?? throw new ArgumentNullException(nameof(user));

            InitializeComponent();

            Customize();
        }

        private void Customize()
        {
            Text = $"欢迎{student.Name}!(学号{student.Id})";
        }
    }
}
