using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiFarmacia.Models

{
    [Table("ClassicFarmacia")]
    public class ClassFarmacia
    {
        // se necessario adicionar mais, são as coisas relacionadas aos produtos
        [Key]
        public int id { get; set; }

        [Required]
        public string Nome { get; set; }
        public string? Categoria { get; set; }
        public string? Fabricante { get; set; }
        public int? Ano { get; set; }
        // usar "?" no int caso tenha que ser um valor diferente de zero, mas pode ser nulo
        public string Descricao { get; set; }
        // O "Status" é obrigatorio em todo caso
        public string Status { get; set; }

    }
}
