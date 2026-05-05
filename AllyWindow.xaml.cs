using System.Windows;
using System.IO;
using System.Text.Json;
using System.Windows.Controls;

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
        
        if (ally.Hp != null)
        {
            HpTextBlock.Text = $"{ally.Hp.Current}/{ally.Hp.Max}";
            HpBorder.Visibility = Visibility.Visible;
        } else { HpBorder.Visibility = Visibility.Collapsed; }

        if (ally.Innate != null)
        {
            InnateBorder.Visibility = Visibility.Visible;
            InnateBorder.DataContext = ally.Innate;
            InnateName.Text = ally.Innate.Name;
            InnateDescription.Text = ally.Innate.Description;
        } else { InnateBorder.Visibility = Visibility.Collapsed; }

        ActionsPanel.Visibility = ally.Actions.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
        ActionsItemsControl.ItemsSource = ally.Actions;
    }

    private void LoadAllyFromFile()
    {
        // string enum converter to handle PoolType
        var options = new JsonSerializerOptions
        {
            Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
        };

        try
        {
            string jsonContent = File.ReadAllText(_filepath);
            var allyFile = JsonSerializer.Deserialize<Ally>(jsonContent, options);
            if (allyFile != null)
            {
                ally = allyFile;
                if (ally.Hp != null && ally.Hp.Current == 0) { ally.Hp.Current = ally.Hp.Max; }
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
                    AllyImage.Visibility = Visibility.Collapsed;
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

    // Handle HP tracking
    private void DamageButton_Click(object sender, RoutedEventArgs e)
    {
        // check for valid input
        if (int.TryParse(DamageInput.Text, out int damageAmount) && damageAmount >= 0)
        {
            int realDamage = damageAmount >= 10 ? 1 : 0;
            if (ally.Hp?.Current >= realDamage)
            {
                ally.Hp?.Current -= realDamage;
            }
            else
            {
                ally.Hp?.Current = 0;
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
        if (ally.Hp?.Current < ally.Hp?.Max)
        {
            // check for valid input
            if (int.TryParse(DamageInput.Text, out int damageAmount) && damageAmount >= 0)
            {
                int realHealing;
                if (ally.Hp.Current == 0)
                {
                    realHealing = damageAmount / 10 > 0 ? damageAmount / 10 : 0;
                    realHealing = realHealing < 3 && realHealing != 0 ? 3 : realHealing;
                } else {
                    realHealing = damageAmount / 10 > 0 ? damageAmount / 10 : 1;
                }
                ally.Hp.Modify(realHealing);
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
        HpTextBlock.Text = $"{ally.Hp?.Current}/{ally.Hp?.Max}";
    }

    // Handle Pool updating
    private void PoolPanel_OnLoad(object sender, RoutedEventArgs e)
    {
        var panel = (StackPanel)sender;
        panel.Visibility = panel.Tag == null ? Visibility.Collapsed : Visibility.Visible;
    }

    private void PoolAdd_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var pool = (Pool)button.Tag;
        var panel = (StackPanel)button.Parent;
        var input = panel.Children.OfType<TextBox>().First();
        if (int.TryParse(input.Text, out int amount))
        {
            pool.Modify(amount);
            panel.Children.OfType<TextBlock>().Skip(1).First().Text = pool.Current.ToString();
        }
    }

    private void PoolSubtract_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var pool = (Pool)button.Tag;
        var panel = (StackPanel)button.Parent;
        var input = panel.Children.OfType<TextBox>().First();
        if (int.TryParse(input.Text, out int amount))
        {
            pool.Modify(-amount);
            panel.Children.OfType<TextBlock>().Skip(1).First().Text = pool.Current.ToString();
        }
    }
}
