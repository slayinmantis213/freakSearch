#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace freakSearch.Models;

public class Presenter
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Episode> Episodes { get; set; } = new();

}