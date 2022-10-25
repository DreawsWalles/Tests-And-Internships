using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Help
{
    public class JsonFiles
    {
        public static void Create(List<AskModel> parametrs, string filePath)
        {
            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<List<AskModel>>(file, parametrs);
            }
        }
        public static void Add(AskModel model, string filePath)
        {
            List<AskModel> tmp = GetAll(filePath);
            if (tmp == null)
                Create(new List<AskModel>() { model }, filePath);
            foreach (AskModel element in tmp)
                if (element.Id == model.Id)
                    throw new Exception("Елеменнт с таким Id уже добавлен");
            tmp.Add(model);
            using(FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<List<AskModel>>(file, tmp);
            }
        }
        public static AskModel Get(int id, string filePath)
        {
            List<AskModel> tmp = GetAll(filePath);
            if (tmp == null)
                throw new Exception("Данный файл пуст");
            foreach (AskModel element in tmp)
                if (element.Id == id)
                    return element;
            return null;
        }
        private static List<AskModel> GetAll(string filePath)
        {
            using(FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                return JsonSerializer.Deserialize<List<AskModel>>(file);
            }
        }
    }
}
