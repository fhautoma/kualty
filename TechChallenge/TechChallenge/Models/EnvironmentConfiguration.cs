using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Models
{
    /// <summary>
    /// The environment configuration properties.
    /// </summary>
    public class EnvironmentConfiguration
    {
        /// <summary>
        /// Gets or sets the application env. Represents application environment.
        /// </summary>
        public string ApplicationEnv { get; set; }

        /// <summary>
        /// Gets or sets the application url. Represents application url.
        /// </summary>
        public string ApplicationUrl { get; set; }

        /// <summary>
        /// Gets or sets the my account url.
        /// </summary>
        public string MyAccountUrl { get; set; }

    }
}
