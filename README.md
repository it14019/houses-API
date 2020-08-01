REST API using ASP.NET Core with functionality to get, create, edit and delete objects.

**Instructions**
1. clone repository `https://github.com/it14019/houses-API.git`
2. go to root directory and run project `dotnet run`
3. test API on, e.g., `Postman`

**Description**

| House         | Apartment     | Resident      |
| ------------- | ------------- | ------------- |
| Id            | Id            | Id            |  
| Number        | Number        | Name          |
| Street        | Floor         | Surname       |
| City          | Rooms         | PersonalCode  |
| Country       | PropertySize  | BirthDate     |
| PostCode      | LivingArea    | Phone         |
|               |               | Mail          |

Apartment is related to house, in which apartment is located. </br>
Resident is related to apartment, in which lives resident.

In-memory database is used.

**Houses**

Getting all houses with `GET`
<img src="https://raw.githubusercontent.com/it14019/houses-API/master/HouseAPI/images/GET-houses.PNG"/>

Adding a new house with `POST`
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/POST-houses.PNG"/>

Result after adding a house
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/after-POST-houses.PNG"/>

Editing house values with `PUT`
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/PUT-houses.PNG"/>

Result after editing house values
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/after-PUT-houses.PNG"/>

Deleting house with `DELETE`
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/DELETE-houses.PNG"/>

Result after deleting house
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/after-DELETE-houses.PNG"/>

**Apartments**

Getting all apartments with `GET`
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/GET-apartments.PNG"/>

Adding a new apartment with `POST`
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/PUT-apartments.PNG"/>

Result after adding an apartment
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/after-POST-apartments.PNG"/>

Editing apartment values with `PUT`
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/PUT-apartments.PNG"/>

Result after editing apartment values
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/after-PUT-apartments.PNG"/>

Deleting apartment with `DELETE`
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/DELETE-apartments.PNG"/>

Result after deleting apartment
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/after-DELETE-apartments.PNG"/>

**Residents**

Getting all residents with `GET`
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/GET-residents.PNG"/>

Adding a new resident with `POST`
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/POST-residents.PNG"/>

Result after adding a resident
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/after-POST-residents.PNG"/>

Editing resident values with `PUT`
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/PUT-residents.PNG"/>

Result after editing resident values
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/after-PUT-residents.PNG"/>

Deleting resident with `DELETE`
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/DELETE-residents.PNG"/>

Result after deleting resident
<img src="https://github.com/it14019/houses-API/blob/master/HouseAPI/images/after-DELETE-residents.PNG"/>
