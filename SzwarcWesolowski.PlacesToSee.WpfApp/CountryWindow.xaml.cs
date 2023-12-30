using System.Windows;
using SzwarcWesolowski.PlacesToSee.BLC;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.WpfApp;

public partial class CountryWindow : Window {
    private IDAO _dao;
    public CountryWindow(IDAO dao) {
        _dao = dao;
        InitializeComponent ();
        Populate ();
    }

    private void Populate() {
        
        var countriesArray = _dao.GetCountries ();
        countries.ItemsSource = countriesArray;
    }

    private void Return_OnClick(object sender, RoutedEventArgs e) {
        var mainPage = new MainWindow ();
        mainPage.Show ();
        this.Close ();
    }
}