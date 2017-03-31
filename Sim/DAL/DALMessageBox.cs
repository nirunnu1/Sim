using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulations
{
   public class DALMessageBox
    {
      private  string[] arr = new[] {
          "กรุนาตั้งเวลา",
          "บันทึกเรียบร้อยแล้ว",
         "ทำงานเสร็จสิ้น"
      };
        public  enum MBset {[Description("กรุนาตั้งเวลา")]settime , save, commit};

        public static DialogResult MessageBoxset(MBset item)
        {
            return MessageBox.Show(item.ToString());
        }
    }
}
