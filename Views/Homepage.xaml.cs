using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectEstimationWinApp.Views
{
    public partial class Homepage : Page
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            string projectName = ProjectNameTextBox.Text;
            string projectType = GetSelectedRadioButtonTag("ProjectType");
            string complexity = GetSelectedRadioButtonTag("Complexity");

         
        
            Application.Current.Properties["ProjectName"] = projectName;
            Application.Current.Properties["ProjectType"] = projectType;
            Application.Current.Properties["Complexity"] = complexity;

            string selectedKey = $"{projectType}-{complexity}";
            Application.Current.Properties["selectedKey"] = selectedKey;

            NavigationService.Navigate(new ESTPage());
           
            
        }

        private string GetSelectedRadioButtonTag(string groupName)
        {
            return FindSelectedRadioButtonTag(this, groupName);
        }

        private string FindSelectedRadioButtonTag(DependencyObject parent, string groupName)
        {
            int childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is RadioButton radioButton && radioButton.GroupName == groupName && radioButton.IsChecked == true)
                {
                    return radioButton.Tag.ToString();
                }
                string result = FindSelectedRadioButtonTag(child, groupName);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}