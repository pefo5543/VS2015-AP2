using Game_AVP2.Helpers;
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
        // GET: AdminStaticCharacters
        public new ActionResult Index()
        {
            return RedirectToAction("index", "admin", null);
        }

        [ChildActionOnly]

        public ActionResult CharacterStart()
        {
            Context = "staticC";
            IEnumerable<SelectListItem> imageList = GetImageList();
            return PartialView("_CharacterStart", imageList);
        }

        [HttpPost]
        public ActionResult AddStaticCharacter([Bind(Exclude = "StaticCharacterId")]StaticCharacterViewModel data)
        {
            bool result = CharacterModel.AddCharacter(data, DbCurrent, Context);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //Gets here from json post from angular
        public JsonResult DeleteStaticCharacter(int Id)
        {
            CharacterModel.DeleteCharacter(Id, DbCurrent, Context);

            return Json(true, JsonRequestBehavior.DenyGet);
        }

        public JsonResult EditStaticCharacter([Bind] StaticCharacter data)
        {
            bool result = CharacterModel.EditCharacter(data, DbCurrent, Context);

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
            List<StaticCharacterShorthandViewModel> list = CharacterModel.RenderStaticSimpleList(characters);

            return Json(list, JsonRequestBehavior.AllowGet);
    }

        [HttpPost]
        public JsonResult GetCharacterImage(int Id)
        {
            string link = CharacterModel.GetImage(Id, DbCurrent, Context);
            return Json(link, JsonRequestBehavior.AllowGet);
        }

        protected IEnumerable<SelectListItem> GetImageList()
        {
            var db = new CharacterImageSelectList();
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
            return RedirectToAction("../AdminCharacters/DisplayWeaponImages/");
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
            return View("AdminCharacterFileUpload");
        }
    }
}