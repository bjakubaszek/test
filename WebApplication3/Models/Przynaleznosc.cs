using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

[Table("Przynaleznosc")]
public class Przynaleznosc
{
    [Column("ID")]
    [Key]
    public int Id { get; set; }
    
    [Column("Partia_ID")]
    public int PartiaId { get; set; }
    
    [Column("Polityk_ID")]
    public int PolitykId { get; set; }
    
    [Column("Od")]
    public DateTime Od { get; set; }

    [Column("Do")]
    public DateTime? Do { get; set; }
    
    [ForeignKey(nameof(PolitykId))]
    public virtual Polityk? Polityk { get; set; }
    
    [ForeignKey(nameof(PartiaId))]
    public virtual Partia? Partia { get; set; }
}