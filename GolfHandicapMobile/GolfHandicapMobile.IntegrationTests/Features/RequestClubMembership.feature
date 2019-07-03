@base @registerplayer @signinplayer @requestclubmembership
Feature: Request Club Membership
	In order to use the Golf Handicap Mobile Application
	As a player
	I require to be able to request membership of a golf club

Background:
	Given the following golf clubs are registered
	| GolfClubName     | Town  | Region  | PostalCode |
	| Test Golf Club 1 | Town1 | Region1 | TE57 1NG   |
	| Test Golf Club 2 | Town2 | Region2 | TE57 2NG   |
	Given There are no players signed up
	And I am on the Sign In Page
	When I tap on Register
	Then I should be on the Register Player screen
	When I enter the First Name "Stuart"
	And I enter the Last Name "Ferguson"
	And I open the gender picker
	And I select "Male" from the Gender picker
	And I enter the Date Of Birth as "13/12/80"
	And I enter the Exact Handicap as "6.7"
	And I enter the Email Address as "stuart.ferguson@hotmail.co.uk"
	And I tap the Register button
	Then the Registration Success message should be displayed
	Given I am on the Sign In Page
	When I enter 'stuart.ferguson@hotmail.co.uk' as the Email Address
	And I enter '123456' as the Password
	When I tap on Sign In
	Then the Player Home Page is displayed

Scenario: Request Club Membership
	Given I am on the Home Page
	And I open up the sidebar
	When I click on the 'My Memberships' sidebar option
	Then the My Memberships screen is shown
	And I have no memberships currently
	When I click on this Request Club Membership button
	Then the Request Club Membership screen is shown
	When I open the golf club picker
	And I select "Test Golf Club 1" from the Golf Club picker
	Then the details for 'Test Golf Club 1' are shown
	When I click on the Request Membership button
	Then the membership request success message should be displayed for 'Test Golf Club 1'