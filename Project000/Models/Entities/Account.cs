using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AccountApp.Models.Entities
{
    [Table("account")]
    public class Account
    {
        [Key, Required]
        public string? Username { get; set; }
        public ICollection<Question>? Questions { get; set; }
        public ICollection<Answer>? Answers { get; set; }
    }
}
