using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTests_API.Models
{
    internal class AnswearValue
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty;

        public Answear Answear { get; set; } = new();
        public int AnswearId { get; set; }
    }
}
