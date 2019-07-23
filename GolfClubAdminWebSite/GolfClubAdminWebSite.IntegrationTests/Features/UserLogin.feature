@userlogin
Feature: UserLogin

Background:
	Given I am on the home page
	And I click on the register golf club administrator button
	Then I should be displayed the registration form
	When I use the follwing details to register
	| FirstName | LastName | Email                       | TelephoneNumber | Password | ConfirmPassword |
	| Test      | User     | testuser@testgolfclub.co.uk | 1234567890      | 123456   | 123456          |
	And I click the register button
	Then I should be presented with the Registration Success Page
	Given I am on the home page
	And I click on the login button
	Then I am presented with the login screen
	When I enter the username 'testuser@testgolfclub.co.uk'
	And I enter the password '123456'
	And I click on the forms login button
	Then I should be presented with the logged in screen
	When I click on the Manage Golf Club sidebar option
	Then I am presented with the Create Golf Club Screen
	When I use the following details to create a new golf club
	| GolfClubName   | AddressLine1   | AddressLine2 | TownCity | Region     | PostCode | TelephoneNumber | EmailAddress            | Website            |
	| Test Golf Club | Address Line 1 |              | TestTown | TestRegion | TE57 1NG | 1234567890      | testclub@testclub.co.uk | www.testclub.co.uk |
	And I click the Create Club button
	Then I should be presented with the Edit Golf Club screen
	When I click on the Users sidebar option
	Then I am presented with the list of golf club users
	And a user with the name "Test User" should be in the list
	When I click on the Users sidebar option
	Then I am presented with the list of golf club users
	When I click on the New Match Secretary Button
	And I use the following details to create a match secretary
	| FirstName | LastName        | Email                                 | TelephoneNumber |
	| Test      | Match Secretary | testmatchsecretary@testgolfclub.co.uk | 1234567890      |
	And I click on the create user button
	Then I am presented with the list of golf club users
	And a user with the name "Test Match Secretary" should be in the list
	And I have logged out of the application

Scenario: Login as Golf Club Administrator
	Given I am on the home page
	And I click on the login button
	Then I am presented with the login screen
	When I enter the username 'testuser@testgolfclub.co.uk'
	And I enter the password '123456'
	And I click on the forms login button
	Then I should be presented with the logged in screen

Scenario: Login as Match Secretary
	Given I am on the home page
	And I click on the login button
	Then I am presented with the login screen
	When I enter the username 'testmatchsecretary@testgolfclub.co.uk'
	And I enter the password '123456'
	And I click on the forms login button
	Then I should be presented with the logged in screen

