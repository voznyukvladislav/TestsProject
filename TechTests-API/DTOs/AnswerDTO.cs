namespace TechTests_API.DTOs
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty;
        public bool Checked { get; set; } = false;
    }
}
