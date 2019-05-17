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
        //测试
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Xanswer.GetType.ToString());
        }

        private void AddType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (addType.SelectedIndex != -1)
            {
                Xtype.Text = "";
            }
        }
    }
}
