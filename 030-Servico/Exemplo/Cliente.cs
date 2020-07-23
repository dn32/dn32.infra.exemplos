using System.ComponentModel.DataAnnotations;
using dn32.infra;

public class Cliente : DnEntidade
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public string Nome { get; set; }
}
