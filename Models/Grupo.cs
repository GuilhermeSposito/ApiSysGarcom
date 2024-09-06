using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSysGarcom.Models;

public class Grupo
{
    [Key]public string? Codigo { get; set;}
    [Column("DESCRICAO")] public string? Descricao { get; set; }
    [Column("FAMILIA")] public string? Familia { get; set; }  
    [Column("OCULTATABLET")] public bool Oculta { get; set; }  
    [Column("TOTGRUPO")] public double TOTGRUPO { get; set; }  
}
