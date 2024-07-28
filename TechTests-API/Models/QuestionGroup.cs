using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTests_API.Models
{
    public class QuestionGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Question_QuestionGroup> Question_QuestionGroup { get; set; } = new();
        public List<Result> Results { get; set; } = new();
    }
}
