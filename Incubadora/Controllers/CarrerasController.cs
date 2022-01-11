using Incubadora.Business.Interface;
using Incubadora.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Incubadora.Controllers
{
    public class CarrerasController : Controller
    {
        private readonly ICatCarrerasBusiness _carrerasBusiness;

        public CarrerasController(ICatCarrerasBusiness carrerasBusiness)
        {
            this._carrerasBusiness = carrerasBusiness;
        }

        // GET: Carreras
        public ActionResult Create()
        {
            return View();
        }


        public JsonResult GetCarreras()
        {
            var carrerasDomainModel = this._carrerasBusiness.GetCarreras();
            List<CatCarreraVM> carreraVM = new List<CatCarreraVM>();
            
            AutoMapper.Mapper.Map(carrerasDomainModel, carreraVM);
            return Json(carreraVM, JsonRequestBehavior.AllowGet);
        }


    }
}