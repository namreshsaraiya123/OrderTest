Feature: TestCompleteLogin

Background: Visit the website
    Given user have visited the testcomplete home page 

	@testcomplete
	Scenario Outline: : Successful Login
	Given user is not logged in
    When user enters username in the username textbox as "<username>" 
    And user enters password in the password textbox as "<password>"
	And user clicks on Login button
	Then verify the user is successfully logged in
	When user clicks on the logout button
	Then verify the user is successfully logged out

	Examples: 
	| username | password |
	| Tester   | test     |

	@testcomplete
	Scenario Outline: : Successful Logout
	Given user is not logged in
    When user enters username in the username textbox as "<username>" 
    And user enters password in the password textbox as "<password>"
	And user clicks on Login button
	Then verify the user is successfully logged in
	When user clicks on the logout button
	Then verify the user is successfully logged out

	Examples: 
	| username | password |
	| Tester   | test     |