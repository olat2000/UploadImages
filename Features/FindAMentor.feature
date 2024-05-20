Feature: FindAMentor

As a user on Mentorskid
I want select Mentor by category & prices
So that I can decide what course to choose

@tag1
Scenario: Verify user can select Mentor by Category and Prices
	Given user navigates to Mentorskid website
    When user click on Find a Mentor on the header section
       And user validates the "What are you looking for?" on the redirected page
       And user validates the "Select category" text on the page
       And user validates the "Start from here" too on the page
       And user select course from Category dropdown
       And user select price from High to Low or Low to High dropdown
       And user click on search now button
    Then Mentors with the selected prices should be displayed

