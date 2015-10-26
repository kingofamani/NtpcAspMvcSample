using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace s01.Models
{
    public class User
    {
        [DisplayName("代碼")]//02-1
        public int UserID { get; set; }//01-1
        [DisplayName("姓名")]
        public string Name { get; set; }
        [CheckAdult]//xx
        //[Required(ErrorMessage="錯誤！請輸入年齡")]
        [DisplayName("年齡")]
        public int Age { get; set; }
    }
}