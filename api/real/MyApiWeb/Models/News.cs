using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApiWeb.Models
{
    [Table("News")]
    public class News
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

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("cover")]
        public string Cover { get; set; }

        [Column("category")]
        public string Category { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("source")]
        public string Source { get; set; }

        [Column("usersId")]
        public int UsersId { get; set; }
    }
}
