Feature: DescriptionProfile

As a seller
 I would like to add description
So Customers could see description on profile page


@tag1
Scenario: 01) Adding description in profile
	When    [I add description]
	Then    [Description details should be saved]
 
	 