using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emprestei.Controllers
{
    public class UsuarioController : Controller
    {
        private IRepositoryWrapper _repository;
        public UsuarioController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

       public IActionResult Login(int? id)
        {
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                }

            }
            return View();
        }


        public IActionResult validarLogin(Entities.Models.Usuario usuario)
        {
            var oUsuario = _repository.Usuario.retornarUsuario(usuario.login, usuario.senha);
               
            if (oUsuario != null && !string.IsNullOrEmpty(oUsuario.login))
            {
                HttpContext.Session.SetString("NomeUsuarioLogado", oUsuario.login);
                HttpContext.Session.SetString("IdUsuarioLogado", oUsuario.Id.ToString());

                return RedirectToAction("Menu", "Home");
            }
            else
            {
                TempData["MensagemLoginInvalido"] = "Login inválido!";
                return RedirectToAction("Login");
            }
                
        }

        [HttpPost]
       
        public IActionResult Registrar(Entities.Models.Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                _repository.Usuario.CriarUsuario(usuario);
                return RedirectToAction("Sucesso");
            }
                return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        public IActionResult Sucesso()
        {
            return View();
        }

      

    }
}