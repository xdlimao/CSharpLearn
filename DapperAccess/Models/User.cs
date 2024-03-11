﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAccess.Models
{
        [Table("[User]")]
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string PasswordHash { get; set; }
            public string Bio { get; set; }
            public string Image { get; set; }
            public string Slug { get; set; }
        }
    
}

