using System.Web.Http;
using System.Web.Mvc;

namespace OnlineAssessmentSystem.Areas.UserArea
{
    public class UserAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "User";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.Routes.MapHttpRoute(
             name: "User",
             routeTemplate: string.Concat("api/", AreaName, "/{controller}/{id}"),
             defaults: new { id = RouteParameter.Optional }
         );


            context.MapRoute(
                "UserArea_default",
                "UserArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}