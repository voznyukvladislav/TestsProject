﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestsDb.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public List<Result> Results { get; set; } = new();
    }
}
