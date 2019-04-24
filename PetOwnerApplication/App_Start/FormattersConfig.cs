namespace PetOwnerApplication.App_Start
{
    using System.Net.Http.Formatting;
    using System.Web.Http;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public static class FormattersConfig
    {
        public static void ConfigureResponseFormatters(HttpConfiguration config)
        {
            config.Formatters.Clear();

            // set JSON as an only formatter supported
            config.Formatters.Add(new JsonMediaTypeFormatter());

            // make sure null values are not included in the response
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
}