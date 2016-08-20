using Game_AVP2.Helpers;
using Game_AVP2.Models;
using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.Models.Avp2.Items.Tables;
using Game_AVP2.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Controllers
{
    public class AdminArmoursController : AdminController
    {
        // GET: AdminArmours
        public new ActionResult Index()
        {
            return RedirectToAction("index", "admin", null);
        }

        [ChildActionOnly]

        public ActionResult ArmourPage()
        {
            IEnumerable<SelectListItem> imageList = GetImageList();
            return PartialView("_ArmourPage", imageList);
        }

        [HttpPost]
        public ActionResult AddArmour([Bind(Exclude = "ArmourId")]ArmourViewModel data)
        {
            bool result = ArmourModel.AddArmour(data, DbCurrent);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Gets here from json post from angular
        public JsonResult DeleteArmour(int ArmourId)
        {
            ArmourModel.DeleteArmour(ArmourId, DbCurrent);

            return Json(true, JsonRequestBehavior.DenyGet);
        }

        public JsonResult EditArmour([Bind] Armour data)
        {
            bool result = ArmourModel.EditArmour(data, DbCurrent);

            return Json(result, JsonRequestBehavior.DenyGet);
        }

        //Json get from angular to retrieve all items in db.
        public JsonResult GetArmours()
        {
            List<Armour> armours = null;
            int count = 0;
            try
            {
                count = DbCurrent.Armours.Count();
            }
            catch
            {
                count = 0;
            }
            try
            {
                armours = DbCurrent.Armours.ToList();
            }
            catch (Exception)
            {
                //...
            }
            List<ArmourViewModel> list = ArmourModel.RenderArmourSimpleList(armours);

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetArmourImage(int ArmourId)
        {
            string link = ArmourModel.GetArmourImage(ArmourId, DbCurrent);
            return Json(link, JsonRequestBehavior.AllowGet);
        }

        protected IEnumerable<SelectListItem> GetImageList()
        {
            var db = new ArmourImageSelectList();
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
                string physicalPath = Server.MapPath("~/Content/Images/armours/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                //save new record in database
                ArmourImage newRecord = new ArmourImage();
                newRecord.Name = Request.Form["name"];
                newRecord.FileName = file.FileName;
                newRecord.ImageLink = "Content/Images/armours/" + ImageName;
                db.ArmourImages.Add(newRecord);
                db.SaveChanges();

            }
            //Display records
            return RedirectToAction("../AdminArmours/DisplayArmourImages/");
        }
        public ActionResult DisplayArmourImages()
        {
            List<ArmourImage> wp = DbCurrent.ArmourImages.ToList();
            return View(wp);
        }

        // GET: Admin
        [HttpGet]
        public ActionResult AdminFileUpload()
        {
            ViewBag.Controller = GetRequestString(3);
            return View("FileUpload");
        }
    }
}