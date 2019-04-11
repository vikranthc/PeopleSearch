# PeopleSearch

**Stack**
1. .Net Core
2. Entity Framework Core 2.2.3
2. Asp.net core webapi
3. Angular 6
4. Bootstrap 4.2
5. rxjs
6. Localdb for persistence

**Prerequisites**
 1. .net core 2.2
 2. Node.js and npm

**To Run**

1. Open the PeopleSearch.sln with Visual Studio
2. Right click on the PeopleSearch.Web project and select 'Set As Startup Project'
3. Open a console window in the PeopleSearch.Web/ClientApp directory and Run: npm install
4. Click the 'Run' button on the Visual Studio tool bar

This should open the application in http://localhost:25785

Web App design decisions:

This is designed as a SPA using Angular6.

There are two pages 
1. Home(Search) http://localhost:25785
2. List All (http://localhost:25785/everyone)

They can be accessed anytime from the nav bar on the top.

The Search page has a search bar, where the user can search for a person by entering any part of first or last name.
The search happens as soon as the user stops typing.
The simulated delay is hardcoded to be 2.5 seconds on the server side.
A blue spinner is displayed to the user on the web page, when the search is loading.

The ***List All*** page lists the first 100 users in the database, for help with testing.


Things I wanted to do, if time permitted

1. Add paging
2. Refactor client side html markup.
3. Use NgRx for state management.
4. CRUD for adding new users.
5. Better styling.



