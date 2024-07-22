# CountRie Overview

Can be accessed via [the link](https://countrie-fsohpe7vuq-lm.a.run.app/Country).

Web app featuring a range of countries, character, and their respective dependencies that the user can view and interact with using clean interface.
User can create an account to be able to create characters or countries. Characters or countries created by a user can be edited or deleted, but they cannot do that to the ones that are not theirs.
Admin account allows for full control over all data, having the ability to do even more than a regular user can. the admin email is used: admin@example.org.

Battles can be created between characters, improving their power. A name can be provided for a battle, or innovative name generator might be used instead.
All battles of a specific character can be viewed on the respective page, as well as characters of a country, etc.

Built using clean architecture and design patterns, providing for easy development process and possible future extensions or changes.
CI / CD workflow is in use for easy integration and deployment.

# Details

## Features

- State of the art authentication system
- Role-based access to the resources
- Ownership of countries/characters
- Supports CRUD operations for all models
- Only authorized users can edit or delete respective models
- Innovative battle system
- Robust validation system, providing for both intuitive user-experience, as well as protection from bad actors

## Architecture

- Clean architecture with SQRS pattern
- Onion architecture used to make separations of concerns easier
- Dependency Inversion used for decoupling and easy extension
- Great respect to DRY, KISS, SOLID

## Technologies

- ASP.NET Core MVC
- Entity Framework Core
- Identity
- Docker
- PostgreSQL
- Google Cloud Platform
- Google/Facebook login
- Bootstrap

## CI / CD

Features separate workflows for CI (Continuous Integration) and CD (Continous Deployment).
The project is automatically built into docker container, uploaded to cloud, and deployed to run. All automatically. The integration provides for seamless developing experience and ease of use.

# Database schema

![diagram](https://github.com/user-attachments/assets/24698d31-a0e3-4256-a289-dbbf274e56b1)

# Screenshots

![image](https://github.com/user-attachments/assets/f5027b68-24aa-4458-8004-d563ab7ef868)
![image](https://github.com/user-attachments/assets/0b6448dc-c89e-47c0-967c-877f99489d65)
![image](https://github.com/user-attachments/assets/b2617984-bbdc-482a-b51f-0ac16f9f5c81)
![image](https://github.com/user-attachments/assets/9e864ae7-7c05-474c-baac-b5bcbd934d5e)
![image](https://github.com/user-attachments/assets/03d205d0-02d5-4ad5-b557-b3c15adafe3b)
