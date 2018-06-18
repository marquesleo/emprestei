using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emprestei.Controllers
{
    public class EmprestimoController : Controller
    {

        private IHttpContextAccessor _httpContextAccessor;
        private IRepositoryWrapper _repository;

        public EmprestimoController(IRepositoryWrapper repository,
                               IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }


        public IActionResult Index()
        {
            int usuarioId = getUsuarioId();
            List<Entities.Models.Amigo> amigos = getAmigos(usuarioId);

          
            ViewBag.amigos = amigos;

            return View();
        }

        private List<Entities.Models.Amigo> getAmigos(int usuarioId)
        {
            return _repository.Amigo.ObterTodos(usuarioId).ToList();
        }

        private int getUsuarioId()
        {
            return Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado"));
        }

        [HttpPost]
        public IActionResult GravarEmprestimo(Models.Emprestimo Emprestimo)
        {

            try
            {
                _repository.Emprestimo.Excluir(getUsuarioId());
                if (Emprestimo.lstJogosEmprestados.Any())
                {
                    foreach (var item in Emprestimo.lstJogosEmprestados)
                    {
                        var emprestimo = new Entities.Models.Emprestimo();
                        emprestimo.Amigo = item.geAmigoId;
                        if (item.emprestado)
                            emprestimo.Emprestado = 1;
                        else
                            emprestimo.Emprestado = 0;
                        emprestimo.Jogo = item.getJogoId;
                        emprestimo.Usuario = getUsuarioId();
                        _repository.Emprestimo.CriarEmprestimo(emprestimo);
                    }
                }

                return View();
            }
            catch (Exception)
            {

                throw;
            }

          
        }

        [HttpPost]
        public IActionResult BuscarJogosEmprestado(Entities.Models.Amigo amigo)
        {

            Models.Emprestimo Emprestimo = retornarEmprestimo(amigo.Id);
            Emprestimo.lstAmigos = getAmigos(getUsuarioId());
            Emprestimo.Usuario = getUsuarioId();
            ViewBag.Emprestimo = Emprestimo;
            return View();
        }

     


        private Models.Emprestimo retornarEmprestimo(int amigoId)
        {
            var usuarioId = getUsuarioId();
            List<Entities.Models.Emprestimo> emprestimos = _repository.Emprestimo.ObterTodos(usuarioId).ToList();
            List<Entities.Models.Jogo> jogos = _repository.Jogo.ObterTodos(usuarioId).ToList();
            var lstJogosEmprestados = new List<Models.JogoEmprestado>();

            foreach (var item in jogos)
            {

                bool emprestado = false;
                if (emprestimos.Any())
                {
                    var oEmprestimo = (from obj in emprestimos
                                       where obj.Amigo == amigoId && item.Id == obj.Jogo
                                       select obj).FirstOrDefault();
                    if (oEmprestimo != null)
                    {
                        emprestado = (oEmprestimo.Emprestado == 1);
                    }

                }
                var jogoEmprestado = new Models.JogoEmprestado(item, amigoId, emprestado);
                lstJogosEmprestados.Add(jogoEmprestado);

            }
            var Emprestimo = new Models.Emprestimo();
            Emprestimo.lstJogosEmprestados = lstJogosEmprestados;
            return Emprestimo;
        }
    }
}