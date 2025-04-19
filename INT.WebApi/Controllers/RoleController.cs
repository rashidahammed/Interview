using INT.Application.Application.Interfaces;
using INT.Domain.Model;
using INT.WebApi.UI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INT.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleServices _service;
        public RoleController(IRoleServices service) {
            _service=service;
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(CreateRoleVm collection)
        //{
        //    try
        //    {
               
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        //Add audit log
        //    }
        //}


        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: RoleController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: RoleController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: RoleController/Create
     

        //// GET: RoleController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: RoleController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: RoleController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: RoleController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
