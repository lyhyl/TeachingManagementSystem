﻿using System;
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

namespace TeachingManagementSystem.UI
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
            else if (!int.TryParse(userTextBox.Text, out int id))
            {
                MessageBox.Show("请输入合法账号",
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

        /// <summary>
        /// 尝试登录
        /// </summary>
        /// <returns>若成功登陆则返回一个对应的User，否则返回null</returns>
        private User Login()
        {
            int id = int.Parse(userTextBox.Text);
            string pass = passwordTextBox.Text;

            switch (authTypeComboBox.SelectedIndex)
            {
                case 0:
                    return StudentManager.Login(id, pass);
                case 1:
                    return TeacherManager.Login(id, pass);
                default:
                    return null;
            }
        }

        /// <summary>
        /// 创建对应的窗口
        /// </summary>
        /// <param name="user">用户</param>
        private void CreateForm(User user)
        {
            Form form = null;
            switch (authTypeComboBox.SelectedIndex)
            {
                case 0:
                    form = new StudentClient(user as Student);
                    break;
                case 1:
                    form = new TeacherClient(user as Teacher);
                    break;
            }
            // Client closed
            form.FormClosed += (s, ea) => Close();

            Hide();
            form.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInfo())
                return;

            User user = Login();
            if (user == null)
            {
                MessageBox.Show(
                    "账号密码不匹配",
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                CreateForm(user);
            }
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
