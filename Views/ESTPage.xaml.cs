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
    /// <summary>
    /// Interaction logic for ESTPage.xaml
    /// </summary>
    public partial class ESTPage : Page
    {
        
        public ESTPage()
        {
            InitializeComponent();
            Load();
        }
       
        private void SummaryButton_Click(object sender, RoutedEventArgs e)
        {
            SummaryDetail.Visibility = SummaryDetail.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
           
        }

        public void UpdateSum(object sender, TextChangedEventArgs e)
        {
            double analysis = getdoublevaluefromtextbox("Analysisandrequirementsignoff");
            double functional = getdoublevaluefromtextbox("FunctionalDesign");
            double technical = getdoublevaluefromtextbox("TechnicalDesign");

            double sum = analysis + functional + technical;
            TextBlock Sumvaleblock = FindName("Sumvaleblock") as TextBlock;
            Sumvaleblock.Text = $"{sum:0}";

            // Sum for Coding
            double frontend = getdoublevaluefromtextbox("Frontendchanges");
            double integration = getdoublevaluefromtextbox("IntegrationChanges");
            double backend = getdoublevaluefromtextbox("BackendChanges");

            double sum1 = frontend + integration + backend;
            TextBlock Codingblock = FindName("Codingblock") as TextBlock;
            Codingblock.Text = $"{sum1:0}";

            // Sum for Unit Testing
            double unitTestCase = getdoublevaluefromtextbox("UnitTestCasePreparation");
            double testLogsAndDefectFix = getdoublevaluefromtextbox("UnittestlogsandDefectFix");
            double review = getdoublevaluefromtextbox("CodeReview");
            double testCaseReview = getdoublevaluefromtextbox("UnitTestCaseReview");
            double testResultReview = getdoublevaluefromtextbox("UnittestResultReview");

            double sum2 = unitTestCase + testLogsAndDefectFix + review + testCaseReview + testResultReview;
            TextBlock UnitTestingblock = FindName("UnitTestingblock") as TextBlock;
            UnitTestingblock.Text = $"{sum2:0}";

            // Sum for QA & UAT Testing
            double qaTestCase = getdoublevaluefromtextbox("QATestCasePreparation");
            double qaTestingAndDefectFix = getdoublevaluefromtextbox("QATestingandDefectFix");
            double integrationTest = getdoublevaluefromtextbox("IntegrationTesting");
            double uatTestAndDefectFix = getdoublevaluefromtextbox("UATTestingandDefectFix");
            double qaTestResultReview = getdoublevaluefromtextbox("QAandTestResultReview");
            double qaUatSupport = getdoublevaluefromtextbox("QAandUATSupport");

            double sum3 = qaTestCase + qaTestingAndDefectFix + integrationTest + uatTestAndDefectFix + qaTestResultReview + qaUatSupport;
            TextBlock QATestingblock = FindName("QATestingblock") as TextBlock;
            QATestingblock.Text = $"{sum3:0}";

            // Sum for Release Management
            double combined = getdoublevaluefromtextbox("Releasemanagement");
            TextBlock ReleaseManagementblock = FindName("ReleaseManagementblock") as TextBlock;
            ReleaseManagementblock.Text = $"{combined:0}";

            // Sum for Support
            double deployment = getdoublevaluefromtextbox("DeploymentSupport");
            double warranty = getdoublevaluefromtextbox("WarrantySupport");

            double sum5 = deployment + warranty;
            TextBlock Supportblock = FindName("Supportblock") as TextBlock;
            Supportblock.Text = $"{sum5:0}";
        }

        //private void UpdateSummary(object sender, RoutedEventArgs e)
        //{


        //}

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
           

            NavigationService.Navigate(new Resource());


        }
        private void TimeLine()
        {
            // Retrieve values from input fields and store them in local storage (or any other storage mechanism)
            ;
            double Analysisandrequirementsignoff = getdoublevaluefromtextbox("Analysisandrequirementsignoff");
            double FunctionalDesign = getdoublevaluefromtextbox("FunctionalDesign");
            double TechnicalDesign = getdoublevaluefromtextbox("TechnicalDesign");
            double Frontendchanges = getdoublevaluefromtextbox("Frontendchanges");
            double IntegrationChanges = getdoublevaluefromtextbox("IntegrationChanges");
            double BackendChanges = getdoublevaluefromtextbox("BackendChanges");
            double UnitTestCasePreparation = getdoublevaluefromtextbox("UnitTestCasePreparation");
            double UnittestlogsandDefectFix = getdoublevaluefromtextbox("UnittestlogsandDefectFix");
            double CodeReview = getdoublevaluefromtextbox("CodeReview");
            double UnitTestCaseReview = getdoublevaluefromtextbox("UnitTestCaseReview");
            double UnittestResultReview = getdoublevaluefromtextbox("UnittestResultReview");
            double QATestCasePreparation = getdoublevaluefromtextbox("QATestCasePreparation");
            double QATestingandDefectFix = getdoublevaluefromtextbox("QATestingandDefectFix");
            double IntegrationTesting = getdoublevaluefromtextbox("IntegrationTesting");
            double UATTestingandDefectFix = getdoublevaluefromtextbox("UATTestingandDefectFix");
            double QAandTestResultReview = getdoublevaluefromtextbox("QAandTestResultReview");
            double QAandUATSupport = getdoublevaluefromtextbox("QAandUATSupport");
            double Releasemanagement = getdoublevaluefromtextbox("Releasemanagement");
            double DeploymentSupport = getdoublevaluefromtextbox("DeploymentSupport");
            double WarrantySupport = getdoublevaluefromtextbox("WarrantySupport");

        }

        private void Load()
        {


            var defaultValues = new Dictionary<string, Dictionary<string, double>>
            {
                {
                    "Small-Low",
                    new Dictionary<string, double>
                    {
                        { "Analysisandrequirementsignoff", 2 },
                        { "FunctionalDesign", 2 },
                        { "TechnicalDesign", 3 },
                        { "Frontendchanges", 20 },
                        { "IntegrationChanges", 10 },
                        { "BackendChanges", 10 },
                        { "UnitTestCasePreparation", 1 },
                        { "UnittestlogsandDefectFix", 6 },
                        { "CodeReview", 1 },
                        { "UnitTestCaseReview", 1 },
                        { "UnittestResultReview", 1 },
                        { "QATestCasePreparation", 2 },
                        { "QATestingandDefectFix", 13 },
                        { "IntegrationTesting", 4 },
                        { "UATTestingandDefectFix", 8 },
                        { "QAandTestResultReview", 1 },
                        { "QAandUATSupport", 4 },
                        { "Releasemanagement", 10 },
                        { "DeploymentSupport", 1 },
                        { "WarrantySupport", 0 }
                    }
                },
                {
                    "Small-Medium",
                    new Dictionary<string, double>
                    {
                        { "Analysisandrequirementsignoff", 2 },
                        { "FunctionalDesign", 3 },
                        { "TechnicalDesign", 5 },
                        { "Frontendchanges", 30 },
                        { "IntegrationChanges", 15 },
                        { "BackendChanges", 15 },
                        { "UnitTestCasePreparation", 1 },
                        { "UnittestlogsandDefectFix", 12 },
                        { "CodeReview", 2 },
                        { "UnitTestCaseReview", 1 },
                        { "UnittestResultReview", 1 },
                        { "QATestCasePreparation", 3 },
                        { "QATestingandDefectFix", 20 },
                        { "IntegrationTesting", 6 },
                        { "UATTestingandDefectFix", 10 },
                        { "QAandTestResultReview", 1 },
                        { "QAandUATSupport", 6 },
                        { "Releasemanagement", 15 },
                        { "DeploymentSupport", 1 },
                        { "WarrantySupport", 1 }
                    }
                },
                {
                    "Small-High",
                    new Dictionary<string, double>
                    {
                        { "Analysisandrequirementsignoff", 2 },
                        { "FunctionalDesign", 4 },
                        { "TechnicalDesign", 18 },
                        { "Frontendchanges", 40 },
                        { "IntegrationChanges", 20 },
                        { "BackendChanges", 20 },
                        { "UnitTestCasePreparation", 2 },
                        { "UnittestlogsandDefectFix", 12 },
                        { "CodeReview", 2 },
                        { "UnitTestCaseReview", 1 },
                        { "UnittestResultReview", 1 },
                        { "QATestCasePreparation", 4 },
                        { "QATestingandDefectFix", 26 },
                        { "IntegrationTesting", 8 },
                        { "UATTestingandDefectFix", 16 },
                        { "QAandTestResultReview", 2 },
                        { "QAandUATSupport", 8 },
                        { "Releasemanagement", 20 },
                        { "DeploymentSupport", 2 },
                        { "WarrantySupport", 2 }
                    }
                },
                {
                    "Medium-Low",
                    new Dictionary<string, double>
                    {
                        { "Analysisandrequirementsignoff", 3 },
                        { "FunctionalDesign", 6 },
                        { "TechnicalDesign", 12 },
                        { "Frontendchanges", 60 },
                        { "IntegrationChanges", 32 },
                        { "BackendChanges", 35 },
                        { "UnitTestCasePreparation", 2 },
                        { "UnittestlogsandDefectFix", 16 },
                        { "CodeReview", 2 },
                        { "UnitTestCaseReview", 1 },
                        { "UnittestResultReview", 1 },
                        { "QATestCasePreparation", 4 },
                        { "QATestingandDefectFix", 40 },
                        { "IntegrationTesting", 12 },
                        { "UATTestingandDefectFix", 24 },
                        { "QAandTestResultReview", 3 },
                        { "QAandUATSupport", 12 },
                        { "Releasemanagement", 25 },
                        { "DeploymentSupport", 2 },
                        { "WarrantySupport", 8 }
                    }
                },
                {
                    "Medium-Medium",
                    new Dictionary<string, double>
                    {
                        { "Analysisandrequirementsignoff", 4 },
                        { "FunctionalDesign", 8 },
                        { "TechnicalDesign", 16 },
                        { "Frontendchanges", 80 },
                        { "IntegrationChanges", 40 },
                        { "BackendChanges", 40 },
                        { "UnitTestCasePreparation", 4 },
                        { "UnittestlogsandDefectFix", 24 },
                        { "CodeReview", 4 },
                        { "UnitTestCaseReview", 2 },
                        { "UnittestResultReview", 2 },
                        { "QATestCasePreparation", 6 },
                        { "QATestingandDefectFix", 54 },
                        { "IntegrationTesting", 18 },
                        { "UATTestingandDefectFix", 32 },
                        { "QAandTestResultReview", 4 },
                        { "QAandUATSupport", 16 },
                        { "Releasemanagement", 30 },
                        { "DeploymentSupport", 4 },
                        { "WarrantySupport", 12 }
                    }
                },
                {
                    "Medium-High",
                    new Dictionary<string, double>
                    {
                        { "Analysisandrequirementsignoff", 6 },
                        { "FunctionalDesign", 8 },
                        { "TechnicalDesign", 16 },
                        { "Frontendchanges", 100 },
                        { "IntegrationChanges", 50 },
                        { "BackendChanges", 50 },
                        { "UnitTestCasePreparation", 4 },
                        { "UnittestlogsandDefectFix", 30 },
                        { "CodeReview", 5 },
                        { "UnitTestCaseReview", 3 },
                        { "UnittestResultReview", 3 },
                        { "QATestCasePreparation", 6 },
                        { "QATestingandDefectFix", 80 },
                        { "IntegrationTesting", 24 },
                        { "UATTestingandDefectFix", 35 },
                        { "QAandTestResultReview", 6 },
                        { "QAandUATSupport", 24 },
                        { "Releasemanagement", 30 },
                        { "DeploymentSupport", 4 },
                        { "WarrantySupport", 16 }
                    }
                },
                {
                    "Large-Low",
                    new Dictionary<string, double>
                    {
                        { "Analysisandrequirementsignoff", 6 },
                        { "FunctionalDesign", 12 },
                        { "TechnicalDesign", 24 },
                        { "Frontendchanges", 120 },
                        { "IntegrationChanges", 70 },
                        { "BackendChanges", 70 },
                        { "UnitTestCasePreparation", 4 },
                        { "UnittestlogsandDefectFix", 32 },
                        { "CodeReview", 4 },
                        { "UnitTestCaseReview", 2 },
                        { "UnittestResultReview", 2 },
                        { "QATestCasePreparation", 8 },
                        { "QATestingandDefectFix", 80 },
                        { "IntegrationTesting", 24 },
                        { "UATTestingandDefectFix", 50 },
                        { "QAandTestResultReview", 6 },
                        { "QAandUATSupport", 24 },
                        { "Releasemanagement", 30 },
                        { "DeploymentSupport", 8 },
                        { "WarrantySupport", 24 }
                    }
                },
                {
                    "Large-Medium",
                    new Dictionary<string, double>
                    {
                        { "Analysisandrequirementsignoff", 8 },
                        { "FunctionalDesign", 15 },
                        { "TechnicalDesign", 25 },
                        { "Frontendchanges", 140 },
                        { "IntegrationChanges", 80 },
                        { "BackendChanges", 80 },
                        { "UnitTestCasePreparation", 4 },
                        { "UnittestlogsandDefectFix", 40 },
                        { "CodeReview", 6 },
                        { "UnitTestCaseReview", 3 },
                        { "UnittestResultReview", 3 },
                        { "QATestCasePreparation", 8 },
                        { "QATestingandDefectFix", 100 },
                        { "IntegrationTesting", 30 },
                        { "UATTestingandDefectFix", 60 },
                        { "QAandTestResultReview", 6 },
                        { "QAandUATSupport", 24 },
                        { "Releasemanagement", 30 },
                        { "DeploymentSupport", 8 },
                        { "WarrantySupport", 30 }
                    }
                },
                {
                    "Large-High",
                    new Dictionary<string, double>
                    {
                        { "Analysisandrequirementsignoff", 10 },
                        { "FunctionalDesign", 16 },
                        { "TechnicalDesign", 32 },
                        { "Frontendchanges", 160 },
                        { "IntegrationChanges", 80 },
                        { "BackendChanges", 80 },
                        { "UnitTestCasePreparation", 6 },
                        { "UnittestlogsandDefectFix", 50 },
                        { "CodeReview", 8 },
                        { "UnitTestCaseReview", 4 },
                        { "UnittestResultReview", 4 },
                        { "QATestCasePreparation", 12 },
                        { "QATestingandDefectFix", 120 },
                        { "IntegrationTesting", 36 },
                        { "UATTestingandDefectFix", 64 },
                        { "QAandTestResultReview", 8 },
                        { "QAandUATSupport", 32 },
                        { "Releasemanagement", 30 },
                        { "DeploymentSupport", 8 },
                        { "WarrantySupport", 40 }

                    }
                }
            };
           
            string selectedKey = Application.Current.Properties["selectedKey"] as string;

          
                if (defaultValues.TryGetValue(selectedKey, out var values))
                {
                    double analysisAndRequirementSignoff = values["Analysisandrequirementsignoff"];
                    double functionalDesign = values["FunctionalDesign"];
                    double technicalDesign = values["TechnicalDesign"];
                    double frontendChanges = values["Frontendchanges"];
                    double integrationChanges = values["IntegrationChanges"];
                    double backendChanges = values["BackendChanges"];
                    double unitTestCasePreparation = values["UnitTestCasePreparation"];
                    double unittestLogsAndDefectFix = values["UnittestlogsandDefectFix"];
                    double codeReview = values["CodeReview"];
                    double unitTestCaseReview = values["UnitTestCaseReview"];
                    double unittestResultReview = values["UnittestResultReview"];
                    double qaTestCasePreparation = values["QATestCasePreparation"];
                    double qaTestingAndDefectFix = values["QATestingandDefectFix"];
                    double integrationTesting = values["IntegrationTesting"];
                    double uatTestingAndDefectFix = values["UATTestingandDefectFix"];
                    double qaAndTestResultReview = values["QAandTestResultReview"];
                    double qaAndUATSupport = values["QAandUATSupport"];
                    double releaseManagement = values["Releasemanagement"];
                    double deploymentSupport = values["DeploymentSupport"];
                    double warrantySupport = values["WarrantySupport"];


                Analysisandrequirementsignoff.Text = analysisAndRequirementSignoff.ToString();
                FunctionalDesign.Text = functionalDesign.ToString();
                TechnicalDesign.Text = technicalDesign.ToString();
                Frontendchanges.Text = frontendChanges.ToString();
                IntegrationChanges.Text = integrationChanges.ToString();
                BackendChanges.Text = backendChanges.ToString();
                UnitTestCasePreparation.Text = unitTestCasePreparation.ToString();
                UnittestlogsandDefectFix.Text = unittestLogsAndDefectFix.ToString();
                CodeReview.Text = codeReview.ToString();
                UnitTestCaseReview.Text = unitTestCaseReview.ToString();
                UnittestResultReview.Text = unittestResultReview.ToString();
                QATestCasePreparation.Text = qaTestCasePreparation.ToString();
                QATestingandDefectFix.Text = qaTestingAndDefectFix.ToString();
                IntegrationTesting.Text = integrationTesting.ToString();
                UATTestingandDefectFix.Text = uatTestingAndDefectFix.ToString();
                QAandTestResultReview.Text = qaAndTestResultReview.ToString();
                QAandUATSupport.Text = qaAndUATSupport.ToString();
                Releasemanagement.Text = releaseManagement.ToString();
                DeploymentSupport.Text = deploymentSupport.ToString();
                WarrantySupport.Text = warrantySupport.ToString();
            }
            
        }
        private double getdoublevaluefromtextbox(string textBoxName)
        {
            TextBox textBox = (TextBox)this.FindName(textBoxName);
            if (textBox != null && double.TryParse(textBox.Text, out double value))
            {
                return value;
            }
            return 0;
        }
        private double ParseHeaderValue(string headerValue) {
            string[] parts = headerValue.Split(' ');
            if (parts.Length > 0 && double.TryParse(parts[parts.Length - 1], out double value))
            {
                return value;
            }
            return 0;
        }
        private void ToogleSummaryVisibility(object sender, RoutedEventArgs e)
        {
            if (SummaryDetail.Visibility == Visibility.Collapsed)
            {
                SummaryDetail.Visibility = Visibility.Visible;
                ToggleButton.Content = "Hide Summary";

            }
            else
            {
                SummaryDetail.Visibility = Visibility.Collapsed;
                ToggleButton.Content = "Estimation Summary";
            }
            SummaryContainerblock.Text = CalculateSummary().ToString();
        }
        private void UpdateSummary(object sender, TextChangedEventArgs e) {
            SummaryContainerblock.Text = CalculateSummary().ToString();
        }

        private double CalculateSummary() {
            // Update the content with the latest values
            double analysis = getdoublevaluefromtextbox("Analysisandrequirementsignoff");
            double functional = getdoublevaluefromtextbox("FunctionalDesign");
            double technical = getdoublevaluefromtextbox("TechnicalDesign");

            double sum = analysis + functional + technical;
            TextBlock Sumvaleblock = FindName("Sumvaleblock") as TextBlock;
  
            Sumvaleblock.Text = $"{sum:0}";

            // Update the AnalysisandDesign1 TextBox with the sum value
            TextBox AnalysisandDesign1 = FindName("AnalysisandDesign1") as TextBox;
            AnalysisandDesign1.Text = sum.ToString();
            

            // Sum for construction
            double construction1 = getdoublevaluefromtextbox("Frontendchanges");
            double construction2 = getdoublevaluefromtextbox("IntegrationChanges");
            double construction3 = getdoublevaluefromtextbox("BackendChanges");
            double construction4 = getdoublevaluefromtextbox("Releasemanagement");
            double unitTestCase = getdoublevaluefromtextbox("UnitTestCasePreparation");
            double testLogsAndDefectFix = getdoublevaluefromtextbox("UnittestlogsandDefectFix");
            double review = getdoublevaluefromtextbox("CodeReview");
            double testCaseReview = getdoublevaluefromtextbox("UnitTestCaseReview");
            double testResultReview = getdoublevaluefromtextbox("UnittestResultReview");

            double construction = construction1 + construction2 + construction3 + construction4 + unitTestCase + testLogsAndDefectFix + review + testCaseReview + testResultReview;
            Construction.Text = construction.ToString();

            // Deployment
            Deploymentsupport.Text = getdoublevaluefromtextbox("DeploymentSupport").ToString();

            // Warranty
            Warantysupport.Text = getdoublevaluefromtextbox("WarrantySupport").ToString();

            // QA & UAT

            double qaTestCase = getdoublevaluefromtextbox("QATestCasePreparation");
            double qaTestingAndDefectFix = getdoublevaluefromtextbox("QATestingandDefectFix");
            double integrationTest = getdoublevaluefromtextbox("IntegrationTesting");
            double uatTestAndDefectFix = getdoublevaluefromtextbox("UATTestingandDefectFix");
            double qaTestResultReview = getdoublevaluefromtextbox("QAandTestResultReview");
            double qaUatSupport = getdoublevaluefromtextbox("QAandUATSupport");

            double sum3 = qaTestCase + qaTestingAndDefectFix + integrationTest + uatTestAndDefectFix + qaTestResultReview + qaUatSupport;
            TextBlock QATestingblock = FindName("QATestingblock") as TextBlock;
            QATestingblock.Text = $"{sum3:0}";

            // Calculate QA and UAT percentages
            double percentage = sum3;
            double qaPercentage = (percentage * 60) / 100;
            double uatPercentage = (percentage * 40) / 100;

            QA.Text = qaPercentage.ToString();
            UAT.Text = uatPercentage.ToString();

                analysis = getdoublevaluefromtextbox("AnalysisandDesign1");
                double construct = getdoublevaluefromtextbox("Construction");
                double deploy = getdoublevaluefromtextbox("Deploymentsupport");
                double warrantySupport = getdoublevaluefromtextbox("Warantysupport");
                double qa = getdoublevaluefromtextbox("QA");
                double uat = getdoublevaluefromtextbox("UAT");

               return analysis + construct + deploy + warrantySupport + qa + uat;
            
          
        }
        //private void SampleBudget()
        //{
        //    double analysis = getdoublevaluefromtextbox("analysisanddesign");
        //    Application.Current.Properties["analysisanddesign"] = analysis;
        //    double coding = getdoublevaluefromtextbox("coding");
        //    Application.Current.Properties["coding"] = coding;
        //    double unittesting = getdoublevaluefromtextbox("unittesting");
        //    Application.Current.Properties["unittesting"] = unittesting;
        //    double qaanduattesting = getdoublevaluefromtextbox("qaanduattesting");
        //    Application.Current.Properties["qaanduattesting"] = qaanduattesting;
        //    double support = getdoublevaluefromtextbox("support");
        //    Application.Current.Properties["support"] = support;
        //}

    }

}