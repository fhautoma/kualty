using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TechChallenge.Pages
{
    public class InventoryPage : BasePage
    {
        #region Locators
        /// <summary>
        /// add to cart back pack item button
        /// </summary>
        By AddToCartBackPackButton => By.Id("add-to-cart-sauce-labs-backpack");

        /// <summary>
        /// Shopping cart link button
        /// </summary>
        By ShoppingCartLink => By.ClassName("shopping_cart_link");

        By ProductsTitle => By.ClassName("title");

        #endregion

        /// <summary>
        /// Add backpack to cart - click
        /// </summary>
        public void AddItemToCart()
        {
            ClickObClickableElement(AddToCartBackPackButton);
        }

        /// <summary>
        /// Click cart link
        /// </summary>
        public void ClickCartLink()
        {
            ClickObClickableElement(ShoppingCartLink);
        }

        public string GetInventoryPageTittle()
        {
            string title = GettextOfElement(ProductsTitle);
            return title;
        }

    }
}
