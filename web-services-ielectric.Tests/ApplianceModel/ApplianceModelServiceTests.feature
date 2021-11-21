Feature: ApplianceModelServiceTests
	As a Developer
	I want to add new ApplianceModel through API
	so that it becomes avaliable for applications.

@applianceModel.adding
Scenario: Add ApplianceModel
	Given The Endpoint https://localhost:44346/api/v1/applianceModel is available
	When A ApplianceModel Request is sent
	| Name  | Model | ImgPath  | PurchaseDate | ApplianceBrandId |
	| T-800 | 1.0.1 | img1.jpg | 23/12/20     | 2                |
	Then A Response with Status 200 is received for the applianceModel