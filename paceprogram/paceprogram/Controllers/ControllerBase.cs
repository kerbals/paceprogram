using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace paceprogram.Controllers
{
    public class ControllerBase : Controller
    {
        //
        // GET: /ControllerBase/

        public ControllerBase()
            : base()
        {
            ViewBag.IsAdmin = false;
            if (WebSecurity.IsAuthenticated)
            {

                try
                {
                    if (Roles.IsUserInRole(WebSecurity.CurrentUserName, "Admin"))
                    {
                        ViewBag.IsAdmin = true;
                    }
                }

                catch { }
            }
        }
    }
}
