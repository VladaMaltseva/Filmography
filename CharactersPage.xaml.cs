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
    /// Логика взаимодействия для CharactersPage.xaml
    /// </summary>
    public partial class CharactersPage : Page
    {
        ActorContext db;
        int editId = 0;
        string editName = "";
        string editRoleType = "";
        int editIdActor = 0;
        int editIdFilm = 0;
        int deleteId = 0;
        public CharactersPage()
        {

            InitializeComponent();

            db = new ActorContext();
            db.Characters.Load();
            charactersGrid.ItemsSource = db.Characters.Local.ToBindingList();
        }
        private void Button_Click_AddingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Visible;
            foreach (Actor a in db.Actors) addNameActor.Items.Add(a.Name);
            foreach (Film f in db.Films) addNameFilm.Items.Add(f.Name);
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
        }
        private void Button_Click_Adding(object sender, RoutedEventArgs e)
        {
            Character character = new Character();
            if (addName.Text != "")
            {
                if (addRoleType.Text != "")
                {
                    if (addNameActor.Text != "")
                    {
                        if (addNameFilm.Text != "")
                        {
                            character.Name = addName.Text;
                            character.Role_type = addRoleType.Text;
                            foreach (Actor a in db.Actors)
                            {
                                if (a.Name == addNameActor.Text)
                                {
                                    character.Id_actor = a.Id;
                                }
                            }
                            foreach (Film f in db.Films)
                            {
                                if (f.Name == addNameFilm.Text)
                                {
                                    character.Id_film = f.Id;
                                }
                            }
                            db.Characters.Add(character);
                            db.SaveChanges();
                            addName.Text = "";
                            addRoleType.Text = "";
                            addNameActor.Items.Clear();
                            addNameFilm.Items.Clear();
                            AddingForm.Visibility = Visibility.Hidden;
                            MessageBox.Show("Successful addition");
                        }
                        else MessageBox.Show("The field 'Film's name' is not filled");
                    }
                    else MessageBox.Show("The field 'Actor's name' is not filled");
                }
                else MessageBox.Show("The field 'Role type' is not filled");
            }
            else MessageBox.Show("The field 'Name' is not filled");
        }
        private void Button_Click_EditingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Character index = (Character)charactersGrid.SelectedItem;
            if (index != null)
            {
                editId = index.Id;
                editName = index.Name;
                editRoleType = index.Role_type;
                editIdActor = index.Id_actor;
                editIdFilm = index.Id_film;
                Character character = db.Characters.Find(editId);
                character.Name = editName;
                character.Role_type = editRoleType;
                character.Id_actor = editIdActor;
                character.Id_film = editIdFilm;
                db.SaveChanges();
                charactersGrid.Items.Refresh();
                MessageBox.Show("Successful editing");
            }
            else MessageBox.Show("Тot selected field");
        }

        private void Button_Click_DeletingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Character index = (Character)charactersGrid.SelectedItem;
            deleteId = index.Id;
            Character character = db.Characters.Find(deleteId);
            db.Characters.Remove(character);
            db.SaveChanges();
            MessageBox.Show("Successful deleting");
        }
    }
}
