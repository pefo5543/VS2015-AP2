using Game_AVP2.Models.Avp2;
using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.Models.Avp2.GameModels;
using Game_AVP2.Models.Avp2.GameModels.Tables;
using Game_AVP2.ModelViews;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpPost]
        public JsonResult SetCharacter(int staticCharacterId)
        {
            int result = -1;
            string userId = User.Identity.GetUserId();
            int characterId = model.CreateUserCharacter(staticCharacterId, userId, DbCurrent);
            if (characterId > 0)
            {
                GameModel gm = new GameModel();
                Game newGame = model.CreateNewGame(characterId, DbCurrent);
                if (newGame != null && newGame.GameId > 0)
                {
                    result = newGame.GameId;
                    //first episode should always have id 1
                    gm.ConstructGameEpisode(newGame, 1, DbCurrent);

                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);

            //return Json(new
            //{
            //    redirectUrl = Url.Action("Index", "Game"),
            //    isRedirect = true?result:false
            //});
        }
    }
}