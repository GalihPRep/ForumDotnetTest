namespace AnswerApp.Models.Requests
{
    public class AnswerPost
    {
        public string? Content { get; set; }
        public string? AuthorUsername { get; set; }
        public long? QuestionId { get; set; }
    }
}