using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        Session1Entities db = new Session1Entities();
        int ID = 0;
        public EditClient(Client client)
        {
            InitializeComponent();
            db.Gender.Load();
            ID = client.ID;
            genderBox.ItemsSource = db.Gender.Local.ToBindingList();

            lastName.Text = client.LastName;
            firstName.Text = client.FirstName;
            patronymic.Text = client.Patronymic;
            birthdate.SelectedDate = client.Birthday.Value;
            email.Text = client.Email;
            phone.Text = client.Phone;
            genderBox.SelectedItem = client.Gender.Name;
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            var client = db.Client.Where(c => c.ID == ID).FirstOrDefault();

            client.LastName = lastName.Text;
            client.FirstName = firstName.Text;
            client.Patronymic = patronymic.Text;
            client.Birthday = birthdate.SelectedDate;
            client.Email = email.Text;
            client.Phone = phone.Text;

            Gender selGender = genderBox.SelectedItem as Gender;

            client.GenderCode = selGender.Code;

            if (selGender.Code == null)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                db.SaveChanges();
                this.Close();
            }

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
