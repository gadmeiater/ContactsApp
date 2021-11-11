using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// статичный класс для записи в файл
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// метод сериализации
        /// </summary>
        /// <param name="data">объект класса Project</param>
        /// <param name="filename">путь к файлу для записи</param>
        public static void SaveToFile(Project data, string filename)
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };
            using (StreamWriter sw = new StreamWriter(filename))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }

        }
        /// <summary>
        /// метод десериализации
        /// </summary>
        /// <param name="filename">путь к файлу</param>
        /// <returns></returns>
        public static Project LoadFromFile(string filename)
        {
            JsonSerializer serializer = new JsonSerializer()
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.All
            };
            using (StreamReader sr = new StreamReader(filename))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return (Project)serializer.Deserialize<Project>(reader);
            }
        }
    }
}