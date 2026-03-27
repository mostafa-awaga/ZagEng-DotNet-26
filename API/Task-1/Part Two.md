###### Question 1 - What is Dependency?
- Tight coupling between `OrderService` and concrete classes.
- Hard to test because dependencies cannot be mocked.
- Poor maintainability since changing implementations requires modifying `OrderService`.
- Violates the Dependency Inversion Principle.

###### Question 2 - Tight Coupling Problem
- Scenario A creates the `EmailService` directly inside `UserService`, which causes tight coupling. This makes the code harder to test, maintain, and modify.
- Scenario B uses Dependency Injection by passing `IEmailService` through the constructor. This creates loose coupling, improves testability, and allows different implementations of the email service.
- Therefore, Scenario B is the better design.

###### Question 3 - Constructor Injection
When a request is received, use the Dependency Injection container to create the required objects.
1. The framework creates `ProductController`.
2. It sees that `ProductController` depends on `ProductService`.
3. The DI container creates `ProductService`.
4. `ProductService` depends on `IRepository`.
5. Since `IRepository` is registered with `SqlRepository`, the container creates a `SqlRepository` instance.
6. Dependencies are injected through the constructor.
7. The `Add` action is executed and the product is saved using the repository.

###### Question 4 - DI Container Registration
- Transient: A new instance is created every time the service is requested, so `email1` and `email2` will be different  `AreSameInstance = false`.
- Scoped: One instance is created per HTTP request, so both variables receive the same instance `AreSameInstance = true`.
- Singleton: Only one instance is created for the entire application lifetime, so both variables reference the same object  `AreSameInstance = true`.

###### Question 5 - Multiple Registrations
- Controller A will receive MailgunEmailService because ASP.NET Core resolves the last registered implementation when a single service is requested.
- Controller B will receive 3 services because `IEnumerable<IEmailService>` injects all registered implementations of the interface.