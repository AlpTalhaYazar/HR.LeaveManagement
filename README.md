# HR Leave Management

This repository contains the source code for the HR Leave Management application. The application is divided into several projects, each with its own specific role.

## Projects

### HR.LeaveManagement.Api

This is the API project of the application. It contains controllers, configuration files, and the main program entry point.

### HR.LeaveManagement.Application

The Application project holds the business logic of the application. It contains contracts, DTOs, exceptions, feature definitions, models, profiles, responses, and service registrations.

### HR.LeaveManagement.Domain

The Domain project is where the domain entities and common domain logic reside. It currently includes Leave Allocation, Leave Request, and Leave Type entities.

### HR.LeaveManagement.Infrastructure

The Infrastructure project is responsible for external concerns like emailing. It also contains infrastructure service registrations.

### HR.LeaveManagement.Persistence

The Persistence project manages data persistence concerns. It includes configurations, database context, entity migrations, repositories, and persistence service registrations.

## Getting Started

To get started with this project:

1. Clone the repository
2. Navigate into the HR.LeaveManagement.Api project
3. Run the application

## Contributing

Contributions are welcome. Please feel free to open an issue or create a pull request.

## License

Please see the [LICENSE](./LICENSE) file for details.
