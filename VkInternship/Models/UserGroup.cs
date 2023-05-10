using System.ComponentModel.DataAnnotations.Schema;

namespace VkInternship.Models
{
    public class UserGroup
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        public string Code { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; }
    }
}
