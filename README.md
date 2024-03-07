
## Key topics

- Design Patterns
- Data
- API Gateway (using Ocelot)
- Microservices
- Caching


## Design Patterns

The project use Repository Pattern to abstract the access to data, providing a higher level of separation between the application's business logic and the data access logic.

In the project you will find a repository for Customer and another for the orders.

## Data persistance

All the data is persisted in a local MS Sql Database using the first database approach.
The communication with the database is managed by a DBContext and using Entity Framework.


## API Gateway

As the solution is composed by different APIs, the API Gateway architecture makes all sense. I'm using Ocelot nuget package to build the Demo.APIGateway. 
All the requests is pass through this gateway that is in charge of redirect each request to the correct service. 
All the routes is defined in the ocelot.json.

## Microservices

For now, as example, I'm using only two Web Api with different databases:
 - Customer API
 - Orders API
