@createtournament
Feature: CreateTournament

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
	When I click on the Measured Courses sidebar option
	Then I am presented with the list of measured courses
	When I click on the New Measured Course button
	Then I am presented with the New Measured Course screen
	When I add the following details for the new measured course
	| Name             | TeeColour | SSS |
	| Test Golf Course | White     | 70  |
	When I add the following hole information for the new measured course
	| HoleNumber | Yardage | Par | StrokeIndex |
	| 1          | 348     | 4   | 10          |
	| 2          | 402     | 4   | 4           |
	| 3          | 207     | 3   | 14          |
	| 4          | 405     | 4   | 8           |
	| 5          | 428     | 4   | 2           |
	| 6          | 477     | 5   | 12          |
	| 7          | 186     | 3   | 16          |
	| 8          | 397     | 4   | 6           |
	| 9          | 130     | 3   | 18          |
	| 10         | 399     | 4   | 3           |
	| 11         | 401     | 4   | 13          |
	| 12         | 421     | 4   | 1           |
	| 13         | 530     | 5   | 11          |
	| 14         | 196     | 3   | 5           |
	| 15         | 355     | 4   | 7           |
	| 16         | 243     | 4   | 15          |
	| 17         | 286     | 4   | 17          |
	| 18         | 399     | 4   | 9           |
	And I click the Create Measured Course
	Then I am presented with the list of measured courses
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
	Given I am on the home page
	And I click on the login button
	Then I am presented with the login screen
	When I enter the username 'testmatchsecretary@testgolfclub.co.uk'
	And I enter the password '123456'
	And I click on the forms login button
	Then I should be presented with the logged in screen

Scenario:  Create Tournament
	When I click on the Tournaments sidebar option
	Then I am presented with the Create Tournament screen
	When I enter the following details for a new tournament
	| MeasuredCourse   | Format     | MemberCategory | Name            | TournamentDate |
	| Test Golf Course | Strokeplay | Gents          | Test Tournament | 2019-07-23     |
	And I click on the create tournament button
	Then I should be presented with the logged in screen
	
