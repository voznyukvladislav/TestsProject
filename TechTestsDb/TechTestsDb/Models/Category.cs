﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestsDb.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Question> Questions { get; set; } = new();
    }
}
