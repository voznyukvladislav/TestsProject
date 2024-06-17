namespace TechTests_API.DTOs
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Categories { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
    }
}
