using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Application.Abstractions.RedisCach
{
    public interface IRedisCachService
    {
        Task<T> GetAsync<T>(string key);

        Task<bool> SetAsync<T>(string key, T value, DateTime? expire = null);
        Task<long> AppendAsync<T>(string key, T value);
        Task<bool> DeleteAsync(string key);

        Task<bool> ExistsAsync(string key);

        
    }
}
