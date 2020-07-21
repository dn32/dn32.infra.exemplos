
using dn32.infra;
using System.ComponentModel.DataAnnotations;

namespace CustomController
{
    public class EntidadeComAPI : DnEntidade
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}