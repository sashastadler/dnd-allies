using System.Windows;
using System.IO;
using System.Text.Json;

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
        NameTextBlock.Text = ally.Name;
        DescriptionTextBlock.Text = ally.Description;
        AcTextBlock.Text = $"AC: {ally.Ac}";
        SpeedTextBlock.Text = $"Speed: {ally.Speed}";
        ImmunitiesTextBlock.Text = $"Immunities: {string.Join(", ", ally.Immunities)}";
        HpTextBlock.Text = $"{ally.HpCurrent}/{ally.HpMax}";
    }

    private void LoadAllyFromFile()
    {
        try
        {
            string jsonContent = File.ReadAllText(_filepath);
            var allyFile = JsonSerializer.Deserialize<Ally>(jsonContent);
            if (allyFile != null)
            {
                ally.Name = allyFile.Name;
                ally.Description = allyFile.Description;
                ally.Speed = allyFile.Speed;
                ally.Ac = allyFile.Ac;
                ally.Immunities = allyFile.Immunities;
                ally.HpMax = allyFile.HpMax;
                ally.Actions = allyFile.Actions;
                ally.Apex = allyFile.Apex;
                ally.HpCurrent = ally.HpMax;
            };
            MessageBox.Show($"Loaded character {ally.Name}", "Loaded!", 
                            MessageBoxButton.OK, MessageBoxImage.Information);
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
        }
    }

    private void HealButton_Click(object sender, RoutedEventArgs e)
    {
        if (ally.HpCurrent < ally.HpMax)
        {
            // read input
            // update HP
        }
    } */
}
