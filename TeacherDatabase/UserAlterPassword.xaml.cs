using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeacherDatabase
{
    /// <summary>
    /// UserAlterPassword.xaml 的交互逻辑
    /// </summary>
    public partial class UserAlterPassword : UserControl
    {
        public UserAlterPassword()
        {
            InitializeComponent();
        }

        string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";


        private void Register_Password_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection(con);
            mycon.Open();
            string sql = "update user set password='" + pwd.Text + "' where id='" + GlobalParams.MyAccount + "'";
            MySqlCommand cmd = new MySqlCommand(sql, mycon);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("密码已成功修改为：" + pwd.Text);
            }
        }

        private void Register_Email_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection mycon = new MySqlConnection(con);
            mycon.Open();
            string sql = "update user set email='" + email.Text + "' where id='" + GlobalParams.MyAccount + "'";
            MySqlCommand cmd = new MySqlCommand(sql, mycon);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("邮箱已成功修改为：" + email.Text);
            }
        }
    }
}
