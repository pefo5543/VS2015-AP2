﻿using Game_AVP2.Helpers;
using Game_AVP2.Models;
using Game_AVP2.Models.Avp2;
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
    public class AdminStaticCharactersController : AdminController
    {
        public CharacterModel model { get; set; }
        public AdminStaticCharactersController()
        {
            model = new CharacterModel();
        }
        // GET: AdminStaticCharacters
        public new ActionResult Index()
        {
            return RedirectToAction("index", "admin", null);
        }

        [ChildActionOnly]

        public ActionResult CharacterStart()
        {
            Context = "staticCharacter";
            //IEnumerable<SelectListItem> imageList = GetImageList();
            return PartialView("_CharacterStart");
        }

        [HttpPost]
        public ActionResult Add([Bind(Exclude = "StaticCharacterId")]StaticCharacterShorthandViewModel data)
        {
            bool result = model.AddStaticCharacter(data, DbCurrent);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Gets here from json post from angular
        public JsonResult DeleteStaticCharacter(int Id)
        {
            bool result = model.DeleteCharacter(Id, DbCurrent);

            return Json(result, JsonRequestBehavior.DenyGet);
        }

        public JsonResult EditStaticCharacter([Bind] StaticCharacterViewModel data)
        {
            bool result = model.EditStaticCharacter(data, DbCurrent);

            return Json(result, JsonRequestBehavior.DenyGet);
        }

        //Json get from angular to retrieve all items in db.
        public JsonResult GetStaticCharacters()
        {
            List<StaticCharacter> characters = null;
            int count = 0;
            try
            {
                count = DbCurrent.StaticCharacters.Count();
            }
            catch
            {
                count = 0;
            }
            try
            {
                characters = DbCurrent.StaticCharacters.ToList();
            }
            catch (Exception)
            {
                //...
            }
            List<StaticCharacterViewModel> list = model.RenderStaticCharacterList(characters, DbCurrent);

            return Json(list, JsonRequestBehavior.AllowGet);
    }

        [HttpPost]
        public JsonResult GetDetail(int Id)
        {
            StaticCharacterViewModel c = model.GetDetail(Id, DbCurrent, Context);
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
            string map = "characters";

            if (file != null)
            {
                ApplicationDbContext db = DbCurrent;
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Content/Images/" + map + "/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                //save new record in database
                CharacterImage newRecord = new CharacterImage();
                newRecord.Name = Request.Form["name"];
                newRecord.FileName = file.FileName;
                newRecord.ImageLink = "Content/Images/" + map + "/" + ImageName;
                db.CharacterImages.Add(newRecord);
                db.SaveChanges();

            }
            //Display records
            return RedirectToAction("../AdminStaticCharacters/DisplayCharacterImages/");
        }
        public ActionResult DisplayCharacterImages()
        {
            List<CharacterImage> c = DbCurrent.CharacterImages.ToList();
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