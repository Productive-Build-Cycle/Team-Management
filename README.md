# Team Management

Clean Architecture–based Team Management System with a strong focus on Domain purity, testability, and clear separation of concerns.

---

## Architecture Overview
The project follows Clean Architecture and DDD-inspired design:

- Domain – Core business logic and invariants  
- Application – Use cases and orchestration  
- Infrastructure – Persistence and external services  
- API – RESTful entry point  

---

## Domain Layer
The Domain layer is fully isolated and contains:

- Team, TeamMember entities
- Business rules & invariants

### Key Domain Rules
- A team cannot have more than one leader  
- Team name cannot be empty  
- Removing a non-existing member is invalid  
- Archived teams cannot be archived again  

---

## Application Layer
The Application layer contains the use cases of the system and acts as the orchestrator between the API and the Domain.

### Responsibilities:
- Execute application workflows
- Coordinate Domain entities and enforce application-level rules
- Define interfaces required by the Domain (e.g. repositories)
- Manage transactions and consistency boundaries (when applicable)

### Key characteristics:
- Has no dependency on Infrastructure implementations
- Does not contain business rules (they belong to Domain)

---

## Infrastructure Layer
Contains technical implementations:

- Entity Framework Core
- Repository implementations
- Database context

❗ The Domain layer has no dependency on Infrastructure.

---

## API Layer
Exposes REST endpoints and delegates requests to the Application layer.

---

## Tech Stack
- .NET / C#
- Entity Framework Core
- xUnit / NUnit
- Git & GitHub

---

## Domain Unit Tests
Domain behavior is validated using unit tests, including:

- CreateTeam_WithEmptyName_Fails
- AddMember_WhenMemberNotExist_AddSuccessfully
- RemoveMember_WhenMemberDoesNotExist_Fails
- ArchiveTeam_WhenAlreadyArchived_Fails
- Team_ShouldNeverHaveMoreThanOneLeader
