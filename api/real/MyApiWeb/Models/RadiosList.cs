using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyApiWeb.Models
{
  [Table("RadiosList")]
  public class RadiosList
  {
    [Column("id")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Radio title
    /// </summary>
    /// <example></example>
    [DefaultValue("")]
    [Column("radiotitle")]
    [Required]
    public string RadioTitle { get; set; }

    /// <summary>
    /// Radio source
    /// </summary>
    /// <example></example>
    [DefaultValue("")]
    [Column("radiosrc")]
    [Required]
    public string RadioSrc { get; set; }

    /// <summary>
    /// Radio image
    /// </summary>
    /// <example></example>
    [DefaultValue("")]
    [Column("radioimage")]
    public string RadioImage { get; set; }
  }
}
