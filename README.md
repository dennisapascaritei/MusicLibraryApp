# Music Library App

This repository contains the code for the Music Library App, a web application built using ASP.NET Core with CQRS pattern and Domain-Driven Design (DDD) principles for the backend, and Angular for the frontend. The app allows users to search, manage, and interact with a collection of music albums and artists.

## Table of Contents
- [Features](#features)
- [Technologies](#technologies)
- [Architecture](#architecture)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Running the Application](#running-the-application)


## Features
- View details of artists, albums, and songs
- Navigate through the web application using search functionality
- Manage the database by adding, updating, and deleting any of the entities

## Technologies
### Backend
- ASP.NET Core
- CQRS pattern
- Domain-Driven Design (DDD)
- Entity Framework Core

### Frontend
- Angular
- TypeScript
- HTML & CSS
- Bootstrap

### Database
- SQL Server

## Architecture
The backend of the application follows the CQRS pattern and DDD principles to ensure separation of concerns and scalability. The frontend is built using Angular for a responsive and dynamic user experience.

## Getting Started
### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js and npm](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/dennisapascaritei/MusicLibraryApp.git
   cd MusicLibraryApp
   ```

2. Set up the backend:
   ```sh
   cd API
   dotnet restore
   dotnet build
   ```

3. Set up the frontend:
   ```sh
   cd ../UI
   npm install
   npm run build
   ```

## Configuration
### Backend
1. Update the `appsettings.json` file in the `API` project with your SQL Server connection string:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Your SQL Server connection string here"
     }
   }
   ```

## Running the Application
### Backend
1. Navigate to the `API` project directory and run:
   ```sh
   dotnet run --project API
   ```
2. The API will be available at https://localhost:7152.

### Frontend
1. Navigate to the `UI` project directory and run:
   ```sh
   ng serve
   ```
2. The application will be available at http://localhost:4200.

