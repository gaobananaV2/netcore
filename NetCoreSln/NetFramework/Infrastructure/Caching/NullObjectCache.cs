namespace Infrastructure.Caching
{
    //不希望数据缓存时可以使用 Null Object 模式作为“替身”
    public class NullObjectCache : ICacheManager
    {
        public void Remove(string key)
        {
             
        }

        public void Set(string key, object data)
        {
             
        }

        public T Get<T>(string key)
        {
            return default(T);
        }


        public void Set(string key, object data, int cacheTime)
        {
            
        }

        public bool IsSet(string key)
        {
            return false; 
        }


        public void RemoveByPattern(string pattern)
        {
             
        }

        public void Clear()
        {
             
        }
    }
}
