﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Administrator
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        //通过手机或者邮箱来找回密码
        public int Phone { get; set; }
        public string email { get; set; }
    }
}
