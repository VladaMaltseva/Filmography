using filmography.Models;
using System;
using System.Collections.Generic;
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
using System.Data.Entity;

namespace filmography
{
    /// <summary>
    /// Логика взаимодействия для ActorsPage.xaml
    /// </summary>
    public partial class ActorsPage : Page
    {
        ActorContext db;
        int editId=0;
        string editName = "";
        DateTime editDate = DateTime.Now;
        string editCountry = "";
        int deleteId = 0;

        public ActorsPage()
        {
            InitializeComponent();

            db = new ActorContext();
            db.Actors.Load();
            actorsGrid.ItemsSource = db.Actors.Local.ToBindingList();
        }

        private void Button_Click_AddingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Visible;
        }
        private void Button_Click_Adding(object sender, RoutedEventArgs e)
        {
            Actor actor = new Actor();
            if (addName.Text != "")
            {
                if(addDate.SelectedDate != null)
                {
                    if (addCountry.Text != "")
                    {
                        actor.Name = addName.Text;
                        actor.Date_of_birth = addDate.SelectedDate.Value;
                        actor.Country = addCountry.Text;
                        db.Actors.Add(actor);
                        db.SaveChanges();
                        addName.Text = "";
                        addDate.SelectedDate = null;
                        addCountry.Text = "";
                        AddingForm.Visibility = Visibility.Hidden;
                        MessageBox.Show("Successful addition");
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
            SearchActor.Visibility = Visibility.Hidden;
            actorsSearchGrid.Visibility = Visibility.Hidden;
        }
        private void Button_Click_EditingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Actor index = (Actor)actorsGrid.SelectedItem;
            if (index != null)
            {
                editName = index.Name;
                editDate = index.Date_of_birth;
                editCountry = index.Country;
                editId = index.Id;
                Actor actor = db.Actors.Find(editId);
                actor.Name = editName;
                actor.Date_of_birth = editDate;
                actor.Country = editCountry;
                db.SaveChanges();
                actorsGrid.Items.Refresh();
            }
        }
        
        private void Button_Click_DeletingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Actor index = (Actor)actorsGrid.SelectedItem;
            if (index != null)
            {
                deleteId = index.Id;
                Actor actor = db.Actors.Find(deleteId);
                db.Actors.Remove(actor);
                db.SaveChanges();
            }
        }
        private void Button_Click_SearchingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            SearchActor.Visibility = Visibility.Visible;
            
        }
        private void Button_Click_Searching(object sender, RoutedEventArgs e)
        {
            actorsSearchGrid.Visibility = Visibility.Visible;
            if (serchName.Text != "")
            {
                actorsSearchGrid.Items.Clear();
                string search = serchName.Text;
                System.Data.SqlClient.SqlParameter name=new System.Data.SqlClient.SqlParameter("@search", search);
                var searching = db.Database.SqlQuery<Actor>("SELECT * FROM dbo.getSerchActors(@search)",name);
                foreach (var actor in searching) { actorsSearchGrid.Items.Add(actor); }
            }
            
        }
    }
}
