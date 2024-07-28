using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTests_API.Models
{
    public class Category_Question
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new();

        public int QuestionId { get; set; }
        public Question Question { get; set; } = new();
    }
}
