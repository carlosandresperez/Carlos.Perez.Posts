# Posts
The purpose of this application is to display a list of 100 posts organized in 10 columns and 10 rows.

## Configuration

```
{
  "JsonPlaceHolderAPI": {
    "Url": "https://jsonplaceholder.typicode.com"
  }
}
```
 
The consumed API belongs to JSONPlaceHolder and is part of an API with test data.
See [JSONPlaceHolder documentation](https://jsonplaceholder.typicode.com/)

## How to run
- Open the solution (File Posts.Zivver.CarlosPerez.sln).
- Make sure Posts.WPF is defined as the startup project.
- Press F5 button or click in the start icon.

## Application architecture

The application is based on MVVM principles and is separated into three projects named below:
- Posts.WPF
- Posts.Domain
- Posts.JsonPlaceHolderAPI

### Posts.WPF

The Posts.WPF project corresponds to the frontend of the application, in it are the files that are part of the graphical interface of the application, and additionally is the configuration file appsettings where the endpoint is specified, the structure of the project is as follows:

- appsettings.json: this configuration file was created to store the url of the api to be consumed, it was done this way so that when it is required to point to a test environment (production, testing, development, etc) it would be much easier and it is not necessary to modify the code and deploy the application again.
- App.xaml.cs: In this file the HostBuilder was specified for the whole dependency injection issue.
- HostBuilders: In the HostBuilders you will find all the classes for the registration of the services and the application helpers.
- Commands: The commands folder contains the commands of the application, a command base object was created to be reused in the implementation of the different commands.

### Posts.JsonPlaceHolderAPI

A project was created for the API wrapper as this allows us to encapsulate its functionality, additionally an interface is used for the service and in this way if in the future it is necessary to change the logic of the service, the components that depend on it will not be affected.

### Posts.Domain

A Domain project was created to store in it the models to be used in the application, so that they can be reused in the different layers of the application and mitigate redundant dependencies.

### Test questions

#### 1 In C# there are several ways to make code run in multiple threads. To make things easier, the await keyword was introduced; what does this do?
It is a modifier that is specified to the methods where it is indicated that this method will have tasks that are executed asynchronously, already inside the method, the await modifier is used to execute each subtask asynchronously.

#### 2 If you make http requests to a remote API directly from a UI component, the UI will freeze for a while, how can you use await to avoid this and how does this work?
I would first organize a service, and make sure that the methods to be used are all asynchronous.

#### 3 Imagine that you have to process a large unsorted CSV file with two columns: productId (int) and availableIn (ISO2 String, e.g. "US", "NL"). The goal is to group the file sorted by productId together with a list where the product is available. Example: 1, "DE" 2, "NL" 1, "US" 3, "US" Becomes: 1 -> ["DE", "US"] 2 -> ["NL"]

##### a. How would you do this using LINQ syntax (write a short example)?
My example in linq would look like this
```
var result = data.GroupBy(p => p.ProductId).Select(p => new { productId = p.Key, availability = p.Select(c => c.availableIn).ToList() }).ToList();
```
##### b. The program crashes with an OutOfMemoryError after processing approx 80%. What would you do to succeed?
If it is a linq that goes to the database as in entity framework, I would make sure to use as little as possible the .ToList(), since every time it is executed it goes to the database, I would prefer to fetch the data from the database and then organize it, additionally I would use the database profiler and verify that the query on the server is optimized.
I would try to optimize the linq to improve the memory usage, decrease the boxing that is not necessary and avoid making concatenations.

#### In C# there is an interface IDisposable.
##### Give an example of where and why to implement this interface

I use the IDisposable interface to free objects from memory that are not managed as database connections.

##### We can use disposable objects in a using block. What is the purpose of doing this?
In this way a scope is defined for an object, for example when a "using" is used to make calls to the database, I am delimiting the existence of that variable in that scope, once the execution of that part of the code is finished, the resources are released.

#### When a user logs in on our API, a JWT token is issued and our Outlook plugin uses this token for every request for authentication. Here's an example of such a token:The token is generally used for authentication purposes, which can be from one user or from one service to another, it is safe to use tokens between services because they are usually part of the backend and are not necessarily public services.
For session tokens it can become unsafe because an attacker could take the token. In the projects that I have worked on the security modules we have added additional validations to invalidate the tokens if necessary, or when the user logs in again, this is combined in the expiration time of the token.






