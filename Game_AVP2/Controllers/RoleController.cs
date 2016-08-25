using Game_AVP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Controllers
{
    public class RoleController : AdminAuthorizationController
    {
        public RoleController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Role
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {


                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Game");
                }
            }
            else
            {
                return RedirectToAction("Index", "Game");
            }

            var Roles = context.Roles.ToList();
            return View(Roles);
        }

            #region Helpers
        private ApplicationDbContext context;
        #endregion
    }
}