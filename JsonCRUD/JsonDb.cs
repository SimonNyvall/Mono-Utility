using Newtonsoft.Json;

namespace JsonCRUD;
public class JsonDb <T>
{
    private readonly List<string> _path = new();
    private readonly List<T> _data = new();
    
    public JsonDb(string path)
    {
        if (!Path.IsPathRooted(path))
            throw new ArgumentException("Path must be rooted");
        
        _path.Add(path);
        _data.Add(JsonConvert.DeserializeObject<T>(File.ReadAllText(path)));
    }

    public void AddPath(string path)
    {
        _path.Add(path);
    }
    
    public void CreateJson(T data, int index)
    {
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        
        File.WriteAllText(_path[index], json);
    }
    
    public T ReadJson(int index)
    {
        return _data[index];
    }
    
    public void UpdateJson(T data, int index)
    {
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        
        File.WriteAllText(_path[index], json);
    }
    
    public void DeleteJson(int index)
    {
        File.Delete(_path[index]);
    }
}
