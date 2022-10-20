using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechChallenge.Hooks;
using EC = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TechChallenge.Pages
{
    public class BasePage
    {
        public BasePage()
        {
            Driver = Hook._driver;
            Wait = new WebDriverWait(Hook._driver, TimeSpan.FromSeconds(300));
        }

        protected IWebDriver Driver { get; private set; }
        protected IWebElement Element { get; private set; }
        protected WebDriverWait Wait { get; private set; }

        /// <summary>
        /// Locate element by locator
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        protected IWebElement LocateElement(By locator) => Driver.FindElement(locator);

        protected void WaitElement(By locator)
        {
            Wait.Until(EC.ElementIsVisible(locator));
        }

        /// <summary>
        /// Wait Element until element to be clickable and send click action
        /// </summary>
        /// <param name="locator"></param>
        protected void ClickObClickableElement(By locator) => 
            Wait.Until(EC.ElementToBeClickable(locator)).Click();

        /// <summary>
        /// Wait Element until element is visible and send text
        /// </summary>
        /// <param name="locator"></param>
        protected void SettextAfterWaiting(By locator, string text) =>
            Wait.Until(EC.ElementIsVisible(locator)).SendKeys(text);

        /// <summary>
        /// Wait Element and return text
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        protected string GettextOfElement(By locator)
        {
            WaitElement(locator);
            return LocateElement(locator).Text;
        }


    }
}
