@base @registerplayer @signinplayer
Feature: Sign In Player
	In order to use the Golf Handicap Mobile Application
	As a player
	I require to be able to sign in once registered

Background: 
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

Scenario: Sign In With Valid Credentials
	Given I am on the Sign In Page
	When I enter 'stuart.ferguson@hotmail.co.uk' as the Email Address
	And I enter '123456' as the Password
	When I tap on Sign In
	Then the Player Home Page is displayed
