#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
namespace freakSearch.Models;

public class Episode
{
    [Key]
    public int EpisodeId { get; set; }

    [Required]
    public string Title { get; set; }

    public string EpisodeNumber { get; set; }
    public string Summary { get; set; }
    public string Link { get; set; }
    public string Transcript { get; set; }

}