using System.Collections.Generic;
using System.Xml.Linq;
using System.Text.Json;
namespace Identity_Task2;

public class JsonService
{
    private readonly Option _option;

    public JsonService(Option option)
    {
        _option = option;
    }
    public void Tojon(string key,User user)
    {
        string path = _option.path;
        if (!System.IO.File.Exists(path))
        {
           
            var dict = new Dictionary<string,User>();
            dict.Add(key,user);
            String json = JsonSerializer.Serialize(dict);
            System.IO.File.WriteAllText(path, json);
        }
        else
        {
            var read = System.IO.File.ReadAllText(path);
            Dictionary<string,User> dict = JsonSerializer.Deserialize <Dictionary<string, User>> (read);
            if (dict.Count == 0)
            {
                Dictionary<string,User> _data = new Dictionary<string,User>();
                _data.Add(key,user);
                String jsonn = JsonSerializer.Serialize(_data);
                // System.IO.File.WriteAllText("output.json", jsonn);
                System.IO.File.WriteAllText(path, jsonn);
            }
            else
            {
                dict.Add(key,user);
                String jsonnn = Newtonsoft.Json.JsonConvert.SerializeObject(dict);
                System.IO.File.WriteAllText(path, jsonnn);
            }
        }
    }

    public  Dictionary<string,User> Fromjson()
    {

        string path = _option.path;
        if (!System.IO.File.Exists(path))
        {
            return null;
        }
        else
        {
            var read = System.IO.File.ReadAllText(path);
            Dictionary<string, User> dict = JsonSerializer.Deserialize<Dictionary<string, User>>(read);
            return dict;
        }
    }
}

