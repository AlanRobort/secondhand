﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    //作废
   public class Customers
    {

        public int Id { get; set; }

        public string CustomerName { get; set; }

        //用户名
        public string Username { get; set; }

        //密码
        //需要加密
        public string Password { get; set; }

        public string Gender { get; set; }
        //身份证
        public string Idcard { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }


    }
}
