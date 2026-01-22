## 1. Architecture Style.

Vertical Slice Architecture— Organizes code into feature folders, each feature encapsulated in a single '.cs' file.
	* UI
	* Application
	* Domain
	* Infrastructure

## 2. Project Description.

CQRS Pattern: Command Query Responsibility Segregation, is a design pattern that separates operations into queries (read) and commands (write) operations for a data store.
In this project, we implement the CQRS pattern to optimize performance, scalability, and security by using different models for reading and writing data.	

Mediator Pattern: Facilitates object interaction through a 'mediator', reducing direct dependencies and simplifying communications.

DI: Core .NET Feature to allow inject dependencies.

Minimal API & Routing: Simplify endpoint definitions, lightweight syntax for routing and handling HTTP requests.

ORM Pattern: Object-Relation Mapping abstracts DB interactions, work with DB objects using high-level coding.

TODO: Mention file structure in which those patterns are implemented.

## 3. Nuget libraries implemented.

- MediatR for CQRS: Implements the Mediator pattern for in-process messaging.
- Carter for API endpoints: Routing and handling HTTP requests, easier to define API endpoints.
- Marten for PostgreSQL interaction: PSQL as Document DB, leverages PostgreSQL JSON capabilities for storing, querying and managing documents.
- Mapster for Object Mapping: Fast, configurable object mapper that simplifies task.
- FluentValidation for Input Validation: Building strongly-typed validation rules, ensure inputs are correct before processed.

## 4. Folder Structure.

1. Project organized into Model, Features, Data and Abstractions.
2. Features like CreateProduct and GetProduct have dedicated handlers and endpoint definitions.
3. Feature folder will be Products.
4. Data folder and Context obejcts manages DB interaction.