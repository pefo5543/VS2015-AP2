using Game_AVP2.Models.Avp2;
using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.ModelViews;
using Game_AVP2.ModelViews.Character;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Controllers
{
    public class CharactersController : BaseController
    {
        public CharacterModel model { get; set; }
        public CharactersController()
        {
            model = new CharacterModel();
        }
        // GET: Character
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            //model send all characters - short info
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

            return View(list);
        }
        //Json get from angular to retrieve all items in db.
        //public JsonResult GetCharacter(int StaticCharacterId)
        //{
        //    try
        //    {
        //        StaticCharacter character = DbCurrent.StaticCharacters.Find(StaticCharacterId);
        //    }
        //    catch (Exception)
        //    {
        //        //...
        //    }
        //    CreateCharacterViewModel c = /*model.RenderCharacter(character, DbCurrent);*/ new CreateCharacterViewModel();

        //    return Json(c, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public JsonResult SetCharacter (int staticCharacterId)
        {
           string userId = User.Identity.GetUserId();
            bool result = model.CreateUserCharacter(staticCharacterId, userId, DbCurrent);
            return Json(result, JsonRequestBehavior.AllowGet);

            //return Json(new
            //{
            //    redirectUrl = Url.Action("Index", "Game"),
            //    isRedirect = true?result:false
            //});
        }
    }
}