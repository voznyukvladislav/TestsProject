namespace TechTests_API.DTOs
{
    public class ResultDTO
    {
        public int QuestionGroupId { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<CategoryResultDTO> CategoryResults { get; set; } = new();
        public double Result { get; set; }
        public double Total { get; set; }
        public string Percentage { get; set; } = string.Empty;
    }
}
