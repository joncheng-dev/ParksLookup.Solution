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

_Navigate to the project's production directory `ParksApi.Solution/ParksApi`. Create a new file called `appsettings.json`. Within the `appsettings.json` file, add the following code snippet. Change the server and port as needed. Replace the `uid`, and `pwd` values with your username and password for MySQL. Under `database`, add a fitting name — although `parks_api` is suggested for clarity of purpose._

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

_In this app's `Properties/launchSettings.json` file, check to see that the `applicationUrl` key is set to a different set of ports than your client app — if using one to query the API endpoints. In the ParksApi app, we have ports set to 5001 and 5000 as shown in the `launchSettings.json` snippet below._

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

##### Notes Regarding Parameters

- For requests of type GET in which the purpose is to return 'all results' or 'any results matching specific criteria' — as opposed to returning a single park object via `ParkId` — the parameters listed in the table are _not_ required / are optional.
- Requests of type POST require a request body with an object literal — complete and properly formatted, with all properties except for `ParkId`. The database will handle assigning a `ParkId` value. Refer to sample below.
- Requests of type PUT require a request body with an object literal — complete and propertly formatted, with all properties, including the `ParkId`. Refer to sample below.

##### Sample POST Query Request Body

```json
{
  "name": "The Ridgiest Ridge",
  "description": "Where many claim the end of the rainbow resides.",
  "feeRequired": "yes",
  "status": "closed",
  "campingAllowed": "yes",
  "dogsAllowed": "yes"
}
```

#### Sample PUT Query Request Body

```json
{
  "parkId": 12,
  "name": "Springfield National Park",
  "description": "Bigfoot was spotted here.",
  "feeRequired": "yes",
  "status": "open",
  "campingAllowed": "no",
  "dogsAllowed": "no"
}
```

#### Example GET Query without Search Parameters

The following query will return the first ten results. This is equivalent of a "Get All" request, but only 10 results by order of numerical `ParkId` values will be returned due to implementation of pagination -- since default values of `pageIndex = 1` and `pageSize = 10`.

```
http://localhost:5000/api/Parks
```

#### Example GET Queries using Optional Search Parameters

The following query will return the 2nd set of results (`pageIndex=2`) if each page is set to have 3 results (`pageSize=3`). Assuming there are 6 entries in the database, it would skip entries 1, 2, 3, and return entries 4, 5, and 6. Sample response provided below this segment.

```
http://localhost:5000/api/Parks?pageIndex=2&pageSize=3
```

The following query will return any parks with matching name "Crater Lake".

```
http://localhost:5000/api/Parks?name=Crater%20Lake
```

The following query will return the first ten results of parks with `feeRequired` value at "no" and `status` value of "open".

```
http://localhost:5000/api/Parks?feeRequired=no&status=open&pageIndex=1&pageSize=10
```

##### Sample Response - GET Query using Optional Search Parameters

```json
[
  {
    "parkId": 4,
    "name": "Oregon Caves National Monument",
    "description": "Eons of acidic water seeping into marble rock created and decorated these wondrous marble halls.",
    "feeRequired": "yes",
    "status": "closed",
    "campingAllowed": "no",
    "dogsAllowed": "no"
  },
  {
    "parkId": 5,
    "name": "John Day Fossil Beds National Monument",
    "description": "Colorful rock formations preserve a world class record of plant and animal evolution, changing climate, and past ecosystems that span over 40 million years.",
    "feeRequired": "no",
    "status": "open",
    "campingAllowed": "no",
    "dogsAllowed": "no"
  },
  {
    "parkId": 6,
    "name": "Cascade-Siskiyou National Monument",
    "description": "This convergence of three geologically distinct mountain ranges has resulted in an area with unparalleled biological diversity and a tremendously varied landscape.",
    "feeRequired": "no",
    "status": "open",
    "campingAllowed": "yes",
    "dogsAllowed": "yes"
  }
]
```

#### Example GET Query for Specific Park Object -- Requires ParkId

The following query will return a park with matching `ParkId` of 3.

```
http://localhost:5000/api/Parks/3
```

##### Sample Response - GET by ParkId

```json
{
  "parkId": 3,
  "name": "Fogarty Creek State Recreation Area",
  "description": "This park has great birdwatching and tidepools to explore.",
  "feeRequired": "no",
  "status": "open",
  "campingAllowed": "yes",
  "dogsAllowed": "yes"
}
```

#### Example POST Query

The following query will add this entry to the database. Note that the `parkId` property is left out, but all others are included in the request body's object literal.

```
http://localhost:5000/api/Parks
```

#### Example PUT Query

The following query will update the park object with the `ParkId` of 12. Note that the property `"parkId": 12` must be included in the request body's object literal. Refer to sample request body above under "Sample PUT Query Request Body".

```
http://localhost:5000/api/Parks/12
```

## Known Bugs

- _Currently no known bugs. Kindly let me know if you happen upon one or would like to say hello: joncheng.dev@gmail.com_

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
