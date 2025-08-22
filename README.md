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

## Renaming the Application

To rename the application from `NetBoilerplate` to a new name, use the provided Bash script `Rename-NetBoilerplate.sh`. This script will rename all occurrences of `NetBoilerplate` in folder names, file names, and within the code.

### Usage

1. Ensure you have Bash installed on your system.
2. Run the script with the new application name as a parameter:
   ```bash
   bash Rename-NetBoilerplate.sh <NewName>
   ```
   Replace `<NewName>` with the desired new application name.

### Example

To rename the application to `MyApp`, run:
   ```bash
   bash Rename-NetBoilerplate.sh MyApp
   ```

This will update all instances of `NetBoilerplate` to `MyApp` throughout the project.
