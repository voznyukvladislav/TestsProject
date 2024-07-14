using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestsDb.DTOs
{
    internal class ResultDTO
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string QuestionGroupId { get; set; } = string.Empty;
        public string DateTime { get; set; } = string.Empty;
        public string ResultJson { get; set; } = string.Empty;
    }
}
