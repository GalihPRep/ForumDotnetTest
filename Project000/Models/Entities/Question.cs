using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AccountApp.Models.Entities
{
    [Table("question")]
    public class Question
    {
        [Key]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public string? Place { get; set; }
        public string? Description { get; set; }
        public string? AuthorUsername { get; set; }
        [JsonIgnore]
        public Account? Author { get; set; }
        [JsonIgnore]
        public ICollection<Answer>? Answers { get; set; }
    }
}