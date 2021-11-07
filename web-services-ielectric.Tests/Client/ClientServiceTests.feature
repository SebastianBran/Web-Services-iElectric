Feature: ClientServiceTests
	As a Developer
	I Want ot add new Client through API
	So that it becomes available for applicantions.

@client-adding
Scenario: Add Client
	Given The Endpoint https://localhost:44346/api/v1/clients is available
	When A Client Request is sent
	| Names | LastNames | CellphoneNumber | Address    | Email           | Password   |
	| Juan  | Perez     | 987654321       | Los Angeles | juan@gmail.com | Juan12345 |
	Then A Response with Status 200 is received for the client