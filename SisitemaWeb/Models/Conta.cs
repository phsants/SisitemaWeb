using System.ComponentModel.DataAnnotations;

namespace SistemaWeb.Models
{
    public class Conta
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [StringLenght(200)]
        [Display(Name = "Descricao")]
        public string descricao { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Colunm(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Data de Pagamento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DataPagamento { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [Display(Name = "Data de Vencimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DataVencimento { get; set; } = DateTime.Now;

        public int TipoId { get; set; }
        public virtual Tipo Tipo { get; set; }

        public int ClassificacaoId { get; set; }
        public virtual Classificacao Classificacao { get; set; }
    }
}
