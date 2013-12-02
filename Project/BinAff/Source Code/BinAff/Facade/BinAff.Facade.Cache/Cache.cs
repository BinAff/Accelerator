using System;
using System.Collections.Generic;

namespace BinAff.Facade.Cache
{

    public class Cache
    {

        static Cache()
        {
            cache = new Dictionary<string, object>();
        }

        private static Dictionary<String, Object> cache;

        public Object this[String key]
        {
            get
            {
                return cache[key];
            }
            set
            {
                Add(key, value);
            }
        }

        public static Dictionary<String, Object> Get()
        {
            return cache;
        }

        public static void Add(String key, Object value)
        {
            if (cache.ContainsKey(key))
            {
                throw new Exception("Key in use");
            }
            cache.Add(key, value);
        }

        public void Remove(String key)
        {
            if (!cache.ContainsKey(key))
            {
                throw new Exception("Key not found");
            }
            cache.Remove(key);
        }

        public void RemoveAll()
        {
            cache.Clear();
        }

    }

}
