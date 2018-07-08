# Onion Architecture
Onion Architecture example in .NET Core

See: https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/

_Onion Architecture_ was mentioned by Jeffry Palermo back in 2008 in a blog posts. The architecture is intended to address the challenges faced with traditional architectures and the common problems like coupling and separation of concerns.

Domain Layer is at the core of the solution. This layer holds all the entities.

Next Layer is the Repository Interfaces to the Domain entities.  It controls access to the entities using a collection-like interface.

This is following by the Service Interface layer, which contains the business rules and interacts with the Repositories and Entities.

