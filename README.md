# NetBoilerplate

A .NET API boilerplate with microservices base, following Clean Architecture principles.

## Features

- Clean Architecture
- Dependency Injection
- Logging and Error Handling
- Validation
- API Versioning
- Security
- Persistence with EF Core
- Messaging and External Integrations
- Observability
- Testing
- DevOps and Deployment
- Developer Experience

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Docker

### Running the Application

1. Clone the repository
2. Run `dotnet restore` to restore dependencies
3. Run `dotnet run` to start the application

### Running with Docker

1. Build the Docker image: `docker build -t netboilerplate .`
2. Run the Docker container: `docker run -p 8080:80 netboilerplate`

## API Endpoints

- GET /api/items - Get all items
- GET /api/items/{id} - Get item by ID
- POST /api/items - Create a new item
- PUT /api/items/{id} - Update an existing item
- DELETE /api/items/{id} - Delete an item

## Logging

Logs are written to the console and to a file at `logs/log.txt`.

## Testing

Tests are located in the `tests` directory. Run `dotnet test` to execute the tests.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.
