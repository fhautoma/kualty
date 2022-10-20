using FluentAssertions;
using System;
using TechChallenge.Models;
using TechChallenge.Pages;
using TechChallenge.Providers;
using TechTalk.SpecFlow;

namespace TechChallenge.StepDefinitions
{

    [Binding]
    public class SharedStepsStepDefinitions
    {
        string firstName;
        string lastName;
        string postalCode;


        readonly ScenarioContext _scenarioContext;
        readonly LoginPage _loginPage = new ();
        readonly CartPage _cartPage = new ();
        readonly InventoryPage _inventoryPage = new ();
        readonly CheckOutStepOnePage _checkOutStepOnePage = new();
        readonly CheckOutStepTwoPage _checkOutStepTwoPage = new();
        readonly CheckOutCompletePage _checkOutCompletePage = new ();

        public SharedStepsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        #region GivenMethods
        [Given(@"Shared steps context")]
        public void GivenSharedStepsContext()
        {
            Console.WriteLine("Init Shared Steps");
        }

        [Given(@"Upload test data")]
        public void GivenUploadTestData()
        {
            var personData = PersonDataProvider.PersonData<PersonalData>();

            firstName = personData.first_name;
            lastName = personData.last_name;
            postalCode = personData.postal_code;

        }

        [Given(@"""([^""]*)"" Navigates to the website login page")]
        public void GivenNavigatesToTheWebsiteLoginPage(string currentUser)
        {
            _loginPage.NavigateToUrl();
        }
        [Given(@"""([^""]*)"" Adds to cart the ""([^""]*)"" item")]
        public void GivenAddsToCartTheItem(string currentUser, string itemName)
        {
            _scenarioContext.Add("InventoryItemName", itemName);
            _inventoryPage.AddItemToCart();
        }

        [Given(@"""([^""]*)"" Selects the shopping cart link")]
        public void GivenSelectsTheShoppingCartLink(string currentuser)
        {
            _inventoryPage.ClickCartLink();
        }

        #endregion

        #region WhenMethods
        [When(@"""([^""]*)"" Logs in with valid credentials username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenLogsInWithValidCredentialsUsernameAndPassword(string currentUser, string userName, string password)
        {
            _loginPage.LogIn(userName, password);
        }

        [When(@"""([^""]*)"" Logs in with invalid credentials username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenLogsInWithInvalidCredentialsUsernameAndPassword(string currentUser, string userName, string password)
        {
            _loginPage.LogIn(userName, password);
        }

        [When(@"""([^""]*)"" Selects the checkout option")]
        public void WhenSelectsTheCheckoutOption(string currentUser)
        {
            _scenarioContext.Add("CartItemPrice", _cartPage.GetInventoryItemPrice());
            _cartPage.ClickCheckOutButton();
        }

        [When(@"""([^""]*)"" Fills personal information form")]
        public void WhenFillsPersonalInformationForm(string currentUser)
        {
            _checkOutStepOnePage.FillPersonalInformation(firstName, lastName, postalCode);
            _checkOutStepOnePage.ClickContinueButton();

        }

        [When(@"""([^""]*)"" Validates the purchase information")]
        public void WhenValidatesThePurchaseInformation(string currentUser)
        {
            string inventoryItemName = _scenarioContext.Get<String>("InventoryItemName");
            string cartItemPrice = _scenarioContext.Get<String>("CartItemPrice");

            string checkOutInventoryItemName = _checkOutStepTwoPage.GetInventoryItemName();
            string checkOutInventoryItemPrice = _checkOutStepTwoPage.GetInventoryItemPrice();

            checkOutInventoryItemName.Should().Be(inventoryItemName);
            checkOutInventoryItemPrice.Should().Be(cartItemPrice);

            _checkOutStepTwoPage.ClickFinishButton();

        }

        #endregion

        #region ThenMethods
        [Then(@"""([^""]*)"" Can see the inventory page")]
        public void ThenCanSeeTheInventoryPage(string currentUser)
        {
            var inventoryPageTittle = _inventoryPage.GetInventoryPageTittle();
            inventoryPageTittle.Should().Be("PRODUCTS");
        }

        [Then(@"""([^""]*)"" Sees login failed error message")]
        public void ThenSeesLoginFailedErrorMessage(string currentUser)
        {
            var errorLoginMessage = _loginPage.GetErrorLogInMessage();
            errorLoginMessage.Should().Be("Epic sadface: Username and password do not match any user in this service");
        }

        [Then(@"The system displays a thank you message for the purchase")]
        public void ThenTheSystemDisplaysAThankYouMessageForThePurchase()
        {
            string message = _checkOutCompletePage.GettextMessage();
            message.Should().Be("THANK YOU FOR YOUR ORDER");

        }
        #endregion
    }
}
