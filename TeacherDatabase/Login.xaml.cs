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
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";
            MySqlConnection mycon = new MySqlConnection(con);
            mycon.Open();
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter("select * from user", con);
            DataSet myda = new DataSet();
            myDataAdapter.Fill(myda, "user");
            DataTable dataTable = new DataTable();
            dataTable = myda.Tables["user"];

            //MessageBox.Show(dataTable.Rows[0][0].ToString()+ dataTable.Rows[0][1].ToString());

        }


        private void Button_Login(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void Btn_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }




        //设置窗口可以移动
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
