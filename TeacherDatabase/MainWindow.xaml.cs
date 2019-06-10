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
            UserAlterPassword userAlterPassword = new UserAlterPassword();
            questionAlter.Content = userAlterPassword;
        }



        
        public MainWindow()
        {

            InitializeComponent();

            StartLoatWindow();
            SelectSubject();
    
        }
        
        void SelectSubject()
        {
            try
            {
                GlobalParams.SubjectName = "";
                MySqlConnection mycon = new MySqlConnection(con);                        //创建SQL连接对象
                mycon.Open();
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter("select distinct subject from question", con);
                DataSet myda = new DataSet();
                myDataAdapter.Fill(myda, "question");
                datab = myda.Tables["question"];
                Ntype.Items.Clear();
                ComboBoxItem cbiAll = new ComboBoxItem();
                cbiAll.Content = "全部类型";
                Ntype.Items.Add(cbiAll);
                Ntype.SelectedIndex = 0;
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
                    GlobalParams.SubjectName += "," + row[0].ToString();
                }
            }
            catch (MySqlException)
            {

            }
        }

        private void Ntype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (start>0)
            {
                string selectSubject = "";
                try
                {
                    selectSubject = Ntype.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                }
                catch (System.NullReferenceException)
                {

                }
               
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
                        if (GlobalParams.TypeRefresh)
                        {
                            SelectSubject();
                            GlobalParams.TypeRefresh = false;
                        }
                        if (GlobalParams.DataRefresh)
                        {
                            UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                            questionAdmin.Content = userQuestionAdmin;
                            GlobalParams.DataRefresh = false;
                        }

                        //Refresh.Visibility = Visibility.Visible;
                        labNtype.Visibility = Visibility.Visible;
                        Ntype.Visibility = Visibility.Visible;
                        break;
                    }
                case 1:
                    {
                        //Refresh.Visibility = Visibility.Collapsed;
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
                        //Refresh.Visibility = Visibility.Collapsed;
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
                        //Refresh.Visibility = Visibility.Collapsed;
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

        //private void Btn_Close(object sender, RoutedEventArgs e)
        //{
        //    Close();
        //}

        //bool isMaxWindow = false;
        //private void Btn_Max(object sender, RoutedEventArgs e)
        //{
        //    if (isMaxWindow)
        //    {
        //        WindowState = WindowState.Normal;
        //        isMaxWindow = false;
        //    }
        //    else
        //    {
        //        WindowState = WindowState.Maximized;
        //        isMaxWindow = true;
        //    }
        //}



        //public static bool dataRefresh;

        //public bool DataRefresh
        //{
        //    get { return dataRefresh; }
        //    set
        //    {
        //        //如果变量改变则调用事件触发函数
        //        if (value != dataRefresh)
        //        {
        //            WhenDataRefreshChange();
        //        }
        //        dataRefresh = value;
        //    }
        //}
        
        

        ////定义委托
        //public delegate void DataRefreshChanged(object sender, RoutedEventArgs e);
        ////与委托相关联的事件
        //public event DataRefreshChanged OnDataRefreshChanged;

        //private void WhenDataRefreshChange()
        //{
        //    if (OnDataRefreshChanged != null)
        //    {
        //        OnDataRefreshChanged(this, null);
        //    }
        //}


        //private void Refresh_Click(object sender, RoutedEventArgs e)
        //{            
        //    MyRefresh();
        //}
        //public void MyRefresh()
        //{
        //    UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
        //    questionAdmin.Content = userQuestionAdmin;
        //    //questionAdmin.DataContext = userQuestionAdmin;
        //}

        private void RibbonWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (GlobalParams.DataRefresh)
            {
                UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                questionAdmin.Content = userQuestionAdmin;
                GlobalParams.DataRefresh = false;
            }
        }


        private void ShowShare_Click(object sender, RoutedEventArgs e)
        {
            if (showShare.IsChecked == true)
            {
                GlobalParams.SqlShowShare = " UNION SELECT * FROM question WHERE share=0 and " + GlobalParams.Condition;
                UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                questionAdmin.Content = userQuestionAdmin;
            }
            else
            {
                GlobalParams.SqlShowShare = "";
                UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                questionAdmin.Content = userQuestionAdmin;
            }
        }
    }
}
