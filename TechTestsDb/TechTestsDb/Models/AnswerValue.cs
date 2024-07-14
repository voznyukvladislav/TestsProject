using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestsDb.Models
{
    internal class AnswerValue
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }

        public Answer Answer { get; set; } = new();
        public int AnswerId { get; set; }
    }
}
