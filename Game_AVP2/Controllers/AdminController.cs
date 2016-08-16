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
        [HttpGet]
        public ActionResult AdminFileUpload()
        {
            return View();
        }
        //[HttpPost]
        //public JsonResult AdminFileUpload(object files)
        //{
        //    string result = "";
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult FileUpload(HttpPostedFileBase file)
        {

            if (file != null)
            {
                ApplicationDbContext db = DbCurrent;
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Content/Images/weapons/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                //save new record in database
                WeaponImage newRecord = new WeaponImage();
                newRecord.Name = Request.Form["name"];
                newRecord.FileName = file.FileName;
                newRecord.ImageLink = "Content/Images/weapons/" + ImageName;
                db.WeaponImages.Add(newRecord);
                db.SaveChanges();

            }
            //Display records
            return RedirectToAction("../Admin/DisplayImages/");
        }
        public ActionResult DisplayImages()
        {
            List<WeaponImage> wp = DbCurrent.WeaponImages.ToList();
            return View(wp);
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

        [ChildActionOnly]

        public ActionResult WeaponPage()
        {
            IEnumerable<SelectListItem> imageList = GetImageList();
            return PartialView("_WeaponPage",imageList);
        }

        //Json get from angular to retrieve all items in db.
        public JsonResult GetWeapons()
        {
            List<Weapon> weapons = null;
            int count = 0;
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
            //string json = JsonConvert.SerializeObject(weapons);

            return Json(weapons, JsonRequestBehavior.AllowGet);
            //return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetWeaponImage(int WeaponId)
        {
            string link = ItemModel.GetWeaponImage(WeaponId, DbCurrent);
            return Json(link, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddWeapon([Bind (Exclude = "WeaponId")]WeaponViewModel data)
        {
           bool result = ItemModel.AddWeapon(data, DbCurrent);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Gets here from json post from angular
        public JsonResult DeleteWeapon(int WeaponId)
        {
            ItemModel.DeleteWeapon(WeaponId, DbCurrent);

            return Json(true, JsonRequestBehavior.DenyGet);
        }

        public JsonResult EditWeapon([Bind] Weapon data)
        {
            bool result = ItemModel.EditWeapon(data, DbCurrent);

            return Json(result, JsonRequestBehavior.DenyGet);
        }

        private IEnumerable<SelectListItem> GetImageList()
        {
            var db = new ImageSelectList();
            var images = db
                        .GetImages(DbCurrent)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.WeaponImageId.ToString(),
                                    Text = x.ImageName
                                });
            var list = new SelectList(images, "Value", "Text");
            return new SelectList(images, "Value", "Text");
        }

        //Gets here from json post from angular
        //public JsonResult AddWeapon([Bind(Exclude = "WeaponId")] Weapon data)
        //{
        //    int resultId = ItemModel.AddWeaponToDb(data, DbCurrent);

        //    return Json(resultId, JsonRequestBehavior.DenyGet);
        //}
    }
}