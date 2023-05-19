using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AccountApp.Models.Entities
{
    [Table("answer")]
    public class Answer
    {
        [Key, Required]
        public string? Id { get; set; }
        public DateTime Created { get; set; }
        public string? Content { get; set; }
        public string? AuthorUsername { get; set; }
        public long? QuestionId { get; set; }
        [JsonIgnore]
        public Account? Author { get; set; }
        [JsonIgnore]
        public Question? Question { get; set; }
    }
}