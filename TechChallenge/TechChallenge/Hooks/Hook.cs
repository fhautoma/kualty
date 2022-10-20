using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using TechChallenge.Models;

namespace TechChallenge.Hooks
{
    [Binding]
    public class Hook
    {
        public static IWebDriver _driver;

        readonly WebDriverConfiguration config = new WebDriverConfiguration();

        /// <summary>
        ///  Before Scenario for Chrome Driver - tag "Chrome"  
        /// </summary>
        [BeforeScenario("Chrome")]

        public void BeforeScenarioChrome()
        {
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--disable-save-password-bubble");
            options.AddArgument("ignore-certificate-errors");
            options.AddArgument("start-maximized");
            options.AddArgument($"--lang={config.BrowserLanguage}");
            options.AddUserProfilePreference("intl.accept_languages", config.BrowserLanguage);
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver(options);


        }

        /// <summary>
        /// After Scenario: Actions to excecute after each scenario
        /// </summary>
        [AfterScenario]

        public void AfterScenario()
        {
            _driver.Close();
            _driver.Quit();
            _driver.Dispose();
        }

    }
}
