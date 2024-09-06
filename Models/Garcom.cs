using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSysGarcom.Models;

public class Garcom
{
    [Key][Column("CODIGO")] public string? Codigo { get; set; }
    [Column("NOME")] public string? Nome { get; set; }
    [Column("SENHA")] public string? Senha { get; set; }
    [Column("VALOR")] public double Valor { get; set; }
}
