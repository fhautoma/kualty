using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TechChallenge.Pages
{
    public class CheckOutStepOnePage : BasePage
    {
        #region Locators
        /// <summary>
        /// first name field locator
        /// </summary>
        By FirstNameField => By.Id("first-name");

        /// <summary>
        /// last name field locator
        /// </summary>
        By LastNameField => By.Id("last-name");

        /// <summary>
        /// postal code field locator
        /// </summary>
        By PostalCodeField => By.Id("postal-code");

        /// <summary>
        /// continue button locator
        /// </summary>
        By ContinueButton => By.Id("continue");
        #endregion

        public void FillPersonalInformation(string firstName, string lastName, string postalCode)
        {
            SettextAfterWaiting(FirstNameField, firstName);
            SettextAfterWaiting(LastNameField, lastName);
            SettextAfterWaiting(PostalCodeField, postalCode);

        }

        public void ClickContinueButton()
        {
            ClickObClickableElement(ContinueButton);
        }



    }
}
