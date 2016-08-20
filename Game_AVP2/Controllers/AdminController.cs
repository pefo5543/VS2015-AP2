using Game_AVP2.Helpers;
using Game_AVP2.Models;
using Game_AVP2.Models.Avp2.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : AdminBaseController
    {
        protected string Context { get; set; }
        public ApplicationDbContext DbCurrent
        {
            get
            {
                var db = HttpContext.Session["Db"] as ApplicationDbContext;
                if (null == db)
                {
                    db = new ApplicationDbContext();
                    HttpContext.Session["Db"] = db;
                }
                return db;
            }
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin
        public ActionResult AdminUsers()
        {
            return View();
        }

        // GET: Admin
        public ActionResult AdminItems()
        {
            return View();
        } 

        // GET: Admin
        public ActionResult AdminCharacters()
        {
            return View();
        }

        // GET: Admin
        public ActionResult AddAbility()
        {
            return View();
        }

        //Gets here from json post from angular
        //public JsonResult AddWeapon([Bind(Exclude = "WeaponId")] Weapon data)
        //{
        //    int resultId = ItemModel.AddWeaponToDb(data, DbCurrent);

        //    return Json(resultId, JsonRequestBehavior.DenyGet);
        //}
    }
}