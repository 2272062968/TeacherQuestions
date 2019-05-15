using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using MySql.Data.MySqlClient;

namespace TeacherDatabase
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Fluent.RibbonWindow
    {

        //
        public static string sqlStr = "select * from question";
        //初始化时跳过选择事件
        int start = 0;
        //连接服务器ip密码和数据表
        string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";
        DataTable datab = new DataTable();
        void StartLoatWindow()
        {
            UserQuestionEntry userQuestionEntry = new UserQuestionEntry();
            questionEntry.Content = userQuestionEntry;
            UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
            questionAdmin.Content = userQuestionAdmin;
        }
        public MainWindow()
        {
            InitializeComponent();
            //Fluent.RibbonWindow.

            StartLoatWindow();
            MySqlConnection mycon = new MySqlConnection(con);                        //创建SQL连接对象
            try
            {
                mycon.Open();
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter("select distinct subject from question", con);
                DataSet myda = new DataSet();
                myDataAdapter.Fill(myda, "question");
                datab = myda.Tables["question"];
                foreach (DataRow row in datab.Rows)
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = row[0].ToString();
                    Ntype.Items.Add(cbi);
                }
            }
            catch (MySqlException)
            {


            }

           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string str = Ntype.SelectedValue.ToString();
            //str = str.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            //MessageBox.Show(str);
            //MessageBox.Show(str.Length.ToString());
        }

        private void Ntype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (start>0)
            {
                string selectSubject = Ntype.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                if (selectSubject != "全部类型")
                {
                    if (selectSubject == "python" || selectSubject == "Python")
                    {
                        sqlStr = "select * from question where subject='python' or subject='Python'";
                        UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                        questionAdmin.Content = userQuestionAdmin;
                    }
                    else if (selectSubject == "java" || selectSubject == "Java")
                    {
                        sqlStr = "select * from question where subject='java' or subject='Java'";
                        UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                        questionAdmin.Content = userQuestionAdmin;
                    }
                    else
                    {
                        sqlStr = "select * from question where subject='" + selectSubject + "'";
                        UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                        questionAdmin.Content = userQuestionAdmin;
                        //MessageBox.Show(sqlStr);
                    }

                }
                else
                {
                    sqlStr = "select * from question";
                    UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                    questionAdmin.Content = userQuestionAdmin;
                }
            }
            start++;
        }




        //判断选择的TabControl
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (this.tabControl.SelectedIndex)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {

                        break;
                    }
                case 2:
                    {
                        break;
                    }
                case 3:
                    {
                        //Fxz.Visibility = Visibility.Collapsed;
                        break;
                    }
                case 4:
                    {
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                default:
                    break;
            }
        }


        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Btn_break(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void Btn_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        bool isMaxWindow = false;
        private void Btn_Max(object sender, RoutedEventArgs e)
        {
            if (isMaxWindow)
            {
                WindowState = WindowState.Normal;
                isMaxWindow = false;
            }
            else
            {
                WindowState = WindowState.Maximized;
                isMaxWindow = true;
            }
        }


    }
}
