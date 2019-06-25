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
        string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";

        void start()
        {
            try
            {
                MySqlConnection mycon = new MySqlConnection(con);
                mycon.Open();
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter("select * from user", con);
                DataSet myda = new DataSet();
                myDataAdapter.Fill(myda, "user");
                dataTable = myda.Tables["user"];
            }
            catch (MySqlException)
            {
            }
        }
        public Login()
        {
            InitializeComponent();
            start();
        }
        public Login(double width, double heigth)
        {
            InitializeComponent();
            start();
            this.Width = width;
            this.Height = heigth;
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

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register(this.Width, this.Height);
            register.Show();
            this.Close();
        }

        private void TbxUser_GotFocus(object sender, RoutedEventArgs e)
        {
            lab1.Content = "";
        }

        private void Lab1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxUser.Text == "")
            {
                lab1.Content = "请输入账号";
            }
        }

        private void Pwd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pwd.Password == "")
            {
                lab2.Content = "请输入密码";
            }
        }

        private void Pwd_GotFocus(object sender, RoutedEventArgs e)
        {
            lab2.Content = "";
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
