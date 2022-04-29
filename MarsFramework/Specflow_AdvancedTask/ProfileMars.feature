Feature: ProfileMars

As a seller
 I would like to add profile details
So Customers could see details on profile page



@tagsignin
Scenario: 01) Sign In
 Given     [I login successfully]
	

@tagdescription
Scenario: 02) Add description in profile
	When    [I add description in profile]
	Then    [Description should be saved]

@tagavailability
Scenario: 03) Adding Availability,Hours and EarnTarget
	When  [I add Availability, Hours and EarnTarget in profile]
	Then  [Availability,Hours and EarnTarget details should be saved]

@taglanguage
Scenario Outline: 04) Adding new languages
	When    [I add new language in profile from <row>]
	Then    [Langauge should be saved]

	Examples:
		| row |
		| 2   |
		| 3   |
		| 4   |

@tagskill
Scenario Outline: 05) Adding skill details
	When  [I add new skill in profile from <row>]
	Then  [Skill should be saved]

	Examples:
	 | row |
	 | 2   |
	 | 3   |
	 | 4   |

@tageducation
Scenario: 06)  Adding Education Details
	When   [I Add Education in profile]
	Then   [Education should be saved]

@tagcertification
Scenario: 07) Adding Certification details
	When  [I add certification in profile]
	Then  [certification should be saved]
