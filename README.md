# Console To Web API Application
Building a Web API Project from Scratch (Console app to Web API app) - ASP.NET Core 5.0

- Each .Net Core app is by default a console app.
- Will not use default ASP.NET Core Web API Template. Instead will use ASP.NET Core Console App and by adding some services and making some changes will convert the Console app into Web API project.

## Steps
### 1. Update the csproj file.
Reference: https://youtu.be/UGCItQXSeD0

### 2. Add a Default Web Host Builder
- Host Builder is an object and it is used to add some features in the application. <br/><br/>
References: 
  https://youtu.be/7WKV9Sqf_VE
  https://youtu.be/Uk8NxQmAbd8
  
### 3. Setup the Startup Class (Configure and ConfigureServices Methods)
Reference: https://youtu.be/lfsrZ_3BcnM

### 4. Setup the default route to access a resource
Reference: https://youtu.be/QLnO-B_lvJU

### 5. Inject Web API services using AddControllers method
- In ASP.NET Core we can create multiple type of web applications like MVC application, Razor application and Web API application. For each application type we have some set of bundles, we called them services. So now we will inject the Web API service. <br/><br/>
Reference: https://youtu.be/nuFITSg28ng

Till here we have changed our Console app to Empty Web API Template we get by default.


# Web API Application

## Controller Class
- A controller class in Web API has a "Controller" suffix.
- The controller class must be inherited from "ControllerBase" (The ControllerBase class provides many methods and properties to handle the HTTP request).
- Use "ApiController" attribute on the controller.
- Use attribute routing.

### ApiContrroller attribute
- Attribute routing requirement.
- Handle the client error i.e. 400 status code.
- Multipart/form-data request inference.
- Bind the incoming data with the parameters using some more attributes.

## Middleware
- Middleware is a piece of code that is used in HTTP Request Pipeline.
- Middleware Examples: Routing, Authentication, Adding Exception Page, etc.

### Methods in Middleware
#### 1. Run()  
- Is used to complete the middleware execution.
#### 2. Use() 
- Is used to insert a new middleware in the pipeline.
#### 3. Next()
- Is used to pass the execution to the next middleware.
#### 4. Map()
- Is used to map the middleware to a specific URL.

