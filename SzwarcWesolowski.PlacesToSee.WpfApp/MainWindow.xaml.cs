using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SzwarcWesolowski.PlacesToSee.BLC;
using SzwarcWesolowski.PlacesToSee.Interfaces;
using SzwarcWesolowski.PlacesToSee.WpfApp.Place;
using SzwarcWesolowski.PlacesToSee.WpfApp.Region;

namespace SzwarcWesolowski.PlacesToSee.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private IDAO _dao;
        public MainWindow()
        {
            var daoPath = @"SzwarcWesolowski.PlacesToSee.DAO.MemoryBased.dll";
            if (! ExternalDAOManager.IsInitialized)
            {
                ExternalDAOManager.Initialize(daoPath);
            }
            _dao = ExternalDAOManager.GetDAOInstance();
            InitializeComponent();
        }


        private void CountryPageButton_OnClick(object sender, RoutedEventArgs e) {
            var countriesPage = new CountryWindow (_dao);
            countriesPage.Show ();
            this.Close ();
        }

        private void RegionPageButton_OnClick(object sender, RoutedEventArgs e) {
            var regionsPage = new RegionWindow (_dao);
            regionsPage.Show ();
            Close ();
        }

        private void PlacePageButton_OnClick(object sender, RoutedEventArgs e) {
            var placesPage = new PlaceWindow (_dao);
            placesPage.Show ();
            Close ();
        }

        private void Empty_OnClick(object sender, RoutedEventArgs e) {
            Close ();
        }
    }
}