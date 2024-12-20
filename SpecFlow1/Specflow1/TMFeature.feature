﻿Feature: TMFeature

A short summary of the feature

As a TurnUp portal admin user
I would like to create, edit and delete time and material records
So that I can manage employees time and materials successfully

@regression
Scenario: create time record with valid data
	Given I logged into TurnUp portal successfully
	When I navigate to Time and Material page
	When I create a time record
	Then the record should be created successfully

Scenario Outline:Edit Existing Time Record With Valid Data
	Given I logged into TurnUp portal successfully
	When I navigate to Time and Material page
	When I update the '<Code>' and '<Description>' on an existing Time record
	Then the record should have the updated '<Code>' and '<Description>'

	Examples: 
	| Code             | Description |
	| Industry Connect | Laptop      |
	| TA Job Ready     | Mouse       |
	| EditedRecord     | Keyboard    |

Scenario: delete existing time record
	Given I logged into TurnUp portal successfully
	When I navigate to Time and Material page
	When I delete an existing record
	Then the record should not be present on the table
