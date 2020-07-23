using dn32.infra;
using System.ComponentModel.DataAnnotations;

public class Endereco: DnEntidade
{
    [Key]
    public int Id { get; set; }

    public int ClienteId { get; set; }
    
    public string Rua { get; set; }
    
    public int Numero { get; set; }
}