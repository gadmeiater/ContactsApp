using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class Project
    {
        /// <summary>
        /// Лист, который хранит в себе список контактов.
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
