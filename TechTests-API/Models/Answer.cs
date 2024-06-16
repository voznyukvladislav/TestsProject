using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTests_API.Models
{
    internal class Answer
    {
        public int Id { get; set; }
        public List<AnswerValue> AnswerValues { get; set; } = new();

        public Question Question { get; set; } = new();
        public int QuestionId { get; set; }
    }
}
