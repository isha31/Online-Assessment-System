using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Unity;
using BusinessLogicLayer;
using Interfaces;
using System.Web.Http.Cors;


namespace OnlineAssessmentSystem
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            
            container.RegisterType<ICategory, BLCategory>();
            container.RegisterType<IDifficultyLevel, BLDifficultyLevel>();
            container.RegisterType<IQuestionBank, BLQuestionBank>();
            
            container.RegisterType<ISubCategory, BLSubCategory>();
            container.RegisterType<ITest, BLTest>();
            container.RegisterType<ITopic, BLTopic>();
            container.RegisterType<IUser, BLUser>();
            container.RegisterType<IUserTest, BLUserTest>();
            container.RegisterType<IReports, BLReport>();
            container.RegisterType<ITestGenerate, BLTestGenerate>();

            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
           config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //for connection between 2 different domain
            //var corsAttr = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(corsAttr);

            //for serialization
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "GET,DELETE,PUT,POST,OPTIONS");
            //config.EnableCors();

        }           
    }
}
