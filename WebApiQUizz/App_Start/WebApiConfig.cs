using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.OData.Builder;
using Models;
using WebApiQUizz.Helpers;
using System.Web.Http.OData.Extensions;
using System.Net.Http.Formatting;

namespace WebApiQUizz
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services de l'API Web
            // Configurer l'API Web pour utiliser uniquement l'authentification de jeton du porteur.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //ODataModelBuilder nbuilder = new ODataConventionModelBuilder();
            //nbuilder.EntitySet<Profile>("Profiles");
            //nbuilder.EntitySet<Langue>("Langues");
            //nbuilder.EntitySet<Matiere>("Matieres");
            //nbuilder.EntitySet<Chapitre>("Chapitres");
            //nbuilder.EntitySet<Niveau>("Niveaux");
            //nbuilder.EntitySet<Module>("Modules");

            //config.Routes.MapODataServiceRoute(
            //    routeName: "odata",
            //    routePrefix: "odata",
            //    model: nbuilder.GetEdmModel());



            ////enable OData Query options Globally
            //config.EnableQuerySupport();
            //// Web API routes
            //// config.MapHttpAttributeRoutes();


            config.Formatters.Add(new BrowserJsonFormatter());
            config.Formatters.JsonFormatter
            .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           // config.Routes.MapHttpRoute(
           //    name: "Profiles",
           //    routeTemplate: "api/profiles/{id}",
           //    defaults: new { controller = "profiles", userName = RouteParameter.Optional }
           //);


            //var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
