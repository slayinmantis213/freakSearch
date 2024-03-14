#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace freakSearch.Models;

[Table("freakonomics_episodes")]
public class Episode
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    [Column("NUMBER")]
    public string EpisodeNumber { get; set; }
    public string Summary { get; set; }
    public string Link { get; set; }
    public string Transcript { get; set; }

}