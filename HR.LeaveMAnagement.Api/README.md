# HR.LeaveManagement.Api

The API project for the HR Leave Management application. This project contains the controllers for the application and serves as the main entry point for the application. It interacts with the `HR.LeaveManagement.Application` project for the business logic and with `HR.LeaveManagement.Persistence` for data persistence.

## Table of Contents
- [Controllers](#controllers)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Controllers
The API project consists of several controllers that handle different functionalities. Each controller is responsible for a specific entity in the application.

### LeaveAllocationsController
The `LeaveAllocationsController` provides endpoints for managing leave allocations. It includes the following endpoints:

- `GET /api/LeaveAllocations`: Retrieves all leave allocations.
- `GET /api/LeaveAllocations/{id}`: Retrieves a specific leave allocation by its ID.
- `POST /api/LeaveAllocations`: Creates a new leave allocation.
- `PUT /api/LeaveAllocations`: Updates an existing leave allocation

### LeaveRequestsController
The `LeaveRequestsController` provides endpoints for managing leave requests. It includes the following endpoints:

- `GET /api/LeaveRequests`: Retrieves all leave requests.
- `GET /api/LeaveRequests/{id}`: Retrieves a specific leave request by its ID.
- `POST /api/LeaveRequests`: Creates a new leave request.
- `PUT /api/LeaveRequests/{id}`: Updates an existing leave request

## Installation
To set up the API project, follow the instructions in the [root README](https://github.com/AlpTalhaYazar/HR.LeaveManagement/blob/main/README.md) of the repository.

## Usage
Once installed, you can run the API project from the command line using the `dotnet run` command. You can then use a tool like Postman to interact with the API.

## Contributing
Contributions are welcome. Please feel free to open an issue or create a pull request. For more information on contributing, refer to the [Contributing section](https://github.com/AlpTalhaYazar/HR.LeaveManagement/blob/main/README.md#contributing) in the root README

## License
For information on the license, refer to the [LICENSE file](https://github.com/AlpTalhaYazar/HR.LeaveManagement/blob/main/LICENSE) in the root of the repository
