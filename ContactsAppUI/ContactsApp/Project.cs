using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс Project, который содержит список всех контактов
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Лист, который хранит в себе список контактов.
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Функция, выполняющая поиск контактов
        /// </summary>
        /// <param name="project">Список, который нужно отсортировать</param>
        /// <returns>Отсортированный список</returns>
        public static Project Sort(Project project, string substring)
        {
            Project sortedProject = new Project();

            foreach (Contact item in project.Contacts)
            {
                if (item.Lastname.Contains(substring) || item.Name.Contains(substring))
                {
                    sortedProject.Contacts.Add(item);
                }

            }

            if (sortedProject.Contacts.Count == 0)
            {
                sortedProject = null;
                return sortedProject;
            }

            sortedProject.Contacts.Sort();

            return sortedProject;
        }

        /// <summary>
        /// Функция, выполняющая поиск людей, у который день рождения в указанную дату.
        /// </summary>
        /// <param name="project">Проект, содержащий список людей, среди который будем искать у кого день рождения.</param>
        /// <param name="today">Дата дня рождения.</param>
        /// <returns>Проект, хранящий список именинников.</returns>
        public static Project Birthday(Project project, DateTime today)
        {
            Project birthdayList = new Project();

            for (int i = 0; i < project.Contacts.Count; i++)
            {
                if (project.Contacts[i].dateOfBirth.Day == today.Day &&
                    project.Contacts[i].dateOfBirth.Month == today.Month)
                {
                    birthdayList.Contacts.Add(project.Contacts[i]);
                }
            }

            return birthdayList;
        }
    }
 
}

