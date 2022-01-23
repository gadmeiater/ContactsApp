using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsApp
{
    /// <summary>
    /// Класс основной формы
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Создаем список контактов.
        /// </summary>
        private Project _project;
        public MainForm()
        {
            InitializeComponent();
            _project = ProjectManager.LoadFromFile(ProjectManager.stringMyDocumentsPath);
            _project.Contacts.Sort();
            listBox1.DataSource = _project.Contacts;
            listBox1.DisplayMember = "Lastname";
            listBox1.ValueMember = "Name";

            Project birthContact = Project.Birthday(_project, DateTime.Today);
            if (birthContact.Contacts.Count != 0)
            {
                panel2.Visible = true;
                for (int i = 0; i < birthContact.Contacts.Count; i++)
                {
                    label9.Text = label9.Text + birthContact.Contacts[i].Lastname + ", ";
                }
            }
            else panel2.Visible = false;
        }

        /// <summary>
        /// Вывод выбранного элемента из ListBox
        /// </summary>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                Contact c = (Contact)listBox1.SelectedItem;
                textBoxLastname.Text = c.Lastname;
                textBoxName.Text = c.Name;
                textBoxEmail.Text = c.Email;
                textBoxVKid.Text = c.VKid;
                textBoxPhone.Text = c.PhoneNumber.ToString();
                dateTimePicker1.Value = c.dateOfBirth;
            }
        }

        /// <summary>
        /// Функция добавления контакта.
        /// </summary>
        private void AddContact()
        {
            var newForm = new AddEditForm();
            var resultOfDialog = newForm.ShowDialog();

            if (resultOfDialog == DialogResult.OK)
            {
                var contact = newForm.Contact;
                _project.Contacts.Add(contact);
                _project.Contacts.Sort();
                ProjectManager.SaveToFile(_project, ProjectManager.stringMyDocumentsPath);

                listBox1.DataSource = null;
                listBox1.DataSource = _project.Contacts;
                listBox1.DisplayMember = "LastName";
            }
        }

        /// <summary>
        /// Функция, выполняющая редактирование данных.
        /// </summary>
        private void EditContact()
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Choose the contact to edit.", "Edit");
            }

            Contact selectedContact = (Contact)listBox1.SelectedItem;
            var newForm = new AddEditForm();
            newForm.Contact = selectedContact;

            var resultOfDialog = newForm.ShowDialog();

            if(resultOfDialog == DialogResult.OK)
            {
                _project.Contacts[listBox1.SelectedIndex] = newForm.Contact;
                ProjectManager.SaveToFile(_project, ProjectManager.stringMyDocumentsPath);
                UpdateListBox();
            }

        }

        /// <summary>
        /// Функция удаления контакта.
        /// </summary>
        private void RemoveContact()
        {
            int index = listBox1.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Choose the contact to remove.", "Remove");
            }

            if (_project.Contacts.Count > 0)
            {
                string removeThisContact = "Do you really want to remove this contact: " + textBoxLastname.Text + "?";

                var result = MessageBox.Show(removeThisContact, "Remove", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    _project.Contacts.RemoveAt(index);
                    ProjectManager.SaveToFile(_project, ProjectManager.stringMyDocumentsPath);
                    UpdateListBox();
                }
                
            }
        }

        /// <summary>
        /// Обновление ListBox
        /// </summary>
        private void UpdateListBox()
        {
            listBox1.DataSource = null;
            if(_project != null)
            {
                listBox1.DataSource = _project.Contacts;
                listBox1.DisplayMember = "Lastname";
            }
        }

        /// <summary>
        /// Вызов окна добавления контакта
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        /// <summary>
        /// Вызов окна добавления контакта из выпадающего меню
        /// </summary>
        private void menuItem4_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        /// <summary>
        /// Кнопка редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        /// <summary>
        /// Кнопка удалить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        /// <summary>
        /// Кнопка редактировать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem5_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        /// <summary>
        /// Кнопка удалить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem6_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        /// <summary>
        /// Открытие AboutForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem8_Click(object sender, EventArgs e)
        {
            var newForm = new AboutForm();
            newForm.Show();
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Событие при смене текста в TextBox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                _project = Project.Sort(_project, textBox1.Text);
                UpdateListBox();

                _project = ProjectManager.LoadFromFile(ProjectManager.stringMyDocumentsPath);
            }

            else
            {
                _project = ProjectManager.LoadFromFile(ProjectManager.stringMyDocumentsPath);
                UpdateListBox();
            }
        }

        /// <summary>
        /// Удаление контакта по нажатию клавиши Delete.
        /// </summary>
        private void ContactsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveContact();
            }
        }
    }
}
