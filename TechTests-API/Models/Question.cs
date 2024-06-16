using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTests_API.Models
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

        public List<Category> Categories { get; set; } = new();
        public List<Answer> Answears { get; set; } = new();
    }
}
