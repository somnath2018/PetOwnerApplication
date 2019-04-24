namespace PetOwnerApplication.Models.PetDetail
{
    using Newtonsoft.Json;
    using static PetOwnerApplication.Models.Constants;

    public class Pet
    {
        [JsonProperty("type")]
        public PetType Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}