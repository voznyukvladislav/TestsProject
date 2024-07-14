using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestsDb.Models
{
    internal class Question
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty;
        public bool IsCaseSensitive { get; set; } = false;

        public Description? Description { get; set; } = new();
        public int? DescriptionId { get; set; }

        public Type Type { get; set; } = new();
        public int TypeId { get; set; }

        public List<Category_Question> Category_Question { get; set; } = new();

        public List<Answer> Answers { get; set; } = new();

        public List<Question_QuestionGroup> Question_QuestionGroup { get; set; } = new();
    }
}
