namespace PetOwnerApplication
{
    using System.Web.Http;
    using App_Start;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            FormattersConfig.ConfigureResponseFormatters(config);
            
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional

                });

        }
    }
}
