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
            Weapon w = new Weapon() { Damage = 2, ExtraDamage = 0, WeaponType="Dagger"};
            Item i = new Item() {Name = "Dagger", Type = "Weapon", Description = "A standard dagger" };
            try
            {
                DbCurrent.Items.Add(i);
            } catch
            {

            }
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
        public JsonResult GetItems()
        {
            List<Item> items = null;
            int count = 0;
            ItemModel model = new ItemModel();

            //IEnumerable<SelectListItem> selectlist = ItemModel.GetSelectListItems();
            try
            {
                count = DbCurrent.Items.Count();
            }
            catch
            {
                count = 0;
            }
            try
            {
                items = DbCurrent.Items.ToList();
            }
            catch (Exception)
            {
                //...
            }
            //IQueryable<ItemViewModel> fullItems = null;
            if (count > 0)
            {
                model.RenderItemsList(items, DbCurrent);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //Gets here from json post from angular
        //public JsonResult Add([Bind(Exclude = "Id")] ItemViewModel data)
        //{
            //int resultId = ItemModel.AddItem(data, DbCurrent);

            //return Json(resultId, JsonRequestBehavior.DenyGet);
        //}
        //Gets here from json post from angular
        public JsonResult Delete(int Id)
        {
            //ItemModel.DeleteItem(Id, DbCurrent);

            return Json(true, JsonRequestBehavior.DenyGet);
        }
    }
}