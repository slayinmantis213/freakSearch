#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace freakSearch.Models;

public class PresentedBy
{
    [Key]
    public int Id { get; set; }
    public int PresenterId { get; set; }
    public int EpisodeId { get; set; }
    public Presenter? Presenter { get; set; }
    public Episode? Episode { get; set; }
}