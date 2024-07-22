# CountRie

CountRie is a web application featuring a range of countries, characters, and their respective dependencies. Users can view and interact with data using a clean interface, create their own countries and characters, and engage in battles.

[Access CountRie](https://countrie-fsohpe7vuq-lm.a.run.app)

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Technologies](#technologies)
- [Installation and Setup](#installation-and-setup)
- [CI / CD](#ci--cd)
- [Database Schema](#database-schema)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Overview

CountRie allows users to:
- Create an account and log in
- View and interact with countries and characters
- Create, edit, and delete their own countries and characters
- Engage in battles between characters, improving their power
- View battle history and character details

Admin accounts have full control over all data. The admin account has an email of admin@example.org.

## Features

- State-of-the-art authentication system
- Role-based access to resources
- Ownership of countries/characters
- CRUD operations for all models
- Innovative battle system with name generator
- Robust validation system for user experience and security

## Architecture

- Clean architecture with CQRS pattern
- Onion architecture for separation of concerns
- Dependency Inversion for decoupling and easy extension
- Adherence to DRY, KISS, and SOLID principles

## Technologies

### Backend
- ASP.NET Core MVC
- Entity Framework Core
- Identity for authentication and authorization

### Database
- PostgreSQL

### Deployment
- Docker
- Aiven for database hosting
- Google Cloud Platform

### Frontend
- Bootstrap for responsive design

### Authentication
- Google/Facebook login integration

## Installation and Setup
Dotnet 8 SDK and runtime is needed to run the app locally, which can be downloaded at: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/CountRie.git
   ```
2. Navigate to the project directory:
   ```
   cd CountRie
   ```
3. Install dependencies:
   ```
   dotnet restore
   ```
4. Set up your database connection string in `appsettings.json`
5. Install dotnet tools:
   ```
   dotnet tool install --global dotnet-ef
   ```
6. Run database migrations:
   ```
   dotnet ef database update --project ./Data --startup-project ./Web
   ```
7. Start the application:
   ```
   dotnet run
   ```

## CI / CD

The project uses separate workflows for Continuous Integration (CI) and Continuous Deployment (CD):

- CI: Automatically builds and tests the project on each push or pull request.
- CD: Automatically builds the project into a Docker container, uploads it to the cloud, and deploys it to run.

This setup provides a seamless development experience and ease of use.

## Database Schema

![Database Diagram](https://github.com/user-attachments/assets/24698d31-a0e3-4256-a289-dbbf274e56b1)

## Screenshots

1. Home Page
   ![Home Page](https://github.com/user-attachments/assets/f5027b68-24aa-4458-8004-d563ab7ef868)

2. Country Creation
   ![Country Creation](https://github.com/user-attachments/assets/0b6448dc-c89e-47c0-967c-877f99489d65)

3. Character Details
   ![Character Details](https://github.com/user-attachments/assets/b2617984-bbdc-482a-b51f-0ac16f9f5c81)

4. Admin Editing
   ![Admin Editing](https://github.com/user-attachments/assets/9e864ae7-7c05-474c-baac-b5bcbd934d5e)

5. Battle Dashboard
   ![Battle Dashboard](https://github.com/user-attachments/assets/03d205d0-02d5-4ad5-b557-b3c15adafe3b)

## Contributing

We welcome contributions to CountRie! Please follow these steps:

1. Fork the repository
2. Create a new branch for your feature
3. Commit your changes
4. Push to your branch
5. Create a new Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Contact

For any questions or feedback, please open an issue on GitHub or contact the maintainer at riebisv@gmail.com.
