using Game_AVP2.Helpers;
using Game_AVP2.Models;
using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.ModelViews;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Controllers
{
    public class AdminWeaponsController : AdminController
    {
        // GET: AdminWeapons
        public new ActionResult Index()
        {
            return RedirectToAction("index", "admin", null);
        }

        [ChildActionOnly]

        public ActionResult WeaponPage()
        {
            IEnumerable<SelectListItem> imageList = GetImageList();
            return PartialView("_WeaponPage", imageList);
        }
        [HttpPost]
        public ActionResult AddWeapon([Bind(Exclude = "WeaponId")]WeaponViewModel data)
        {
            bool result = WeaponModel.AddWeapon(data, DbCurrent);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Gets here from json post from angular
        public JsonResult DeleteWeapon(int WeaponId)
        {
            WeaponModel.DeleteWeapon(WeaponId, DbCurrent);

            return Json(true, JsonRequestBehavior.DenyGet);
        }

        public JsonResult EditWeapon([Bind] Weapon data)
        {
            bool result = WeaponModel.EditWeapon(data, DbCurrent);

            return Json(result, JsonRequestBehavior.DenyGet);
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
            List<WeaponViewModel> list = WeaponModel.RenderWeaponSimpleList(weapons);

            return Json(list, JsonRequestBehavior.AllowGet);

            //annonymt objekt
            //var x = new
            //{
            //    Name = weapons.First().Name,
            //    weapons.First().WeaponImage.WeaponImageId
            //};

            //return Json(x);

        }
        [HttpPost]
        public JsonResult GetWeaponImage(int WeaponId)
        {
            string link = WeaponModel.GetWeaponImage(WeaponId, DbCurrent);
            return Json(link, JsonRequestBehavior.AllowGet);
        }

        protected IEnumerable<SelectListItem> GetImageList()
        {
            var db = new WeaponImageSelectList();
            var images = db
                        .GetImages(DbCurrent)
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.ImageId.ToString(),
                                    Text = x.ImageName
                                });
            var list = new SelectList(images, "Value", "Text");
            return new SelectList(images, "Value", "Text");
        }

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
            return RedirectToAction("../AdminWeapons/DisplayWeaponImages/");
        }
        public ActionResult DisplayWeaponImages()
        {
            List<WeaponImage> wp = DbCurrent.WeaponImages.ToList();
            return View(wp);
        }

        // GET: Admin
        [HttpGet]
        public ActionResult AdminFileUpload()
        {
            return View("AdminWeaponFileUpload");
        }
    }
}