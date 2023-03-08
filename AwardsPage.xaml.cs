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
    /// Логика взаимодействия для AwardsPage.xaml
    /// </summary>
    public partial class AwardsPage : Page
    {
        ActorContext db;
        int editId = 0;
        string editName = "";
        int editYear = 0;
        int editIdActor = 0;
        int editIdFilm = 0;
        int editIdNomination = 0;
        int deleteId = 0;
        public AwardsPage()
        {
            InitializeComponent();
            db = new ActorContext();
            db.Awards.Load();
            awardsGrid.ItemsSource = db.Awards.Local.ToBindingList();
        }
        private void Button_Click_AddingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Visible;
            foreach (Nomination n in db.Nominations) addNameNomination.Items.Add(n.Name);
            foreach (Actor a in db.Actors) addNameActor.Items.Add(a.Name);
            foreach (Film f in db.Films) addNameFilm.Items.Add(f.Name);
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
        }
        private void Button_Click_Adding(object sender, RoutedEventArgs e)
        {
            Award award = new Award();
            int.TryParse(addYear.Text, out int yof);
            if (addName.Text != "")
            {
                    if (addYear.Text != "")
                    {
                        if (yof < 2023 || yof > 1895)
                        {
                            if (addNameActor.Text != "")
                            {
                                if (addNameFilm.Text != "")
                                {
                                    if (addNameNomination.Text != "")
                                    {
                                        award.Name = addName.Text;
                                        award.Year = yof;
                                        foreach (Actor a in db.Actors)
                                        {
                                            if (a.Name == addNameActor.Text)
                                            {
                                            award.Id_actor = a.Id;
                                            }
                                        }
                                        foreach (Film f in db.Films)
                                        {
                                            if (f.Name == addNameFilm.Text)
                                            {
                                            award.Id_film = f.Id;
                                            }
                                        }
                                    foreach (Nomination n in db.Nominations)
                                    {
                                        if (n.Name == addNameNomination.Text)
                                        {
                                            award.Id_nomination = n.Id;
                                        }
                                    }
                                    db.Awards.Add(award);
                                        db.SaveChanges();
                                        addName.Text = "";
                                        addYear.Text = "";
                                        AddingForm.Visibility = Visibility.Hidden;
                                        MessageBox.Show("Successful addition");
                                    }
                                    else MessageBox.Show("The field 'Nomination's name' is not filled");
                                }
                                else MessageBox.Show("The field 'Film's name' is not filled");
                            }
                            else MessageBox.Show("The field 'Actor's name' is not filled");
                        }
                        else MessageBox.Show("The field 'Year' cannot have such values");
                    }
                    else MessageBox.Show("The field 'Year' is not filled");
            }
            else MessageBox.Show("The field 'Name' is not filled");
        }
        private void Button_Click_EditingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Award index = (Award)awardsGrid.SelectedItem;
            if (index != null)
            {
                editId = index.Id;
                editName = index.Name;
                editYear = index.Year;
                editIdActor = index.Id_actor;
                editIdFilm = index.Id_film;
                editIdNomination = index.Id_nomination;
                Award award = db.Awards.Find(editId);
                award.Name = editName;
                award.Year= editYear;
                award.Id_actor = editIdActor;
                award.Id_film = editIdFilm;
                award.Id_nomination = editIdNomination;
                db.SaveChanges();
                awardsGrid.Items.Refresh();
                MessageBox.Show("Successful editing");
            }
            else MessageBox.Show("Тot selected field");
        }

        private void Button_Click_DeletingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Award index = (Award)awardsGrid.SelectedItem;
            deleteId = index.Id;
            Award award = db.Awards.Find(deleteId);
            db.Awards.Remove(award);
            db.SaveChanges();
            MessageBox.Show("Successful deleting");
        }
    }
}
