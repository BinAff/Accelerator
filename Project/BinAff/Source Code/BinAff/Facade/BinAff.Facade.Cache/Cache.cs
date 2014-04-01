using System;
using System.Collections.Generic;

namespace BinAff.Facade.Cache
{

    public class Cache
    {

        static Cache()
        {
            cache = new Dictionary<String, Object>();
        }

        private static Dictionary<String, Object> cache;

        public Object this[String key]
        {
            get
            {
                if (cache.ContainsKey(key))
                {
                    return cache[key];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (cache.ContainsKey(key))
                {
                    cache[key] = value;
                }
                else
                {
                    Add(key, value);
                }
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
