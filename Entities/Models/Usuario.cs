using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Usuario : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Preencha o Login!")]
        public string login { get; set; }


        [Required(ErrorMessage = "Preencha a senha!")]
        public string senha { get; set; }
    }
}
