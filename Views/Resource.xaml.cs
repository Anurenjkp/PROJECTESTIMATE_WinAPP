using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


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
            ComboBoxItem selectedItem = (ComboBoxItem)resourceType.SelectedItem;
            string resourceTypeValue = selectedItem.Content.ToString();
            string formattedResourceType = System.Text.RegularExpressions.Regex.Replace(resourceTypeValue, "([A-Z])", " $1").Trim();

            // Create new TextBlock
            TextBlock resourceLabel = new TextBlock
            {
                Text = $"{formattedResourceType}:",
                VerticalAlignment = VerticalAlignment.Center
            };

            // Create new TextBox
            TextBox resourceInput = new TextBox
            {
                Name = resourceTypeValue.Replace(" ", "_") + "New", // Replace spaces with underscores
                MaxLength = 25,
                Width = 200,
                Margin = new Thickness(10, 0, 0, 0)
            };

            // Find the existing resource type and insert the new TextBlock and TextBox next to it
            bool inserted = false;
            for (int i = 0; i < resourceGrid.Children.Count; i++)
            {
                if (resourceGrid.Children[i] is TextBlock existingLabel && existingLabel.Text == $"{formattedResourceType}:")
                {
                    int row = Grid.GetRow(existingLabel);
                    int column = Grid.GetColumn(existingLabel);

                    // Insert new TextBlock and TextBox in the next available column
                    if (column == 0)
                    {
                        Grid.SetRow(resourceLabel, row);
                        Grid.SetColumn(resourceLabel, 2);
                        Grid.SetRow(resourceInput, row);
                        Grid.SetColumn(resourceInput, 3);
                    }
                    else
                    {
                        Grid.SetRow(resourceLabel, row + 1);
                        Grid.SetColumn(resourceLabel, 0);
                        Grid.SetRow(resourceInput, row + 1);
                        Grid.SetColumn(resourceInput, 1);
                    }

                    resourceGrid.Children.Add(resourceLabel);
                    resourceGrid.Children.Add(resourceInput);
                    inserted = true;
                    break;
                }
            }

            // If the resource type was not found, add it to the end
            if (!inserted)
            {
                int nextRow = resourceGrid.RowDefinitions.Count;
                resourceGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                Grid.SetRow(resourceLabel, nextRow);
                Grid.SetColumn(resourceLabel, 0);
                Grid.SetRow(resourceInput, nextRow);
                Grid.SetColumn(resourceInput, 1);

                resourceGrid.Children.Add(resourceLabel);
                resourceGrid.Children.Add(resourceInput);
            }
        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            var resources = new Dictionary<string, ResourceData>();

            foreach (var child in resourceGrid.Children)
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