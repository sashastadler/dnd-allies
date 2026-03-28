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
        LoadAllyImage();
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
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading character data: {ex.Message}", "Error", 
                            MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void LoadAllyImage()
    {
        try
        {
            // Get the image file name from the JSON file name
            string allyName = Path.GetFileNameWithoutExtension(_filepath);
            string imageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "characters", "images");
            string defaultImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "default.png");


            // Try to find the image with the same name as the JSON file
            string imageFile = Path.Combine(imageDirectory, allyName + ".png");
            // If neither exists, use default image
            if (!File.Exists(imageFile))
            {
                if (File.Exists(defaultImage))
                {
                    imageFile = defaultImage;
                }
                else
                {
                    // If no default image exists, show nothing
                    return;
                }
            }
            
            // Set the image source
            var image = new System.Windows.Media.Imaging.BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(imageFile);
            image.EndInit();
            
            AllyImage.Source = image;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error loading image: {ex.Message}");
        }
    }

    // Handle exit button
    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void DamageButton_Click(object sender, RoutedEventArgs e)
    {
        // check for valid input
        if (int.TryParse(DamageInput.Text, out int damageAmount) && damageAmount >= 0)
        {
            int realDamage = damageAmount >= 10 ? 1 : 0;
            if (ally.HpCurrent >= realDamage)
            {
                ally.HpCurrent -= realDamage;
            }
            else
            {
                ally.HpCurrent = 0;
            }
            UpdateAllyHealth();
        }
        else
        {
            MessageBox.Show("Please enter a number", "Invalid Input", 
                        MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void HealButton_Click(object sender, RoutedEventArgs e)
    {
        if (ally.HpCurrent < ally.HpMax)
        {
            // check for valid input
            if (int.TryParse(DamageInput.Text, out int damageAmount) && damageAmount >= 0)
            {
                int realHealing = 0;
                if (ally.HpCurrent == 0)
                {
                    realHealing = damageAmount / 10 > 0 ? damageAmount / 10 : 0;
                    realHealing = realHealing < 3 && realHealing != 0 ? 3 : realHealing;
                } else {
                    realHealing = damageAmount / 10 > 0 ? damageAmount / 10 : 1;
                }
                if (ally.HpMax - ally.HpCurrent < realHealing)
                { ally.HpCurrent = ally.HpMax; } else { ally.HpCurrent += realHealing; }
                UpdateAllyHealth();
            }
            else
            {
                MessageBox.Show("Please enter a number", "Invalid Input", 
                            MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            UpdateAllyHealth();
        }
    }

    private void UpdateAllyHealth()
    {
        HpTextBlock.Text = $"{ally.HpCurrent}/{ally.HpMax}";
    }
}
