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
    /// Логика взаимодействия для FilmsPage.xaml
    /// </summary>
    public partial class FilmsPage : Page
    {
        ActorContext db;
        int editId = 0;
        string editName = "";
        string editCountry = "";
        int editYear = 0;
        int editIdActor = 0;
        int editIdStudio = 0;
        int deleteId = 0;
        public FilmsPage()
        {
            InitializeComponent();

            db = new ActorContext();
            db.Films.Load();
            filmsGrid.ItemsSource = db.Films.Local.ToBindingList();
        }
        private void Button_Click_AddingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Visible;
            foreach (Actor a in db.Actors) addNameActor.Items.Add(a.Name);
            foreach (Studio s in db.Studios) addNameStudio.Items.Add(s.Name);
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            SearchFilm.Visibility = Visibility.Hidden;
            filmsSearchGrid.Visibility = Visibility.Hidden;
        }
        private void Button_Click_Adding(object sender, RoutedEventArgs e)
        {
            Film film = new Film();
            int.TryParse(addYear.Text, out int yof);
            if (addName.Text != "")
            {
                if (addCountry.Text != "")
                {
                    if (addYear.Text != "")
                    {
                        if (yof < 2023 || yof > 1895)
                        {
                            if (addNameActor.Text != "")
                            {
                                if (addNameStudio.Text != "")
                                {
                                    film.Name = addName.Text;
                                    film.Country = addCountry.Text;
                                    film.Year_of_release = yof;
                                    foreach (Actor a in db.Actors) 
                                    {
                                        if (a.Name == addNameActor.Text)
                                        {
                                            film.Id_actor = a.Id;
                                        }
                                    }
                                    foreach (Studio s in db.Studios)
                                    {
                                        if (s.Name == addNameStudio.Text)
                                        {
                                            film.Id_studio = s.Id;
                                        }
                                    }
                                    db.Films.Add(film);
                                    db.SaveChanges();
                                    addName.Text="";
                                    addCountry.Text="";
                                    addYear.Text = "";
                                    addNameActor.Items.Clear();
                                    addNameStudio.Items.Clear();
                                    AddingForm.Visibility = Visibility.Hidden;
                                    MessageBox.Show("Successful addition");
                                }
                                else MessageBox.Show("The field 'Studio's name' is not filled");
                            }
                            else MessageBox.Show("The field 'Actor's name' is not filled");
                        }
                        else MessageBox.Show("The field 'Year of release' cannot have such values");
                    }
                    else MessageBox.Show("The field 'Year of release' is not filled");
                }
                else MessageBox.Show("The field 'Country' is not filled");
            }
            else MessageBox.Show("The field 'Name' is not filled");
        }
        private void Button_Click_EditingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Film index = (Film)filmsGrid.SelectedItem;
            if (index != null)
            {
                editId = index.Id;
                editName = index.Name;
                editCountry = index.Country;
                editYear = index.Year_of_release;
                editIdActor = index.Id_actor;
                editIdStudio = index.Id_studio;
                Film film = db.Films.Find(editId);
                film.Name = editName;
                film.Country = editCountry;
                film.Year_of_release = editYear;
                film.Id_actor = editIdActor;
                film.Id_studio = editIdStudio;
                db.SaveChanges();
                filmsGrid.Items.Refresh();
                MessageBox.Show("Successful editing");
            }
            else MessageBox.Show("Тot selected field");
        }

        private void Button_Click_DeletingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Film index = (Film)filmsGrid.SelectedItem;
            deleteId = index.Id;
            Film film = db.Films.Find(deleteId);
            db.Films.Remove(film);
            db.SaveChanges();
            MessageBox.Show("Successful deleting");
        }
        private void Button_Click_SearchingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            SearchFilm.Visibility = Visibility.Visible;

        }
        private void Button_Click_Searching(object sender, RoutedEventArgs e)
        {
            filmsSearchGrid.Visibility = Visibility.Visible;
            if (serchName.Text != "")
            {
                filmsSearchGrid.Items.Clear();
                string search = serchName.Text;
                System.Data.SqlClient.SqlParameter name = new System.Data.SqlClient.SqlParameter("@search", search);
                var searching = db.Database.SqlQuery<Film>("searchFilms @search", name);
                foreach (var film in searching) { filmsSearchGrid.Items.Add(film); }
            }

        }
    }
}
