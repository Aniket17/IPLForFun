using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using IPLForFun.Models;

namespace IPLForFun.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationUser _applicationUser;
        public ApplicationUser ApplicationUser
        {
            get
            {
                return _applicationUser ?? HttpContext.GetOwinContext().Get<ApplicationUser>();
            }
            private set
            {
                _applicationUser = value;
            }
        }
    }
}