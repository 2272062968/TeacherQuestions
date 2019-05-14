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
        string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";
        DataTable DataTable = new DataTable();      //创建DtatTable实例
        public UserQuestionAdmin()
        {
            InitializeComponent();
            GetDataGrid();
        }
        //测试插入数据（刷新）
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            string sql = "INSERT INTO question(`id`, `subject`, `type`, `chapter`, `name`, `answer`, `diffculty`, `anthor`, `datatime`, `account`) VALUES ('6', '数学', '判断题', '第一章', 'dfg', 'dfg', '简单', '果冻', '2019/5/5', 'root')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            MessageBox.Show(result.ToString());
            conn.Close();
            questions.ItemsSource = null;
            GetDataGrid();
        }
        //读取数据
        private void ReadSQL()
        {
            MySqlConnection mycon = new MySqlConnection(con);                        //创建SQL连接对象
            mycon.Open();
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter("select * from question", con);
            DataSet myda = new DataSet();
            myDataAdapter.Fill(myda, "question");
            DataTable = myda.Tables["question"];
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
                user.Type = DataTable.Rows[i][2].ToString();
                user.Chapter = DataTable.Rows[i][3].ToString();

                
                user.Name = DataTable.Rows[i][4].ToString();
                user.Answer = DataTable.Rows[i][5].ToString();
                user.Diffculty = DataTable.Rows[i][6].ToString();
                user.Anthor = DataTable.Rows[i][7].ToString();
                user.Datatime = DataTable.Rows[i][8].ToString();

                user.BtnActionStr = new Button();
                user.BtnActionStr.Content = "修改_" + i;
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


    }
}
