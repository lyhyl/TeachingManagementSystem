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

namespace TeachingManagementSystem.UI.TeaFuncUI
{
    public partial class AddClassDialog : ExitConfirmForm
    {
        private Teacher teacher;

        public AddClassDialog(Teacher user)
        {
            InitializeComponent();

            teacher = user;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (Manager.AddClass(teacher,
                nameTextBox.Text,
                categoryTextBox.Text,
                timeTextBox.Text,
                placeTextBox.Text,
                (int)capabilityNumericUpDown.Value,
                (float)usualProNumericUpDown.Value))
            {
                MessageBox.Show(
                    "",
                    "注册成功!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                NeedConfirmOnExit = false;
                Close();
            }
            else
            {
                MessageBox.Show("注册失败,请联系系统管理员", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
