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
using filmography.Models;
using System.Data.Entity;

namespace filmography
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new ActorsPage();
        }

        private void Button_Click_Actors(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ActorsPage());
        }
        private void Button_Click_Films(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new FilmsPage());
        }
        private void Button_Click_Characters(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CharactersPage());
        }
        private void Button_Click_Studios(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StudiosPage());
        }
        private void Button_Click_Awards(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AwardsPage());
        }
        private void Button_Click_Nominations(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new NominationPage());
        }
        private void Button_Click_Producers(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProducersPage());
        }
    }
}
