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

        //public string condition { get; set; }


        //public static int startIndex = 0;
        //public static int IndexNumbers = 25;

        //public static GlobalParams Tj = new GlobalParams();
        //public string condition="true";


        //public static string sqlStr = "select * from question where " + Tj.Condition + " limit " + startIndex + "," + IndexNumbers;

        //public static string sqlStr = "select * from question where " limit " + startIndex.ToString() + "," + IndexNumbers.ToString();
        //初始化时跳过选择事件
        int start = 0;
        //连接服务器ip密码和数据表
        string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";
        DataTable datab = new DataTable();
        
        void StartLoatWindow()
        {
            account.Content = GlobalParams.MyAccount;
            UserQuestionEntry userQuestionEntry = new UserQuestionEntry();
            questionEntry.Content = userQuestionEntry;
            UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
            questionAdmin.Content = userQuestionAdmin;
            UserCreateExam userCreateExam = new UserCreateExam();
            questionExam.Content = userCreateExam;
        }
        public MainWindow()
        {

            InitializeComponent();
            //Fluent.RibbonWindow.
            GlobalParams.SubjectName = "";

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
                    if (row[0].ToString() == "python" || row[0].ToString() == "java")
                    {
                        continue;
                    }
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = row[0].ToString();
                    Ntype.Items.Add(cbi);
  
                    //GlobalParams.SubjectName[x] = (row[0].ToString());
                    GlobalParams.SubjectName += ","+row[0].ToString();
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
                        GlobalParams.ThisPage = 1;
                        GlobalParams.startIndex = 0;
                        //Tj.Condition = null;
                        GlobalParams.Condition = "subject='python' or subject='Python'";
                        //sqlStr = "select * from question where subject='python' or subject='Python' limit 0,25";
                        UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                        questionAdmin.Content = userQuestionAdmin;
                    }
                    else if (selectSubject == "java" || selectSubject == "Java")
                    {
                        GlobalParams.ThisPage = 1;
                        GlobalParams.startIndex = 0;
                        GlobalParams.Condition = "subject='java' or subject='Java'";
                        //sqlStr = "select * from question where subject='java' or subject='Java' limit 0,25";
                        UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                        questionAdmin.Content = userQuestionAdmin;
                    }
                    else if (selectSubject == "C#" || selectSubject == "c#")
                    {
                        GlobalParams.ThisPage = 1;
                        GlobalParams.startIndex = 0;
                        GlobalParams.Condition = "subject='c#' or subject='C#'";
                        //sqlStr = "select * from question where subject='java' or subject='Java' limit 0,25";
                        UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                        questionAdmin.Content = userQuestionAdmin;
                    }
                    else
                    {
                        GlobalParams.ThisPage = 1;
                        GlobalParams.startIndex = 0;
                        GlobalParams.Condition = "subject='" + selectSubject + "'";
                        //sqlStr = "select * from question where subject='" + selectSubject + "' limit 0,25";
                        UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                        questionAdmin.Content = userQuestionAdmin;
                        //MessageBox.Show(sqlStr);
                    }

                }
                else
                {

                    GlobalParams.ThisPage = 1;
                    GlobalParams.startIndex = 0;
                    GlobalParams.Condition = "true";
                    //sqlStr = "select * from question";
                    UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                    questionAdmin.Content = userQuestionAdmin;
                }
            }
            start++;
        }




        int StartClick1 = 0;
        int StartClick2 = 0;
        //判断选择的TabControl
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (this.tabControl.SelectedIndex)
            {
                case 0:
                    {
                        labNtype.Visibility = Visibility.Visible;
                        Ntype.Visibility = Visibility.Visible;
                        break;
                    }
                case 1:
                    {
                        labNtype.Visibility = Visibility.Collapsed;
                        Ntype.Visibility = Visibility.Collapsed;
                        if (StartClick1 == 0)
                        {
                            UserQuestionEntry userQuestionEntry = new UserQuestionEntry();
                            questionEntry.Content = userQuestionEntry;
                        }
                        StartClick1++;
                        break;
                    }
                case 2:
                    {
                        labNtype.Visibility = Visibility.Collapsed;
                        Ntype.Visibility = Visibility.Collapsed;
                        if (StartClick2 == 0)
                        {
                            UserCreateExam userCreateExam = new UserCreateExam();
                            questionExam.Content = userCreateExam;
                        }
                        StartClick2++;
                        break;
                    }
                case 3:
                    {
                        labNtype.Visibility = Visibility.Collapsed;
                        Ntype.Visibility = Visibility.Collapsed;
                        break;
                    }
                //case 4:
                //    {
                //        labNtype.Visibility = Visibility.Collapsed;
                //        Ntype.Visibility = Visibility.Collapsed;
                //        break;
                //    }
                //case 5:
                //    {
                //        labNtype.Visibility = Visibility.Collapsed;
                //        Ntype.Visibility = Visibility.Collapsed;
                //        break;
                //    }
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
