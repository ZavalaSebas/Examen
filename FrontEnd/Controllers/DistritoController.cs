using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FrontEnd.Controllers
{
    public class DistritoController : Controller
    {
        private readonly IDistritoHelper _distritoHelper;

        public DistritoController(IDistritoHelper distritoHelper)
        {
            _distritoHelper = distritoHelper;
        }

        // GET: DistritoController
        public ActionResult Index()
        {
            List<DistritoViewModel> lista = _distritoHelper.GetDistritos();
            return View(lista);
        }

        // GET: DistritoController/Details/5
        public ActionResult Details(int id)
        {
            DistritoViewModel distrito = _distritoHelper.GetDistrito(id);
            return View(distrito);
        }

        // GET: DistritoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DistritoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DistritoViewModel distrito)
        {
            try
            {
                _distritoHelper.AddDistrito(distrito);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DistritoController/Edit/5
        public ActionResult Edit(int id)
        {
            DistritoViewModel distrito = _distritoHelper.GetDistrito(id);
            return View(distrito);
        }

        // POST: DistritoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DistritoViewModel distrito)
        {
            try
            {
                _distritoHelper.UpdateDistrito(distrito);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DistritoController/Delete/5
        public ActionResult Delete(int id)
        {
            DistritoViewModel distrito = _distritoHelper.GetDistrito(id);
            return View(distrito);
        }

        // POST: DistritoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DistritoViewModel distrito)
        {
            try
            {
                _distritoHelper.DeleteDistrito(distrito.DistritoId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
