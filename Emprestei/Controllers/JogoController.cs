using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Emprestei.Controllers
{
    public class JogoController : Controller
    {

        private IRepositoryWrapper _repository;
        private IHttpContextAccessor _httpContextAccessor;

        public JogoController(IRepositoryWrapper repository,IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;

        }

        public IActionResult Index()
        {
            var usuarioId = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado"));
           var jogos = _repository.Jogo.ObterTodos(usuarioId);
            ViewBag.ListaJogos = jogos;

            return View();
        }

        [HttpPost]
        public IActionResult CriarJogo(Entities.Models.Jogo jogo)
        {

            if (ModelState.IsValid)
            {
                var usuarioId = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado"));
                jogo.Usuario = usuarioId;
                _repository.Jogo.CriarJogo(jogo);

                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CriarJogo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var jogo = _repository.Jogo.retornarJogo(id);
            _repository.Jogo.Excluir(jogo.Id);
            return View();
        }




    }
}