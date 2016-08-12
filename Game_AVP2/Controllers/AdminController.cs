using Game_AVP2.Models;
using Game_AVP2.Models.Avp2.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
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
            //test add item
            //Weapon w = new Weapon() { Damage = 2, ExtraDamage = 0, WeaponType="Dagger"};
            //Item i = new Item() {ItemId = 1, Name = "Dagger", Type = "Weapon", Description = "A standard dagger" };
            //try
            //{
            //    DbCurrent.Items.Add(i);
            //} catch
            //{

            //}
            return View();
        }

        // GET: Admin
        public ActionResult AdminUsers()
        {
            return View();
        }

        // GET: Admin
        public ActionResult AdminCharacters()
        {
            return View();
        }

        // GET: Admin
        public ActionResult AdminItems()
        {
            return View();
        }

        // GET: Admin
        public ActionResult AddStaticCharacter()
        {
            return View();
        }

        // GET: Admin
        public ActionResult AddAbility()
        {
            return View();
        }

        //[ChildActionOnly]

        //public ActionResult ShowItems()

        //{

        //    var model = new List<string>();



        //    return PartialView("_ItemsTable", model);

        //}

        //Json get from angular to retrieve all items in db.
        public JsonResult GetWeapons()
        {
            List<Weapon> weapons = null;
            int count = 0;
            //ItemModel model = new ItemModel();

            //IEnumerable<SelectListItem> selectlist = ItemModel.GetSelectListItems();
            try
            {
                count = DbCurrent.Weapons.Count();
            }
            catch
            {
                count = 0;
            }
            try
            {
                weapons = DbCurrent.Weapons.ToList();
            }
            catch (Exception)
            {
                //...
            }
            //IQueryable<ItemViewModel> fullItems = null;
            //if (count > 0)
            //{
            //model.RenderAllItems(DbCurrent);
            //}
            return Json(weapons, JsonRequestBehavior.AllowGet);
        }

        //Gets here from json post from angular
        public JsonResult AddWeapon([Bind(Exclude = "WeaponId")] Weapon data)
        {
            int resultId = ItemModel.AddWeapon(data, DbCurrent);

            return Json(resultId, JsonRequestBehavior.DenyGet);
        }
        //Gets here from json post from angular
        public JsonResult DeleteWeapon(int Id)
        {
            ItemModel.DeleteWeapon(Id, DbCurrent);

            return Json(true, JsonRequestBehavior.DenyGet);
        }

        public JsonResult EditWeapon([Bind] Weapon data)
        {
            bool result = ItemModel.EditWeapon(data, DbCurrent);

            return Json(result, JsonRequestBehavior.DenyGet);
        }
    }
}