using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        #region Variaveis

        private readonly IProdutoAppService _produtoApp;
        private readonly IClienteAppService _clienteApp;

        public ProdutosController(IProdutoAppService produtoApp, IClienteAppService clienteApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
        }

        #endregion

        #region GET

        public ActionResult Index()
        {
            var ProdutoViewModel = Mapper.Map<IEnumerable<Produto>,
                                   IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());

            return View(ProdutoViewModel);
        }


        public ActionResult Edit(int id)
        {
            var Produto = _produtoApp.GetById(id);
            var ProdutoViewModel = Mapper.Map<Produto, ProdutoViewModel>(Produto);
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");

            return View(ProdutoViewModel);
        }

        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");
            return View();
        }

        public ActionResult Details(int id)
        {
            var Produto = _produtoApp.GetById(id);
            var ProdutoViewModel = Mapper.Map<Produto, ProdutoViewModel>(Produto);

            return View(ProdutoViewModel);
        }
        
        #endregion

        #region POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel Produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(Produto);
                _produtoApp.Add(produtoDomain);

                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");
            return View(Produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel Produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(Produto);
                _produtoApp.Update(produtoDomain);

                return RedirectToAction("Index");
            }
            return View(Produto);
        }

        public ActionResult Delete(int id)
        {
            var Produto = _produtoApp.GetById(id);
            var ProdutoViewModel = Mapper.Map<Produto, ProdutoViewModel>(Produto);

            return View(ProdutoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var Produto = _produtoApp.GetById(id);
            _produtoApp.Remove(Produto);
            return RedirectToAction("Index");
        }

        #endregion


    }
}
