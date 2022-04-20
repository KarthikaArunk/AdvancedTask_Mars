Feature: ManageRequests

As a seller
 when I click on ManageRequests on Home page 
then I should be able to see all sent and received requests

@tag9
Scenario: 10)  Managing Sent and Received Requests
	When    [I click on Manage Requests]
	Then    [I should be able to see received and sent requests]
