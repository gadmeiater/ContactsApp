﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс, содержащий номер телефона.
    /// </summary>
    public class Phone
    {
        private long _number;
        public long Number
        {
            get { return _number; }
            set
            {
                if (value.ToString()[0] !='7')
                {
                    throw new ArgumentException("Номер должен начинаться с 7");
                }

                else if (value > 80000000000)
                {
                    throw new ArgumentException("Неверно, номер должен содежать 11 цифр");
                }

                else if (value < 70000000000)
                {
                    throw new ArgumentException("Неверно, номер должен содежать 11 цифр");
                }
                _number = value;
            }
        }
    }
}
