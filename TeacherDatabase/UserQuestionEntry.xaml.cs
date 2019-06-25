using MySql.Data.MySqlClient;
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

namespace TeacherDatabase
{
    /// <summary>
    /// UserQuestionEntry.xaml 的交互逻辑
    /// </summary>
    public partial class UserQuestionEntry : UserControl
    {
        string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";
        public UserQuestionEntry()
        {
            InitializeComponent();
            foreach (var subName in GlobalParams.subjectName.Split(','))
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = subName;
                addType.Items.Add(item);
            }
            

            
        }

        //新建其他学科
        private void Xtype_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Xtype.Text != "")
            {
                addType.SelectedIndex = -1;
            }
        }
        //选择学科
        private void AddType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (addType.SelectedIndex != -1)
            {
                Xtype.Text = "";
            }
        }

        //清空插入填写的数据
        private void Btn_Click_Close(object sender, RoutedEventArgs e)
        {
            addType.SelectedIndex = -1;
            Xtype.Text = "";
            choice.IsChecked = false;
            judge.IsChecked = false;
            design.IsChecked = false;
            fillBlank.IsChecked = false;
            selectXtype.Text = "";
            tbxChapter.Text = "";
            tbxQuestion.Text = "";
            tbxAnswer.Text = "";
            C.IsChecked = false;
            B.IsChecked = false;
            A.IsChecked = false;
            tbxIssueAnthor.Text = "";
        }
        //自定义其他题型
        private void selectType_LostFocus(object sender, RoutedEventArgs e)
        {
            if (selectXtype.Text != "")
            {
                choice.IsChecked = false;
                judge.IsChecked = false;
                design.IsChecked = false;
                fillBlank.IsChecked = false;
            }
        }
        //选择题型
        private void queType_Click(object sender, RoutedEventArgs e)
        {
            selectXtype.Text = "";
        }

     
        //获取数据库中的最大ID再加1返回
        string getMaxId()
        {
            DataTable table = new DataTable();
            MySqlConnection mycon = new MySqlConnection(con);
            mycon.Open();
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter("select max(id) from question;", con);
            DataSet myda = new DataSet();
            myDataAdapter.Fill(myda, "question");
            table = myda.Tables["question"];
            return (int.Parse(table.Rows[0][0].ToString()) + 1).ToString();
        }

        //获取要插入的学科
        string getSubject()
        {
            if (Xtype.Text == "")
            {
                return addType.Text;
            }
            else
            {
                return Xtype.Text;
            }

        }

        //获取选择的题型
        string getQuestionType()
        {
            if (choice.IsChecked == true)
            {
                return "选择题";
            }
            if (judge.IsChecked == true)
            {
                return "判断题";
            }
            if (fillBlank.IsChecked == true)
            {
                return "填空题";
            }
            if (design.IsChecked == true)
            {
                return "设计题";
            }
            else
            {
                return selectXtype.Text;
            }
        }

        //获取题目难度
        string getQuestionDiffculty()
        {
            if (A.IsChecked == true)
            {
                return "较难";
            }
            if (B.IsChecked == true)
            {
                return "一般";
            }
            if (C.IsChecked == true)
            {
                return "简单";
            }
            else
            {
                return "";
            }
        }

        //开始执行插入
        private void Btn_Click_StartInstall(object sender, RoutedEventArgs e)
        {

            if (getSubject() != "" && getQuestionType() != "" && tbxQuestion.Text != "")
            {
                QuestionClass question = new QuestionClass();
                question.id = getMaxId();
                question.subject = getSubject();
                question.type = getQuestionType();
                question.chapter = tbxChapter.Text;
                question.name = tbxQuestion.Text;
                question.answer = tbxAnswer.Text;
                question.diffculty = getQuestionDiffculty();
                question.anthor = tbxIssueAnthor.Text;
                //question.datetime = DateTime.Now.ToString();
                question.account = GlobalParams.MyAccount;
                if (isShare.IsChecked == true)
                {
                    question.share = "0";
                }
                else
                {
                    question.share = "1";
                }
                


                MySqlConnection mycon = new MySqlConnection(con);
                mycon.Open();
                string sqlStr = "INSERT INTO `question`(`id`, `subject`, `type`, `chapter`, `name`, `answer`, `diffculty`, `anthor`, `datatime`, `account`, `share`) VALUES('"
                    + question.id + "', '" + question.subject + "', '" + question.type + "', '" + question.chapter + "', '" + question.name +
                    "', '" + question.answer + "', '" + question.diffculty + "', '" + question.anthor + "', NOW(), '" + question.account+"',"+ question.share + ")";
                MySqlCommand myDataAdapter = new MySqlCommand(sqlStr, mycon);
                GlobalParams.DataRefresh = true;
                if (Xtype.Text != "")
                {
                    GlobalParams.TypeRefresh = true;
                }
                if (myDataAdapter.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("插入成功！");
                }
                else
                {
                    MessageBox.Show("插入失败！出现了未知问题~");
                }
                

            }
            else
            {
                MessageBox.Show("*标注的信息为必填项，请填写后重试");
            }
            


        }

    }
}
