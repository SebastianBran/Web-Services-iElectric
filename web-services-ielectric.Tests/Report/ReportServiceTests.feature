Feature: ReportServiceTests
	As a Developer
	I want to add new Report throught the API
	So that it becomes available for applications

@mytag
Scenario: Add Report
	Given The Endpoint https://localhost:44346/api/v1/reports is available
	When A Client Request is sent to the API
	| Observation             | Diagnosis             | RepairDescription                      | ImagePath                 | Date     | TechnicianId | AppointmentId |
	| The microwave smell bad | A component is burned |  I replaced the microchip successfully | https://google.com/images | 10-12-24 | 2            | 1             |
	Then A Response with Status 200 is received
