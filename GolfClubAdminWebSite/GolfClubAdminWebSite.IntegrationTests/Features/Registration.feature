@registration

Feature: Registration

Scenario: Register Golf Club Administrator
	Given I am on the home page
	And I click on the register golf club administrator button
	Then I should be displayed the registration form
	When I use the follwing details to register
	| FirstName | LastName | Email                       | TelephoneNumber | Password | ConfirmPassword |
	| Test      | User     | testuser@testgolfclub.co.uk | 1234567890      | 123456   | 123456          |
	And I click the register button
	Then I should be presented with the Registration Success Page
	
