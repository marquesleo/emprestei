using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("jogo")]
    public class Jogo:IEntity
    {

        [Key]
        public int Id { get; set; }

        public int Usuario { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(100, ErrorMessage = "Descrição não deve ter mais que 100 caracteres")]
        public string Descricao { get; set; }
            
    }
}
