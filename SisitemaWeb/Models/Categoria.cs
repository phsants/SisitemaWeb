using System.ComponentModel.DataAnnotations;

namespace SisitemaWeb.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }
    }
}
