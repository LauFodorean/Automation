Feature: MainWidowCloseButton
	I want to verify the "close" button of the main window of notepad
	The application is open but the file is not saved
	i write something in the editing area
	If I press the close button a new window should appear asking me if I want to save

@mytag
Scenario: CloseWithoutSaving
	Given I have opened the notepad application
	And I have writen something in the editing area
	When I click on close button
	Then I should see a new window with a message asking me if I want to save the file
