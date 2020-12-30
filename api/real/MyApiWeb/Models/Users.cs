using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApiWeb.Models
{
    [Table("Users")]
    public class Users
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        /// <example></example>
        [DefaultValue("")]
        [Column("username")]
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Password User
        /// </summary>
        /// <example></example>
        [DefaultValue("")]
        [Column("password")]
        [Required]
        public string Password { get; set; }


        /// <summary>
        /// Email User
        /// </summary>
        /// <example></example>
        [DefaultValue("")]
        [Column("email")]
        public string Email { get; set; }

        /// <summary>
        /// Role User
        /// </summary>
        /// <example>user</example>
        [DefaultValue("user")]
        [Column("role")]
        public string Role { get; set; }

        /// <summary>
        /// First Name User
        /// </summary>
        /// <example></example>
        [DefaultValue("")]
        [Column("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name User
        /// </summary>
        /// <example></example>
        [DefaultValue("")]
        [Column("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Image User
        /// </summary>
        /// <example></example>
        [DefaultValue("guest.png")]
        [Column("image")]
        public string Image { get; set; }

        /// <summary>
        /// Token User
        /// </summary>
        /// <example></example>
        [DefaultValue("")]
        [Column("token")]
         public string Token { get; set; }
    }

    public class UsersAuth {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
