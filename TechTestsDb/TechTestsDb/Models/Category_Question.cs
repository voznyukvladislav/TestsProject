using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestsDb.Models
{
    internal class Category_Question
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new();

        public int QuestionId { get; set; }
        public Question Question { get; set; } = new();
    }
}
