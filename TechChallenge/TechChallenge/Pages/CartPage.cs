using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TechChallenge.Pages
{
    public class CartPage : BasePage
    {
        #region Locators
        /// <summary>
        /// check out button locator
        /// </summary>
        By CheckOutButton => By.Id("checkout");

        /// <summary>
        /// inventory item price label locator
        /// </summary>
        By InventoryItemPrice => By.ClassName("inventory_item_price");
        #endregion

        /// <summary>
        /// click on checkout button
        /// </summary>
        public void ClickCheckOutButton()
        {
            ClickObClickableElement(CheckOutButton);
        }

        /// <summary>
        /// Get the inventory item price
        /// </summary>
        /// <returns>return item price as string</returns>
        public string GetInventoryItemPrice()
        {
            string price = GettextOfElement(InventoryItemPrice).Replace("$","");
            return price;
        }

    }
}
