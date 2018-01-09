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
using TeachingManagementSystem.Common;

namespace TeachingManagementSystem.UI
{
    public partial class StudentRegisterForm : Form
    {
        private bool registered = false;

        public StudentRegisterForm()
        {
            InitializeComponent();

            FormClosing += StudentRegisterForm_FormClosing;
        }

        /// <summary>
        /// 显示注册窗口
        /// </summary>
        /// <returns>注册情况</returns>
        public static DialogResult ShowRegisterDialog()
        {
            using (var form = new StudentRegisterForm())
                return form.ShowDialog();
        }

        private bool ValidateInfo()
        {
            if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("请填写密码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("请填写姓名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(collegeTextBox.Text))
            {
                MessageBox.Show("请填写学院", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!maleRadioButton.Checked && !femaleRadioButton.Checked)
            {
                MessageBox.Show("请填写性别", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
             

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInfo())
                return;

            int id = Manager.StudentRegister(
                passwordTextBox.Text,
                nameTextBox.Text,
                collegeTextBox.Text,
                maleRadioButton.Checked ? SexType.Male : SexType.Female,
                phoneTextBox.Text);

            MessageBox.Show($"请牢记学号: {id}", "注册成功!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            registered = true;
            Close();
        }

        private void StudentRegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!registered &&
                MessageBox.Show("确定?", "取消注册",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
