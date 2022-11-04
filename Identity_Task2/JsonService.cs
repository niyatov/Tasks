using System.Collections.Generic;
using System.Xml.Linq;
using System.Text.Json;
namespace Identity_Task2;

public class JsonService
{
    public void Tojon(string key,User user)
    {
        if (!System.IO.File.Exists("output.json"))
        {
            var dict = new Dictionary<string,User>();
            dict.Add(key,user);
            String json = JsonSerializer.Serialize(dict);
            System.IO.File.WriteAllText("output.json", json);
        }
        else
        {
            var read = System.IO.File.ReadAllText("output.json");
            Dictionary<string,User> dict = JsonSerializer.Deserialize <Dictionary<string, User>> (read);
            if (dict.Count == 0)
            {
                Dictionary<string,User> _data = new Dictionary<string,User>();
                _data.Add(key,user);
                String jsonn = JsonSerializer.Serialize(_data);
                System.IO.File.WriteAllText("output.json", jsonn);
            }
            else
            {
                dict.Add(key,user);
                String jsonnn = Newtonsoft.Json.JsonConvert.SerializeObject(dict);
                System.IO.File.WriteAllText("output.json", jsonnn);
            }
        }
    }

    public  Dictionary<string,User> Fromjson()
    {

        if (!System.IO.File.Exists("output.json"))
        {
            return null;
        }
        else
        {
            var read = System.IO.File.ReadAllText("output.json");
            Dictionary<string, User> dict = JsonSerializer.Deserialize<Dictionary<string, User>>(read);
            return dict;
        }
    }
}

