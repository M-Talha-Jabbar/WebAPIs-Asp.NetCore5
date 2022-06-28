# ConsoleToWebAPI
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
