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
    public partial class MainWindow : Window
    {
        string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";
        DataTable DataTable = new DataTable();      //创建DtatTable实例
        public MainWindow()
        {
            InitializeComponent();
            MySqlConnection mycon = new MySqlConnection(con);                        //创建SQL连接对象
            mycon.Open();
            GetDataGrid();
        }

        //测试插入数据（刷新）
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //dataBinding();
            //ReadSQL();
            string sql = "insert into [questions].[dbo].[data] (id,Subject,type,name,answer,difficulty,author,datatime) values('24','java','判断题','是否正确','T','一般','神','2019/4/23');";
            SqlDataAdapter myda = new SqlDataAdapter(sql, con);
            //DataTable DataTable = new DataTable();
            DataTable.Clear();
            myda.Fill(DataTable);
            questions.ItemsSource = null;
            //ItemsControl.ItemsSource();

            GetDataGrid();
            MessageBox.Show(DataTable.Rows.Count.ToString());
        }
        //读取数据
        private void ReadSQL()
        {
            //string sql = "select * from data";                //SQL查询语句

            //                                    //打开
            //MySqlCommand myda = new MySqlCommand(sql, mycon);

            //myda.Fill(DataTable);                                                      //填充table

            MySqlConnection mycon = new MySqlConnection(con);                        //创建SQL连接对象
            mycon.Open();
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter("select * from question", con);
            DataSet myda = new DataSet();
            myDataAdapter.Fill(myda, "question");
            DataTable = myda.Tables["question"];

            //foreach (DataRow myRow in DataTable.Rows)
            //{
            //    foreach(DataColumn myColumn in DataTable.Columns)
            //    {

            //    }
            //}

            //dt.Rows[0][1] = "呵呵呵";
            //MessageBox.Show(dt.Rows.Count.ToString());
            //MessageBox.Show(DataTable.Rows[1][4].ToString());
            //questions.ItemsSource = dt.DefaultView;                              //这里在WPF界面中拖拽一个DataGrid，然后用DataTable进行填充。
        }



        //向DataGrid中添加数据
        private void GetDataGrid()
        {
            List<User> users = new List<User>();
            ReadSQL();
            for (int i = 0; i < DataTable.Rows.Count; i++)
            {
                User user = new User();
                user.Id = DataTable.Rows[i][0].ToString();
                //MessageBox.Show(DataTable.Rows[i][0].ToString());
                user.Subject = DataTable.Rows[i][1].ToString();

                user.Chapter = DataTable.Rows[i][2].ToString();

                user.Type = DataTable.Rows[i][3].ToString();
                user.Name = DataTable.Rows[i][4].ToString();
                user.Answer = DataTable.Rows[i][5].ToString();
                user.Diffculty = DataTable.Rows[i][6].ToString();
                user.Anthor = DataTable.Rows[i][7].ToString();
                user.Datatime = DataTable.Rows[i][8].ToString();

                user.BtnActionStr = new Button();
                user.BtnActionStr.Content = "修改" + i;
                user.BtnActionStr.Height = 20;
                user.BtnActionStr.FontSize = 10;



                user.Enabled = true;

                users.Add(user);
            }
            //数据绑定
            questions.ItemsSource = users;
            questions.RowHeight = 25;
        }

        //定义要绑定的类
        private class User
        {
            public string Id { get; set; }
            public string Subject { get; set; }
            public string Type { get; set; }
            public string Chapter { get; set; }
            public string Name { get; set; }
            public string Answer { get; set; }
            public string Diffculty { get; set; }
            public string Anthor { get; set; }
            public string Datatime { get; set; }
            public Button BtnActionStr { get; set; }
            public bool Enabled { get; set; }
            //public string BtnActionStr1 { get; set; }
            //public bool Enabled1 { get; set; }
        }

        //初始化表格平均分配各列的宽度
        private void datagrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int WidthSize = (int)(questions.ActualWidth / 9 - 10);
            UserId.Width = 100;
            UserSubject.Width = WidthSize;
            UserChapter.Width = WidthSize;
            UserType.Width = WidthSize;
            UserName.Width = WidthSize;
            UserAnswer.Width = WidthSize;
            UserDiffculty.Width = WidthSize;
            UserAnthor.Width = WidthSize;
            UserDatatime.Width = WidthSize;

            UserAction.Width = 80;

        }

        //第一个按钮点击事件
        private void BtnAction_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(users[questions.SelectedIndex].Subject);
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

        //查询最大id
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string sql = "select max(id) from data;";
            SqlDataAdapter maxData = new SqlDataAdapter(sql, con);
            DataTable dataTable = new DataTable();
            maxData.Fill(dataTable);
            MessageBox.Show(dataTable.Rows[0][0].ToString());
        }

        //private void Choice_Checked(object sender, RoutedEventArgs e)
        //{
        //    string rabtnMame = choice.Content.ToString();
        //    AnswerStyle(rabtnMame);
        //}

        //private void Judge_Checked(object sender, RoutedEventArgs e)
        //{
        //    string rabtnMame = judge.Content.ToString();
        //    AnswerStyle(rabtnMame);
        //}

        //private void Design_Checked(object sender, RoutedEventArgs e)
        //{
        //    string rabtnMame = design.Content.ToString();
        //    AnswerStyle(rabtnMame);
        //}
        private void AnswerStyle(string rabtnMame)
        {

            //if (choice.IsChecked == true)
            //{
            //    //if (Xanswer.GetType)
            //    //{

            //    //}


            //    //TextBox tbx = spAnswer.FindName("tbxAnswer") as TextBox;//找到刚新添加的按钮   
            //    //if (tbx != null)//判断是否找到，以免在未添加前就误点了   
            //    //{
            //    //    spAnswer.Children.Remove(tbx);//移除对应按钮控件   
            //    //    spAnswer.UnregisterName("tbxAnswer");//还需要把对用的名字注销掉，否则再次点击Button_Add会报错   
            //}
        }

        //判断答案控件是否存在--开发中
        //private ExistType()
        //{
        //    TextBox tbx = spAnswer.FindName("tbxAnswer") as TextBox;
        //    if (tbx == null)
        //    {
        //        //选择题，选项，通过获取···········
        //        return "tbxAnswer"
        //    }
        //}


        //测试
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Xanswer.GetType.ToString());
        }




        //Button btn1 = new Button();
        //btn1.Width = 100;
        //btn1.Height = 50;
        ////删除控件
        ////spAnswer.Children.Remove(tbxAnswer);
        //spAnswer.Children.Add(btn1);
        //spAnswer.RegisterName("Name1", btn1);
        ////spAnswer.FindName("Name1") as Button;
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
