namespace TechTests_API.Data
{
    public class Message
    {
        public string Status { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public static Message CreateSuccessful(string title, string value)
        {
            Message message = new();
            message.Status = Constants.MESSAGE_SUCCESS;
            message.Title = title;
            message.Value = value;

            return message;
        }

        public static Message CreateFailed(string title, string value)
        {
            Message message = new();
            message.Status = Constants.MESSAGE_FAILED;
            message.Title = title;
            message.Value = value;

            return message;
        }
    }
}
