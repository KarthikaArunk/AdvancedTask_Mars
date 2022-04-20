Feature: SkillProfile

As a seller
 I would like to add skills
So Customers could see skills  on profile page

@tag4
Scenario Outline: 04) Adding skill details
	When  [I add new skill details from <row>]
	Then  [Skill details should be saved]

	Examples:
	 | row |
	 | 2   |
	 | 3   |
	 | 4   |