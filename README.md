# Project Name
  **PayrollManagement**

## Table of Contents
- General Information
- Technologies Used
- Solution Architecture
- Features
- Screenshots
- Setup
- Usage
- Project Status
- Room for Improvement
- Acknowledgements
- Contact

## General Information
- When supplied with employee details like first name, last name, annual salary (positive integer) and super rate (0% - 50% inclusive), 
  payment start date, the program should generate an employee monthly pay slip with metadata like name, pay period, gross income, income tax, net income and super.
- The program should use the input from the employee details & business logic from the tax slab, the payslip information should be calculated.
- I did it as a coding exercise for the developer position @ MYOB.

## Technologies Used
- This soltuion has been built using Visual Studio 2019, C# 8.0, .Net Core framework & xUnit.net Testing framework. If you wish to run the test cases, maybe you need to install some plugin for xUnit.

## Solution Architecture
- Solution name for the project is **PayrollManagement**. There are two separate projects. **PayrollManagement** project is a console app that has all folder & files that are being used for creating the services, that will be running as a background process inside the application. I have created a Services folder in the project to contain these application specific processes.I have also used the Dependency Inversion Principle in C# for this project. The **PayrollManagement.Tests** project is a test project to write the unit tests for the programming model that I am introducing to calculate the payslip and provide those features that define the application. Please refer to the Screnshots section for more details.
- I have added [CsvHelper](https://joshclose.github.io/CsvHelper/) library, since I want to use CSV as input and output format. That's why I didn't add test cases for IO Operations as I did not want to test the .Net Framework.
- The business logic of the project can be found under the services folder. It has all details to calculate the payslip.
## Features
- Dependency Injection
- Logging using Serilog
- Configuration using appsettings.json

## Screenshots

![image](https://user-images.githubusercontent.com/90431401/157336597-2315f2a1-adfe-41f8-ac49-67af7fe4f775.png)

## Setup
The project requirements/dependencies are as follows
- CsvHelper Version 12.2.1
- Microsoft.ApplicationInsights.AspNetCore Version 2.20.0
- Microsoft.Extensions.DependencyInjection Version 3.1.0
- Microsoft.Extensions.Hosting Version 3.0.0
- Microsoft.Extensions.Options Version 3.1.1
- Serilog.Extensions.Hosting Version 3.1.0
- Serilog.Extensions.Logging Version 3.0.1
- Serilog.Settings.Configuration Version 3.0.0
- Serilog.Sinks.Console Version 4.0.1
- FluentAssertions Version 4.0.0
- Moq 4.1.7.2
- xunit Version 2.4.1
- xunit.runner.visualstudio Version 2.4.1

## How to install / setup one's local environment / get started with the project.
- Build the project to get all the dependencies in your local environment.
- Add the file Employee.csv under C:\Temp folder

## Usage
- Try to run the tests for different services using Test Explorer. This step is optional.
- Hit F5 to run the console app.
- The salary slip file named SalarySlip.csv will be generated under  C:\Temp folder.
- use the command dotnet run. The command depends on the dotnet build command to build the code. Any requirements for the build,
  such as that the project must be restored first, apply to dotnet run as well.

## Project Status
- Project is complete.
- It is open for extension for adding more features.

## Room for Improvement
- Adding another service for handling the changes to the tax slab.
- Introducing a logger that takes advantage of .NET Core structured event logging.
- Read and write the contents of a text file asynchronously.

To do:
- Add TaxSlabService to handle the previous & future tax rates.
- Structured Event logging using Serilog.
- Implement async methods on stream classes.

## Acknowledgements
- This project is inspired by a mixture of videos from Practical C# - Tim Corey.
- Many thanks to [IAmTimCorey](https://www.youtube.com/user/IAmTimCorey/featured)

## Contact
Created by @kuldeepSingh - feel free to contact me!
