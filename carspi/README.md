# Cars API

This is a simple RESTful API for managing cars.

## Technologies Used

- C#
- .NET Core 3.1
- Entity Framework Core 3.1
- PostgreSQL 13
- Visual Studio Code

## Prerequisites

- .NET Core SDK 3.1 or higher
- PostgreSQL 13 or higher
- An IDE of your choice, preferably Visual Studio Code

## Setup

1. Clone the repository

```
git clone https://github.com/shahzeen031/CarAPI
```

2. Create a database in PostgreSQL

3. Update the `appsettings.json` file with your PostgreSQL database connection string

```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=5432;Database=mydatabase;User Id=myusername;Password=mypassword;"
}
```

4. Run the following command in the terminal to install the required packages

```
cd carspi
dotnet restore
```

5. Run the following command in the terminal to create the database schema

```
dotnet ef database update
```

6. Run the following command in the terminal to start the API

```
dotnet run
```

## API Endpoints

| Endpoint         | HTTP Method | CRUD Method | Result               |
|------------------|-------------|-------------|----------------------|
| `/api/CarModel/GetCars`      | GET         | READ        | Get all cars         |
| `/api/CarModel/GetCarById/{id}`  | GET         | READ        | Get a single car by id|
| `/api/CarModel/SaveCar`  | POST        | CREATE      | Add a new car        |
| `/api/CarModel/UpdateCar`  | PUT         | UPDATE      | Update an existing car|
| `/api/CarModel/DeleteCar/{id}` | DELETE      | DELETE      | Delete a car by id    |

## Result


```
# Sample API Request and Response

##  GET Request

```curl
curl -X 'GET' \
  'http://localhost:5197/api/CarModel/api/CarModel/GetCars' \
  -H 'accept: */*'
```

## Response

```json
{
  "code": "0",
  "message": "Success",
  "responseData": [
    {
      "id": 1,
      "make": "Toyota",
      "model": "Camry",
      "colour": null,
      "year": 2019
    },
    {
      "id": 3,
      "make": "BMW",
      "model": "BMWX1",
      "colour": null,
      "year": 2019
    },
    {
      "id": 4,
      "make": "Honda",
      "model": "Civic",
      "colour": null,
      "year": 2017
    }
  ]
}
```

## Post Request

```curl
curl -X 'POST' \
  'http://localhost:5197/api/CarModel/api/CarModel/SaveCar' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": 0, //always put id = 0 for ost request
  "make": "BMW",
  "model": "BMW5",
  "colour": "Black",
  "year": 2018
}'
```


## Response

```json
{
  "code": "0",
  "message": "Success",
  "responseData": {
    "id": 0,
    "make": "BMW",
    "model": "BMW5",
    "colour": "Black",
    "year": 2018
  }
}
```



## Response Format

All API responses will be returned in the following JSON format:

```
{
    "status": "success/error",
    "message": "Success/Error Message",
    "data": "Response Data"
}
```

## Error Handling

If an error occurs while processing an API request, the response will be returned in the following format:

```
{
    "status": "error",
    "message": "Error Message",
    "data": null
}
```

