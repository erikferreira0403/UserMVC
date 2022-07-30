using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserMVC.Models;
using UserMVC.Repositorio;

namespace UserMVC.Controllers
{
    public class ContatoController : Controller
    {
        public readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contato =_contatoRepositorio.BuscarTodos();
            return View(contato);
        }
        public IActionResult Criar()
        {

            return View();
        }
        public IActionResult Editar(int Id)
        {
           ContatoModel contato = _contatoRepositorio.ListarPorId(Id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int Id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(Id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastro com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos cadastrar, tente novamente\n erro:{erro.Message}";
                throw;
            }
    
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {

                TempData ["MensagemErro"] = $"Ops! Não conseguimos atualizar, tente novamente\n erro:{erro.Message}"; 
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int Id)
        {
            try
            {
            bool apagado = _contatoRepositorio.Apagar(Id);
                if (apagado) { 
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso"; 
                }
                else { 
                    TempData["MensagemErro"] = $"Ops! Não conseguimos apagar seu contato"; }
                        return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos apagar seu contato\n erro: {erro}";
            
            throw;
            }
            
        }



    }
}
