# UserManagementAPI

## Description

UserManagementAPI is a RESTful API developed with ASP.NET Core for user management at TechHive Solutions. This API allows creating, reading, updating, and deleting (CRUD) user records, integrating validations, error handling, token-based authentication, and logging for auditing.

## Features

- CRUD endpoints for users:
  - `GET /users` - Get all users.
  - `GET /users/{id}` - Get user by ID.
  - `POST /users` - Create a new user.
  - `PUT /users/{id}` - Update an existing user.
  - `DELETE /users/{id}` - Delete user by ID.

- Input data validation to ensure only valid data is processed.

- Custom middleware:
  - Logging of HTTP requests and responses.
  - Global error handling with consistent JSON responses.
  - Token-based authentication to protect endpoints.

