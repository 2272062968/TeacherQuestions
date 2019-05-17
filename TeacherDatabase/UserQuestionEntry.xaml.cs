using System;
using System.Collections.Generic;
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

        private void Xtype_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Xtype.Text != "")
            {
                addType.SelectedIndex = -1;
            }
        }
        

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
            selectXtype.Text = "";
            tbxChapter.Text = "";
            tbxQuestion.Text = "";
            tbxAnswer.Text = "";
            C.IsChecked = false;
            B.IsChecked = false;
            A.IsChecked = false;
            tbxIssueAnthor.Text = "";
        }
        private void selectType_LostFocus(object sender, RoutedEventArgs e)
        {
            if (selectXtype.Text != "")
            {
                choice.IsChecked = false;
                judge.IsChecked = false;
                design.IsChecked = false;                    
            }
        }
        
        private void queType_Click(object sender, RoutedEventArgs e)
        {
            selectXtype.Text = "";
        }
    }
}
