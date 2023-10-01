Feature: PlanYourJourney

As a user I would like to plan my journey from and to stations 
So that I can see the journey detaisl and edit and view return journey

Background: 
	Given I open tfl plan your journey page
	And Tfl journey planner page is displayed	 

@PlanJourney
Scenario: Verify validating plan your journey page with valid data
	When I enter From '<From>' and To '<To>' station
	And click on plan my journey button
	Then results page is displayed with title Journey results
	And results page shows From station as '<Result From>' 
	And results page shows To station as '<Result To>' 
	And View Cycling and other options are displayed	

Examples: 
| From                    | To                                                  | Result From             | Result To                                           |
| Maidenhead Rail Station | London Victoria Rail Station                        | Maidenhead Rail Station | London Victoria Rail Station                        |
| Slough Rail Station     | Paddington (London), London Paddington Rail Station | Slough Rail Station     | Paddington (London), London Paddington Rail Station |

@PlanJourney
Scenario: Attempt to verify plan your journey option with invalid data
	When I enter From '<From>' and To '<To>' station
	And click on plan my journey button
	Then results page is displayed with title Journey results
	Then journey results page shows an error message '<Error>'

	Examples: 
| From             | To         | Error                                                                       |
| 1111111111122222 | 355dd53535 | Sorry, we can't find a journey matching your criteria                       |
| 1$%$^dgdg2222    | +++==33    | Journey planner could not find any results to your search. Please try again |

@PlanJourney
Scenario: Attempt to verify error message when both address are not entered while journey planning
	When I enter From '<From>' and To '<To>' station
	And click on plan my journey button
	Then error under From station is displayed as '<FromError>'
	Then error under To station is displayed as '<ToError>'

	Examples: 
| From | To | FromError                   | ToError                   |
|      |    | The From field is required. | The To field is required. |

@PlanJourney
Scenario: Attempt to verify error message when From address is blank while journey planning
	When I enter From '<From>' and To '<To>' station
	And click on plan my journey button
	Then error under From station is displayed as '<Error>'	

	Examples: 
| From       | To         | Error                       |
|            | Paddingtom | The From field is required. |

@PlanJourney
Scenario: Attempt to verify error message when To address is blank while journey planning
	When I enter From '<From>' and To '<To>' station
	And click on plan my journey button	
	Then error under To station is displayed as '<Error>'

Examples: 
| From       | To         | Error                       |
| Paddingtom |            | The To field is required.   |


@PlanJourney
Scenario: Verify Edit journey planning option
	When I enter From '<From>' and To '<To>' station
	And click on plan my journey button
	Then results page is displayed with title Journey results
	And results page shows From station as '<From>' 
	And results page shows To station as '<To>' 
	And View Cycling and other options are displayed
	And click on Edit journey option in results page
	And switch To and From stations in journey results page	
	And I click on Update journey button
	Then results page shows From station as '<UpdatedFrom>' 
	And results page shows To station as '<UpdatedTo>' 
	And View Cycling and other options are displayed


Examples: 
| From                | To                                                  | UpdatedFrom                                         | UpdatedTo           |
| Slough Rail Station | Paddington (London), London Paddington Rail Station | Paddington (London), London Paddington Rail Station | Slough Rail Station |
