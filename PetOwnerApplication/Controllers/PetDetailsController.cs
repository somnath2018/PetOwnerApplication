namespace PetOwnerApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Models;
    using Models.PetDetail;
    using PetOwnerApplication.Filters;
    using PetOwnerApplication.Services;

    public class PetDetailsController : BaseController
    {
        public PetDetailsController() : base()
        {
            
        }
        [AuditAttribute]
        public async Task<ActionResult> Index()
        {
            var pets = new List<PetGroup>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings[Constants.GetLocalApiUrl]);
                    var responseTask = client.GetAsync(Constants.EndPointName);
                    await responseTask;

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<PetGroup>>();
                        await readTask;
                        pets = readTask.Result;
                    }
                }

                ViewBag.Title = "All Cats by their Owner's gender.";
                return View(pets);
            
        }
    }

}
