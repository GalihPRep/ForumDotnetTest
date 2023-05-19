using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnswerApp.Models.Entity
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
    }
}