using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSysGarcom.Models;

[Table("Cardapio")]
public class Produto
{
    [Key][Column("CODIGO")]public string? Codigo { get; set; }  
    [Column("DESCRICAO")]public string? Descricao { get; set; }  
    [Column("GRUPO")]public string? Grupo { get; set; }  
    [Column("PVENDA1")]public double Preco1 { get; set; }  
    [Column("PVENDA2")]public double Preco2 { get; set; }  
    [Column("PVENDA3")]public double Preco3 { get; set; }  
}
