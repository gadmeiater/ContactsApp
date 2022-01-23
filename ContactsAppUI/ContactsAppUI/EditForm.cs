using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsApp
{
    /// <summary>
    /// Класс формы EditForm
    /// </summary>
    public partial class AddEditForm : Form
    {
        private Contact _сontact = new Contact();
        private string _textException;
        private bool buttonOKisAvailableToClick_Lastname = false;
        private bool buttonOKisAvailableToClick_Name = false;
        private bool buttonOKisAvailableToClick_Birthday = false;
        private bool buttonOKisAvailableToClick_Phone = false;
        private bool buttonOKisAvailableToClick_Email = false;
        private bool buttonOKisAvailableToClick_IdVk = false;

        /// <summary>
        ///  Метод, устанавливающий и возвращающий данные о контакте
        /// </summary>
        public Contact Contact
        {
            get { return _сontact; }
            set
            {
                _сontact.Lastname = value.Lastname;
                _сontact.Name = value.Name;
                _сontact.PhoneNumber.Number = value.PhoneNumber.Number;
                _сontact.dateOfBirth = value.dateOfBirth;
                _сontact.Email = value.Email;
                _сontact.VKid = value.VKid;
            }
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public AddEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Запись в DialogResult "OK" при нажатии "ОК".
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (buttonOKisAvailableToClick_Lastname && buttonOKisAvailableToClick_Name &&
                buttonOKisAvailableToClick_Birthday && buttonOKisAvailableToClick_Phone &&
                buttonOKisAvailableToClick_Email && buttonOKisAvailableToClick_IdVk == true)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }

            else
            {
                buttonOk.Enabled = false;
                ToolTip okToolTip = new ToolTip();
                okToolTip.Show("Form has incorrect values.", buttonOk,
                    (Point)(textBoxSurename.Size + new Size(-500, 10)), 1000);
                buttonOk.Enabled = true;
            }
        }

        /// <summary>
        /// Запись в DialogResult "Cancel" при нажатии "Cancel".
        /// </summary>
        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Считывает фамилию контакта с TextBox
        /// </summary>
        private void textBoxLastname_TextChanged_1(object sender, EventArgs e)
        {
            int countException = 0;
            ToolTip LastnameToolTip = new ToolTip();

            try
            {
                _сontact.Lastname = textBoxSurename.Text;
                buttonOKisAvailableToClick_Lastname = true;
            }
            catch (Exception exception)
            {
                _textException = exception.Message;
                countException++;
                buttonOKisAvailableToClick_Lastname = false;
            }

            if (countException != 0)
            {
                textBoxSurename.BackColor = Color.LightSalmon;
                LastnameToolTip.Show(_textException, textBoxSurename,
                    (Point)(textBoxSurename.Size + new Size(-400, 10)), 1000);
            }

            else
            {
                textBoxSurename.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Считывает имя контакта с TextBox
        /// </summary>
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            int countException = 0;
            ToolTip nameToolTip = new ToolTip();

            try
            {
                _сontact.Name = textBoxName.Text;
                buttonOKisAvailableToClick_Name = true;
            }

            catch (Exception exception)
            {
                _textException = exception.Message;
                countException++;
                buttonOKisAvailableToClick_Name = false;
            }

            if (countException != 0)
            {
                textBoxName.BackColor = Color.LightSalmon;
                nameToolTip.Show(_textException, textBoxName,
                    (Point)(textBoxName.Size + new Size(-400, 10)), 1000);
            }

            else
            {
                textBoxName.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Считывает дату рождения контакта с TextBox
        /// </summary>
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            int countException = 0;
            ToolTip dateOfBirthToolTip = new ToolTip();

            try
            {
                _сontact.dateOfBirth = dateTimePicker1.Value;
                buttonOKisAvailableToClick_Birthday = true;
            }
            catch (Exception exception)
            {
                _textException = exception.Message;
                countException++;
                buttonOKisAvailableToClick_Birthday = false;
            }

            if (countException != 0)
            {
                dateTimePicker1.CalendarMonthBackground = Color.LightSalmon;
                dateOfBirthToolTip.Show(_textException, dateTimePicker1,
                    (Point)(dateTimePicker1.Size + new Size(-163, 10)), 1000);
            }
            else
            {
                dateTimePicker1.CalendarMonthBackground = Color.White;
            }
        }

        /// <summary>
        /// Считывает номер телефона контакта с TextBox
        /// </summary>
        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {
            int countException = 0;
            ToolTip phoneToolTip = new ToolTip();

            try
            {
                if (textBoxPhone.Text.Length == 11)
                {
                    _сontact.PhoneNumber.Number = Convert.ToInt64(textBoxPhone.Text);
                    buttonOKisAvailableToClick_Phone = true;
                }
                else
                {
                    countException++;
                    phoneToolTip.Show("Filed is empty.", textBoxPhone,
                        (Point)(textBoxPhone.Size + new Size(-400, 10)), 1000);
                    buttonOKisAvailableToClick_Phone = false;
                }
            }

            catch (ArgumentException exception)
            {
                _textException = exception.Message;
                countException++;
                buttonOKisAvailableToClick_Phone = false;
            }

            if (countException != 0)
            {
                textBoxPhone.BackColor = Color.LightSalmon;
                phoneToolTip.Show(_textException, textBoxPhone,
                    (Point)(textBoxPhone.Size + new Size(-400, 10)), 1000);
            }
            else
            {
                textBoxPhone.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Считывает e-mail контакта с TextBox
        /// </summary>
        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            int countException = 0;
            ToolTip emailToolTip = new ToolTip();

            try
            {
                _сontact.Email = textBoxEmail.Text;
                buttonOKisAvailableToClick_Email = true;
            }

            catch (Exception exception)
            {
                _textException = exception.Message;
                countException++;

                buttonOKisAvailableToClick_Email = false;
            }

            if (countException != 0)
            {
                textBoxEmail.BackColor = Color.LightSalmon;
                emailToolTip.Show(_textException, textBoxEmail,
                    (Point)(textBoxEmail.Size + new Size(-400, 10)), 1000);
            }

            else
            {
                textBoxEmail.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Считывает Id vk контакта с TextBox
        /// </summary>
        private void textBoxIdvkcom_TextChanged(object sender, EventArgs e)
        {
            int countException = 0;
            ToolTip idVkToolTip = new ToolTip();

            try
            {
                _сontact.VKid = textBoxIdvkcom.Text;
                buttonOKisAvailableToClick_IdVk = true;
            }

            catch (Exception exception)
            {
                _textException = exception.Message;
                countException++;
                buttonOKisAvailableToClick_IdVk = false;
            }

            if (countException != 0)
            {
                textBoxIdvkcom.BackColor = Color.LightSalmon;
                idVkToolTip.Show(_textException, textBoxIdvkcom,
                    (Point)(textBoxIdvkcom.Size + new Size(-400, 10)), 1000);
            }

            else
            {
                textBoxIdvkcom.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Заполняет форму для дальнейшего редактирования данных.
        /// </summary>
        private void AddEditForm_Load(object sender, EventArgs e)
        {
            if (_сontact.Lastname != null)
            {
                textBoxSurename.Text = _сontact.Lastname;
                textBoxName.Text = _сontact.Name;
                dateTimePicker1.Value = _сontact.dateOfBirth;
                textBoxPhone.Text = _сontact.PhoneNumber.Number.ToString();
                textBoxEmail.Text = _сontact.Email;
                textBoxIdvkcom.Text = _сontact.VKid;
            }
        }
    }
}
