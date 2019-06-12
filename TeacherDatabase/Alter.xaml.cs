using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace TeacherDatabase
{
    /// <summary>
    /// Alter.xaml 的交互逻辑
    /// </summary>
    public partial class Alter : Window
    {


        string con = "Server=39.108.153.12;port=3306;user=teacher;password=myrootsql;database=teacher;";
        QuestionClass QC;

        public Alter(QuestionClass question)
        {
            InitializeComponent();
            this.DataContext = question;
            if (question.share == "0")
            {
                isShare.IsChecked = true;
            }
            else
            {
                isShare.IsChecked = false;
            }
            QC = question;
            if (QC.account == GlobalParams.MyAccount)
            {
                isShare.IsEnabled = true;
                isShare.Opacity = 1;
                del.IsEnabled = true;
                save.IsEnabled = true;
            }
            else
            {
                isShare.IsEnabled = false;
                isShare.Opacity = 0.5;
                del.IsEnabled = false;
                save.IsEnabled = false;
            }
        }

        private void Btn_Delete(object sender, RoutedEventArgs e)
        {

            GlobalParams.DataRefresh = true;
            MySqlConnection mycon = new MySqlConnection(con);
            mycon.Open();
            string delete = "delete from question where id='" + QC.id + "'";
            MySqlCommand cmd = new MySqlCommand(delete, mycon);
            int result = cmd.ExecuteNonQuery();
            //MessageBox.Show(result.ToString());
            this.Close();

        }

        

        private void Btn_Save(object sender, RoutedEventArgs e)
        {
            string share;
            if (isShare.IsChecked == true)
            {
                share = "0";
            }
            else
            {
                share = "1";
            }

            MySqlConnection mycon = new MySqlConnection(con);
            mycon.Open();
            string revise = "UPDATE question SET subject='" + QC.subject + "',type='" + QC.type +
                "',chapter='" + QC.chapter + "',name='" + QC.name + "',answer='" + QC.answer +
                "',diffculty='" + QC.diffculty + "',anthor='" + QC.anthor + "',account='"
                + GlobalParams.MyAccount + "' "+",share="+share+" WHERE id = '" + QC.id + "'";
            MySqlCommand cmd = new MySqlCommand(revise, mycon);
            int result = cmd.ExecuteNonQuery();
            //MessageBox.Show(result.ToString());

            GlobalParams.DataRefresh = true;
            
            this.Close();
        }

    }
}
