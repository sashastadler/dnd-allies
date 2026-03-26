using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace dnd_allies;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<string> characterFiles = [];
    private const string CharacterDirectory = "characters";
    public MainWindow()
    {
        LoadCharacterFiles();
        InitializeComponent();
        PopulateAllyButtons();
    }

    // Load character file names at startup
    private void LoadCharacterFiles()
    {
        if (!Directory.Exists(CharacterDirectory))
        {
            Directory.CreateDirectory(CharacterDirectory);
            return;
        }

        characterFiles = [.. Directory.GetFiles(CharacterDirectory, "*.json")];
    }

    // Create the list of buttons
    private void PopulateAllyButtons()
    {
        CharacterButtonsPanel.Children.Clear();

        foreach (string characterFile in characterFiles)
        {
            StackPanel stackPanel = new();
            Button characterButton = new()
            {
                Height = 30,
                Width = 300,
                Margin = new Thickness(10),
                Tag = characterFile // Store file path for json parsing step
            };

            string characterName = Path.GetFileNameWithoutExtension(characterFile);
            string allyNameClean = characterName.Replace("_", " ");
            stackPanel.Children.Add(
                new TextBlock
                {
                    Text = allyNameClean,
                    HorizontalAlignment = HorizontalAlignment.Center
                });
            characterButton.Content = stackPanel;
            characterButton.Click += CharacterButton_Click;

            CharacterButtonsPanel.Children.Add(characterButton);
        }
    }

    // Handle character selection
    private void CharacterButton_Click(object sender, RoutedEventArgs e)
    {
        Button? button = sender as Button;
        string characterName = "";

        // Get character name from button content
        if (button?.Content is StackPanel stackPanel)
        {
            foreach (var child in stackPanel.Children)
            {
                if (child is TextBlock textBlock)
                {
                    characterName = textBlock.Text;
                    break;
                }
            }
        }

        // Navigate to ally window
        if (button?.Tag is string filePath)
        {
            var allyWindow = new AllyWindow(filePath);
            allyWindow.InitInfo();
            allyWindow.Show();
        }
    }

    // Handle exit button
    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}