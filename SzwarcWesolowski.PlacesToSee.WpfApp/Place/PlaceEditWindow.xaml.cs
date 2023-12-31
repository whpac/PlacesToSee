using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.WpfApp.Place;

public partial class PlaceEditWindow : Window {
    private readonly IDAO _dao;
    private IPlace _place;
    private bool _isEditing;
    private IEnumerable<ICountry> CountryList { get; }
    private IEnumerable<IRegion> RegionList { get; }
    private double Longitude { get; set; }
    private double Latitude { get; set; }
    public PlaceEditWindow(IPlace? place, IDAO dao) {
        _dao = dao;
        
        InitializeComponent ();
        CountryList = _dao.GetCountries ();
        RegionList =  _dao.GetRegions ();

        CountryComboBox.ItemsSource = CountryList;
        RegionComboBox.ItemsSource = RegionList;
        
        if (place is not null)
        {
            _place = place;
            _dao.RemovePlace (place);
            Longitude = _place.Location.Longitude;
            Latitude = _place.Location.Latitude;
            _isEditing = true;
        }
        else
        {
            _place = _dao.CreatePlace ();
            Longitude = 0;
            Latitude = 0;
            _isEditing = false;
        }
        LatitudeText.Text = Latitude.ToString ();
        LongitudeText.Text = Longitude.ToString ();
        DataContext = _place;

    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        Latitude = Convert.ToDouble (LatitudeText.Text);
        Longitude = Convert.ToDouble (LongitudeText.Text);
        _place.SetLocation (Latitude, Longitude);
        _dao.AddPlace (_place);
        var listPage = new PlaceWindow (_dao);
        listPage.Show ();
        Close ();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) {
        if (_isEditing)
        {
            _dao.AddPlace (_place);
        }
        var listPage = new PlaceWindow (_dao);
        listPage.Show ();
        Close ();
    }
}