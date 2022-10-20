using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Pages
{
    public class CheckOutStepTwoPage : BasePage
    {
        #region Locators
        /// <summary>
        /// inventory item price label locator
        /// </summary>
        By InventoryItemPrice => By.ClassName("inventory_item_price");

        /// <summary>
        /// inventory item name label locator
        /// </summary>
        By InventoryItemName => By.ClassName("inventory_item_name");

        /// <summary>
        /// finish button
        /// </summary>
        By FinishButton => By.Id("finish");

        #endregion

        /// Get the inventory item price
        /// </summary>
        /// <returns>return item price as string</returns>
        public string GetInventoryItemPrice()
        {
            string price = GettextOfElement(InventoryItemPrice).Replace("$", "");
            return price;
        }

        /// Get the inventory item price
        /// </summary>
        /// <returns>return item name</returns>
        public string GetInventoryItemName()
        {
            string itenName = GettextOfElement(InventoryItemName);
            return itenName;
        }

        public void ClickFinishButton()
        {
            ClickObClickableElement(FinishButton);
        }


    }
}
