using System.ComponentModel.DataAnnotations;

namespace SistemaWeb.Models
{
    public class Tipo
    {
        [Key]
        public int Id { get; set; }

        public string Metodospagamento { get; set; }
    }
}
