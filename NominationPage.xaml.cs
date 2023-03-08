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
    /// Логика взаимодействия для NominationPage.xaml
    /// </summary>
    public partial class NominationPage : Page
    {
        ActorContext db;
        int editId = 0;
        string editName = "";
        int deleteId = 0;
        public NominationPage()
        {
            InitializeComponent();

            db = new ActorContext();
            db.Nominations.Load();
            nominationsGrid.ItemsSource = db.Nominations.Local.ToBindingList();

        }
        private void Button_Click_AddingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Visible;
        }
        private void Button_Click_Adding(object sender, RoutedEventArgs e)
        {
            Nomination nomination = new Nomination();
            if (addName.Text != "")
            {
                nomination.Name = addName.Text;
                db.Nominations.Add(nomination);
                db.SaveChanges();
                AddingForm.Visibility = Visibility.Hidden;
                MessageBox.Show("Successful addition");
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
            Nomination index = (Nomination)nominationsGrid.SelectedItem;
            if (index != null)
            {
                editName = index.Name;
                Nomination nomination = db.Nominations.Find(editId);
                nomination.Name = editName;
                db.SaveChanges();
                nominationsGrid.Items.Refresh();
                MessageBox.Show("Successful editing");
            }
        }

        private void Button_Click_DeletingForm(object sender, RoutedEventArgs e)
        {
            AddingForm.Visibility = Visibility.Hidden;
            Nomination index = (Nomination)nominationsGrid.SelectedItem;
            deleteId = index.Id;
            Nomination nomination = db.Nominations.Find(deleteId);
            db.Nominations.Remove(nomination);
            db.SaveChanges();
            MessageBox.Show("Successful deleting");
        }
    }
}
