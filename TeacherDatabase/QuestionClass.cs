using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherDatabase
{
    public class QuestionClass
    {
        //主码id
        public string id { get; set; }
        //学科
        public string subject { get; set; }
        //试题类型
        public string type { get; set; }
        //章节
        public string chapter { get; set; }
        //题目
        public string name { get; set; }
        //难度
        public string diffculty { get; set; }
        //答案
        public string answer { get; set; }
        //出题人
        public string anthor { get; set; }
        //修改日期
        public string datatime { get; set; }
        //操作账号
        public string account { get; set; }
    }
}
