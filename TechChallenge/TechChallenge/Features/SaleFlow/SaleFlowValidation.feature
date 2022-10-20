Feature: SaleFlowValidation

Basic Sale flow validation
Background: 
		Given "User" Navigates to the website login page
		* Upload test data
		When "User" Logs in with valid credentials username "standard_user" and password "secret_sauce"


@Chrome
Scenario: Sauce Labs Backpack purchase flow
	Given "User" Adds to cart the "Sauce Labs Backpack" item
	And "User" Selects the shopping cart link
	When "User" Selects the checkout option
	And "User" Fills personal information form
	* "User" Validates the purchase information
	Then The system displays a thank you message for the purchase
