using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для DataList.xaml
    /// </summary>
    public partial class DataList : Page
    {
        Session1Entities db = new Session1Entities();

        public DataList()
        {
            InitializeComponent();

            db.Client.Load();
            db.Gender.Load();
            dataGrid.ItemsSource = db.Client.Local.ToBindingList();
            genderBox.ItemsSource = db.Gender.Local.ToBindingList();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = searchBox.Text;

            var result = from c in db.Client
                         where (c.Email.Contains(search) || c.LastName.Contains(search) || c.FirstName.Contains(search) || c.Patronymic.Contains(search) || c.Phone.Contains(search))
                         select new { c.Email, c.LastName, c.FirstName, c.Patronymic, c.Phone, c.RegistrationDate, c.Birthday, c.GenderCode };

            dataGrid.ItemsSource = result.ToList();
        }

        private void Filtration(object sender, SelectionChangedEventArgs e)
        {
            Gender gender = genderBox.SelectedItem as Gender;
            var result = from c in db.Client
                         where (c.Gender.Name == gender.Name)
                         select new { c.Email, c.LastName, c.FirstName, c.Patronymic, c.Phone, c.RegistrationDate, c.Birthday, c.GenderCode };

            dataGrid.ItemsSource = result.ToList();
        }

        private void EditClient(object sender, System.Windows.RoutedEventArgs e)
        {
            Client client = dataGrid.SelectedItem as Client;

            if (client == null)
            {
                MessageBox.Show("Выберите клиента!");
            }
            else
            {
                EditClient form = new EditClient(client);
                form.ShowDialog();

            }

        }

        private void AddClient(object sender, System.Windows.RoutedEventArgs e)
        {
            AddClient form = new AddClient();
            form.ShowDialog();
        }

        private void Sorting(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)sortBox.SelectedItem;
            string sort = item.Content.ToString();
           
            switch(sort)
            {
                case "Фамилии":
                    var result = from c in db.Client
                                 orderby(c.LastName)
                                 select new { c.Email, c.LastName, c.FirstName, c.Patronymic, c.Phone, c.RegistrationDate, c.Birthday, c.GenderCode };
                    dataGrid.ItemsSource = result.ToList();
                    break; 
            }

            
        }
    }
}
