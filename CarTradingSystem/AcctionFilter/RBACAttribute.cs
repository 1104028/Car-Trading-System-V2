using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


public class RBACAttribute : AuthorizeAttribute
{
    public override void OnAuthorization(AuthorizationContext filterContext)
    {
       
        if(string.IsNullOrEmpty(filterContext.RequestContext.HttpContext.User.Identity.Name))
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Login" }, { "controller", "Admin" } });
        }

       
    }
}
