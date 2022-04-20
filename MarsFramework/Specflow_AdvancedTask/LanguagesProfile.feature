Feature: LanguagesProfile

As a seller
 I would like to add languages
So Customers could see languages  on profile page

@tag3
Scenario Outline: 03) Adding new languages
	When    [I add new language details from <row>]
	Then    [Langauge details should be saved]

	Examples:
		| row |
		| 2   |
		| 3   |
		| 4   |

	