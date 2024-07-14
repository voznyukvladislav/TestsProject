using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestsDb.DTOs
{
    internal class QuestionDTO
    {
        public string Id { get; set; } = string.Empty;
        public string TypeId { get; set; } = string.Empty;
        public string DescriptionId { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string IsCaseSensitive { get; set; } = string.Empty;
    }
}
