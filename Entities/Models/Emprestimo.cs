using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models
{
    [Table("emprestimo")]
    public class Emprestimo : IEntity
    {

        [Key]
        public int Id { get; set; }
             
        public byte Emprestado { get; set; }
      
        public int Jogo { get; set; }

        public int Amigo { get; set; }
        
        public int Usuario { get; set; }

    }
}
