using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TirageTests
{
    public class JsonListDAO<T>
    {
        private readonly string directoryPath;

        public JsonListDAO(string directoryPath)
        {
            this.directoryPath = directoryPath;
            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        public bool SaveList(string name, List<T> list)
        {
            try
            {
                File.WriteAllText(directoryPath + Path.DirectorySeparatorChar + name + ".json", JsonSerializer.Serialize(list));
            }catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<T> LoadList(string name)
        {
            List<T> list;
            try
            {
                list = JsonSerializer.Deserialize<List<T>>(File.ReadAllText( directoryPath + Path.DirectorySeparatorChar + name + ".json"))!;
            }
            catch (Exception ex)
            {
                return null;
            }
            return list;
        }

        public List<string> GetJsonListFiles()
        {
            return Directory.GetFiles(directoryPath).Select(f => Path.GetFileNameWithoutExtension(f)).ToList();
        }
    }
}
