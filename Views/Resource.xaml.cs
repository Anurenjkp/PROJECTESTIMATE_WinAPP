using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProjectEstimationWinApp.Views
{
    public partial class Resource : Page
    {
        public Resource()
        {
            InitializeComponent();
        }

        private void AddResource_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected resource type from the ComboBox
            ComboBoxItem selectedItem = (ComboBoxItem)resourceType.SelectedItem;
            string resourceTypeValue = selectedItem.Content.ToString();
            string formattedResourceType = System.Text.RegularExpressions.Regex.Replace(resourceTypeValue, "([A-Z])", " $1").Trim();

            // Create new TextBlock and TextBox
            TextBlock resourceLabel = new TextBlock
            {
                Text = $"{formattedResourceType}:",
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBox resourceInput = new TextBox
            {
                Name = resourceTypeValue.Replace(" ", "_") + "New", // Replace spaces with underscores
                MaxLength = 25,
                Width = 200,
                Margin = new Thickness(10, 0, 0, 0)
            };

            // Find the last row in the additional resources grid
            int nextRow = additionalResourcesGrid.RowDefinitions.Count;
            additionalResourcesGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            // Add the TextBlock and TextBox to the additional resources grid
            Grid.SetRow(resourceLabel, nextRow);
            Grid.SetColumn(resourceLabel, 0);
            Grid.SetRow(resourceInput, nextRow);
            Grid.SetColumn(resourceInput, 1);

            additionalResourcesGrid.Children.Add(resourceLabel);
            additionalResourcesGrid.Children.Add(resourceInput);
        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            var resources = new Dictionary<string, ResourceData>();

            // Collect data from the main resource grid
            foreach (var child in resourceGrid.Children)
            {
                if (child is TextBox textBox)
                {
                    string resourceType = textBox.Name;
                    if (!resources.ContainsKey(resourceType))
                    {
                        resources[resourceType] = new ResourceData { Count = 0, Names = new List<string>() };
                    }
                    resources[resourceType].Names.Add(textBox.Text);
                    resources[resourceType].Count++;
                }
            }

            // Collect data from the additional resources grid
            foreach (var child in additionalResourcesGrid.Children)
            {
                if (child is TextBox textBox)
                {
                    string resourceType = textBox.Name.Replace("New", "");
                    if (!resources.ContainsKey(resourceType))
                    {
                        resources[resourceType] = new ResourceData { Count = 0, Names = new List<string>() };
                    }
                    resources[resourceType].Names.Add(textBox.Text);
                    resources[resourceType].Count++;
                }
            }

            // Save resources to local storage (simulated using Application.Current.Properties)
            Application.Current.Properties["resources"] = resources;

            // Save project start and end dates
            Application.Current.Properties["projectStartDate"] = projectStartDate.SelectedDate;
            Application.Current.Properties["projectEndDate"] = projectEndDate.SelectedDate;

            MessageBox.Show("Data saved successfully!");
        }
    }

    public class ResourceData
    {
        public int Count { get; set; }
        public List<string> Names { get; set; }
    }
}