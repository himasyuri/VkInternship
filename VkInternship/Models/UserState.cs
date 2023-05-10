using System.ComponentModel.DataAnnotations.Schema;

namespace VkInternship.Models
{
    public class UserState
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        public string Code { get; set; } = "Active";

        [Column("description")]
        public string? Description { get; set; }
    }
}
