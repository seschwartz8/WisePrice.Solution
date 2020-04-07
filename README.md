# Wise Price API and MVC Application

#### Team Week C# Project for Epicodus. Built API and MVC applications for a community to share grocery deals.

#### Current version: 04.06.20

#### By Sarah "Sasa" Schwartz, Adela Darmansyah, Tiffany Siu, Jiwon Han

<!-- [![Project Status: Inactive – The project has reached a stable, usable state but is no longer being actively developed; support/maintenance will be provided as time allows.](https://www.repostatus.org/badges/latest/inactive.svg)](https://www.repostatus.org/#inactive) -->
[![Project Status: WIP – Initial development is in progress, but there has not yet been a stable, usable release suitable for the public.](https://www.repostatus.org/badges/latest/wip.svg)](https://www.repostatus.org/#wip)
![LastCommit](https://img.shields.io/github/last-commit/seschwartz8/WisePrice.Solution)
![Languages](https://img.shields.io/github/languages/top/seschwartz8/WisePrice.Solution)
[![MIT license](https://img.shields.io/badge/License-MIT-orange.svg)](https://lbesson.mit-license.org/)

---

## Wise Price API: Table of Contents

1. [API Description](#api-description)
2. [API Setup/Installation Requirements](#api-setup)
3. [API Documentaion](#api-documentation)
4. [API Known Bugs](#api-known-bugs)
5. [API Screenshots](#api-screenshots)

## Wise Price MVC Application: Table of Contents

1. [MVC Description](#mvc-description)
2. [MVC Setup/Installation Requirements](#mvc-setup)
3. [MVC Specifications](#specifications)
4. [MVC Known Bugs](#mvc-known-bugs)
5. [MVC Screenshots](#mvc-screenshots)

## Miscellaneous

1. [Work Distribution](#work-distribution)
2. [Improvement Opportunities](#improvement-opportunities)
3. [Technologies Used](#technologies-used)
4. [Support and Contact Details](#support-and-contact-details)
5. [License](#license)

---

## API Description

A C#/.NET Core API that hosts information on grocery locations, items, and deals. This API provides full CRUD functionality, allowing users to create, view, edit, and delete grocery deals. 

## API Setup
To run dev mode locally:
```bash
  $ git clone 
  $ cd WisePrice
  $ dotnet add package Microsoft.EntityFrameworkCore -v 2.2.0
  $ dotnet add package Pomelo.EntityFrameworkCore.MySql -v 2.2.0
  $ dotnet add package Microsoft.EntityFrameworkCore.Proxies
  - To enable lazy loading
  $ dotnet add package --version 5.3.1 Swashbuckle.AspNetCore
  - for Swagger that describes the capabilities of the API and how to access it with HTTP
  $ dotnet build 
  $ dotnet ef migrations add MigrationName
  $ dotnet ef database update  
  # After successfull pkg installtion
  $ dotnet run
```
Now, it will automatically open http://localhost:5000 and API is available on [Postman](https://www.postman.com/) or [Swagger UI](localhost:5000/swagger)

## API Documentation

- Base url: http://localhost:5000

#### Routes

| Action for DEALS                 | Method | Endpoint          | Query Parameters | Raw JSON Body Input |
| :------------------------------- | :----- | :---------------- | :--------------- | :------------------ |
| List all deals (paginated)       | GET    | /api/deals        | string itemName, string zipCode, int page, int size | N/A |
| Retrieve specific deal           | GET    | /api/deals/{id}   | N/A | N/A |
| Create deal                      | POST   | /api/deals        | N/A | { "itemId": #, "locationId": #, "userId": #, "price": #, "timeUpdated": "YYYY-MM-DD", "upVotes": #, "downVotes": # } |
| Edit deal                        | PUT    | /api/deals/{id}   | N/A | { "itemId": #, "locationId": #, "userId": #, "price": #, "timeUpdated": "YYYY-MM-DD", "upVotes": #, "downVotes": # } |
| Delete deal                      | DELETE | /api/deals/{id}   | N/A | N/A |
| Count all deals                  | GET    | /api/deals/count  | string itemName, string locationName | N/A |

| Action for ITEMS                 | Method | Endpoint          | Query Parameters | Raw JSON Body Input |
| :------------------------------- | :----- | :---------------- | :--------------- | :------------------ |
| List all items* (paginated)      | GET    | /api/items        | string name, int page, int size | N/A |
| Retrieve specific location       | GET    | /api/locations/{id}   | N/A | N/A |
| Create item                      | POST   | /api/items        | N/A | { "ItemName": "[item name]" } |
| Edit item                        | PUT    | /api/items/{id}   | N/A | { "ItemName": "[edited item name]" } |
| Delete item                      | DELETE | /api/items/{id}   | N/A | N/A |
| Count all items                  | GET    | /api/items/count  | N/A | N/A |

| Action for LOCATIONS                 | Method | Endpoint          | Query Parameters | Raw JSON Body Input |
| :------------------------------- | :----- | :---------------- | :--------------- | :------------------ |
| List all locations* (paginated)      | GET    | /api/locations        | string name, string zipcode, string address, int page, int size | N/A |
| Retrieve specific location           | GET    | /api/locations/{id}   | N/A | N/A |
| Create location                      | POST   | /api/locations        | N/A | { "Name": "[location name]" } |
| Edit location                        | PUT    | /api/locations/{id}   | N/A | { "Name": "[edited location name]" } |
| Delete location                      | DELETE | /api/locations/{id}   | N/A | N/A |
| Count all locations                  | GET    | /api/locations/count  | N/A | N/A |
| Retrieve locations in specific zip code | GET | api/locations/neareststores | int userZipCode | N/A |

> _*Returns a list of items that includes users & locations of other items' users and locations. However, query search works well._

| Action for USERS                 | Method | Endpoint          | Query Parameters | Raw JSON Body Input |
| :------------------------------- | :----- | :---------------- | :--------------- | :------------------ |
| Retrieve a user's pinned and posted deals  | GET | /api/users/{id} | N/A | N/A |
| Delete a user along with their pinned and posted deals | DELETE | /api/users/{id} | N/A | N/A |

#### Example Query Search Parameters

| Parameter | Type   | Example            | Response                                             |
| :-------- | :----- | :----------------- | :--------------------------------------------------- |
| Name      | String | /?itemname="broccoli" | Deals with name "broccoli"                        |
| Location  | String | /?zipcode="98105"  | Deals offered in the area of "98105"                 |
| Page      | Int    | /?page=2           | Page 2 of paginated deal results (default is page 1) |
| Size      | Int    | /?size=25          | 25 deals per page (default is 20 and max is 50)      |

#### Pagination

- This API returns paginated results, with a default page size of 20 results per page and a max page size of 50 results per page.
- The default page number is set to 1.
- See the [search parameters](#search-parameters) above for information on how to adjust page size and number.

#### Example Query

- Example query: http://localhost:5000/api/deal/?itemname=broccoli&zipcode=98105&page=3&size=25

  - This query returns deals for the item broccoli in the area near 98105. It starts at page 3 with 5 results per page.

## API Known Bugs

_There are currently no known bugs in this program._

## API Screenshots


---
## MVC Description

WRITE THE MVC DESCRIPTION HERE

## MVC Setup

- Clone the repository on Github
- Open the terminal on your desktop
- \$git clone "insert your cloned URL here"
- Change directory to the WisePriceClient directory, within the WisePrice.Solution directory
- \$dotnet restore
- Recreate the database structure with migration:
  - \$dotnet ef migrations add Initial
  - \$dotnet ef database update
  - If you receive an error during this stage, check to make sure the password in "appsettings.json" matches your personal MySQL password
- \$dotnet run (runs the server at localhost:5000)
- Call this API with your web application or test out the requests using Postman.


## Specifications
### MVP Specs
- As a user, I want to be able to share a deal for a specific item at a specific store.
  - Sample input: User fills out and submits "add deal" form
  - Expected output:  Deal is added to list of deals for all users
- As a user, I want to be able to add an item if the one I'm looking for is not already present.
  - Sample input: User fills out deal form, but cannot find their item and clicks "don't see your item?"
  - Expected output: Additional form field appears, allowing user to add a new item for their deal
- As a user, I want to be able to edit deals I have posted.
  - Sample input: User edits the milk deal posted on today and clicks edit button 
  - Expected output: Milk price is edited from $2 to $1.50
- As a user, I want to be able to delete deals I have posted.
  - Sample input: User delete the egg deal posted on yesterday and clicks delete button
  - Expected output: The post is deleted
- As a user, I want to be able to pin deals I want to save.
  - Sample input: User clicks the "pin" button on a deal while browsing
  - Expected output: That deal is added to user's "pinned deals" list
- As a user, I want to be able to browse through deals.
  - Sample input: User clicks the "deals" button
  - Expected output: A list of deals is presented to the user to scroll through
- As a user, I want to be able to register for an account on Wise Price. 
- As a user, I want to be able to log into and out of my account on Wise Price.
- As a developer, I want to notify the user about the privacy policy prior to them logging on.
- As a developer, I want the website to have a navigation bar at the top and footer at the bottom.


### Future Specs?

High - Low prioritized future features:
As a user, I want to be able to remove deals I have pinned.
As a user, I want to see how recently each deal was posted/updated.
As a user, I want to view deals sorted by how close they are to my inputted location.
As a user, I want to view deals sorted by how recently they were posted.

As a user, I want to be able to "like" or vote up a deal that I like.
As a user, I want to be able to "dislike" or vote down a deal that I dislike.
As a user, I want to be able to see the overall vote percentage for another user to know if their deals are trustworthy?

As a user, I want to add items per category.
As an admin, I want to be able to view and manage all member accounts.
As a developer, I want to be able to launch a live demo of the application.
As a user, I want to be able to change my password.

## MVC Known Bugs

- No known bugs

## MVC Screenshots

--- 

## Work Distribution

* Sasa Schwartz
* Adela Darmansyah
* Tiffany Siu
* Jiwon Han

## Improvement Opportunities

INSERT PARKING LOT ITEMS HERE AT END OF WEEK

## Technologies Used

- C#
- [.NET CORE](https://dotnet.microsoft.com/download/dotnet-core/)
- Entity Framework and Razor
- [MySQL](https://dev.mysql.com/downloads/file/?id=484919)
- [Semantic UI](https://semantic-ui.com/)

## Support and Contact Details

_If there are any question or concerns please contact us at our emails: [Sasa Schwartz](mailto:#), [Adela Darmansyah](mailto:#), [Tiffany Siu](mailto:tsiu88@gmail.com), and [Jiwon Han](mailto:#jiwon1.han@gmail.com). Thank you._

### License

- This software is licensed under the MIT license.

Copyright (c) 2020 **_Sasa Schwartz, Adela Darmansyah, Tiffany Siu, Jiwon Han_**
