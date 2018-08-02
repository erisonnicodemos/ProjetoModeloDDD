using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using System.Collections;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.Application.Interface;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        #region Variaveis

        private readonly IClienteAppService _clienteApp;

        public ClientesController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        #endregion

        #region GET
       
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>,
                                   IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());

            return View(clienteViewModel);
        }


        public ActionResult Edit(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var ClienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(ClienteViewModel);
        }


        public ActionResult Details(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var ClienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(ClienteViewModel);
        }

      
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Especiais()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>,
                                   IEnumerable<ClienteViewModel>>(_clienteApp.ObterClientesEspeciais());

            return View(clienteViewModel);
        }

        #endregion

        #region POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Update(clienteDomain);

                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Delete(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }
               
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _clienteApp.GetById(id);
            _clienteApp.Remove(cliente);
            return RedirectToAction("Index");
        }

        #endregion
       
     
    }
}
