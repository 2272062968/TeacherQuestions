using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherDatabase
{
    public class WriteData
    {
        //标题
        public string title { get; set; }
        //试题类型
        public string questionType { get; set; }
        //选择题数量
        public int xuanzeAllNum { get; set; }
        //选择题简单数量
        public int xuanzeCNum { get; set; }
        //选择题一般数量
        public int xuanzeBNum { get; set; }
        //选择题较难数量
        public int xuanzeANum { get; set; }
        //填空题数量
        public int tiankongAllNum { get; set; }
        //填空题简单数量
        public int tiankongCNum { get; set; }
        //填空题一般数量
        public int tiankongBNum { get; set; }
        //填空题较难数量
        public int tiankongANum { get; set; }
        //判断题数量
        public int panduanAllNum { get; set; }
        //判断题简单数量
        public int panduanCNum { get; set; }
        //判断题一般数量
        public int panduanBNum { get; set; }
        //判断题较难数量
        public int panduanANum { get; set; }
        //设计题数量
        public int shejiAllNum { get; set; }
        //设计题简单数量
        public int shejiCNum { get; set; }
        //设计题一般数量
        public int shejiBNum { get; set; }
        //设计题较难数量
        public int shejiANum { get; set; }
        //页眉
        public string header { get; set; }

        //public WriteData()
        //{
        //    xuanzeAllNum = 0;
        //}
    }
}
