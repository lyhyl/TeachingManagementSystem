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
using TeachingManagementSystem.UI.TeacherFunctionalUI;

namespace TeachingManagementSystem.UI
{
    public partial class TeacherClient : Form
    {
        private Teacher teacher;

        public TeacherClient(Teacher user)
        {
            teacher = user ?? throw new ArgumentNullException(nameof(user));

            InitializeComponent();

            Initialize();
            Customize();
            RefreshClassTable();
        }

        private void Initialize()
        {
            var table = new DataTable();
            table.Columns.AddRange(new DataColumn[] {
                new DataColumn("ID"),
                new DataColumn("名称"),
                new DataColumn("类别"),
                new DataColumn("时间"),
                new DataColumn("地点"),
                new DataColumn("人数"),
                new DataColumn("平时成绩比重")
            });
            classDataGridView.DataSource = table;
            classDataGridView.SelectionChanged += ClassDataGridView_SelectionChanged;
        }

        private void ClassDataGridView_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void Customize()
        {
            Text = $"欢迎{teacher.Name}!(工号{teacher.Id})";
            splitContainer1.SplitterDistance = splitContainer1.Width * 3 / 5;
        }

        private void RefreshClassTable()
        {
            var cls = TeacherManager.GetAssociatedClasses(teacher);
            DataTable table = classDataGridView.DataSource as DataTable;
            table.Rows.Clear();
            foreach (var c in cls)
            {
                var r = table.NewRow();
                r.ItemArray = new object[] {
                    c.Id,
                    c.Name,
                    c.Category,
                    c.Time,
                    c.Place,
                    c.Capability,
                    c.UsualGradeProportion
                };
                table.Rows.Add(r);
            }
        }

        private void addClassToolStripButton_Click(object sender, EventArgs e)
        {
            using (ClassDialog classDialog = new ClassDialog(teacher))
                classDialog.ShowDialog();
            RefreshClassTable();
        }

        private void updateClassToolStripButton_Click(object sender, EventArgs e)
        {
            if (classDataGridView.CurrentRow == null)
                return;
            var r = classDataGridView.CurrentRow.Cells;
            using (ClassDialog classDialog = new ClassDialog(teacher,
                Convert.ToInt32(r[0].Value),
                r[1].Value as string,
                r[2].Value as string,
                r[3].Value as string,
                r[4].Value as string,
                Convert.ToInt32(r[5].Value),
                Convert.ToSingle(r[6].Value)))
                classDialog.ShowDialog();
            RefreshClassTable();
        }

        private void deleeteClassToolStripButton_Click(object sender, EventArgs e)
        {
            if (classDataGridView.CurrentRow == null)
                return;
            var r = classDataGridView.CurrentRow.Cells;
            int clsid = Convert.ToInt32(r[0].Value);
            if (MessageBox.Show($"确定删除课程{clsid}?", "确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (TeacherManager.DeleteClass(teacher, clsid))
                {
                    RefreshClassTable();
                }
                else
                {
                    MessageBox.Show("");
                }
            }
        }
    }
}
