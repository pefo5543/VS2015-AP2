using Game_AVP2.Models.Avp2;
using Game_AVP2.Models.Avp2.CharacterModels;
using Game_AVP2.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Controllers
{
    public class CharacterController : BaseController
    {
        public CharacterModel model { get; set; }
        public CharacterController()
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
    }
}