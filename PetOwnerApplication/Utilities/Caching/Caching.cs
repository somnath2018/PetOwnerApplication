namespace PetOwnerApplication.Utilities.Caching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Caching;
    using System.Text.RegularExpressions;

    public class Caching : ICaching
    {
        public const double DefaultCacheDuration = 20;
        private const string SessionId = "MyRandomSessionIdjshfbgwo87t34iot7894y";
        private const string RegionName = "Mem_Cache";
        private readonly ObjectCache _cache = MemoryCache.Default;

        #region Cache Internal Functions
        public object Get(string key, bool isSessionSpecific, params string[] args)
        {
            string keyName = GetKey(isSessionSpecific, args, key);
            if (this.CacheExists(keyName))
            {
                return this._cache.Get(keyName);
            }
            else
            {
                return null;
            }
        }

        public bool Set(string key, object value, bool isSessionSpecific, double? duration, params string[] args)
        {
            string keyName = GetKey(isSessionSpecific, args, key);
            try
            {
                var policy = new CacheItemPolicy();
                if (isSessionSpecific)
                {
                    policy.SlidingExpiration = new TimeSpan(0, 0, (int)(duration ?? DefaultCacheDuration), 0);
                }
                else
                {
                    policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(duration ?? DefaultCacheDuration);
                }
                policy.Priority = CacheItemPriority.Default;

                CacheItem item = new CacheItem(keyName, value, RegionName);
                this._cache.Set(item, policy);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(string key, bool isSessionSpecific = true, params string[] args)
        {
            string keyName = GetKey(isSessionSpecific, args, key);
            try
            {
                if (this.CacheExists(keyName))
                {
                    this._cache.Remove(keyName);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Exists(string key, bool isSessionSpecific, params string[] args) => this._cache.Contains(GetKey(isSessionSpecific, args, key));
        private bool CacheExists(string keyName)
        {
            return this._cache.Contains(keyName);
        }

        #endregion

        #region Private Functions
        private string ConcatArgs(List<string> args)
        {
            string result = string.Empty;
            foreach (string str in args)
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                string st = string.IsNullOrWhiteSpace(str) ? string.Empty : str;
                result += "_" + rgx.Replace(st, "_");
            }
            return result;
        }

        private string GetKeyName(string[] args, params string[] prms)
        {
            return this.ConcatArgs(prms.ToList().Concat(args).ToList());
        }

        private string GetKey(bool isSessionSpecific, string[] args, string key)
        {
            return isSessionSpecific ? GetKeyName(args, key, SessionId) : GetKeyName(args, key);
        }
        #endregion
    }
}
