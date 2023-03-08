using filmography.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace filmography
{
    /// <summary>
    /// Логика взаимодействия для ProducersPage.xaml
    /// </summary>
    public partial class ProducersPage : Page
    {
        ActorContext db;
        int editId = 0;
        string editName = "";
        DateTime editDate = DateTime.Now;
        string editCountry = "";
        int editIdFilm = 0;
        int deleteId = 0;
        public ProducersPage()
        {
            InitializeComponent();

            db = new ActorContext();
            db.Producers.Load();
            producersGrid.ItemsSource = db.Producers.Local.ToBindingList();

        }
        private void Button_Click_AddingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Visible;
            foreach (Film f in db.Films) addNameFilm.Items.Add(f.Name);
        }
        private void Button_Click_Adding(object sender, RoutedEventArgs e)
        {
            Producer producer = new Producer();
            if (addName.Text != "")
            {
                if (addDate.SelectedDate != null)
                {
                    if (addCountry.Text != "")
                    {
                        if (addNameFilm.Text != "")
                        {
                            producer.Name = addName.Text;
                            producer.Date_of_birth = addDate.SelectedDate.Value;
                            producer.Country = addCountry.Text;
                            foreach (Film f in db.Films)
                            {
                                if (f.Name == addNameFilm.Text)
                                {
                                    producer.Id_film = f.Id;
                                }
                            }
                            db.Producers.Add(producer);
                            db.SaveChanges();
                            AddingForm.Visibility = Visibility.Hidden;
                            MessageBox.Show("Successful addition");
                        }
                        else MessageBox.Show("The field 'Film's name' is not filled");
                    }
                    else MessageBox.Show("The field 'Country' is not filled");
                }
                else MessageBox.Show("The field 'Date of birth' is not filled");
            }
            else MessageBox.Show("The field 'Name' is not filled");

        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
        }
        private void Button_Click_EditingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Producer index = (Producer)producersGrid.SelectedItem;
            if (index != null)
            {
                editName = index.Name;
                editDate = index.Date_of_birth;
                editCountry = index.Country;
                editId = index.Id;
                editIdFilm = index.Id_film;
                Producer producer = db.Producers.Find(editId);
                producer.Name = editName;
                producer.Date_of_birth = editDate;
                producer.Country = editCountry;
                producer.Id_film = editIdFilm;
                db.SaveChanges();
                producersGrid.Items.Refresh();
                MessageBox.Show("Successful editing");
            }
        }

        private void Button_Click_DeletingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Producer index = (Producer)producersGrid.SelectedItem;
            deleteId = index.Id;
            Producer producer = db.Producers.Find(deleteId);
            db.Producers.Remove(producer);
            db.SaveChanges();
            MessageBox.Show("Successful deleting");
        }
    }
}

