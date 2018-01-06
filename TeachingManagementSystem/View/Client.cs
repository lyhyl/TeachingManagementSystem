using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachingManagementSystem.View
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 验证信息是否完整
        /// </summary>
        private bool ValidateInfo()
        {
            if (authTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择身份",
                      "错误",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(userTextBox.Text))
            {
                MessageBox.Show("请输入账号",
                      "错误",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("请输入密码",
                      "错误",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInfo())
                return;
            // TODO : login

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            switch (authTypeComboBox.SelectedIndex)
            {
                case 0:
                    StudentRegisterForm.ShowRegisterDialog();
                    break;
                case 1:
                    TeacherRegisterForm.ShowRegisterDialog();
                    break;
                default:
                    MessageBox.Show("请先选择身份",
                        "错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
