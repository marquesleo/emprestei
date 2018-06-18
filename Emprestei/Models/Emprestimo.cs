using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprestei.Models
{
    public class Emprestimo
    {
     
        public int Usuario { get; set; }

        public List<Entities.Models.Amigo> lstAmigos;

        private List<Models.JogoEmprestado> _lstJogoEmprestados;

       public  List<Models.JogoEmprestado> lstJogosEmprestados
        {
            get
            {
                if (_lstJogoEmprestados == null)
                    _lstJogoEmprestados = new List<JogoEmprestado>();
                return _lstJogoEmprestados;
            }
            set
            {
                _lstJogoEmprestados = value;
            }
        }

        public Emprestimo()
        {
            
        }
    }
}
