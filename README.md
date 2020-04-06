# Restaurants API

#### C#/.NET Core API for restaurants with full CRUD functionality. Current version: 04.03.20

#### By Sarah "Sasa" Schwartz

---

## Table of Contents

1. [Description](#description)
2. [Setup/Installation Requirements](#installation-requirements)
3. [API Documentaion](#api-documentation)
4. [Known Bugs](#known-bugs)
5. [Technologies Used](#technologies-used)
6. [License](#license)

---

## Description

Epicodus Friday project: C#/.NET Core API for restaurants with full CRUD functionality. A user can view all restaurants, search for restaurants by name or rating, view a specific restaurant by id, return a random restaurant, create a restaurant, edit a restaurant, and delete a restaurant. Please see the API documentation below for instructions on how to access and use this API.

## Installation Requirements

- Clone the repository on Github
- Open the terminal on your desktop
- \$git clone "insert your cloned URL here"
- Change directory to the RestaurantAPI directory, within the RestaurantAPI.Solution directory
- \$dotnet restore
- Recreate my database structure with migration:
  - \$dotnet ef migrations add Initial
  - \$dotnet ef database update
- \$dotnet run (runs the server at localhost:5000)
- Call this API with your web application or test out the requests using Postman.

---

## API Documentation

- Base url: http://localhost:5000

#### Routes

| Action                           | Method | Endpoint                |
| :------------------------------- | :----- | :---------------------- |
| List all restaurants (paginated) | GET    | /api/restaurants        |
| Retrieve specific restaurant     | GET    | /api/restaurants/{id}   |
| Create restaurant                | POST   | /api/restaurants        |
| Edit restaurant                  | PUT    | /api/restaurants/{id}   |
| Delete restaurant                | DELETE | /api/restaurants/{id}   |
| Retrieve random restaurant       | GET    | /api/restaurants/random |

#### Search Parameters

| Parameter | Type   | Example            | Response                                                   |
| :-------- | :----- | :----------------- | :--------------------------------------------------------- |
| Name      | String | /?name=burger+king | Restaurants with name "burger king"                        |
| Rating    | Int    | /?rating=5         | Restaurants with rating of 5                               |
| Page      | Int    | /?page=2           | Page 2 of paginated restaurant results (default is page 1) |
| Size      | Int    | /?size=25          | 25 restaurants per page (default is 20 and max is 50)      |

#### Pagination

- This API returns paginated results, with a default page size of 20 results per page and a max page size of 50 results per page.
- The default page number is set to 1.
- See the [search parameters](#search-parameters) above for information on how to adjust page size and number.

#### Example Query

- Example query: http://localhost:5000/api/restaurants/?rating=4&name=burger+king&page=3&size=5

  - This query returns restaurants with a rating of 4 and name of "burger king". It starts at page 3 with 5 results per page.

---

## Known Bugs

- No known bugs

## Technologies Used

- C#
- .NET

### License

- This software is licensed under the MIT license.
