using Newtonsoft.Json;

namespace JsonCRUD;
public class JsonDb <T>
{
    private string _path;
    private T _data;
    
    public JsonDb(string path)
    {
        if (!Path.IsPathRooted(path))
            throw new ArgumentException("Path must be rooted");
        
        _path = path;
        _data = JsonConvert.DeserializeObject<T>(File.ReadAllText(_path));
    }

    public void CreateJson(T data)
    {
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        
        File.WriteAllText(_path, json);
    }
    
    public T ReadJson()
    {
        return _data;
    }
    
    public void UpdateJson(T data)
    {
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        
        File.WriteAllText(_path, json);
    }
    
    public void DeleteJson()
    {
        File.Delete(_path);
    }
}
