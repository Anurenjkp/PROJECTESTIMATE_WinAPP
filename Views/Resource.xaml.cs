using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ProjectEstimationWinApp.Views
{
    public partial class Resource : Page
    {
        private Dictionary<string, ResourceData> resources = new Dictionary<string, ResourceData>();

        public Resource()
        {
            InitializeComponent();
            InitializeResourceCounts();
        }

        private void InitializeResourceCounts()
        {
            // Initialize resource counts based on the initial state of the resource grid
            foreach (var child in resourceGrid.Children)
            {
                if (child is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    string resourceType = textBox.Name;
                    if (!resources.ContainsKey(resourceType))
                    {
                        resources[resourceType] = new ResourceData { Count = 1, Names = new List<string> { textBox.Text } };
                    }
                }
            }
        }

        private void AddResource_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected resource type from the ComboBox
            if (resourceType.SelectedItem is ComboBoxItem selectedItem)
            {
                string resourceTypeValue = selectedItem.Content.ToString();
                string resourceTypeKey = resourceTypeValue.Replace(" ", "").ToLower();

                // Find the matching TextBlock in the Resources Required GroupBox
                TextBlock matchingLabel = null;
                foreach (var child in resourceGrid.Children)
                {
                    if (child is TextBlock textBlock && textBlock.Text.TrimEnd(':').ToLower() == resourceTypeValue.ToLower())
                    {
                        matchingLabel = textBlock;
                        break;
                    }
                }

                if (matchingLabel != null)
                {
                    // Create new TextBlock and TextBox for the UI
                    TextBlock resourceLabel = new TextBlock
                    {
                        Text = matchingLabel.Text,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    TextBox resourceInput = new TextBox
                    {
                        Name = resourceTypeKey + "New",
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

                    // Update the resource count in the resources dictionary
                    if (!resources.ContainsKey(resourceTypeKey))
                    {
                        resources[resourceTypeKey] = new ResourceData { Count = 1, Names = new List<string>() };
                    }
                    else
                    {
                        resources[resourceTypeKey].Count++;
                    }
                }
                else
                {
                    MessageBox.Show("Matching label not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            // Reset the resources dictionary to avoid duplicating counts
            resources = new Dictionary<string, ResourceData>();

            // Collect data from the main resource grid
            foreach (var child in resourceGrid.Children)
            {
                if (child is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    string resourceType = textBox.Name.ToLower();
                    if (!resources.ContainsKey(resourceType))
                    {
                        resources[resourceType] = new ResourceData { Count = 1, Names = new List<string> { textBox.Text } };
                    }
                    else
                    {
                        resources[resourceType].Count++;
                        resources[resourceType].Names.Add(textBox.Text);
                    }
                }
            }

            // Collect data from the additional resources grid
            foreach (var child in additionalResourcesGrid.Children)
            {
                if (child is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    string resourceType = textBox.Name.Replace("New", "").ToLower();
                    if (!resources.ContainsKey(resourceType))
                    {
                        resources[resourceType] = new ResourceData { Count = 0, Names = new List<string>() };
                    }
                    resources[resourceType].Names.Add(textBox.Text);
                    resources[resourceType].Count++;
                }
            }

            // Consolidate resources to ensure combined names and counts
            ConsolidateResources();

            // Save resources to local storage (simulated using Application.Current.Properties)
            Application.Current.Properties["resources"] = resources;

            // Save project start and end dates
            Application.Current.Properties["projectStartDate"] = projectStartDate.SelectedDate;
            Application.Current.Properties["projectEndDate"] = projectEndDate.SelectedDate;

            // Display the saved data in a MessageBox
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Data saved successfully!");
            sb.AppendLine($"Project Start Date: {projectStartDate.SelectedDate?.ToString("d")}");
            sb.AppendLine($"Project End Date: {projectEndDate.SelectedDate?.ToString("d")}");
            sb.AppendLine();
            sb.AppendLine("Resources:");
            foreach (var resource in resources)
            {
                sb.AppendLine($"Resource Type: {resource.Key.Replace("_", " ")}, Names: {string.Join(", ", resource.Value.Names)}, Count: {resource.Value.Count}");
            }

            MessageBox.Show(sb.ToString(), "Saved Data", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ConsolidateResources()
        {
            var consolidatedResources = new Dictionary<string, ResourceData>();

            foreach (var resource in resources)
            {
                string resourceType = resource.Key;
                if (!consolidatedResources.ContainsKey(resourceType))
                {
                    consolidatedResources[resourceType] = new ResourceData { Count = resource.Value.Count, Names = new List<string>(resource.Value.Names) };
                }
                else
                {
                    consolidatedResources[resourceType].Count += resource.Value.Count;
                    consolidatedResources[resourceType].Names.AddRange(resource.Value.Names);
                }
            }

            resources = consolidatedResources;
        }
    }

    public class ResourceData
    {
        public int Count { get; set; }
        public List<string> Names { get; set; }
    }
}