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
    /// Создание, загрузка и хранения файла
    /// </summary> 
    public class ProjectManager
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public static readonly string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + "\\ContactsApp" + "\\ContactsApp.json";

        /// <summary>
        /// Метод, выполняющий запись файла
        /// </summary>
        /// <param name="contact">Экземпляр проекта для сериализации</param>
        /// <param name="fileContactAppPath">Путь к файлу</param>
        public static void SaveToFile(Project contact, string fileContactAppPath)
        {
            JsonSerializer serializer = new JsonSerializer();
            var directoryFileContactApp = System.IO.Path.GetDirectoryName(fileContactAppPath);
            if (!System.IO.Directory.Exists(directoryFileContactApp))
            {
                Directory.CreateDirectory(directoryFileContactApp);
            }

            if (!System.IO.File.Exists(fileContactAppPath))
            {
                File.Create(fileContactAppPath).Close();
            }

            using (StreamWriter sw = new StreamWriter(fileContactAppPath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, contact);
            }
        }

        /// <summary>
        /// Метод, выполняющий чтение из файла 
        /// </summary>
        /// <param name="fileContactAppPath">Путь к файлу</param>
        /// <returns>Экземпляр проекта, считанный из файла</returns>
        public static Project LoadFromFile(string fileContactAppPath)
        {
            Project project = new Project();
            JsonSerializer serializer = new JsonSerializer();

            if (System.IO.File.Exists(fileContactAppPath))
            {
                using (StreamReader sr = new StreamReader(fileContactAppPath))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    project = (Project)serializer.Deserialize<Project>(reader);
                }
            }
            return project;
        }
    }
}
