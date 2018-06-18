using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("amigo")]
    public class Amigo:IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome não deve ter mais que 100 caracteres")]
        public string Nome { get; set; }

        public int Usuario { get; set; }
    }
}
