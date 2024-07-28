using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTests_API.Models
{
    public class Question_QuestionGroup
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; } = new();

        public int QuestionGroupId { get; set; }
        public QuestionGroup QuestionGroup { get; set; } = new();
    }
}
