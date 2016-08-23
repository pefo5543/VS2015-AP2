using Game_AVP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Controllers
{
    public abstract class BaseController : Controller
    {
        protected string Context { get; set; }
        public ApplicationDbContext DbCurrent
        {
            get
            {
                var db = HttpContext.Session["Db"] as ApplicationDbContext;
                if (null == db)
                {
                    db = new ApplicationDbContext();
                    HttpContext.Session["Db"] = db;
                }
                return db;
            }
        }
    }
}