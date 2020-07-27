using dn32.infra;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Usuario : DnEntidade
{
    [Key]
    public long Id { get; set; }

    public string Email { get; set; }

    [Newtonsoft.Json.JsonIgnore]
    [NotMapped]
    public string Senha { get; set; }

    public string SenhaCifrada { get; set; }

    public string Nome { get; set; }
}
