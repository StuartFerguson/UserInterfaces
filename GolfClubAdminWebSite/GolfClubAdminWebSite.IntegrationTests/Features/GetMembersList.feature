@base @registration @creategolfclub @getmemberslist
Feature: GetMembersList

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
	| GolfClubName | AddressLine1 | AddressLine2 | TownCity | Region     | PostCode | TelephoneNumber | EmailAddress            | Website            |
	| Test Golf Club | Address Line 1 |                | TestTown | TestRegion | TE57 1NG | 1234567890      | testclub@testclub.co.uk | www.testclub.co.uk |
	And I click the Create Club button
	Then I should be presented with the Edit Golf Club screen
	And the following players have registered and requested membership of 'Test Golf Club'
	| PlayerNumber | EmailAddress              | GivenName | MiddleName | FamilyName | Age | Gender | ExactHandicap |
	| 1            | testplayer1@players.co.uk | Test      |            | Player1    | 25  | M      | 2             |

	Scenario: Get Members List
	When I click on the Members sidebar option
	Then I am presented with the Members List Screen
	And a member with the following details should be in the list
	| Name          | Age | Gender | MembershipStatus | MembershipNumber |
	| Test Player1 | 25  | M      | Rejected         | 000002           |
