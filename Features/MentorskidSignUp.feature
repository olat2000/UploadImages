Feature: MentorskidSignUp

As a user on Mentorskid website
I want to register 
So that I can have access to profile board

@register
Scenario: Verify user can Register 
	Given user navigate to MentorsKid website
	   And user click on signup
	   And user enter first name 
	   And user enter last name
	   And user enter email address 
	   And user enter pword 
	   And user select the options Mentor or Mentee 
	   And user check terms and conditions 
   When user click on join now 
   Then user profile page should displayed
