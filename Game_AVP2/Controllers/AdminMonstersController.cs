using Game_AVP2.Models;
using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using Game_AVP2.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Controllers
{
    public class AdminMonstersController : AdminController
    {
        public MonsterModel model { get; set; }
        public AdminMonstersController()
        {
            model = new MonsterModel();
        }
        // GET: AdminMonsters
        public new ActionResult Index()
        {
            return RedirectToAction("index", "admin", null);
        }

        [ChildActionOnly]

        public ActionResult MonsterStart()
        {
            //IEnumerable<SelectListItem> imageList = GetImageList();
            return PartialView("_MonsterStart");
        }

        [HttpPost]
        public ActionResult Add([Bind(Exclude = "MonsterId")]MonsterShorthandViewModel data)
        {
            bool result = model.AddMonster(data, DbCurrent);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Gets here from json post from angular
        public JsonResult DeleteMonster(int Id)
        {
            bool result = model.DeleteMonster(Id, DbCurrent);

            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult EditMonster([Bind] MonsterViewModel data)
        {
            bool result = model.EditMonster(data, DbCurrent);

            return Json(result, JsonRequestBehavior.DenyGet);
        }

        //Json get from angular to retrieve all items in db.
        public JsonResult GetMonsters()
        {
            List<Monster> Monsters = null;
            int count = 0;
            try
            {
                count = DbCurrent.Monsters.Count();
            }
            catch
            {
                count = 0;
            }
            try
            {
                Monsters = DbCurrent.Monsters.ToList();
            }
            catch (Exception)
            {
                //...
            }
            List<MonsterViewModel> list = model.RenderMonsterList(Monsters, DbCurrent);

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDetail(int Id)
        {
            MonsterViewModel c = model.GetDetail(Id, DbCurrent);
            return Json(c, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetImages()
        {
            IEnumerable<SelectListItem> images = model.GetImagesSelectList(DbCurrent);
            return Json(images, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            string map = "Monsters";

            if (file != null)
            {
                ApplicationDbContext db = DbCurrent;
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Content/Images/" + map + "/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                //save new record in database
                MonsterImage newRecord = new MonsterImage();
                newRecord.Name = Request.Form["name"];
                newRecord.FileName = file.FileName;
                newRecord.ImageLink = "Content/Images/" + map + "/" + ImageName;
                db.MonsterImages.Add(newRecord);
                db.SaveChanges();

            }
            //Display records
            return RedirectToAction("../AdminMonsters/DisplayMonsterImages/");
        }
        public ActionResult DisplayMonsterImages()
        {
            List<MonsterImage> c = DbCurrent.MonsterImages.ToList();
            return View(c);
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