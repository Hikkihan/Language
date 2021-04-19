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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        Session1Entities db = new Session1Entities();
        public AddClient()
        {
            InitializeComponent(); 
            db.Gender.Load();
            genderBox.ItemsSource = db.Gender.Local.ToBindingList();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            Client client = new Client();

            client.LastName = lastName.Text;
            client.FirstName = firstName.Text;
            client.Patronymic = patronymic.Text;
            client.Birthday = birthdate.SelectedDate;
            client.Email = email.Text;
            client.Phone = phone.Text;

            Gender selGender = genderBox.SelectedItem as Gender;

            client.GenderCode = selGender.Code;

            if (lastName.Text == null || firstName.Text == null || patronymic.Text == null || birthdate.SelectedDate == null || email.Text == null || phone.Text == null || genderBox.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                db.Client.Add(client);
                db.SaveChanges();
                this.Close();
            }
        }
    }
}
