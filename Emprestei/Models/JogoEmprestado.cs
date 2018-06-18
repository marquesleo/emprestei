using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprestei.Models
{
    public class JogoEmprestado
    {
        private Entities.Models.Jogo jogo;
        private int amigoId;
        public JogoEmprestado(Entities.Models.Jogo jogo, int amigoId,  bool emprestado)
        {
            this.jogo = jogo;
            this.emprestado = emprestado;
            this.amigoId = amigoId;
        }

        public string DescricaoJogo {
            get
            {
                
                return jogo.Descricao;
            }
        }

        public int getJogoId { get { return jogo.Id; } }
        public int geAmigoId { get { return amigoId; } }
        public bool emprestado { get; set; }


    }
}
