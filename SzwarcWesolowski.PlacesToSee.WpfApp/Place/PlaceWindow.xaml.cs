using System.Windows;
using System.Windows.Controls;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.WpfApp.Place;

public partial class PlaceWindow : Window {
    private readonly IDAO _dao;
    public PlaceWindow(IDAO dao) {
        _dao = dao;
        InitializeComponent ();
        Populate ();
    }
    
    private void Populate() {

        var placesArray = _dao.GetPlaces ();
        places.ItemsSource = placesArray;
    }

    private void Edit_OnClick(object sender, RoutedEventArgs e) {
        var button = (Button) sender;
        var editPage = new PlaceEditWindow((IPlace) button.DataContext, _dao);
        editPage.Show ();
        this.Close ();
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e) {
        var button = (Button) sender;
        var item = (IPlace) button.DataContext;
        _dao.RemovePlace (item);
        places.Items.Refresh ();
    }

    private void Return_OnClick(object sender, RoutedEventArgs e) {
        var mainPage = new MainWindow ();
        mainPage.Show ();
        this.Close ();
    }

    private void New_OnClick(object sender, RoutedEventArgs e) {
        var editPage = new PlaceEditWindow(null, _dao);
        editPage.Show ();
        this.Close ();
    }
}