namespace TechTests_API.DTOs
{
    public class CategoryResultDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public double Result { get; set; }
        public double Total { get; set; }
        public string Percentage { get; set; } = string.Empty;
    }
}
