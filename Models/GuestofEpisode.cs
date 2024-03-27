#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace freakSearch.Models;

public class GuestofEpisode
{
    [Key]
    public int Id { get; set; }
    public int GuestId { get; set; }
    public int EpisodeId { get; set; }
    public Guest? Guest { get; set; }
    public Episode? Episode { get; set; }
}