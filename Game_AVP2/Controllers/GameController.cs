using Game_AVP2.Models;
using Game_AVP2.Models.Avp2.GameModels;
using Game_AVP2.Models.Avp2.GameModels.Tables;
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
                    id = "";
                    HttpContext.Session["GameId"] = id;
                }
                return Int32.Parse(id);
            }
            set
            {
                HttpContext.Session["GameId"] = value.ToString();
            }
        }
        public GameController()
        {
            model = new GameModel();
            string userId = User.Identity.GetUserId();
            HttpContext.Session["userId"] = userId;
                
        }
        public ActionResult Index()
        {
            ViewBag.HasCharacter = false;
            ViewBag.HasGame = false;
            //Check if user has character, if so - if a game has been started
            string userId = User.Identity.GetUserId();
          ApplicationUser u = DbCurrent.Users.Find(userId);
            int count = u.Characters.Count();
            Game g = null;
            if( count > 0 )
            {
                ViewBag.HasCharacter = true;
                g = model.GetUserMostRecentGame(u.Characters, DbCurrent);
                if(g != null && g.GameId > 0 )
                {
                    ViewBag.HasGame = true;
                    GameId = g.GameId;
                }
            }
            return View();
        }
        //[Authorize(Roles = "Admin")]
        //public ActionResult Admin()
        //{
        //    string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Admin", });
        //    ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

        //    return View();
        //}

        public ActionResult NewGame()
        {
            string userId = User.Identity.GetUserId();
            Game g = model.CreateGame();
            GameId = g.GameId;
            return RedirectToAction("Index", "Game");
        }

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