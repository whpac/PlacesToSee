using System.Windows;
using System.Windows.Controls;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.WpfApp.Country;

public partial class CountryEditWindow : Window {
    private readonly IDAO _dao;
    private ICountry _country;
    private bool _isEditing;
    private bool _isNameCorrect = true;
    public CountryEditWindow(ICountry? country, IDAO dao) {
        _dao = dao;
        
        InitializeComponent ();
        
        if (country is not null)
        {
            _country = country;
            _dao.RemoveCountry (country);
            _isEditing = true;
        }
        else
        {
            _country = _dao.CreateCountry ();
            _isEditing = false;
        }
        DataContext = _country;
        
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {
        if (NameText.Text.Length > 0)
        {
            errorName.Text = "";
            _isNameCorrect = true;
        }
        else
        {
            errorName.Text = "This field cannot be empty.";
            _isNameCorrect = false;
        }

        if (_isNameCorrect)
        {
            _dao.AddCountry (_country);
            var countryPage = new CountryWindow (_dao);
            countryPage.Show ();
            Close ();
        }
        
    }
    
    private void CancelButton_Click(object sender, RoutedEventArgs e) {
        if (_isEditing)
        {
            _dao.AddCountry (_country);
        }
        var listPage = new CountryWindow (_dao);
        listPage.Show ();
        Close ();
    }

    private void NameText_OnTextChanged(object sender, TextChangedEventArgs e) {
        if (NameText.Text.Length > 0)
        {
            errorName.Text = "";
            _isNameCorrect = true;
        }
        else
        {
            errorName.Text = "This field cannot be empty.";
            _isNameCorrect = false;
        }
    }
}