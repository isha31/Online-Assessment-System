using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Newtonsoft.Json.Serialization;
using System.Threading;

namespace OnlineAssessmentSystem
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

           



            //GlobalConfiguration.Configure(config => { // This HAS to be here. Having it last caused routing to not work.
            //    config.MapHttpAttributeRoutes(); // This allows us to use AttributeRouting

            //    config.Routes.MapHttpRoute( // This allows us to use conventional HTTP routing
            //      name: "Name",
            //      routeTemplate: "api/{controller}/{id}",
            //      defaults: new { id = RouteParameter.Optional }
            //  ); 


            //    // This sets JSON as the default return format and removes any circular references
            //    var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            //    config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            //    var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //    json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //    config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //});




            // LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);


            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

       
    }
}
