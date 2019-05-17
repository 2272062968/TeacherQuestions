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
    /// UserQuestionAdmin.xaml 的交互逻辑
    /// </summary>
    public partial class UserQuestionAdmin : UserControl
    {
        //判断窗体加载时选择跳过
        int count = 0;
        string sqlStr = "select * from question where " + GlobalParams.Condition + " limit " + GlobalParams.StartIndex.ToString() + "," + GlobalParams.IndexNumbers.ToString();
        //GlobalParams Tj = new GlobalParams();
        string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";
        DataTable DataTable = new DataTable();      //创建DtatTable实例
        public UserQuestionAdmin()
        {
            InitializeComponent();
            //MessageBox.Show(sqlStr);
            //MessageBox.Show(GlobalParams.Condition);
            //MessageBox.Show(sqlStr);
            getSumPage();
            GetDataGrid(sqlStr);

            //SELECT COUNT(*) FROM question


            //MessageBox.Show(GlobalParams.Page.ToString());
            pageCount.Text = "共" + GlobalParams.Page.ToString() + "页";
        }
        public void getSumPage()
        {
            string sqlText = "SELECT COUNT(*) FROM question where " + GlobalParams.Condition;
            MySqlConnection mycon = new MySqlConnection(con);                        //创建SQL连接对象
            try
            {
                mycon.Open();
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(sqlText, con);
                DataSet myda = new DataSet();
                myDataAdapter.Fill(myda, "question");
                DataTable = myda.Tables["question"];
                GlobalParams.Page = int.Parse(DataTable.Rows[0][0].ToString()) / GlobalParams.IndexNumbers + 1;
            }
            catch (MySql.Data.MySqlClient.MySqlException) { }
            
        }
        ////测试插入数据（刷新）
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    MySqlConnection conn = new MySqlConnection(con);
        //    conn.Open();
        //    string sql = "INSERT INTO question(`id`, `subject`, `type`, `chapter`, `name`, `answer`, `diffculty`, `anthor`, `datatime`, `account`) VALUES ('6', '数学', '判断题', '第一章', 'dfg', 'dfg', '简单', '果冻', '2019/5/5', 'root')";
        //    MySqlCommand cmd = new MySqlCommand(sql, conn);
        //    int result = cmd.ExecuteNonQuery();
        //    MessageBox.Show(result.ToString());
        //    conn.Close();
        //    questions.ItemsSource = null;
        //    GetDataGrid("select * from question");
        //}
        //读取数据



        //向DataGrid中添加数据
        private void GetDataGrid(string sqlStr)
        {
            MySqlConnection mycon = new MySqlConnection(con);                        //创建SQL连接对象
            try
            {
                mycon.Open();
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(sqlStr, con);
                DataSet myda = new DataSet();
                myDataAdapter.Fill(myda, "question");
                DataTable = myda.Tables["question"];

                List<User> users = new List<User>();

                for (int i = 0; i < DataTable.Rows.Count; i++)
                {
                    User user = new User();
                    user.Id = DataTable.Rows[i][0].ToString();
                    user.Subject = DataTable.Rows[i][1].ToString();
                    user.Type = DataTable.Rows[i][2].ToString();
                    user.Chapter = DataTable.Rows[i][3].ToString();
                    user.Name = DataTable.Rows[i][4].ToString();
                    user.Answer = DataTable.Rows[i][5].ToString();
                    user.Diffculty = DataTable.Rows[i][6].ToString();
                    user.Anthor = DataTable.Rows[i][7].ToString();
                    user.Datatime = DataTable.Rows[i][8].ToString();

                    user.BtnActionStr = new Button();
                    if (i<10)
                    {
                        user.BtnActionStr.Content = "修改_0" + i;
                    }
                    else
                    {
                        user.BtnActionStr.Content = "修改_" + i;
                    }
                    
                    user.BtnActionStr.Height = 20;
                    user.BtnActionStr.FontSize = 10;
                    //user.BtnActionStr += 

                    user.Enabled = true;
                    users.Add(user);
                }
                //数据绑定
                questions.ItemsSource = users;
                questions.RowHeight = 25;
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {

                MessageBox.Show("网络出现问题！");
            }
           
           
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
            int WidthSize = (int)((questions.ActualWidth-57.5) / 9);
            UserId.Width = WidthSize;
            UserSubject.Width = WidthSize;
            UserChapter.Width = WidthSize;
            UserType.Width = WidthSize;
            UserName.Width = WidthSize;
            UserAnswer.Width = WidthSize;
            UserDiffculty.Width = WidthSize;
            UserAnthor.Width = WidthSize;
            UserDatatime.Width = WidthSize;

            //UserAction.Width = 80;

        }

        //第一个按钮点击事件
        private void BtnAction_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            MessageBox.Show(btn.Content.ToString());
            //MessageBox.Show(users[questions.SelectedIndex].Subject);
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

        //选择当前查看行数
        private void RowNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (count > 0)
            {
                string RowCount = RowNum.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                GlobalParams.IndexNumbers = int.Parse(RowCount);
                GlobalParams.startIndex = 0;
                getSumPage();
                pageCount.Text = "共" + GlobalParams.Page.ToString() + "页";
                sqlStr = "select * from question where " + GlobalParams.Condition + " limit " + GlobalParams.StartIndex.ToString() + "," + GlobalParams.IndexNumbers.ToString();
                GetDataGrid(sqlStr);

                //UserQuestionAdmin userQuestionAdmin = new UserQuestionAdmin();
                //MainWindow.questionAdmin.Content = userQuestionAdmin;
            }
            count++;
            //MessageBox.Show(RowCount);
        }

        //跳转按钮，可以进行优化如当前页面的时候不用刷新数据，暂时未优化

        //首页
        private void Btn_BackHome(object sender, RoutedEventArgs e)
        {
            GlobalParams.StartIndex = 0;
            GlobalParams.ThisPage = 1;
            sqlStr = "select * from question where " + GlobalParams.Condition + " limit " + GlobalParams.StartIndex.ToString() + "," + GlobalParams.IndexNumbers.ToString();
            GetDataGrid(sqlStr);
            thisPage.Text = GlobalParams.ThisPage.ToString();
        }
        
        //上一页
        private void Btn_LastPage(object sender, RoutedEventArgs e)
        {
            if (GlobalParams.StartIndex != 0)
            {
                GlobalParams.StartIndex -= GlobalParams.IndexNumbers;
                GlobalParams.ThisPage--;
                sqlStr = "select * from question where " + GlobalParams.Condition + " limit " + GlobalParams.StartIndex.ToString() + "," + GlobalParams.IndexNumbers.ToString();
                GetDataGrid(sqlStr);
                thisPage.Text = GlobalParams.ThisPage.ToString();
            }
        }

        //下一页
        private void Btn_NextPage(object sender, RoutedEventArgs e)
        {
            if (GlobalParams.IndexNumbers * GlobalParams.ThisPage < GlobalParams.IndexNumbers * GlobalParams.Page)
            {
                GlobalParams.StartIndex += GlobalParams.IndexNumbers;
                GlobalParams.ThisPage++;
                sqlStr = "select * from question where " + GlobalParams.Condition + " limit " + GlobalParams.StartIndex.ToString() + "," + GlobalParams.IndexNumbers.ToString();
                GetDataGrid(sqlStr);
                thisPage.Text = GlobalParams.ThisPage.ToString();
            }
        }

        //末页
        private void Btn_EndPage(object sender, RoutedEventArgs e)
        {
            GlobalParams.StartIndex = GlobalParams.IndexNumbers * (GlobalParams.Page - 1);
            GlobalParams.ThisPage = GlobalParams.Page;
            sqlStr = "select * from question where " + GlobalParams.Condition + " limit " + GlobalParams.StartIndex.ToString() + "," + GlobalParams.IndexNumbers.ToString();
            GetDataGrid(sqlStr);
            thisPage.Text = GlobalParams.ThisPage.ToString();
        }

        //跳转
        private void Btn_JumpPage(object sender, RoutedEventArgs e)
        {
            int page = int.Parse(thisPage.Text);
            if (page >= 0 && page <= GlobalParams.Page)
            {
                GlobalParams.startIndex = GlobalParams.IndexNumbers * (page - 1);
                GlobalParams.ThisPage = page;
                sqlStr = "select * from question where " + GlobalParams.Condition + " limit " + GlobalParams.StartIndex.ToString() + "," + GlobalParams.IndexNumbers.ToString();
                GetDataGrid(sqlStr);
            }
            else
            {
                MessageBox.Show("超出页面范围");
            }
        }

    }
}
