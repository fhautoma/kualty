Feature: LoginValidation

login feature validation

@Chrome
Scenario: Correct Login
	Given "User" Navigates to the website login page
	When "User" Logs in with valid credentials username "standard_user" and password "secret_sauce"
	Then "User" Can see the inventory page

@Chrome
Scenario: Failed Login
	Given "User" Navigates to the website login page
	When "User" Logs in with invalid credentials username "test" and password "test"
	Then "User" Sees login failed error message