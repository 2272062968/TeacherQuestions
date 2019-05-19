using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
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
        public UserCreateExam()
        {
            InitializeComponent();
            AddComBoxItem();
            foreach (var subName in GlobalParams.subjectName.Split(','))
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = subName;
                quesType.Items.Add(item);
            }
        }
        void AddComBoxItem()
        {
            for (int i = 1; i <= 30; i++)
            {
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

        void WriteQuestionInWord()
        {
            string strText = @"本系统就是针对环境星数据，对经过检验的标准处理流程进行系统化开发，" +
                           "并可以使用处理过后的数据生成一些初级地表参数产品。编写这份测试分析报告的" +
                           "目的是为了让本系统的用户通过本报告更加信任本系统，测试分析报告主要是对" +
                          "软件系统的测试分析工作进行总结与整理。本报告的主要读者是将要使用本系统" +
                            "或者需要对环境星进行处理并生产植被指数标准产品的用户。";
            string strResult = "";
            Object Nothing = System.Reflection.Missing.Value;
            Directory.CreateDirectory(@"E:\TEMP\SaveWord");  //创建文件所在目录

            string wordName = "MyNewWord" + DateTime.Now.ToLongDateString() + ".doc";//文件名

            object wordPathName = @"E:\TEMP\SaveWord\" + wordName;  //文件保存路径

            //创建Word文档
            Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

            //添加页眉
            WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
            WordApp.ActiveWindow.ActivePane.Selection.InsertAfter("");
            WordApp.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;//设置居中
            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;//跳出页眉设置
            WordApp.Selection.ParagraphFormat.LineSpacing = 15f;//设置文档的行间距

            //WordApp.Selection();//插入段落

            WordApp.Selection.Text = "  标题";
            WordApp.Selection.Range.Bold = 2;
            WordApp.Selection.Range.Font.Size = 24;
            WordApp.Selection.Range.Bold = 1;

            //移动焦点并换行
            object count = 14;
            object WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;

            WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
            WordApp.Selection.TypeParagraph();//插入段落
            WordApp.Selection.Text = strText;

            WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
            WordApp.Selection.TypeParagraph();//插入段落
            WordApp.Selection.Text = strText;

            //WordApp.Selection.Range.Font.Size = 12;
            
            //WordDoc.Paragraphs.Last.Range.Text = "\n\n\n\n";//此处会将落款覆盖


            //WordDoc.Paragraphs.Add(ref Nothing);//在最后再增加一段
            //WordDoc.Paragraphs.Last.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;
            //string strText = @"本系统就是针对环境星数据，对经过检验的标准处理流程进行系统化开发，" +
            //               "并可以使用处理过后的数据生成一些初级地表参数产品。编写这份测试分析报告的" +
            //               "目的是为了让本系统的用户通过本报告更加信任本系统，测试分析报告主要是对" +
            //              "软件系统的测试分析工作进行总结与整理。本报告的主要读者是将要使用本系统" +
            //                "或者需要对环境星进行处理并生产植被指数标准产品的用户。";
            //WordDoc.Paragraphs.Last.Range.Text = strText;
            //WordDoc.Paragraphs.Last.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphLeft;

            //WordDoc.Paragraphs.Add(ref Nothing);
            //WordDoc.Paragraphs.Last.Range.Text = "\n\n\n";

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
                WriteQuestionInWord();
            }


           
            

            

        }


    }
}
