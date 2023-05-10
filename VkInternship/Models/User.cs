using System.ComponentModel.DataAnnotations.Schema;

namespace VkInternship.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("login")]
        public string? Login { get; set; }

        [Column("password")]
        public string? Password { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column("user_group_id")]
        public int UserGroupId { get; set; }

        [Column("user_state_id")]
        public int UserStateId { get; set; }

        public UserGroup? UserGroup { get; set; }

        public UserState? UserState { get; set; }
    }
}
