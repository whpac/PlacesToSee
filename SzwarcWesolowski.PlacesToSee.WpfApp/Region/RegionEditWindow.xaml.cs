using System.Windows;
using System.Windows.Controls;
using SzwarcWesolowski.PlacesToSee.Interfaces;

namespace SzwarcWesolowski.PlacesToSee.WpfApp.Region;

public partial class RegionEditWindow : Window {
    private readonly IDAO _dao;
    private IRegion _region;
    private bool _isEditing;
    private bool _isNameCorrect = true;

    public RegionEditWindow(IRegion? region, IDAO dao) {
        _dao = dao;

        InitializeComponent ();

        if (region is not null)
        {
            _region = region;
            _dao.RemoveRegion (region);
            _isEditing = true;
        }
        else
        {
            _region = _dao.CreateRegion ();
            _isEditing = false;
        }

        DataContext = _region;

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
            _dao.AddRegion (_region);
            var listPage = new RegionWindow (_dao);
            listPage.Show ();
            Close ();
        }
        
    }
    
    private void CancelButton_Click(object sender, RoutedEventArgs e) {
        if (_isEditing)
        {
            _dao.AddRegion (_region);
        }
        var listPage = new RegionWindow (_dao);
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