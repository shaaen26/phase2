### Section One Illustration

For this part, I created three configuration files - appsetting.json, appsetting.Development.json, and appsetting.Production.json. The appsetting.json contains the information about the HTTP client name and address while the other two files contain the setting for the program to choose different services for the controller. In the development environment, the program will choose to use the in-memory cache to store data while in the production environment, the program will choose to use the real database to store data and for this program, I choose to use the SQLite database.



### Section Two Illustration

In program.cs file, multiple middlewares are injected into service container like swagger, database context, and so on. When we write codes related to these middlewares, we can use them by the dependency injection way which can simplify our code since we don't need to care about using which service. For a specific example, in my program, I create two services the first one is an in-memory cache to store data and the second one is to connect to the real database. These two services have the same interface and the controller only focuses on such interface-type service and doesn't care about the detailed implementation. Thus, we can easily inject different services into the controller without modifying any code in the controller.



### Section Three Illustration

As mentioned above, the controller doesn't focus on the actual implementation of the service and by using a mock library like NSubstitute we can mock such a service and inject the service into the controller to test its functionality of the controller. In this way, we don't need to care about the correctness of the service since we can define its behaviors by using some methods in the NSubstitue and what we focus on is only the correctness of controller logic. 
