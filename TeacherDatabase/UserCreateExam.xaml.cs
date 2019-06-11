using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// UserCreateExam.xaml 的交互逻辑
    /// </summary>
    public partial class UserCreateExam : UserControl
    {
        string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";
        WriteData writeData = new WriteData();
        bool QuestionIsEnough = true;
        List<string> questionName = new List<string>();

        int XZNumWord = 0;
        int TKNumWord = 0;
        int PDNumWord = 0;
        int SJNumWord = 0;
        public UserCreateExam()
        {
            InitializeComponent();
            this.DataContext = writeData;
            AddComBoxItem();
            foreach (var subName in GlobalParams.subjectName.Split(','))
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = subName;
                quesType.Items.Add(item);
            }
        }
        //添加ComBoxItem
        void AddComBoxItem()
        {
            for (int i = 1; i <= 30; i++)
            {
                ComboBoxItem XuanZeAllItem = new ComboBoxItem();
                XuanZeAllItem.Content = i.ToString();
                XuanZeAll.Items.Add(XuanZeAllItem);
                ComboBoxItem TianKongAllItem = new ComboBoxItem();
                TianKongAllItem.Content = i.ToString();
                TianKongAll.Items.Add(TianKongAllItem);
                ComboBoxItem PanDuanAllItem = new ComboBoxItem();
                PanDuanAllItem.Content = i.ToString();
                PanDuanAll.Items.Add(PanDuanAllItem);
                ComboBoxItem SheJiAllItem = new ComboBoxItem();
                SheJiAllItem.Content = i.ToString();
                SheJiAll.Items.Add(SheJiAllItem);


                ComboBoxItem XuanZeAItem = new ComboBoxItem();
                XuanZeAItem.Content = i.ToString();
                XuanZeA.Items.Add(XuanZeAItem);
                ComboBoxItem XuanZeBItem = new ComboBoxItem();
                XuanZeBItem.Content = i.ToString();
                XuanZeB.Items.Add(XuanZeBItem);
                ComboBoxItem XuanZeCItem = new ComboBoxItem();
                XuanZeCItem.Content = i.ToString();
                XuanZeC.Items.Add(XuanZeCItem);

                ComboBoxItem TianKongAItem = new ComboBoxItem();
                TianKongAItem.Content = i.ToString();
                TianKongA.Items.Add(TianKongAItem);
                ComboBoxItem TianKongBItem = new ComboBoxItem();
                TianKongBItem.Content = i.ToString();
                TianKongB.Items.Add(TianKongBItem);
                ComboBoxItem TianKongCItem = new ComboBoxItem();
                TianKongCItem.Content = i.ToString();
                TianKongC.Items.Add(TianKongCItem);


                ComboBoxItem PanDuanAItem = new ComboBoxItem();
                PanDuanAItem.Content = i.ToString();
                PanDuanA.Items.Add(PanDuanAItem);
                ComboBoxItem PanDuanBItem = new ComboBoxItem();
                PanDuanBItem.Content = i.ToString();
                PanDuanB.Items.Add(PanDuanBItem);
                ComboBoxItem PanDuanCItem = new ComboBoxItem();
                PanDuanCItem.Content = i.ToString();
                PanDuanC.Items.Add(PanDuanCItem);

                ComboBoxItem SheJiAItem = new ComboBoxItem();
                SheJiAItem.Content = i.ToString();
                SheJiA.Items.Add(SheJiAItem);
                ComboBoxItem SheJiBItem = new ComboBoxItem();
                SheJiBItem.Content = i.ToString();
                SheJiB.Items.Add(SheJiBItem);
                ComboBoxItem SheJiCItem = new ComboBoxItem();
                SheJiCItem.Content = i.ToString();
                SheJiC.Items.Add(SheJiCItem);
            }
        }

        //写入Word
        void WriteQuestionInWord(string path)
        {
            try
            {
                string strResult = "";
                Object Nothing = System.Reflection.Missing.Value;
                //Directory.CreateDirectory(@"E:\TEMP\SaveWord");  //创建文件所在目录
                string wordName = writeData.title + ".doc";//文件名
                object wordPathName = path + wordName;


                //创建Word文档
                Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

                //添加页眉
                WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
                WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
                WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(writeData.header);
                WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;//设置居中
                WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;//跳出页眉设置
                WordApp.Selection.ParagraphFormat.LineSpacing = 15f;//设置文档的行间距

                //WordApp.Selection();//插入段落

                WordApp.Selection.Text = "  " + writeData.title;
                WordApp.Selection.Range.Font.Size = 24;

                //移动焦点并换行
                object count = 14;
                object WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;

                int num = 0;

                foreach (var item in questionName)
                {

                    if (num == 0 && XZNumWord != 0)
                    {
                        WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
                        WordApp.Selection.TypeParagraph();//插入段落
                        WordApp.Selection.Text = "选择题";
                    }
                    if (num == XZNumWord && TKNumWord != 0)
                    {
                        WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
                        WordApp.Selection.TypeParagraph();//插入段落
                        WordApp.Selection.Text = "填空题";
                    }
                    if (num == XZNumWord + TKNumWord && PDNumWord != 0)
                    {
                        WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
                        WordApp.Selection.TypeParagraph();//插入段落
                        WordApp.Selection.Text = "判断题";
                    }
                    if (num == XZNumWord + TKNumWord + PDNumWord && SJNumWord != 0)
                    {
                        WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
                        WordApp.Selection.TypeParagraph();//插入段落
                        WordApp.Selection.Text = "设计题";
                    }
                    num++;

                    WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
                    WordApp.Selection.TypeParagraph();//插入段落
                    WordApp.Selection.Text = num.ToString() + ". " + item;


                }


                //WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);
                //WordApp.Selection.TypeParagraph();
                //WordApp.Selection.Text = strText;


                try
                {
                    //文件保存
                    object objWordName = wordPathName;
                    WordDoc.SaveAs(ref objWordName, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                    WordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                    WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
                    strResult = wordName + "\n" + @"文档生成并写入成功" + "\n" + "信息：" + wordPathName;
                    MessageBox.Show(strResult);
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show("警告，出现生成错误问题！您的电脑正在运行office，或者是\n您的电脑管理.doc格式文件的软件不是office，如果您安装了其他软件，请在--设置--应用--默认应用--按应用设置默认值找到Microsoft Office Word进行管理，设置.doc为此应用默认格式");
                }
            }
            catch (System.InvalidCastException)
            {

                MessageBox.Show("生成失败，原因可能是您以前安装过wps后来卸载后，wps 会修改注册表相关office的未知相关项，导致vsto加载项报错；\n解决方案：找到office安装包选择修复\n详情可以参考：https://www.cnblogs.com/wuhailong/p/5583232.html");
            }
           
        }

        // Number随机数个数
        // minNum随机数下限
        // maxNum随机数上限
        public int[] GetRandomArray(int Number, int minNum, int maxNum)
        {
            int j;
            int[] b = new int[Number];
            Random r = new Random();
            for (j = 0; j < Number; j++)
            {
                int i = r.Next(minNum, maxNum + 1);
                int num = 0;
                for (int k = 0; k < j; k++)
                {
                    if (b[k] == i)
                    {
                        num = num + 1;
                    }
                }
                if (num == 0)
                {
                    b[j] = i;
                }
                else
                {
                    j = j - 1;
                }
            }
            return b;
        }



        //获取数据库中试题数量
        int GetQuestionCount(string select)
        {
           
            System.Data.DataTable table = new System.Data.DataTable();
            MySqlConnection mycon = new MySqlConnection(con);

            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(" select count(*) from question where "+select +" and account='"+GlobalParams.MyAccount+"'", con);
            //MySqlDataAdapter myDataAdapter = new MySqlDataAdapter("select count(*) from question where type = '选择题' and(subject = 'python' or subject = 'Python')", con);
            DataSet XuanZeData = new DataSet(); 
            myDataAdapter.Fill(XuanZeData, "question");
            table = XuanZeData.Tables["question"];
            return int.Parse(table.Rows[0][0].ToString());
        }

        //int MaxXuanze;
        //int MaxTiankong;
        //int MaxPanduan;
        //int MaxSheji;
        //int MaxXuanzeA;
        //int MaxXuanzeB;
        //int MaxXuanzeC;
        //int MaxTiankongA;
        //int MaxTiankongB;
        //int MaxTiankongC;
        //int MaxPanduanA;
        //int MaxPanduanB;
        //int MaxPanduanC;
        //int MaxShejiA;
        //int MaxShejiB;
        //int MaxShejiC;

        //判断难度选择试题数量是否足够
        void isEnoughDiff(string type, int typeACount, int typeBCount, int typeCCount)
        {
            if (writeData.questionType == "Python")
            {
                
                if (GetQuestionCount("type='"+type+"' and (subject='python' or subject = 'Python') and diffculty='简单'") < typeCCount)
                {
                    MessageBox.Show("题库中的" + writeData.questionType + "简单" + type + "数量不足");
                    QuestionIsEnough = false;
                }
                if (GetQuestionCount("type='" + type + "' and (subject='python' or subject = 'Python') and diffculty='一般'") < typeBCount)
                {
                    MessageBox.Show("题库中的" + writeData.questionType + "一般" + type + "数量不足");
                    QuestionIsEnough = false;
                }
                if (GetQuestionCount("type='" + type + "' and (subject='python' or subject = 'Python') and diffculty='较难'") < typeACount)
                {
                    MessageBox.Show("题库中的" + writeData.questionType + "较难" + type + "数量不足");
                    QuestionIsEnough = false;
                }
            }
            else if (writeData.questionType == "Java")
            {
                if (GetQuestionCount("type='" + type + "' and (subject='java' or subject = 'Java') and diffculty='简单'") < typeCCount)
                {
                    MessageBox.Show("题库中的" + writeData.questionType + "简单" + type + "数量不足");
                    QuestionIsEnough = false;
                }
                if (GetQuestionCount("type='" + type + "' and (subject='java' or subject = 'Java') and diffculty='一般'") < typeBCount)
                {
                    MessageBox.Show("题库中的" + writeData.questionType + "一般" + type + "数量不足");
                    QuestionIsEnough = false;
                }
                if (GetQuestionCount("type='" + type + "' and (subject='java' or subject = 'Java') and diffculty='较难'") < typeACount)
                {
                    MessageBox.Show("题库中的" + writeData.questionType + "较难" + type + "数量不足");
                    QuestionIsEnough = false;
                }
            }
            else
            {
                if (GetQuestionCount("type='" + type + "' and subject='" + writeData.questionType + "' and diffculty='简单'") < typeCCount)
                {
                    MessageBox.Show("题库中的" + writeData.questionType + "简单" + type + "数量不足");
                    QuestionIsEnough = false;
                }
                if (GetQuestionCount("type='" + type + "' and subject='" + writeData.questionType + "' and diffculty='一般'") < typeBCount)
                {
                    MessageBox.Show("题库中的" + writeData.questionType + "一般" + type + "数量不足");
                    QuestionIsEnough = false;
                }
                if (GetQuestionCount("type='" + type + "' and subject='" + writeData.questionType + "' and diffculty='较难'") < typeACount)
                {
                    MessageBox.Show("题库中的" + writeData.questionType + "较难" + type + "数量不足");
                    QuestionIsEnough = false;
                }
            }
        }
        //判断试题数量是否足够
        void isEnoughAll(string type,int typeAllCount)
        {
            if (writeData.questionType == "Python")
            {
                if (GetQuestionCount("type='"+ type+"' and (subject='python' or subject = 'Python')") < typeAllCount)
                {
                    MessageBox.Show("题库中的" + writeData.questionType + type + "数量不足");
                    QuestionIsEnough = false;
                }
            }
            else if (writeData.questionType == "Java")
            {
                if (GetQuestionCount("type='"+ type + "' and (subject='java' or subject = 'Java')") < typeAllCount)
                {
                    MessageBox.Show("题库中的" + writeData.questionType + type + "数量不足");
                    QuestionIsEnough = false;
                }

            }
            else
            {
                if (GetQuestionCount("type='"+ type + "' and subject='" + writeData.questionType + "'") < typeAllCount)
                {
                    MessageBox.Show("题库中的" + writeData.questionType + type + "数量不足");
                    QuestionIsEnough = false;
                }

            }
        }



        //查询试题
        string AddQuesitonName(string sql)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            MySqlConnection mycon = new MySqlConnection(con);
            MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(sql, con);
            DataSet XuanZeData = new DataSet();
            myDataAdapter.Fill(XuanZeData, "question");
            table = XuanZeData.Tables["question"];
            if (table.Rows.Count != 0)
            {
                return table.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
        //向列表随机添加难度选择的试题
        void AddSelectQueston(string type, int NumA, int NumB, int NumC)
        {
            string thisAccount = " and account = '" + GlobalParams.MyAccount + "'";
            if (writeData.questionType == "Python")
            {
                foreach (var item in GetRandomArray(NumC, 0, GetQuestionCount("type='" + type + "' and (subject='python' or subject = 'Python') and diffculty='简单'") - 1))
                {
                    string name = AddQuesitonName("select name from question where type = '" + type + "' and (subject='python' or subject='Python') and diffculty='简单'" + thisAccount + " limit " + item.ToString() + ",1");
                    questionName.Add(name);
                }
                foreach (var item in GetRandomArray(NumB, 0, GetQuestionCount("type='" + type + "' and (subject='python' or subject = 'Python') and diffculty='一般'") - 1))
                {
                    string name = AddQuesitonName("select name from question where type = '" + type + "' and (subject='python' or subject='Python') and diffculty='一般'" + thisAccount + "  limit " + item.ToString() + ",1");
                    questionName.Add(name);
                }
                foreach (var item in GetRandomArray(NumA, 0, GetQuestionCount("type='" + type + "' and (subject='python' or subject = 'Python') and diffculty='较难'") - 1))
                {
                    string name = AddQuesitonName("select name from question where type = '" + type + "' and (subject='python' or subject='Python') and diffculty='较难'" + thisAccount + "  limit " + item.ToString() + ",1");
                    questionName.Add(name);
                }
            }
            else if (writeData.questionType == "Java")
            {
                foreach (var item in GetRandomArray(NumC, 0, GetQuestionCount("type='" + type + "' and (subject='java' or subject = 'Java') and diffculty='简单'") - 1))
                {
                    string name = AddQuesitonName("select name from question where type = '" + type + "' and (subject='java' or subject='Java') and diffculty='简单' " + thisAccount + " limit " + item.ToString() + ",1");
                    questionName.Add(name);
                }
                foreach (var item in GetRandomArray(NumB, 0, GetQuestionCount("type='" + type + "' and (subject='java' or subject = 'Java') and diffculty='一般'") - 1))
                {
                    string name = AddQuesitonName("select name from question where type = '" + type + "' and (subject='java' or subject='Java') and diffculty='一般'" + thisAccount + "  limit " + item.ToString() + ",1");
                    questionName.Add(name);
                }
                foreach (var item in GetRandomArray(NumA, 0, GetQuestionCount("type='" + type + "' and (subject='java' or subject = 'Java') and diffculty='较难'") - 1))
                {
                    string name = AddQuesitonName("select name from question where type = '" + type + "' and (subject='java' or subject='Java') and diffculty='较难'" + thisAccount + "  limit " + item.ToString() + ",1");
                    questionName.Add(name);
                }
            }
            else
            {
                foreach (var item in GetRandomArray(NumC, 0, GetQuestionCount("type='" + type + "' and (subject='" + writeData.questionType + "') and diffculty='简单'") - 1))
                {
                    string name = AddQuesitonName("select name from question where type = '" + type + "' and subject='" + writeData.questionType + "' and diffculty='简单'" + thisAccount + "  limit " + item.ToString() + ",1");
                    questionName.Add(name);
                }
                foreach (var item in GetRandomArray(NumB, 0, GetQuestionCount("type='" + type + "' and (subject='" + writeData.questionType + "') and diffculty='一般'") - 1))
                {
                    string name = AddQuesitonName("select name from question where type = '" + type + "' and subject='" + writeData.questionType + "' and diffculty='一般' " + thisAccount + " limit " + item.ToString() + ",1");
                    questionName.Add(name);
                }
                foreach (var item in GetRandomArray(NumA, 0, GetQuestionCount("type='" + type + "' and (subject='" + writeData.questionType + "') and diffculty='较难'") - 1))
                {
                    string name = AddQuesitonName("select name from question where type = '" + type + "' and subject='" + writeData.questionType + "' and diffculty='较难'" + thisAccount + "  limit " + item.ToString() + ",1");
                    questionName.Add(name);
                }
            }
        }
        //向列表随机添加试题
        void AddAllQuestion(string type, int Num)
        {
            //int[] index;
            if (writeData.questionType == "Python")
            {
                foreach (var item in GetRandomArray(Num, 0, GetQuestionCount("type='" + type + "' and (subject='python' or subject = 'Python')") - 1))
                {
                    string name = AddQuesitonName("select name from question where type = '" + type + "' and (subject='python' or subject='Python') limit " + item.ToString() + ",1");
                    questionName.Add(name);
                }

            }
            else if (writeData.questionType == "Java")
            {
                foreach (var item in GetRandomArray(Num, 0, GetQuestionCount("type='" + type + "' and (subject='java' or subject = 'Java')") - 1))
                {
                    string name = AddQuesitonName("select name from question where type = '" + type + "' and (subject='java' or subject='Java') limit " + item.ToString() + ",1");
                    questionName.Add(name);
                }

            }
            else
            {
                foreach (var item in GetRandomArray(Num, 0, GetQuestionCount("type='" + type + "' and (subject='" + writeData.questionType + "')") - 1))
                {
                    string name = AddQuesitonName("select name from question where type = '" + type + "' and subject='" + writeData.questionType + "' limit " + item.ToString() + ",1");
                    questionName.Add(name);
                }

            }
        }


        private void StartNewExam_Click(object sender, RoutedEventArgs e)
        {

            string title = docTitle.Text;
            string subject = quesType.Text;
            if (title == "" || subject == "")
            {
                MessageBox.Show("请填写标题内容和选择学科！");
            }
            else
            {
                QuestionIsEnough = true;
                #region 判断选择的题目在数据库中是否足够
                if (XuanZeAll.Visibility == Visibility.Visible)
                {
                    isEnoughAll("选择题", writeData.xuanzeAllNum);
                }
                else
                {
                    isEnoughDiff("选择题", writeData.xuanzeANum, writeData.xuanzeBNum, writeData.xuanzeCNum);
                }
                if (TianKongAll.Visibility == Visibility.Visible)
                {
                    isEnoughAll("填空题", writeData.tiankongAllNum);
                }
                else
                {
                    isEnoughDiff("填空题", writeData.tiankongANum, writeData.tiankongBNum, writeData.tiankongCNum);
                }
                if (PanDuanAll.Visibility == Visibility.Visible)
                {
                    isEnoughAll("判断题", writeData.panduanAllNum);
                }
                else
                {
                    isEnoughDiff("判断题", writeData.panduanANum, writeData.panduanBNum, writeData.panduanCNum);
                }
                if (SheJiAll.Visibility == Visibility.Visible)
                {
                    isEnoughAll("设计题", writeData.shejiAllNum);
                }
                else
                {
                    isEnoughDiff("设计题", writeData.shejiANum, writeData.shejiBNum, writeData.shejiCNum);
                }
                #endregion
                questionName.Clear();
                if (QuestionIsEnough)
                {
                    if (XuanZeAll.Visibility == Visibility.Visible && writeData.xuanzeAllNum != 0)
                    {
                        AddAllQuestion("选择题", writeData.xuanzeAllNum);
                        XZNumWord = writeData.xuanzeAllNum;
                    }
                    else
                    {
                        AddSelectQueston("选择题", writeData.xuanzeANum, writeData.xuanzeBNum, writeData.xuanzeCNum);
                        XZNumWord = writeData.xuanzeANum + writeData.xuanzeBNum + writeData.xuanzeCNum;
                    }
                    if (TianKongAll.Visibility == Visibility.Visible && writeData.tiankongAllNum != 0)
                    {
                        AddAllQuestion("填空题", writeData.tiankongAllNum);
                        TKNumWord = writeData.tiankongAllNum;
                    }
                    else
                    {
                        AddSelectQueston("填空题", writeData.tiankongANum, writeData.tiankongBNum, writeData.tiankongCNum);
                        TKNumWord = writeData.tiankongANum + writeData.tiankongBNum + writeData.tiankongCNum;
                    }
                    if (PanDuanAll.Visibility == Visibility.Visible && writeData.panduanAllNum != 0)
                    {
                        AddAllQuestion("判断题", writeData.panduanAllNum);
                        PDNumWord = writeData.panduanAllNum;
                    }
                    else
                    {
                        AddSelectQueston("判断题", writeData.panduanANum, writeData.panduanBNum, writeData.panduanCNum);
                        PDNumWord = writeData.panduanANum + writeData.panduanBNum + writeData.panduanCNum;
                    }
                    if (SheJiAll.Visibility == Visibility.Visible && writeData.shejiAllNum != 0)
                    {
                        AddAllQuestion("设计题", writeData.shejiAllNum);
                        SJNumWord = writeData.shejiAllNum;
                    }
                    else
                    {
                        AddSelectQueston("设计题", writeData.shejiANum, writeData.shejiBNum, writeData.shejiCNum);
                        SJNumWord = writeData.shejiANum + writeData.shejiBNum + writeData.shejiCNum;
                    }

                    string path = "";
                    System.Windows.Forms.FolderBrowserDialog dilog = new System.Windows.Forms.FolderBrowserDialog();
                    dilog.Description = "请选择文件夹";
                    if (dilog.ShowDialog() == System.Windows.Forms.DialogResult.OK || dilog.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
                    {
                        path = dilog.SelectedPath+"\\";
                        WriteQuestionInWord(path);
                    }
                }


                //foreach (var item in questionName)
                //{
                //    MessageBox.Show(item);
                //}

            }


        }


        private void RbXuanZeF_Click(object sender, RoutedEventArgs e)
        {
            labXuanZeAll.Visibility = Visibility.Visible;
            stXuanZe.Visibility = Visibility.Collapsed;
            XuanZeAll.Visibility = Visibility.Visible;
        }
        private void RbXuanZeT_Click(object sender, RoutedEventArgs e)
        {
            labXuanZeAll.Visibility = Visibility.Collapsed;
            XuanZeAll.Visibility = Visibility.Collapsed;
            stXuanZe.Visibility = Visibility.Visible;
        }
        private void TianKongF_Click(object sender, RoutedEventArgs e)
        {
            labTiankongAll.Visibility = Visibility.Visible;
            stTianKong.Visibility = Visibility.Collapsed;
            TianKongAll.Visibility = Visibility.Visible;
        }
        private void TianKongT_Click(object sender, RoutedEventArgs e)
        {
            labTiankongAll.Visibility = Visibility.Collapsed;
            stTianKong.Visibility = Visibility.Visible;
            TianKongAll.Visibility = Visibility.Collapsed;
        }
        private void PanDuanF_Click(object sender, RoutedEventArgs e)
        {
            labPanDuanAll.Visibility = Visibility.Visible;
            stPanDuan.Visibility = Visibility.Collapsed;
            PanDuanAll.Visibility = Visibility.Visible;
        }
        private void PanDuanT_Click(object sender, RoutedEventArgs e)
        {
            labPanDuanAll.Visibility = Visibility.Collapsed;
            stPanDuan.Visibility = Visibility.Visible;
            PanDuanAll.Visibility = Visibility.Collapsed;
        }
        private void SheJiF_Click(object sender, RoutedEventArgs e)
        {
            labSheJiAll.Visibility = Visibility.Visible;
            stSheJi.Visibility = Visibility.Collapsed;
            SheJiAll.Visibility = Visibility.Visible;
        }
        private void SheJiT_Click(object sender, RoutedEventArgs e)
        {
            labSheJiAll.Visibility = Visibility.Collapsed;
            stSheJi.Visibility = Visibility.Visible;
            SheJiAll.Visibility = Visibility.Collapsed;
        }

        private void XuanZeAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (XuanZeAll.Text != "")
            {
                writeData.xuanzeAllNum = int.Parse(XuanZeAll.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }           
        }
        private void TianKongAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TianKongAll.Text != "")
            {
                writeData.tiankongAllNum = int.Parse(TianKongAll.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void PanDuanAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PanDuanAll.Text != "")
            {
                writeData.panduanAllNum = int.Parse(PanDuanAll.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void SheJiAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SheJiAll.Text != "")
            {
                writeData.shejiAllNum = int.Parse(SheJiAll.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void XuanZeC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (XuanZeC.Text != "")
            {
                writeData.xuanzeCNum = int.Parse(XuanZeC.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void XuanZeB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (XuanZeB.Text != "")
            {
                writeData.xuanzeBNum = int.Parse(XuanZeB.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void XuanZeA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (XuanZeA.Text != "")
            {
                writeData.xuanzeANum = int.Parse(XuanZeA.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void TianKongC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TianKongC.Text != "")
            {
                writeData.tiankongCNum = int.Parse(TianKongC.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void TianKongB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TianKongB.Text != "")
            {
                writeData.tiankongBNum = int.Parse(TianKongB.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void TianKongA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TianKongA.Text != "")
            {
                writeData.tiankongANum = int.Parse(TianKongA.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void PanDuanC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PanDuanC.Text != "")
            {
                writeData.panduanCNum = int.Parse(PanDuanC.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void PanDuanB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PanDuanB.Text != "")
            {
                writeData.panduanBNum = int.Parse(PanDuanB.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void PanDuanA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PanDuanA.Text != "")
            {
                writeData.panduanANum = int.Parse(PanDuanA.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void SheJiC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SheJiC.Text != "")
            {
                writeData.shejiCNum = int.Parse(SheJiC.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void SheJiB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SheJiB.Text != "")
            {
                writeData.shejiBNum = int.Parse(SheJiB.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
        private void SheJiA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SheJiA.Text != "")
            {
                writeData.shejiANum = int.Parse(SheJiA.SelectedValue.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }
    }
}
