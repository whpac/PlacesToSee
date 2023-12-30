using System.Windows;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.WpfApp.Place;

public partial class PlaceEditWindow : Window {
    private readonly IDAO _dao;
    private IPlace _place;
    private IEnumerable<ICountry> CountryList { get; }
    private IEnumerable<IRegion> RegionList { get; }
    private double Longitude { get; set; }
    private double Latitude { get; set; }
    public PlaceEditWindow(IPlace? place, IDAO dao) {
        _dao = dao;
        this.CountryList = _dao.GetCountries ();
        RegionList =  _dao.GetRegions ();

        InitializeComponent ();

        if (place is not null)
        {
            _place = place;
            _dao.RemovePlace (place);
            Longitude = _place.Location.Longitude;
            Latitude = _place.Location.Latitude;
        }
        else
        {
            _place = _dao.CreatePlace ();
            Longitude = 0;
            Latitude = 0;
        }
        DataContext = _place;

    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        _place.SetLocation (Latitude, Longitude);
        _dao.AddPlace (_place);
        var listPage = new PlaceWindow (_dao);
        listPage.Show ();
        Close ();
    }
}