using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Providers;

namespace TechChallenge.Pages
{
    public class LoginPage: BasePage
    {
        #region Locators
        /// <summary>
        /// user name field locator
        /// </summary>
        By UserNameField => By.Id("user-name");

        /// <summary>
        /// password field locator
        /// </summary>
        By PasswordField => By.Id("password");

        /// <summary>
        /// login button locator
        /// </summary>
        By LogInButton => By.Id("login-button");

        /// <summary>
        /// error message locator
        /// </summary>
        By LogInErrorMessage => By.CssSelector("#login_button_container > div > form > div.error-message-container.error");

        #endregion

        private static Uri WebPageUrl => new Uri(ConfigurationProvider.Env.ApplicationUrl);

        internal void NavigateToUrl()
        {
            Driver.Navigate().GoToUrl(WebPageUrl);
        }

        public void LogIn(string userName, string password)
        {
            SettextAfterWaiting(UserNameField, userName);
            SettextAfterWaiting(PasswordField, password);
            ClickObClickableElement(LogInButton);
        }
        public string GetErrorLogInMessage()
        {
            string errorMessage = GettextOfElement(LogInErrorMessage);
            return errorMessage;
        }

    }
}
