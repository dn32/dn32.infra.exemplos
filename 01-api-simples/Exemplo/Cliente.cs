using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dn32.infra.dados;

[Table ("clientes")]
public class Cliente : DnEntidade {
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
}