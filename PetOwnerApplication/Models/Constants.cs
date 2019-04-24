namespace PetOwnerApplication.Models
{
    public class Constants
    {
        public const string MemCacheAppSettings = "MemCacheEnabled";
        public const string ExtApiUserAgent = "ExtApiUserAgent";
        public const string UseProxy = "UseProxy";
        public const string ProxyUrl = "ProxyUrl";
        public const string ProxyPort = "ProxyPort";

        #region BaseController
        public const string area = "area";
        public const string controller = "controller";
        public const string action = "action";
        #endregion

        #region PetOwner
        public const string ApiUrl = "GetPetOwnerApiUrl";
        public const string GetLocalApiUrl = "GetLocalApiUrl";
        public const string PetOwnerCache = "PetOwnerCache";
        public const string EndPointName = "Pet";
        
        #endregion

        public enum Gender
        {
            Male,
            Female
        }

        public enum PetType
        {
            Cat,
            Dog,
            Fish
        }
    }
}
