using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Pages
{
    public class CheckOutCompletePage : BasePage
    {
        #region Locators
        By ThanksMessage => By.ClassName("complete-header");

        #endregion

        /// <summary>
        /// Get thanks message
        /// </summary>
        /// <returns>return item price as string</returns>
        public string GettextMessage()
        {
            string message = GettextOfElement(ThanksMessage);
            return message;
        }

    }
}
