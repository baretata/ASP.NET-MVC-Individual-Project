![alt tag](http://url/to/img.png)# Recruit Yourself Application

The application is for people who want to volunteer in different spheres where help is needed.They can join events or organizator foundations which raise charity or organize charity events.

Helping others is essential in our nature and as Gandhi said "The best way to find yourself is to lose yourself in service of others".

### Types of users

1.Admin: has access to CRUD operations over categories, volunteers and organizations

2.Registered users: They can create events or join events.

3.Visitors /without login/: they can only read events and articles information.


### Database

##### Models:

`User`

`Volunteer` (inherit `User`) 

`Organization` (inherit `User`)

`Category` (for events)

`Event`

`Article`


##### Relations:

`Volunteer` inherit `User`

`Organization` inherit `User`

`Users` to `Events`: many to many

`Categories` to `Events`: 1 to many

`Organizations` to `Articles`: 1 to many

`Organizations` to `Events`: 1 to many

### MVC Controllers
`AccountController`

`ManagerController`

`BaseController` - all controllers inherit BaseController.Holds main properties for all controllers (Mapper, Cacher).

`HomeController` - provides the newest articles and events and cache them for 30 minutes.

`ErrorController` - provide control over error page and unauthorized page.

##### Admin Area

`AllCategoriesController` - provide CRUD operations over categories via grid (Kendo UI)

`AllVolunteersController` - provide CRUD operations over volunteer users via grid (Kendo UI)

`AllOrganizationsController` - provide CRUD operations over organization users via grid (Kendo UI)

##### Article Area

##### Event Area

### Screenshots
##### Home Page
![alt tag](http://i.imgur.com/48UfYAt.jpg)
##### Events Page
![alt tag](http://i.imgur.com/KAVzFDY.jpg)
##### Create Event Page
![alt tag](http://i.imgur.com/C0UD6Ug.jpg)
##### Admin Grid for categories
![alt tag](http://i.imgur.com/IoMCc3E.jpg)
