Feature: AdministratorServiceTests
	As a Developer
	I Want ot add new Administrator through API
	So that it becomes available for applicantions.

@administrator-adding
Scenario: Add Administrator
	Given The Endpoint https://localhost:44346/api/v1/administrators is available
	When A Administrator Request is sent
	| Names | LastNames | CellphoneNumber | Address    | Email           | Password   |
	| Carlos | Leon   | 940596111       | San Martin | carlos.leon@gmail.com | carlos123 |
	Then A Response with Status 200 is received for the administrator