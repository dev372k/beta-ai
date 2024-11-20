using Microsoft.Extensions.Caching.Distributed;
using Shared.Helpers;
using System.Text.Json;

namespace Infrastructure.Externals;

public class CacheService
{
    private readonly IDistributedCache _cache;

    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task Set<T>(string key, T value) =>
        await _cache.SetStringAsync(key, JsonSerializer.Serialize(value), CacheHelper.CacheOptions());

    public async Task<T> Get<T>(string key)
    {
        var value = await _cache.GetStringAsync(key);
        if (!string.IsNullOrEmpty(value))
            return JsonSerializer.Deserialize<T>(value)!;
        return default!;
    }

    public async Task<bool> Remove(string key)
    {
        var value = await _cache.GetStringAsync(key);
        if (string.IsNullOrEmpty(value))
            return false;

        await _cache.RemoveAsync(key);
        return true;
    }
}
