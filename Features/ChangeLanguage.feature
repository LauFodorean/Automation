Feature: ChangeLanguage
	I want to see if by pressing tab item View and pressing on User Interface Button
	a new window appears allowing me to select a new UI language.

@mytag
Scenario: Change the UI language
	
	Given I am in the main window of the application
	
	When I press the User Interface Language in the View tab item
	Then The User Interface Language window appears allowing me to select anothe language
