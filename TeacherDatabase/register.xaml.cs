using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TeacherDatabase
{
    /// <summary>
    /// register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }        //关闭
        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void TbxUser_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxUser.Text == "")
            {
                lab1.Content = "请输入账号";
            }
        }

        private void TbxUser_GotFocus(object sender, RoutedEventArgs e)
        {
            lab1.Content = "";
        }

        private void Pwd1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pwd1.Password == "")
            {
                lab2.Content = "请输入密码";
            }
        }

        private void Pwd1_GotFocus(object sender, RoutedEventArgs e)
        {
            lab2.Content = "";
        }

        private void Pwd2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pwd2.Password == "")
            {
                lab3.Content = "请确认密码";
            }
        }

        private void Pwd2_GotFocus(object sender, RoutedEventArgs e)
        {
            lab3.Content = "";
        }

        private void TbxEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxEmail.Text == "")
            {
                lab4.Content = "请输入邮箱";
            }
        }

        private void TbxEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            lab4.Content = "";
        }
        string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";
        private void Btn_logon_Click(object sender, RoutedEventArgs e)
        {
            if (tbxUser.Text != "" && pwd1.Password != "" && pwd2.Password != "" && tbxEmail.Text != "")
            {
                if (pwd1.Password == pwd2.Password)
                {
                    DataTable table = new DataTable();
                    string sql = "select * from user where id='" + tbxUser.Text + "'";
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(sql, con);
                    DataSet XuanZeData = new DataSet();
                    myDataAdapter.Fill(XuanZeData, "user");
                    table = XuanZeData.Tables["user"];
                    if (table.Rows.Count == 0)
                    {
                        MySqlConnection mycon = new MySqlConnection(con);
                        mycon.Open();
                        string sqlStr = "insert into user (id,password,email)values('" + tbxUser.Text + "','" + pwd1.Password + "','" + tbxEmail.Text + "')";
                        MySqlCommand cmd = new MySqlCommand(sqlStr, mycon);
                        int result = cmd.ExecuteNonQuery();
                        if (result == 1)
                        {
                            MessageBox.Show("注册成功，快去登录吧！");
                        }
                        else
                        {
                            MessageBox.Show("注册失败，未知原因！请及时向开发者反馈");
                        }
                    }
                    else
                    {
                        MessageBox.Show("此账号已被注册！");
                    }
                }
                else
                {
                    MessageBox.Show("两次密码不一致！");
                }
                
            }
            else
            {
                MessageBox.Show("请将信息填写完整！");
            }
        }
    }
}
