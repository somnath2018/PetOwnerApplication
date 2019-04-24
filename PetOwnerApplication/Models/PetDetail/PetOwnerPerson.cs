namespace PetOwnerApplication.Models.PetDetail
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using static PetOwnerApplication.Models.Constants;

    public class PetOwnerPerson
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("gender")]
        public Gender Gender { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("pets")]
        public List<Pet> Pets { get; set; }
    }
}