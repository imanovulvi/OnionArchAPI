using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OnionArchAPI.Application.Abstractions.RedisCach;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Infrastructure.Concretes.RedisCach
{
    public class RedisCachService : IRedisCachService
    {
        private readonly IConnectionMultiplexer connectionMultiplexer;

        public RedisCachService(IConnectionMultiplexer connectionMultiplexer)
        {
            this.connectionMultiplexer = connectionMultiplexer;
        }



        public async Task<T?> GetAsync<T>(string key)
        {
            IDatabase database = connectionMultiplexer.GetDatabase();
            var value=await database.StringGetAsync(key);
            
            if (value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }



        public async Task<bool> SetAsync<T>(string key, T value,DateTime? expire=null)
        {
            TimeSpan? timeSpan;
            if (expire is not null)
                timeSpan = expire.Value - DateTime.Now;
            else
                timeSpan = null;

            IDatabase database = connectionMultiplexer.GetDatabase();
            return await database.StringSetAsync(key, JsonConvert.SerializeObject(value),timeSpan);
        }



        public async Task<bool> DeleteAsync(string key)
        {
            IDatabase database = connectionMultiplexer.GetDatabase();
           return await database.KeyDeleteAsync(key);
        }

        public async Task<long> AppendAsync<T>(string key, T value)
        {
            IDatabase database = connectionMultiplexer.GetDatabase();
           return  await database.StringAppendAsync(key, JsonConvert.SerializeObject(value));

        }

        public async Task<bool> ExistsAsync(string key)
        {
            IDatabase database = connectionMultiplexer.GetDatabase();
            return await database.KeyExistsAsync(key);
        }
    }
}
