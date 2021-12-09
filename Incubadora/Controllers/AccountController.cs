using Incubadora.Business.Interface;
using NLog;
using System.Web.Mvc;

namespace Incubadora.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAspNetRolesBusiness rolesBusiness;
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        public AccountController(IAspNetRolesBusiness _rolesBusiness)
        {
            rolesBusiness = _rolesBusiness;
        }


        // GET: Account
        public ActionResult Create()
        {
            try
            {
                ViewBag.IdRol = new SelectList(rolesBusiness.GetRoles(), "Id", "Name");
                return View();
            }
            catch (System.Exception ex)
            {
                Log.Error(ex, "Ocurrio una exepcion en el metodo create del controlador Account");
                loggerdb.Error(ex);
                return RedirectToAction("InternalServerError", "Error");
            }
            
        }




    }
}