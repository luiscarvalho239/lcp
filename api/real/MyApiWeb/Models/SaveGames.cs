using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApiWeb.Models
{
    [Table("SaveGames")]
    public class SaveGames
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("title")]
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Column("is_req_to_100")]
        public bool Is_req_to_100 { get; set; }

        [Column("type_medal")]
        public string Type_medal { get; set; }

        [Column("file_img")]
        public string File_img { get; set; }

        [Column("file_url")]
        public string File_url { get; set; }

        [Column("gamesId")]
        public int GamesId { get; set; }

        [Column("usersId")]
        public int UsersId { get; set; }
    }
}
