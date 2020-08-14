# Pierre's Sweet and Savory Treats

#### Latest version date 8/14/2020

#### By Deryck Jackson

## Description

A webpage for creating and tracking an assortment of treats and flavors associated with them.

## Specifications

| Spec | Input | Output |
| :---: | :---: | :---: |
| Webpage will allow user to create an account | Email: D@G.com | 'User account created' |
| Webpage will allow users that are logged in to create treats and flavors | Create treat and flavor | treat: { Name: pastry }, flavor: { Name: strawberry } |
| Webpage will allow users to associate flavors to treats or vice versa | treat flavor strawberry | treat: {flavor: strawberry} |
| Webpage will display a list of all treats and flavors on the home screen a user not logged in can see and click on |  | List of treats and flavors |


## Setup and Installation

* .NET Core 2.2 will need to be installed, it can be found here https://dotnet.microsoft.com/download/dotnet-core/2.2
* For Mac users, download MySQL here: https://dev.mysql.com/downloads/file/?id=484914
* For Windows users, download MySQL here: https://dev.mysql.com/downloads/file/?id=484919
* to clone this content, copy the url provided by the 'clone or download' button in GitHub
* Navigate to the newly created `Sneuss.Solution` folder
* Navigate to the `Sneuss` subfolder and run `dotnet restore`
* Run `dotnet ef database update` in the terminal
* Run `dotnet build` to build the app and `dotnet run` to run it
* The web app will now be available on `http://localhost:5000/` in your browser

## Tech used

* C#
* ASP.NET MVC
* Entity Framework Core
* Identity Framework
* MYSQL

### License

This project is licensed under the [MIT License](https://opensource.org/licenses/MIT).

Copyright (c) 2020 Deryck Jackson