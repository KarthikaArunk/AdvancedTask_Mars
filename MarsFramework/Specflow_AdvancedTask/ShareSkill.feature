Feature: ShareSkill

As a seller
 I would like to list new skills
 So customers could see new skill listings on profile

@tag7
Scenario Outline: 07) [Adding new skill listings]
	#Given [I logged into the Mars portal successfully]
	When  [I add new skill listings from <row>]
	Then  [Skill listings should be saved]
Examples: 
 | row |
 | 2   |
 | 3   |
 | 4   |
 @tag7
 Scenario: 08) Adding New Skill Failed(Negative Test Case)
     When   [I add few fields for new skill]
	 Then   [An error message should be displayed]
