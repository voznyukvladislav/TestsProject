using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestsDb.Models
{
    internal class Answear
    {
        public int Id { get; set; }
        public List<AnswearValue> AnswearValues { get; set; } = new();

        public Question Question { get; set; } = new();
        public int QuestionId { get; set; }
    }
}
