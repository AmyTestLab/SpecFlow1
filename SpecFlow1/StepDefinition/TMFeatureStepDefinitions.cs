using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SpecFlow1.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow1.StepDefinition
{
    [Binding]
    public class TMFeatureStepDefinitions
    {
        private IWebDriver driver;

        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            
            // Open Chrome Browser
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

        }

        [When(@"I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.navigatetoTMPage(driver);
        }

        [When(@"I create a time record")]
        public void WhenICreateATimeRecord()
        {
            // TM page object initialization and definition
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver);
        }

        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TMPage tMPageObj = new TMPage();


            // Retrieve values from the application
            string newCode = tMPageObj.GetCode(driver);
            string newDescription = tMPageObj.GetDescription(driver);
            string newPrice = tMPageObj.GetPrice(driver);

            // Log actual values for debugging
            Console.WriteLine($"Actual Code: {newCode}");
            Console.WriteLine($"Actual Description: {newDescription}");
            Console.WriteLine($"Actual Price: {newPrice}");

            // Perform assertions
            Assert.That(newCode == "TA Programme", "Actual code do not match");
            Assert.That(newDescription == "This is a description", "Actual description do not match with expected description");
            // Handle formatting for price
            decimal actualPrice = decimal.Parse(newPrice.Trim('$').Trim());
            Assert.That(actualPrice == 12.00m, "Actual price does not match the expected price");
            // Assert.That(newPrice == "12", "Actual price do not match with expected price");

        }
        [When(@"I update the '([^']*)' and '([^']*)' on an existing Time record")]
        public void WhenIUpdateTheAndOnAnExistingTimeRecord(string code, string description)
        {
            // Create an instance of the TMPage class and call the EditTimeRecord method
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTimeRecord(driver, code, description);

        }

        [Then(@"the record should have the updated '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdatedAnd(string code, string description)
        {

            TMPage tMPageObj = new TMPage();

            string editedCode = tMPageObj.GetEditedCode(driver);
            string editedDescription = tMPageObj.GetEditedDescription(driver);

            Assert.That(editedCode == code, "Expected Edited Code and actual edited code do not match.");
            Assert.That(editedDescription == description, "Expected Edited Description and actual edited description do not match.");

        }
        [When(@"I delete an existing record")]
        public void WhenIDeleteAnExistingRecord()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.DeleteTimeRecord(driver);
        }

        [Then(@"the record should not be present on the table")]
        public void ThenTheRecordShouldNotBePresentOnTheTable()
        {
            // Verify deletion logic here
            TMPage tMPageObj = new TMPage();

            string editedCode = tMPageObj.GetEditedCode(driver);
            string editedDescription = tMPageObj.GetEditedDescription(driver);

            Assert.That(editedCode != "EditedRecord", "Time record is not deleted successfully. Test Failed");
            Assert.That(editedDescription != "Keyboard", "Expected Edited Description and actual edited description do not match.");
        }

    }
}
