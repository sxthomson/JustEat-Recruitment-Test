@SelfHostedApi
Feature: Restaurants

As a user running the application
I can view a list of restaurants in a user submitted outcode (e.g. SE19)
So that I know which restaurants are currently available


Scenario: Known outcodes return restaurants
	Given a known outcode "SE19"
	When I request restaurant information from the api
	Then restaurants are returned

Scenario: Known outcodes return name, cuisine types and ratings of restaurants
	Given a known outcode "SE19"
	When I request restaurant information from the api
	Then the name, cuisine types and ratings of the restaurants are returned