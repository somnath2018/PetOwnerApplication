namespace PetOwnerApplication.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using PetOwnerApplication.Filters;
    using PetOwnerApplication.Utilities;
    using Services;
    using static PetOwnerApplication.Models.Constants;

    public class PetController : ApiController
    {
        private readonly IPetOwnerService _petService;

        public PetController(IPetOwnerService petService)
        {
            _petService = petService;
        }
        [Audit]
       public IHttpActionResult GetPet()
        {
            var result = _petService.GetPetDetailsByGenderGroup(PetType.Cat);
            if (result != null)
            {
                return Ok(result);
            }
            Logging.LogError("Pet Service Returned null.");
            return this.NotFound();
        }
    }
}
