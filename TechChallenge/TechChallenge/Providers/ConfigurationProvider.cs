using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Models;
using Newtonsoft.Json.Linq;
using System.IO;

namespace TechChallenge.Providers
{
    /// <summary>
    /// The configuration provider class.
    /// </summary>
    public static class ConfigurationProvider
    {
        /// <summary>
        /// The web driver config section name.
        /// </summary>
        private const string WebDriverConfigSectionName = "webdriver";

        /// <summary>
        /// The environment config section name.
        /// </summary>
        private const string EnvironmentConfigSectionName = "environment";

        /// <summary>
        /// The Test Settings file path.
        /// </summary>
        private const string FilePath = @"..//..//..//TestSettings.json";
        private static readonly string SettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath);

        /// <summary>
        /// Gets the web driver.
        /// </summary>
        public static WebDriverConfiguration WebDriver =>
            Load<WebDriverConfiguration>(WebDriverConfigSectionName);

        /// <summary>
        /// Gets the environment.
        /// </summary>
        public static EnvironmentConfiguration Env =>
            Load<EnvironmentConfiguration>(EnvironmentConfigSectionName);

        /// <summary>
        /// Parse JsonObject.
        /// </summary>
        /// <param name="sectionName">The section name.</param>
        /// <returns>A T.</returns>
        private static T Load<T>(string sectionName) =>
            JObject.Parse(File.ReadAllText(SettingsPath)).SelectToken(sectionName).ToObject<T>();
    }
}
