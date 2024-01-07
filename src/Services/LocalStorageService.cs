using System.Collections.Concurrent;
using System.Text.Json;

namespace SmartLocate.Desktop.Admin.Services;

public class LocalStorageService
{
    private readonly ConcurrentDictionary<string, byte[]> _storage = new();

    public T GetItem<T>(string key)
    {
        return _storage.TryGetValue(key, out var value) ? (T)JsonSerializer.Deserialize(value, typeof(T)) : default;
    }

    public byte[] GetItem(string key)
    {
        return _storage.GetValueOrDefault(key);
    }
    
    public void SetItem<T>(string key, T value)
    {
        _storage.AddOrUpdate(key, JsonSerializer.SerializeToUtf8Bytes(value), (_, _) => JsonSerializer.SerializeToUtf8Bytes(value));
    }
    
    public void SetItem(string key, byte[] value)
    {
        _storage.AddOrUpdate(key, value, (_, _) => value);
    }
    
    public void RemoveItem(string key)
    {
        _storage.TryRemove(key, out _);
    }
    
    public void Clear()
    {
        _storage.Clear();
    }
}