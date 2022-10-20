Feature: SharedSteps

Steps for use in multiple scenarios

@shared
Scenario: Givens
	Given Shared steps context
	* Upload test data
	* "" Navigates to the website login page
	* "" Adds to cart the "" item
	* "" Selects the shopping cart link

@shared
Scenario: Whens
	When "" Logs in with valid credentials username "" and password ""
	* "" Logs in with invalid credentials username "" and password ""
	* "" Selects the checkout option
	* "" Fills personal information form
	* "" Validates the purchase information
	

@shared
Scenario: Thens
	Then "" Can see the inventory page
	* "" Sees login failed error message
	* The system displays a thank you message for the purchase