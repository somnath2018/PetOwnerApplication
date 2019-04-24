namespace PetOwnerApplication.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Threading.Tasks;
    using Models;
    using Models.PetDetail;
    using Newtonsoft.Json;
    using Utilities;
    using Utilities.Caching;

    public class PetOwnerRepository : IPetOwnerRepository
    {
        private readonly ICaching _cache;

        public PetOwnerRepository(ICaching cache)
        {
            _cache = cache;
        }
        public List<PetOwnerPerson> GetAllPetOwnerDetails()
        {
            try
            {
                string petOwnerResultStream;
                bool isProxyEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings[Constants.UseProxy]);
                ProxyDetail proxyDetail = null;
                if (isProxyEnabled)
                {
                    proxyDetail = new ProxyDetail
                    {
                        Url = ConfigurationManager.AppSettings[Constants.ProxyUrl],
                        Port = ConfigurationManager.AppSettings[Constants.ProxyPort]
                    };

                }

                var headerDetails = new Dictionary<string, string>
                {
                    { "User-Agent", ConfigurationManager.AppSettings[Constants.ExtApiUserAgent] }
                };

                bool isMemoryCacheEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings[Constants.MemCacheAppSettings]);

                if (isMemoryCacheEnabled)
                {
                    if (_cache.Get(Constants.PetOwnerCache, false) == null)
                    {
                        petOwnerResultStream = ApiHandler.GetApiResult(ConfigurationManager.AppSettings[Constants.ApiUrl], headerDetails, isProxyEnabled, proxyDetail); 
                        _cache.Set(Constants.PetOwnerCache, petOwnerResultStream, false, null);
                    }
                    else
                    {
                        petOwnerResultStream = Convert.ToString(_cache.Get(Constants.PetOwnerCache, false));
                    }
                }
                else
                {
                    petOwnerResultStream = ApiHandler.GetApiResult(ConfigurationManager.AppSettings[Constants.ApiUrl], headerDetails, isProxyEnabled, proxyDetail);
                }

                return JsonConvert.DeserializeObject<List<PetOwnerPerson>>(petOwnerResultStream);
            }
            catch (Exception ex)
            {
                Logging.HandleException(ex);
                throw;
            }
        }
    }
}