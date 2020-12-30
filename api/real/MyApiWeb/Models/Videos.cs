using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApiWeb.Models
{
    [Table("Videos")]
    public class Videos
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Video Source
        /// </summary>
        /// <example>v1.mp4</example>
        [DefaultValue("v1.mp4")]
        [Column("src")]
        [Required]
        public string Src { get; set; }

        /// <summary>
        /// Video Type
        /// </summary>
        /// <example>video/mp4</example>
        [DefaultValue("video/mp4")]
        [Column("type")]
        public string Type { get; set; }
    }
}