![3](https://user-images.githubusercontent.com/76180043/176383323-73f86f3c-fae3-4221-93d8-a90c1ca31a21.PNG)

![1](https://user-images.githubusercontent.com/76180043/176383547-cec2aae5-29d5-4d7c-84f1-84d0c91de58b.PNG) 

![2](https://user-images.githubusercontent.com/76180043/176383579-035a513e-2821-4b25-8926-d97f1b3577c5.PNG)

### Custom Middleware
- The custom middleware class must be inherited from "IMiddleware".

## Routing
- Routing is the process of mapping the incoming http request (URL) to a particular resource (the action method).

### Enable Routing in ASP.NET Core Apps
- We can enable by inserting two middlewares in the HTTP Pipeline:

#### 1. UseRouting()
- Will only enable routing, will not map any URL to any resource.
#### 2. UseEndpoint()
 - By using this middleware we can map our resource.
 
 ### Ways of Routing
#### 1. Conventional Routing
#### 2. Attribute Routing
- Widely used.

## Best Practices for RESTful APIs

![Capture](https://user-images.githubusercontent.com/76180043/176834132-609a5bd7-a58f-4ddb-99fd-164afbac5bc4.PNG)

![2](https://user-images.githubusercontent.com/76180043/176834158-45b14c6e-ddf5-485e-a3e4-c7a5d7d1dd77.PNG)

![3](https://user-images.githubusercontent.com/76180043/176834170-a7bb7a58-0a27-490f-a7d9-8319a7289b2b.PNG)

![4](https://user-images.githubusercontent.com/76180043/176834185-c8e06db8-5bc0-4ff5-8feb-3f9a55786e2a.PNG)

## Action Method Return Types

### 1. Specific Type
- Returns primitive and complex types.

### 2. IActionResult
- The IActionResult return type is appropriate when multiple ActionResult return types are possible in an action. The ActionResult types represent various HTTP status codes.
- For example, if you want to return OK(200), Created(201), Accepted(202), BadRequest(400), NotFound(404), Redirect, etc. data from your action method then you need to use IActionResult as the return type from your action method.

### 3. ActionResult&lt;T&gt; (ActionResult with Type)
- It is the combination of ActionResult and Specific type.

## Model Binding
- The process of binding the HTTP Request data to the parameters of application Controllers and Properties is known as Model Binding. (Note: Exact same name required for mapping)

![Capture](https://user-images.githubusercontent.com/76180043/176880724-811ac9c7-6251-4395-b079-f922045f698f.PNG)

### Default way of Data Binding
- <b>By default the primitive types parameter in action method will get bind with URL data.</b>
- <b>By default the complex type parameter in action method will get bind with the body of request.</b> <br /><br />
Reference: https://youtu.be/gPoO42sgCyc

### Built-in Attributes for Model Binding
All built-in attributes <b>works on both primitive types (int, string, etc) and complex data objects.</b>

#### 1. [BindProperty] & [BindProperties]
- Used to bind the incoming form-data to the public properties of the controller.
- By default they does not work with HTTPGet Request. To enable this we have to set "SupportGets" property of these BindProperty and BindProperties Attributes to true.

The only difference between these two is BindProperty is applied on each target property individually while BindProperties is applied on the Controller level.

#### 2. [FromQuery]
- Used to bind data available in query string to the parameters in action method.
- The action method parameter with [FromQuery] attribute will get bind with the data in query string of the url only, ignoring all other places of data available in HTTP request (i.e. route parameter, body and headers).

#### 3. [FromRoute]
- Used to bind data available in route to the parameters in action method.
- The action method parameter with [FromRoute] attribute will get bind with the data in the route(url) only, ignoring all other places of data available in HTTP request (i.e. query string, body and headers).

#### 4. [FromBody]
- Used to bind data (Content-Type: application/json) available in body of the request to the parameters in action method.
- The action method parameter with [FromBody] attribute will get bind with the data in body of the request only, ignoring all other places of data available in HTTP request (i.e. route parameter, query string, body(form-data) and headers).

#### 5. [FromForm]
- Used to bind the form-data (Content-Type: application/x-www-form-urlencoded) available in body of the request to the parameters in action method ONLY.
- The action method parameter with [FromForm] attribute will get bind with the form-data in body of the request only, ignoring all other places of data available in HTTP request (i.e. route parameter, query string, body(json-data) and headers).

![Capture](https://user-images.githubusercontent.com/76180043/177051184-fe5f4373-43a8-4617-8b00-c9c610f19d3b.PNG)

#### 6. [FromHeader]
- Used to bind the data available in headers to the parameters in action method.
- The action method parameter with [FromHeader] attribute will get bind with the data in the headers only, ignoring all other places of data available in HTTP request (i.e. router paramater, query string, and body).

### Custom Model Binder
- The custom model binder class must be inherited from "IModelBinder".

## Dependency Injection (DI)
![1](https://user-images.githubusercontent.com/76180043/177111497-2649006e-947e-4728-a4a6-67d30a01484f.PNG)

### Working with Services without using DI
![2](https://user-images.githubusercontent.com/76180043/177111544-f9d2f1ac-12e6-476e-bec1-6db639b1d29e.PNG)
In this normal way, the HomeController is tightly couple with the EmailSender service. <br /><br />
Reference: https://youtu.be/pCzrw2CPA4g

### Working with Services using DI
![2](https://user-images.githubusercontent.com/76180043/177112132-68fbcd1e-93dd-46ea-8cc0-48db8888bf76.PNG)
Here instead of using instances of the services (RepositoryA, ...) directly in the controller we will use the interfaces of the services in the controller.

- The main concept behind Dependency Injection (DI) is to implement IOC (Inversion of Control).
- IOC means to have loosely coupling in the code.
- By creating instances using DI it is very easy to do Unit Testing.

Reference: https://youtu.be/ZEo6R8X4P4o

### Configuring DI
- Asp.Net Core framework provides the built-in support for DI. 
- Dependencies(services) are registered in containers, and the container in asp.net core is IServiceCollection and then we are free to use these services anywhere in the application.
- The IServiceCollection is available as a parameter in Startup.ConfigureServices method.

### LifeTime of Services in DI
#### 1. Singleton
- Singleton services can be registered using AddSingleton<> method.
- There will be only one instance of the Singleton service throughout the application.

#### 2. Scoped
- Scoped services can be registered using AddScoped<> method.
- A new instance of the service will be created for new HTTP request.

#### 3. Transient
- Transient services can be registered using AddTransient<> method.
- A new instance of the service will be created every-time it is requested. For example, lets say CotrollerA is using a Transient service S 3 times in same HTTP request, then there will be 3 separate instances of this S service.

### TryAddSingleton, TryAddScoped, TryAddTransient methods 
Reference: https://youtu.be/PA9rrjWCl-U

### Resolve Dependency(Service) directly in the Action Method rather than in Constructor Function (b/c we need that service only in that particular action method)
- [FromServices] attribute will be used in the action method and the service will only be available for that particular action method.
Reference: https://youtu.be/SJlkw2zvqYo

## Entity Framework Core
- Is an ORM(Object-Relational Mapper) framework and works on the object-oriented perspective. This means all the tables are converted into C# classes and the corresponding columns are converted as the properties of classes.
- It is an enhancement to ADO.NET that gives developers an automated mechanism for accessing & storing the data in the database.
![Capture](https://user-images.githubusercontent.com/76180043/180143674-b097c4dc-e904-4de8-a6ec-d8f0d2c8f387.PNG)

### Install EF Core
Reference: https://youtu.be/cNmh5IvaF4o

### Setup the DbContext Class & Database Connection String
- The context class is used to query or save data to the database. It is also used to configure domain classes, database related mappings, change tracking settings, caching, transaction etc.
- DbContext is a combination of the Unit Of Work and Repository patterns.
- DbContext in EF Core allows us to perform following tasks:
  1. Manage Database Connection
  2. Configure model & relationship
  3. Querying database
  4. Saving data to database
  5. Configure change tracking
  6. Caching
  7. Transaction Management <br />
Reference: https://youtu.be/DpW63L06SPw

### Read Connection String from appsettings.json file
Reference: https://youtu.be/Aw3IC63_UJw

### Generate SQL Server database using Entity Framework Core migrations (i.e. Code-first Approach)
- <b>add-migration &lt;name&gt;</b> (creating a new migration file after making some changes in code that is related to the database)
- <b>update-database</b> (updating the database with the latest migration file)
Now, whenever we add or update domain(entity) classes or configurations, we need to sync the database with the model using add-migration and update-database commands.

### Working Approaches
#### 1. Code first
#### 2. Database first <br />
Note: EF Core mainly targets the code-first approach and provides little support for the database-first approach.
Reference: https://www.entityframeworktutorial.net/choosing-development-approach-with-entity-framework.aspx

### How EF Works
![Capture](https://user-images.githubusercontent.com/76180043/180206572-1ade5336-1d11-4911-bb35-aa5599c743c6.PNG)

### Entity in EF
- An entity in Entity Framework is a class that maps to a database table. This class must be included as a DbSet<TEntity> type property in the DbContext class.
- An Entity can include two types of properties: 
#### 1. Scalar Property
#### 2. Navigation Property
- Navigation Property has further two more types: 
#### 1. Reference Navigation 
#### 2. Collection Navigation <br />
Reference: https://www.entityframeworktutorial.net/basics/entity-in-entityframework.aspx

### Persistence in EF
Reference: https://www.entityframeworktutorial.net/EntityFramework4.3/persistence-in-entity-framework.aspx

### Default Conventions in EF
Reference: https://www.entityframeworktutorial.net/efcore/conventions-in-ef-core.aspx <br />
  
### Configurations in EF
- There are two ways to configure domain(entity) classes if we want to customize the entity to table mapping and do not want to follow default conventions:
#### 1. By using Data Annotation Attributes <br />
- Data Annotations attributes are .NET attributes which can be applied on an entity class or properties to override default conventions.
#### 2. By using Fluent API <br />
 
Note: Data annotations only give you a subset of configuration options. Fluent API provides a full set of configuration options available in Code-First. <br />
Note: Fluent API configurations have higher precedence than data annotation attributes.
  
### Querying in EF Core
- Entity framework supports three types of queries:
#### 1. LINQ-to-Entities
- LINQ-to-Entities queries operate on the entity set (DbSet type properties) to access the data from the underlying database.
- The DbSet class is derived from **IQuerayable** so thats why we can use LINQ for querying against DbSet.
- You can either use the LINQ **method syntax** or **query syntax** when querying with EDM.
![Capture](https://user-images.githubusercontent.com/76180043/182031161-fd6f19cc-7f4b-425f-a2b7-3958361f4c56.PNG)

#### 2. Entity SQL
#### 3. Native SQL
  
## Important!

![Capture](https://user-images.githubusercontent.com/76180043/177321152-c163051e-5dda-4a0a-a82a-1dcea0f9c825.PNG)

## HTTP PATCH method in ASP.NET Core Web API
- Use Microsoft.AspNetCore.JsonPatch Package in combination with HTTP PATCH method to partially updates data in a standard compliant way. <br />
Reference: https://jsonpatch.com/

![Capture](https://user-images.githubusercontent.com/76180043/177804339-ab9b1ded-84f6-4832-9671-9c5000752b39.PNG)

## Identity Core
- Identity Core has everything that is required to work with the authentication and authorization including:
  1. Signup, Login, Change Password, Forgot Password
  2. Multi factor authentication
  3. Login with third party app like Google, Facebook, Microsoft, etc
- Along with these features the Identity Core works with Entity Framework Core. It will provide you all the tables that are required to work with authentication and authorization.

## 3-Tier Architecture

![Capture](https://user-images.githubusercontent.com/76180043/180648197-c84129f2-acdb-4d8f-adb1-64417115a13e.PNG)

These layers are implemented as separate projects.
