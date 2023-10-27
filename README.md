# Parks API

#### By Jonathan Cheng

## Description

A Web API app that shares data about state and national parks in the State of Oregon complete with full CRUD functionality. Data is accessible by a client. Pagination is used to display a limited number of results at a time.

- _This web API application is written using C#, run using .NET framework, and database query and relationships handled with Entity Framework Core._
- _Data annotations validate input._
- _Full CRUD functionality for the `Park` class / model._
- _Data storage is managed using MySQL. Entity Framework Core .NET Command-line Tools (or dotnet ef) is used for database version control -- migrations inform MySQL on database structure and updates._
- _Swashbuckle (Swagger, Swagger UI) and Postman are used to document and test API endpoints._

## Technologies Used

- _C#_
- _.NET 6_
- _ASP.NET Core MVC_
- _MySQL_
- _MySQL Workbench_
- _Entity Framework Core_
- _Swashbuckle v6.2.3_
- _Postman v10.19_

## Setup/Installation Requirements

### Required Technology

- _Verify that you have the required technology installed for [MySQL](https://dev.mysql.com/doc/mysql-installation-excerpt/5.7/en/) and [MySQL Workbench](https://dev.mysql.com/doc/workbench/en/)._
- _Also check that Entity Framework Core's `dotnet-ef` tool is installed on your system so that it can perform database migrations and updates. Run the following command in your terminal:_
  > ```bash
  > $ dotnet tool install --global dotnet-ef --version 6.0.0
  > ```

### Setting Up the Project

#### Clone the Project

_1. Open your terminal (e.g., Terminal or GitBash)._

_2. Navigate to where you want to place the cloned directory._

_3. Clone the repository from the GitHub link by entering in this command:_

> ```bash
> $ git clone https://github.com/joncheng-dev/ParksApi.Solution.git
> ```

#### Set up a Connection String to Database

_Navigate to the project's production directory `ParksApi.Solution/ParksApi`. Create a new file called `appsettings.json`. Within the `appsettings.json` file, add the following code snippet. Change the server and port as needed. Replace the `uid`, and `pwd` values with your username and password for MySQL. Under `database`, add a fitting name -- although `parks_api` is suggested for clarity of purpose._

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DATABASE-NAME-HERE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}
```

#### Check for Port Conflicts

_In this app's `Properties/launchSettings.json` file, check to see that the `applicationUrl` key is set to a different set of ports than your client app -- if using one to query the API endpoints. In the ParksApi app, we have ports set to 5001 and 5000 as shown in the `launchSettings.json` snippet below._

```json
"ParksApi": {
    "commandName": "Project",
    "dotnetRunMessages": true,
    "launchBrowser": true,
    "launchUrl": "swagger",
    "applicationUrl": "https://localhost:5001;http://localhost:5000",
    "environmentVariables": {
      "ASPNETCORE_ENVIRONMENT": "Development"
    }
  }
```

#### Generate the Database

_In the terminal, while in the project's production directory `ParksApi`, run the command below. The repository's migrations will be used to generate the database with appropriate modifications via Entity Framework Core. You may opt to verify that the database has been created successfully in MySQL Workbench._

> ```bash
> $ dotnet ef database update
> ```

## Launching the API

_In the command line, while in the project's production directory `ParksApi.Solution/ParksApi`, enter the command `dotnet run` to compile and execute the application. Afterwards, the API is accessible via a client._

> ```bash
> $ dotnet run
> ```

## API Documentation

To explore the API endpoints, use a client such as a browser, Postman, or Swagger UI. If using Swagger, navigate to the following URL: `https://localhost:5001/swagger/index.html`, or `http://localhost:5000/swagger/index.html`.

#### Note on Pagination

ParksApi is set to return the first index of results, and show up to 10 results per page. To make modifications, opt to do one of the following:

- _Navigate to the project's Controller directory, file `ParksController.cs` to edit the HttpGet controller's Get() action parameters `pageIndex = 1` and `int pageSize = 10`. This allows customization of values for pageIndex and pageSize._
- _Change the parameters in the http request: `http://localhost:5000/api/Parks?pageIndex=1&pageSize=10`. Set the parameters `pageIndex` and `pageSize` to different integer values, such as 2 for pageIndex to see the second page of all results, and 20 for pageSize to return twenty results per page, respectively._

### API Endpoints

Base URL: `http://localhost:5000`

#### HTTP Request Structure

| Request Type |      Path       |
| :----------: | :-------------: |
|     GET      |   /api/parks    |
|     GET      | /api/parks/{id} |
|     POST     |   /api/parks    |
|     PUT      | /api/parks/{id} |
|    DELETE    | /api/parks/{id} |

#### Path Parameters

|   Parameter    |  Type   | Default | Required | Description                                           |
| :------------: | :-----: | :-----: | :------: | ----------------------------------------------------- |
|   pageIndex    | integer |    1    |  false   | Returns the requested index page.                     |
|    pageSize    | integer |   10    |  false   | Returns up to the requested number of parks per page. |
|      name      | string  |  none   |  false   | Returns matches by park name.                         |
|  feeRequired   | string  |  none   |  false   | Returns matches for values "yes" or "no".             |
|     status     | string  |  none   |  false   | Returns matches for values "open" or "closed".        |
| campingAllowed | string  |  none   |  false   | Returns matches for values "yes" or "no".             |
|  dogsAllowed   | string  |  none   |  false   | Returns matches for values "yes" or "no".             |

#### Example Queries

The following query will return the first ten results.

```
http://localhost:5000/api/Parks?pageIndex=1&pageSize=10
```

The following query will return any parks with matching name `Crater Lake`.

```
http://localhost:5000/api/Parks?name=Crater%20Lake&pageIndex=1&pageSize=10
```

The following query will return the first ten results of parks with feeRequired valued at "yes".

```
http://localhost:5000/api/Parks?feeRequired=yes&pageIndex=1&pageSize=10

```

The following query will return the first ten results of parks with feeRequired value at "no" and status value of "open".

```
http://localhost:5000/api/Parks?feeRequired=no&status=open&pageIndex=1&pageSize=10
```

#### Sample JSON Response

```json
[
  {
    "parkId": 2,
    "name": "Agate Beach State Recreation Site",
    "description": "No agates, but a great place to see the sunset.",
    "feeRequired": "no",
    "status": "open",
    "campingAllowed": "yes",
    "dogsAllowed": "yes"
  }
]
```

## Known Bugs

- _Currently no known bugs. Kindly let me know if you happen upon one: joncheng.dev@gmail.com_

## License

```
MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

Copyright (c) 2023 Jonathan Cheng
```

<a align=left href="#">Return to Top</a>
