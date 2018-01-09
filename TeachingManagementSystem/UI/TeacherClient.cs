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
    public partial class TeacherClient : Form
    {
        private Teacher teacher;

        public TeacherClient(Teacher user)
        {
            teacher = user ?? throw new ArgumentNullException(nameof(user));

            InitializeComponent();

            Customize();
        }

        private void Customize()
        {
            Text = $"欢迎{teacher.Name}!(工号{teacher.Id})";
        }
    }
}
