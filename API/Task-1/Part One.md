###### 1. What are the fundamental differences between the original ASP.NET and ASP.NET Core?
   ASP.NET Core 
   - is a modern, fast, and open-source version 
   - that runs on (Windows, Linux, macOS)
   - and it fundamentally supports Dependency Injection.
     
   ASP.NET
   - is the older version.
   - runs only on the Windows operating system.
   - does not have built-in Dependency Injection.
     
###### 2. What does it mean for an API to be "Stateless"?
   - Stateless API means the server does not store any information about your previous requests.
   - Every request you send must be independent and include all the data the server needs to execute it.

###### 3. Break down the anatomy of an HTTP Request URL?
- Protocol:  `https` 
- Domain: `example.com` 
- Port: `5001` 
- Path: `/api/products/42`
- Query String: `?color=red&sort=asc`

###### 4. What are the primary HTTP Methods (Verbs) and their standard uses?
 - GET — Retrieve data
 - POST — Create
 - PUT — Update
 - DELETE — Delete a resource
 - PATCH — Partially update a resource

###### 5. What is the role of Program.cs in an ASP.NET Core application?
- Build the Host: It configures the Web Server (such as Kestrel) and defines the fundamental settings for the project.
- Configuring Services and Middleware: In this part, you register the Services you will use (like Database context or Auth) within the 
- Builder section and define the order of the Middleware (like Routing or Static Files) that the request passes through.

###### 6. Why is Swagger/OpenAPI typically enabled only in the "Development" environment?
- Swagger displays a complete map of all your API endpoints. In Development this is very useful for testing. 
- But in Production it's a security risk because anyone can see your entire API and use it to attack it.

###### 7. What is the core concept of "Dependency Injection" (DI)?
- Instead of a class creating the tools it needs by itself, those tools are provided to it from outside.
- A DI Container takes responsibility for creating all the objects and distributing them.

###### 8. Explain the three Service Lifetimes in ASP.NET Core DI?
- Transient
- Scoped
- Singleton

###### 9. Why is it a "Best Practice" to register services against an Interface rather than a concrete Class?
- Because if you want to change the implementation, you only change one line in one place without touching any other class.
- It also makes testing easier since you can inject a fake implementation instead of the real one.

###### 10. What are the "Launch Profiles" found in launchSettings.json ?
- These are settings that define how the app runs during Development.
- Each profile specifies which port to run on, what the environment is (Development / Production), and whether to open a browser automatically. 
- You can have more than one profile .
- for example, one for HTTP and one for HTTPS.

###### 11. How does JSON facilitate data exchange in APIs?
 - is a simple and lightweight way to write data that any programming language can read and write.
