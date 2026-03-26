using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
namespace dnd_allies;
public partial class AllyWindow : Window
{
    private string _filepath;
    private Ally ally = new();
    public AllyWindow(string file)
    {
        _filepath = file;
        InitializeComponent();
        LoadAllyFromFile();
    }

    // Initialize the ally info display
    public void InitInfo()
    {
        this.Title = ally.Name;
    }

    private void LoadAllyFromFile()
    {
        try
        {
            string jsonContent = File.ReadAllText(_filepath);
            var allyFile = JsonSerializer.Deserialize<Ally>(jsonContent);
            if (allyFile != null)
            {
                ally = new Ally
                {
                    Name = allyFile.Name,
                    Description = allyFile.Description,
                    Immunities = allyFile.Immunities,
                    HpMax = allyFile.HpMax,
                    HpCurrent = allyFile.HpMax,
                    Actions = allyFile.Actions,
                    Apex = allyFile.Apex
                };
            MessageBox.Show($"Loaded character {ally.Name}", "Loaded!", 
                            MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading character data: {ex.Message}", "Error", 
                            MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // Handle exit button
    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    /*
        private void DamageButton_Click(object sender, RoutedEventArgs e)
    {
        if (ally.HpCurrent > 0)
        {
            // read input
            // do dmg calc
            // update HP
            OnPropertyChanged();
        }
    }

    private void HealButton_Click(object sender, RoutedEventArgs e)
    {
        if (ally.HpCurrent < ally.HpMax)
        {
            // read input
            // update HP
            OnPropertyChanged();
        }
    }

    private void OnPropertyChanged()
    {
        //refresh HP display
    } */
}
