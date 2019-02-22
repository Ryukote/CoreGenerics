# CoreGenerics
Core generics for: repository pattern and api controllers for CRUD operations

# What is new (version 1.0.1)
I had minor issues regarding DbContext and methods inside the controller. There was 2 controllers with HttpGet method which cause a
conflict. I have decided to move all CRUDController methods to be Actions, so each method can be accessed via "api/[controller]/[action]"

# How does it work?
It is very simple. This library is nothing WOW, cause you are doing those things very often, like: creating repository for your models/DTO
and exposing those repositories inside your controllers, so you can handle basic CRUD operations.

Since this process is schematic and you are doing the same thing in every Web API project, it can become boring. This is why I have
decided to place all that under one Nuget package which you can use and save your time.

# Only CRUD controller and repository pattern?
Yes for now. I have just started with this project and I would be happy if you have some great ideas for what could be in this library.
If you have some great idea, feel free to create issue.
There is no limitation on what domain I will cover, so if you have an idea which is not for web type of applications, you can give the idea
for that as well.

# How do I use this library?
It is very simple. Here is a small code sample that can be a reference for your implementations:

```cs
public class ValuesController : CRUDController<Test, int>
{
   public ValuesController()
   {
       base.OptionsBuilder = new DbContextOptionsBuilder<TestDbContext>();
       base.OptionsBuilder.UseInMemoryDatabase("TestDb");
   }
}
```
And this is the list of URL-s that you get out of the box with inheriting CRUDController class:
  - api/[controller]/add (POST)
  - api/[controller]/delete (DELETE)
  - api/[controller]/getall (GET)
  - api/[controller]/getby (GET)
  - api/[controller]/update (PUT)

# You want to support this library?
If you think this library is great idea and you want to support this, you can help with issues, pull requests and small donations.
You can do donations with:
  - BTC on: 322SRqTS3EeKGaVFuo6xsw8e5Xji4QcJR6
  - ETH on: 0xc06d8766061e0644fb780f38abb1226ba289664c
  - XRP on: rE1sdh25BJQ3qFwngiTBwaq3zPGGYcrjp1 with destination tag: 59558
