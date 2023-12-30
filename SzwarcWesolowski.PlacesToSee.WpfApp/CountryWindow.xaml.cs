using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
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

    private void Edit_OnClick(object sender, RoutedEventArgs e) {
        Console.WriteLine ("Editing: nothing here");
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e) {
        var button = (Button) sender;
        var item = (ICountry) button.DataContext;
        _dao.RemoveCountry (item);
        countries.Items.Refresh ();
    }

    private void New_OnClick(object sender, RoutedEventArgs e) {
        _dao.CreateCountry ("Ukraina", "");
        countries.Items.Refresh ();
    }
}