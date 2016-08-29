using Game_AVP2.Helpers;
using Game_AVP2.Models;
using Game_AVP2.Models.Avp2;
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

        [HttpGet]
        public JsonResult GetArmoursSelectList()
        {
            CharacterModel model = new CharacterModel();
            IEnumerable<SelectListItem> armours = model.GetArmourSelectList(DbCurrent);
            return Json(armours, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetWeaponsSelectList()
        {
            CharacterModel model = new CharacterModel();
            IEnumerable<SelectListItem> weapons = model.GetWeaponSelectList(DbCurrent);
            return Json(weapons, JsonRequestBehavior.AllowGet);
        }

        //Gets here from json post from angular
        //public JsonResult AddWeapon([Bind(Exclude = "WeaponId")] Weapon data)
        //{
        //    int resultId = ItemModel.AddWeaponToDb(data, DbCurrent);

        //    return Json(resultId, JsonRequestBehavior.DenyGet);
        //}
    }
}