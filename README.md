## Setup:
	+ Clone / Download solution
	+ DB Connection string is configured at <root>\Api\Api\appsettings.json.
	+ API deployment config is configured at <root>\Api\Api\Properties\launchsettings.json
	+ API url for Web is configured at <root>\Web\app\environments\environments.ts

## Run app
	+ To deploy the API: in powershell, navigate to the <root>\Api\Api and
	+ run command: dotnet run
	+ To run Web app: navigate to <root>\Web and
	+ run command: npm install and
	+ run command: ng serve

## Run unit tests
	+ Run: ng test (for web)
	+ Run: dotnet test (for API)
