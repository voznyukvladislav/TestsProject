using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestsDb.DTOs
{
    internal class AnswerValueDTO
    {
        public string Id { get; set; } = string.Empty;
        public string AnswerId { get; set; } = string.Empty;
        public string Value { get; set;} = string.Empty;
        public string IsCorrect { get; set; } = string.Empty;
    }
}
