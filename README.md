# CoreGenerics
Core generics for: repository pattern and api controllers for CRUD operations

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
It is very simple. You can use this library as a Nuget package from: https://www.nuget.org/packages/CoreGenerics/ 
Here is a small code sample that can be a reference for your implementations:

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
  
## Supporting repository 

You can support this repository by contributing on it or by sponsoring it.
