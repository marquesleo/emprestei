using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emprestei.Controllers
{
    public class AmigoController : Controller
    {

        private IHttpContextAccessor _httpContextAccessor;
        private IRepositoryWrapper _repository;

        public AmigoController(IRepositoryWrapper repository,
                               IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

     
        public IActionResult Index()
        {
            var usuarioId = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado"));
            var amigos = _repository.Amigo.ObterTodos(usuarioId);
            ViewBag.ListaAmigos = amigos;
            return View();
        }

        [HttpPost]
        public IActionResult CriarAmigo(Entities.Models.Amigo amigo)
        {

            if (ModelState.IsValid)
            {
                var usuarioId = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("IdUsuarioLogado"));
                amigo.Usuario = usuarioId;
                _repository.Amigo.CriarAmigo(amigo);

                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CriarAmigo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var amigo = _repository.Amigo.retornarAmigo(id);
            _repository.Amigo.Excluir(amigo.Id);
            return View();
        }
    }
}