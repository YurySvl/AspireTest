# AspireUserApp

A .NET Aspire application for managing users, demonstrating a microservices architecture with a Blazor frontend, a Minimal API backend, and a SQL Server database.

## Core Functionality

The project consists of the following components:

- **UserApp.AppHost**: The .NET Aspire orchestrator that manages the startup and configuration of all services and containers.
- **UserApp.Web**: A Blazor Interactive Server frontend that provides the user interface. It communicates with the backend API to fetch and create users.
- **UserApp.ApiService**: A Minimal API backend that handles user data operations. It uses Entity Framework Core to interact with the SQL Server database.
    - `GET /users`: Retrieves a list of all users.
    - `POST /users`: Creates a new user (capped at 100 users to prevent overload).
- **UserApp.Database**: Contains the Entity Framework Core `DbContext` and database migrations.
- **SQL Server**: A containerized SQL Server instance used for data persistence.

## Prerequisites

To run this project locally, you need the following installed:

- **[.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)**
- **[Docker Desktop](https://www.docker.com/products/docker-desktop/)** (or a compatible container runtime like Podman)

## How to Run Locally

1.  **Clone the repository**:
    ```bash
    git clone <repository-url>
    cd AspireTest
    ```

2.  **Ensure Docker is running**.

3.  **Run the AppHost project**:
    You can run the project from the command line or using an IDE like Visual Studio or VS Code.

    **Command Line:**
    Navigate to the `UserApp.AppHost` directory and run:
    ```bash
    dotnet run --project AspireUserApp/UserApp.AppHost/UserApp.AppHost.csproj
    ```
    
    Or if you are in the root:
    ```bash
    dotnet run --project AspireUserApp/UserApp.AppHost
    ```

    **Visual Studio:**
    - Open `AspireUserApp/UserApp.sln`.
    - Set `UserApp.AppHost` as the startup project.
    - Press `F5` or click "Start".

4.  **Access the Dashboard**:
    Once running, the console output will show a URL for the **Aspire Dashboard** (usually `http://localhost:18888` or similar). Open this URL in your browser to view the running services (`webfrontend`, `userapi`, `sql`, etc.) and access their endpoints.

    - Click on the endpoint for `webfrontend` to use the application.
    - Click on the endpoint for `userapi` to view the API (Swagger UI is enabled in Development).

## Project Structure

```
AspireUserApp/
├── UserApp.AppHost/       # Orchestrator project
├── UserApp.ApiService/    # Backend API service
├── UserApp.Web/           # Blazor frontend
├── UserApp.Database/      # EF Core context and migrations
├── UserApp.ServiceDefaults/ # Shared service defaults (telemetry, health checks)
└── UserApp.sln            # Solution file
```
