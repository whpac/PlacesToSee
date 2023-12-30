using System.Windows;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.WpfApp.Country;

public partial class CountryEditWindow : Window {
    private readonly IDAO _dao;
    private ICountry _country;
    public CountryEditWindow(ICountry? country, IDAO dao) {
        _dao = dao;
        
        InitializeComponent ();
        
        if (country is not null)
        {
            _country = country;
            _dao.RemoveCountry (country);
        }
        else
        {
            _country = _dao.CreateCountry ();
        }
        DataContext = _country;
        
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        _dao.AddCountry (_country);
        var countryPage = new CountryWindow (_dao);
        countryPage.Show ();
        this.Close ();
    }
}