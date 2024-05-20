Feature: ImageUploadTest

As a user of Mentors Kid
I want to login to my account
So that I can upload my image

@uploadimage
Scenario: Image Upload
	Given I navigate to Mentors Kid website
	When I click on Log in from the header section
	And I enter my user email 
	And I enter my user pasword
	And I click on submit button
	And I choose from profile settings section
	And I click on upload photo button
	Then image should be uploaded
	

	

