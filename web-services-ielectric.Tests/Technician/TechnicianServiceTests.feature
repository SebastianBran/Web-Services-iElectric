Feature: TechnicianServiceTests
	As a Developer
	I Want ot add new Technician through API
	So that it becomes available for applicantions.

@technician-adding
Scenario: Add Technician
	Given The Endpoint https://localhost:44346/api/v1/technicians is available
	When A Technician Request is sent
	| Names | LastNames | CellphoneNumber | Address    | Email           | Password   |
	| Pedro | Jimenez   | 978675641       | San Isidro | pedro@gmail.com | Pedro12345 |
	Then A Response with Status 200 is received for the technician