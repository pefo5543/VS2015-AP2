using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Game_AVP2.Controllers
{
    public abstract class AdminBaseController : BaseController
    {
        public string GetRequestString(int index)
        {
            string path = HttpContext.Request.FilePath;
            string[] pathArray = path.Split('/');

            return pathArray[index];
        }
    }
}