using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace s01.Models
{
    public class CheckAdult:ValidationAttribute
    {
        //xx-1
        public CheckAdult()
        {
            ErrorMessage = "你還沒滿18歲喔！";
        }

        //xx-2
        public override bool IsValid(object value)
        {
            //int age = (int)value;
            //if (age < 18)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}

            return (int)value < 18;
        }
    }
}