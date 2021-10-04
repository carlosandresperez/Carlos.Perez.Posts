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