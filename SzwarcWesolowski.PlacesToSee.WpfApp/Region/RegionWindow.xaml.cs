using System.Windows;
using System.Windows.Controls;
using SzwarcWesolowski.PlacesToSee.Interfaces;
using SzwarcWesolowski.PlacesToSee.WpfApp.Country;

namespace SzwarcWesolowski.PlacesToSee.WpfApp.Region;

public partial class RegionWindow : Window {
    private IDAO _dao;
    public RegionWindow(IDAO dao) {
        _dao = dao;
        InitializeComponent ();
        Populate ();
    }

    private void Populate() {
        
        var regionsArray = _dao.GetRegions ();
        regions.ItemsSource = regionsArray;
    }
    
    private void Return_OnClick(object sender, RoutedEventArgs e) {
        var mainPage = new MainWindow ();
        mainPage.Show ();
        this.Close ();
    }

    private void Edit_OnClick(object sender, RoutedEventArgs e) {
        var button = (Button) sender;
        var editPage = new RegionEditWindow((IRegion) button.DataContext, _dao);
        editPage.Show ();
        this.Close ();
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e) {
        var button = (Button) sender;
        var item = (IRegion) button.DataContext;
        _dao.RemoveRegion (item);
        regions.Items.Refresh ();
    }

    private void New_OnClick(object sender, RoutedEventArgs e) {
        var editPage = new RegionEditWindow(null, _dao);
        editPage.Show ();
        this.Close ();
    }
}