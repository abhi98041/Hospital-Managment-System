using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Team3CAS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start()
        {            
            Session["OrderItem"] = new List<ClinicalELDAL.EntityLayer.OrderItem>();
            Session["ViewCart"] = new List<ViewModels.CartViewModel>();
            Session["UserID"] = 8;
            Session["Name"] = "Admin";
            Session["RoleID"] = 0;
        }
    }
}
