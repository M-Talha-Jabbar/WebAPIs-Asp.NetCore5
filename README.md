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
- For example, if you want to return NotFound, OK, Redirect, etc. data from your action method then you need to use IActionResult as the return type from your action method.

### 3. ActionResult&lt;T&gt; (ActionResult with Type)
- It is the combination of ActionResult and Specific type.
