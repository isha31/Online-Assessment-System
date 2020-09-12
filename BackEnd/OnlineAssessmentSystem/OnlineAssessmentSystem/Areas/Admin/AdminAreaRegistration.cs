using System.Web.Http;
using System.Web.Mvc;

namespace OnlineAssessmentSystem.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            

            //thisworks
            //context.Routes.MapHttpRoute(
            //"Admin",
            //"Admin/api/{controller}/{id}",
            //new { AreaName = "Admin", id = UrlParameter.Optional }
            //);

            // context.Routes.MapHttpRoute(
            //"Admin_Get",
            //"Admin/api/{controller}/{action}",
            //new { AreaName = "Admin" }
            //);

            //New change

            context.Routes.MapHttpRoute(
             name: "Admin",
             routeTemplate: string.Concat("api/", AreaName, "/{controller}/{id}"),
             defaults: new { id = RouteParameter.Optional }
         );




            context.MapRoute(
              "Admin_default",
              "Admin/{controller}/{action}/{id}",
              new { action = "Index", id = UrlParameter.Optional }
          );




        }
    }
}