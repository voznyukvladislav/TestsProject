using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace TechTests_API.Models
{
    public class Result
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string ResultJson { get; set; } = string.Empty;
        
        public int UserId { get; set; }
        public User User { get; set; } = new();

        public int QuestionGroupId { get; set; }
        public QuestionGroup QuestionGroup { get; set; } = new();
    }
}
