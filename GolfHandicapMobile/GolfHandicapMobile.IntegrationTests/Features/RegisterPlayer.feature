@base @registerplayer
Feature: RegisterPlayer
	In order to use the Golf Handicap Mobile Application
	As a player
	I require to be able to register

Background: 
	Given There are no players signed up

Scenario: Register Player
	Given I am on the Main Page
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
	Then the Registration Success screen should be displayed

Scenario: Register Player without a first name
	Given I am on the Main Page
	When I tap on Register
	Then I should be on the Register Player screen
	When I enter the Last Name "Ferguson"
	And I open the gender picker
	And I select "Male" from the Gender picker
	And I enter the Date Of Birth as "13/12/80"
	And I enter the Exact Handicap as "6.7"
	And I enter the Email Address as "stuart.ferguson@hotmail.co.uk"
	And I tap the Register button
	Then an error indicating first name is required will be displayed

Scenario: Register Player without a last name
	Given I am on the Main Page
	When I tap on Register
	Then I should be on the Register Player screen
	When I enter the First Name "Stuart"
	And I open the gender picker
	And I select "Male" from the Gender picker
	And I enter the Date Of Birth as "13/12/80"
	And I enter the Exact Handicap as "6.7"
	And I enter the Email Address as "stuart.ferguson@hotmail.co.uk"
	And I tap the Register button
	Then an error indicating last name is required will be displayed

Scenario: Register Player without a gender
	Given I am on the Main Page
	When I tap on Register
	Then I should be on the Register Player screen
	When I enter the First Name "Stuart"
	When I enter the Last Name "Ferguson"
	And I enter the Date Of Birth as "13/12/80"
	And I enter the Exact Handicap as "6.7"
	And I enter the Email Address as "stuart.ferguson@hotmail.co.uk"
	And I tap the Register button
	Then an error indicating gender is required will be displayed

Scenario: Register Player without a date of birth
	Given I am on the Main Page
	When I tap on Register
	Then I should be on the Register Player screen
	When I enter the First Name "Stuart"
	And I enter the Last Name "Ferguson"
	And I open the gender picker
	And I select "Male" from the Gender picker
	And I enter the Exact Handicap as "6.7"
	And I enter the Email Address as "stuart.ferguson@hotmail.co.uk"
	And I tap the Register button
	Then an error indicating date of birth is required will be displayed

Scenario: Register Player with an invalid date of birth
	Given I am on the Main Page
	When I tap on Register
	Then I should be on the Register Player screen
	When I enter the First Name "Stuart"
	And I enter the Last Name "Ferguson"
	And I open the gender picker
	And I select "Male" from the Gender picker
	And I enter the Date Of Birth as "99/99/99"
	And I enter the Exact Handicap as "6.7"
	And I enter the Email Address as "stuart.ferguson@hotmail.co.uk"
	And I tap the Register button
	Then an error indicating date of birth is invalid will be displayed

Scenario: Register Player without an exact handicap
	Given I am on the Main Page
	When I tap on Register
	Then I should be on the Register Player screen
	When I enter the First Name "Stuart"
	And I enter the Last Name "Ferguson"
	And I open the gender picker
	And I select "Male" from the Gender picker
	And I enter the Date Of Birth as "13/12/80"
	And I enter the Email Address as "stuart.ferguson@hotmail.co.uk"
	And I tap the Register button
	Then an error indicating exact handicap is required will be displayed
	
Scenario: Register Player with an exact handicap less than -10.0
	Given I am on the Main Page
	When I tap on Register
	Then I should be on the Register Player screen
	When I enter the First Name "Stuart"
	And I enter the Last Name "Ferguson"
	And I open the gender picker
	And I select "Male" from the Gender picker
	And I enter the Date Of Birth as "13/12/80"
	And I enter the Exact Handicap as "-10.1"
	And I enter the Email Address as "stuart.ferguson@hotmail.co.uk"
	And I tap the Register button
	Then an error indicating exact handicap is outwith the valid range will be displayed

Scenario: Register Player with an exact handicap greater than 36.0
	Given I am on the Main Page
	When I tap on Register
	Then I should be on the Register Player screen
	When I enter the First Name "Stuart"
	And I enter the Last Name "Ferguson"
	And I open the gender picker
	And I select "Male" from the Gender picker
	And I enter the Date Of Birth as "13/12/80"
	And I enter the Exact Handicap as "36.1"
	And I enter the Email Address as "stuart.ferguson@hotmail.co.uk"
	And I tap the Register button
	Then an error indicating exact handicap is outwith the valid range will be displayed

Scenario: Register Player without an email address
	Given I am on the Main Page
	When I tap on Register
	Then I should be on the Register Player screen
	When I enter the First Name "Stuart"
	And I enter the Last Name "Ferguson"
	And I open the gender picker
	And I select "Male" from the Gender picker
	And I enter the Date Of Birth as "13/12/80"
	And I enter the Exact Handicap as "6.7"
	And I tap the Register button
	Then an error indicating email adddress is required will be displayed

Scenario: Register Player with an invalid email address
	Given I am on the Main Page
	When I tap on Register
	Then I should be on the Register Player screen
	When I enter the First Name "Stuart"
	And I enter the Last Name "Ferguson"
	And I open the gender picker
	And I select "Male" from the Gender picker
	And I enter the Date Of Birth as "13/12/80"
	And I enter the Exact Handicap as "6.7"
	And I enter the Email Address as "stuart.fergusonhotmail.co.uk"
	And I tap the Register button
	Then an error indicating email address is invalid is required will be displayed