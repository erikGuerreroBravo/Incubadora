using Incubadora.Business.Interface;
using Incubadora.ViewModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Incubadora.Controllers
{
    public class CalendarizacionController : Controller
    {
        //private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        //private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly ICalendarizacionBusiness _calendarizacion;

        public CalendarizacionController(ICalendarizacionBusiness calendarizacion)
        {
            this._calendarizacion = calendarizacion;
        }
        // GET: Calendarizacion
        public ActionResult Eventos()
        {
            return View();
        }

        public JsonResult GetEventos() {

            var eventos = this._calendarizacion.GetEventos();
            List<CalendarizacionVM> calendarizacionesVM = new List<CalendarizacionVM>();
            AutoMapper.Mapper.Map(eventos, calendarizacionesVM);
            return Json(calendarizacionesVM, JsonRequestBehavior.AllowGet);
        }
    }
}