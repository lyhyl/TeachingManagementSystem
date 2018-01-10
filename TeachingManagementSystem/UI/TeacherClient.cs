using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachingManagementSystem.BLL;
using TeachingManagementSystem.Model;
using TeachingManagementSystem.UI.TeaFuncUI;

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
            RefreshClassTable();
        }

        private void Customize()
        {
            Text = $"欢迎{teacher.Name}!(工号{teacher.Id})";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (AddClassDialog addClassDialog = new AddClassDialog(teacher))
                addClassDialog.ShowDialog();
            RefreshClassTable();
        }

        private void RefreshClassTable()
        {
            var cls = TeacherManager.GetAssociatedClasses(teacher);
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[] {
                new DataColumn("名称"),
                new DataColumn("类别"),
                new DataColumn("时间"),
                new DataColumn("地点"),
                new DataColumn("人数"),
                new DataColumn("平时成绩比重")
            });
            foreach (var c in cls)
            {
                var r = table.NewRow();
                r.ItemArray = new object[] {
                    c.Name,
                    c.Category,
                    c.Time,
                    c.Place,
                    c.Capability,
                    c.UsualGradeProportion
                };
                table.Rows.Add(r);
            }
            classDataGridView.DataSource = table;
        }
    }
}
