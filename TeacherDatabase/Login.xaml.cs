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
using System.Windows.Threading;


namespace TeacherDatabase
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        //统计密码验证失败次数
        int pwdCount = 1;
        bool isSuccess = false;
        DataTable dataTable = new DataTable();
        public Login()
        {
            InitializeComponent();

            string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";
            MySqlConnection mycon = new MySqlConnection(con);
            try
            {
                mycon.Open();
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter("select * from user", con);
                DataSet myda = new DataSet();
                myDataAdapter.Fill(myda, "user");
                dataTable = myda.Tables["user"];
            }
            catch (MySqlException)
            {

            
            }


            //MessageBox.Show(dataTable.Rows[0][0].ToString()+ dataTable.Rows[0][1].ToString());

        }

        //登录
        void LoginIn()
        {
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row[0].ToString() == tbxUser.Text && row[1].ToString() == pwd.Password)
                    {
                        isSuccess = true;
                        GlobalParams.MyAccount = row[0].ToString();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                }
                if (!isSuccess)
                {
                    mess.Content = "登录验证失败，账号或密码错误+" + pwdCount.ToString();
                    pwdCount++;
                }
            }
            else
            {
                MessageBox.Show("网络错误，请尝试连接网络后重新打开软件");
            }
            
        }
        private void Button_Login(object sender, RoutedEventArgs e)
        {
            LoginIn();
        }        
        private void Pwd_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginIn();
            }
        }


        private void Btn_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //设置窗口可以移动
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point pp = e.GetPosition(this);
            if (pp.Y < 50)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            }
        }


    }
}
