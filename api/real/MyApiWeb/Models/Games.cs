using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApiWeb.Models
{
    [Table("Games")]
    public class Games
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("title")]
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("desc")]
        public string Desc { get; set; }

        [Column("platforms")]
        public string Platforms { get; set; }

        [Column("platform_used")]
        public string Platform_used { get; set; }

        [Column("genre")]
        public string Genre { get; set; }

        [Column("release_date")]
        public DateTime Release_date { get; set; }

        [Column("publisher")]
        public string Publisher { get; set; }

        [Column("developer")]
        public string Developer { get; set; }

        [Column("cover")]
        public string Cover { get; set; }

        [Column("usersId")]
        public int UsersId { get; set; }
    }
}
