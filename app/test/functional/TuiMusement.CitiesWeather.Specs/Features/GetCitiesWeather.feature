Feature: Get the cities weather forecasts
    
    Scenario: Executing the program will print out the weather forecast
        Given the weather forecast for London today is "Moderate Rain"
        And the weather forecast for London tomorrow is "Patchy rain possible"
        When I execute the program
        Then it prints out "Processed city London | Moderate rain - Patchy rain possible"