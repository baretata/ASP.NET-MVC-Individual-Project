# Recruit Yourself Application

The application is for people who want to volunteer in different spheres where help is needed.They can join events or organizator foundations which raise charity or organize charity events.

Helping others is essential in our nature and as Gandhi said "The best way to find yourself is to lose yourself in service of others".

### Types of users

1.Admin: has access to CRUD operations over categories, volunteers and organizations

2.Registered users: They can create events or join events.

3.Visitors /without login/: they can only read events and articles information.


### Database

##### Models:

User

Volunteer (inherit User) 

Organization (inherit User)

Category (for events)

Event

Article


##### Relations:

Volunteer inherit User

Organization inherit User

Users to Events: many to many

Categories to Events: 1 to many

Organizations to Articles: 1 to many

Organizations to Events: 1 to many
