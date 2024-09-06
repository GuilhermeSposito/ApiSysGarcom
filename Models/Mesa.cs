using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiSysGarcom.Models;

public class Mesa
{
    [Key][Column("CODIGO")] public string? Codigo { get; set; }
    [Column("PRACA")] public string? Praca { get; set; }
    [Column("TIPO")] public string? Tipo { get; set; }
    [Column("CARTAO")] public string? Cartao { get; set; }
    [Column("BLOQUEADO")] public bool Bloqueado { get; set; }
}
