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
    /// Логика взаимодействия для StudiosPage.xaml
    /// </summary>
    public partial class StudiosPage : Page
    {
        ActorContext db;
        int editId = 0;
        string editName = "";
        string editCountry = "";
        int editYear = 0;
        int deleteId = 0;
        public StudiosPage()
        {
            InitializeComponent();
            db = new ActorContext();
            db.Studios.Load();
            studiosGrid.ItemsSource = db.Studios.Local.ToBindingList();
        }
        private void Button_Click_AddingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Visible;
        }
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
        }
        private void Button_Click_Adding(object sender, RoutedEventArgs e)
        {
            Studio studio = new Studio();
            int.TryParse(addYear.Text, out int yof);
            if (addName.Text != "")
            {
                if(addCountry.Text!="")
                {
                    if (addYear.Text != "")
                    {
                        if(yof<2023 || yof > 1893)
                        {
                            studio.Name = addName.Text;
                            studio.Country = addCountry.Text;
                            studio.Year_of_foundation = yof;

                            db.Studios.Add(studio);
                            db.SaveChanges();
                            AddingForm.Visibility = Visibility.Hidden;
                            MessageBox.Show("Successful addition");
                        }
                        else MessageBox.Show("The field 'Year of foundation' cannot have such values");
                    }
                    else MessageBox.Show("The field 'Year of foundation' is not filled");
                }
                else MessageBox.Show("The field 'Country' is not filled");
            }
            else MessageBox.Show("The field 'Name' is not filled");

        }
        private void Button_Click_EditingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Studio index = (Studio)studiosGrid.SelectedItem;
            if (index != null)
            {
                editId = index.Id;
                editName = index.Name;
                editCountry = index.Country;
                editYear = index.Year_of_foundation;
                Studio studio = db.Studios.Find(editId);
                studio.Name = editName;
                studio.Country = editCountry;
                studio.Year_of_foundation = editYear;
                db.SaveChanges();
                studiosGrid.Items.Refresh();
                MessageBox.Show("Successful editing");
            }
        }

        private void Button_Click_DeletingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Studio index = (Studio)studiosGrid.SelectedItem;
            deleteId = index.Id;
            Studio studio = db.Studios.Find(deleteId);
            db.Studios.Remove(studio);
            db.SaveChanges();
            MessageBox.Show("Successful deleting");
        }
    }
}
