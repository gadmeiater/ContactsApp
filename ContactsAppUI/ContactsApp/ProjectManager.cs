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
    /// Класс, реализующий сохранение данных в файл и загрузки из него.
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// Стандартный путь к файлу.
        /// </summary>
        public static readonly string FilesDirectory =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
            "\\ContactApp" + "\\ContactApp.notes";

        /// <summary>
        /// Метод, выполняющий запись в файл 
        /// </summary>
        /// <param name="contact">Экземпляр проекта для сериализации</param>
        /// <param name="fileContactAppPath">Путь к файлу</param>
        public static void SaveToFile(Project contact)
        {
            JsonSerializer serializer = new JsonSerializer();
            var directoryFileContactApp = System.IO.Path.GetDirectoryName(FilesDirectory);

            if (!System.IO.Directory.Exists(directoryFileContactApp))
            {
                Directory.CreateDirectory(directoryFileContactApp);
            }

            if (!System.IO.File.Exists(FilesDirectory))
            {
                File.Create(FilesDirectory).Close();
            }
            using (StreamWriter sw = new StreamWriter(FilesDirectory))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, contact);
            }
        }

        /// <summary>
        /// Метод, выполняющий чтение из файла 
        /// </summary>
        public static Project LoadFromFile()
        {
            try
            {
                Project project = new Project();
                JsonSerializer serializer = new JsonSerializer();
                if (System.IO.File.Exists(FilesDirectory))
                {
                    using (StreamReader sr = new StreamReader(FilesDirectory))
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        project = (Project)serializer.Deserialize<Project>(reader);
                    }
                }
                return project;
            }
            catch
            {
                return new Project();
            }
        }
    }
}
