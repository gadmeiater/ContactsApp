using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс, содержащий 6 полей
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Фамилия 
        /// </summary>
        private string _lastname;

        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// День рождения
        /// </summary>
        private DateTime _dateOfBirth;

        /// <summary>
        /// Почта
        /// </summary>
        private string _email;

        /// <summary>
        /// Айди Вконтакте
        /// </summary>
        private string _vkid;

        //Автосвойтсво для поля Phone
        public Phone phoneNumber { get; set; }

        /// <summary>
        /// Фамилия контакта, ограничение в 50 символов
        /// </summary>
        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("максимальное количество символов = 50");
                }
                _lastname = value;
            }
        }

        /// <summary>
        /// Имя контакта, ограничение в 50 символов
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("максимальное количество символов = 50");
                }
                _name = value;
            }
        }

        /// <summary>
        /// дата рождения контакта, год не может быть < 1900 и не может быть более текущей даты
        /// </summary>
        public DateTime dateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value.Year < 1900 || value > DateTime.Now)
                {
                    throw new ArgumentException("дата рождения должна быть в промежутке между 1900 и сейчас");
                }
                _dateOfBirth = value;
            }
        }

        /// <summary>
        /// электронная почта контакта, ограничение в 50 символов
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("максимальное количество символов = 50");
                }
                _email = value;
            }
        }

        /// <summary>
        /// ВКайди контакта, ограничение в 15 символов
        /// </summary>
        public string VKid
        {
            get
            {
                return _vkid;
            }
            set
            {
                if (value.Length > 15)
                {
                    throw new ArgumentException("максимальное количество символов = 15");
                }
                _vkid = value;
            }
        }

        /// <summary>
        /// Метод, который возвращает копию объекта
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Contact(phoneNumber, Lastname, Name, dateOfBirth, Email, VKid);
        }

        /// <summary>
        /// Конструктор, для установки значений
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="lastname"></param>
        /// <param name="name"></param>
        /// <param name="birthdate"></param>
        /// <param name="email"></param>
        /// <param name="vkid"></param>

        public Contact(Phone phone, string lastname, string name, DateTime birthdate,
            string email, string vkid)
        {
            phoneNumber = phone;
            _lastname = lastname;
            _name = name;
            _dateOfBirth = birthdate;
            _email = email;
            _vkid = vkid;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Contact()
        {

        }
    }
}
