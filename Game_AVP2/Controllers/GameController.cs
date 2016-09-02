using Game_AVP2.Models;
using Game_AVP2.Models.Avp2.CharacterModels.Tables;
using Game_AVP2.Models.Avp2.GameModels;
using Game_AVP2.Models.Avp2.GameModels.Tables;
using Game_AVP2.Models.Avp2.Items;
using Game_AVP2.ModelViews.CharacterModelViews;
using Game_AVP2.ModelViews.Game;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Controllers
{
    [Authorize]
    public class GameController : AdminAuthorizationController
    {
        public GameModel model { get; set; }
        //public int gameId { get; set; }
        public int GameId
        {
            get
            {
                var id = HttpContext.Session["GameId"] as string;
                if (null == id)
                {
                    ApplicationUser u = DbCurrent.Users.Find(UserId);
                    Game g = model.GetUserMostRecentGame(u.Characters, DbCurrent);
                    id = g.GameId.ToString();
                    HttpContext.Session["GameId"] = id;
                }
                return Int32.Parse(id);
            }
            set
            {
                HttpContext.Session["GameId"] = value.ToString();
            }
        }
        public string UserId
        {
            get
            {
                var userId = HttpContext.Session["UserId"] as string;
                if (null == userId)
                {
                    if (User != null && User.Identity != null)
                    {
                        userId = User.Identity.GetUserId();
                        HttpContext.Session["UserId"] = userId;
                    } else
                    {
                        userId = null;
                    }
                }
                return userId;
            }
            set
            {
                HttpContext.Session["UserId"] = value;
            }
        }
        public GameController()
        {
            model = new GameModel();
            //if(User != null && User.Identity != null)
            //{
            //    UserId = User.Identity.GetUserId();
            //}
                
        }
        public ActionResult Index()
        {
            ViewBag.HasCharacter = false;
            ViewBag.HasGame = false;
            //Check if user has character, if so - if a game has been started
            //string userId = User.Identity.GetUserId();
          ApplicationUser u = DbCurrent.Users.Find(UserId);
            int count = u.Characters.Count();
            Game g = null;
            if ( count > 0 )
            {
                ViewBag.HasCharacter = true;
                g = model.GetUserMostRecentGame(u.Characters, DbCurrent);
                if(g != null && g.GameId > 0 )
                {
                    ViewBag.HasGame = true;
                    ViewBag.Progress = g.Progress;
                    //set GameId in session
                    GameId = g.GameId;
                }
            }
            return View();
        }

        public ActionResult Run()
        {
            GameViewModel viewModel = null;
            CharacterViewModel character = new CharacterViewModel();
            if (GameId > 0 && UserId != null)
            {
                character = model.PopulateCharacterViewModel(GameId ,DbCurrent);
                viewModel = new GameViewModel(GameId, character);
            } else
            {
                //redirect to index
                RedirectToAction("Index");
            }
            return View(viewModel);
        }
        //[Authorize(Roles = "Admin")]
        //public ActionResult Admin()
        //{
        //    string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Admin", });
        //    ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

        //    return View();
        //}

            //dont need to come here, game created when character created
        //public ActionResult NewGame()
        //{
        //    string userId = User.Identity.GetUserId();
        //    Game g = model.CreateNewGame()
        //    GameId = g.GameId;
        //    return RedirectToAction("Run", "Game");
        //}

        //public ActionResult Start()
        //{
        //    //Get the latest played game object for this user
        //    DbCurrent.Games
        //    //get last string in url (the just created gameid)
        //    int index = GetNumOfRequestParams();
        //    string param = GetRequestString(index - 1);
        //    //int gameId = Int32.Parse(GetRequestString(index - 1));
            
        //    return RedirectToAction("Index", "Game");
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}