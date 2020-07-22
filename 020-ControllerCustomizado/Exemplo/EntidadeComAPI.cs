
using dn32.infra;
using System.ComponentModel.DataAnnotations;

public class Usuario2 : DnEntidade
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }
}