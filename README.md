# SmartLocate.Desktop.Admin

This project is a desktop application that provides an interface for the Admin Users of the SmartLocate application to manage the application.

It is primarily a WPF desktop application that uses Blazor and WebView2 to provide a web-based administration panel, that communicates with the backend microservices through the API Gateway.

## Prerequisites

- .NET 8.0 SDK
- Windows 7 or above
- Webview2 Runtime (Comes pre-installed in Windows 11)
- Already running microservices from the [SmartLocate.Backend](https://github.com/CloudMavericks/SmartLocate.Backend) repository

## Running the application

### Using Visual Studio or Rider

- Open the solution in Visual Studio or Rider
- Set the `SmartLocate.Desktop.Admin` project as the startup project
- Run the application. Just like any other WPF application, it will open a window with the application running.

### Using the command line

- Open the command line in the root of the repository
- Run the following command to build the application
  ```bash
  dotnet build src/SmartLocate.Desktop.Admin/SmartLocate.Desktop.Admin.csproj
  ```
- Run the following command to run the application
  ```bash
  dotnet run --project src/SmartLocate.Desktop.Admin/SmartLocate.Desktop.Admin.csproj
  ```
  
> **Note:** Ensure running the microservices from the [SmartLocate.Backend](https://github.com/CloudMavericks/SmartLocate.Backend) repository before running this project.