# Movie Application

Welcome to the Movie Database Application, a C#.NET 6 based project leveraging WPF for the frontend, Rabbit MQ for messaging, and a Windows Service for the backend. This application follows the Model-View-ViewModel (MVVM) pattern to separate concerns, enhance maintainability, and improve the user experience.

## Features

- **List of Movies**: View titles, genres, years, and ratings. Search functionality included with an option for autocomplete.
- **Movie Details**: Access detailed information about movies, including title, year, rating, and description.
- **Category Filtering**: Filter movies by categories using a multi-select control.
- **Robust Backend**: Utilizes Rabbit MQ for message-based communication between the frontend and backend, ensuring a responsive and scalable application.

## Technologies Used

- C#.NET 6
- Windows Presentation Foundation (WPF)
- Rabbit MQ
- Windows Services

## Application Architecture

This application is designed incrementally with a focus on read-only views initially. The architecture includes a WPF frontend application that communicates with a backend service through Rabbit MQ. The backend service runs as a Windows service, managing business logic and data access.

## Getting Started

### Prerequisites

- .NET 6 SDK
- Docker

### Setup

1.  **Run Rabbit MQ in docker**:
    ```bash
    docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management

2. **Clone the repository**:
   ```bash
   git clone https://github.com/BreakTheSilence/MovieApp

3. **Navigate to the project directory**:
   ```bash
   cd [project-directory]

4. **Publish the Windows service**:
      ***Publish the app using***
    ```bash
     dotnet publish --output "C:\custom\publish\directory"
    
5. **Create the Windows Service with PowerShell**
    ```bash
    sc.exe create "Movie Service" binpath="C:\Path\To\MovieApp.MovieBackend.exe"

6. **Build the application**:
   ```bash
   dotnet build

7. **Run the WPF Application**:
   ```bash
   dotnet run --project MovieAppWpf


## Licence

This project is licensed under the [MIT License](LICENSE).
