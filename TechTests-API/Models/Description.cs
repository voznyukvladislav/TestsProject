﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTests_API.Models
{
    public class Description
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty;

        public List<Question> Questions { get; set; } = new();
    }
}
