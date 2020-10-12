# MT-LRS Introductory Project

This project is using .NET Core (v.3.1) as back-end API and Angular 10 for the front-end

NOTE: This project requires node.js and node package manager (npm) to be installed on your computer.
Please see https://github.com/angular/angular for minimum requirements.

## Installation/Usage

1. Run init-db.sql in order to create a local database for the API
2. Modify "ConnectionStrings" in appsettings.json in order to connect to your local db
3. Open a command-line prompt and cd to MT-LRS-Intro/Web/ClientApp
4. Run 'npm install' to install all packages needed for the Angular application
5. Right click on Solution in Solution Explorer, click on "Select Startup Projects"
   and under "Multiple Startup Projects" set "Start" for both Api and Web projects.
6. Start the app in Visual Studio without debugging (Ctrl + F5)

Two tabs will open in your default browser:

1. Swagger. A web page/tool that allows you to try out the API
2. The actual front-end application
