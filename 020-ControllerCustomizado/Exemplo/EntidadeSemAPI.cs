
using dn32.infra;
using System.ComponentModel.DataAnnotations;

namespace CustomController
{
    [DnControllerApi(gerarAutomaticamente: false)]
    public class EntidadeSemAPI : DnEntidade
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}