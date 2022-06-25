# AssignementTask
# Working Flow
Change ConnectionString in appseeting.json
run db Maigrator
First Add Customer.
Add Order Against Customer from Customer Page.
Order Is Confirm,Dispatch,Receive from Order Page.

# Coding Techniques
# Application Service
Define an interface for each application service in the application contracts package.
Interface inherit from the IApplicationService interface
Use the AppService postfix for the interface name 
Create DTOs (Data Transfer Objects) for inputs and outputs of the service
Not get/return entities for the service methods
# Domain Layer
Define repository interfaces in the domain layer
Inherit the repository interface from the IRepository<TEntity, TKey>
Define all repository methods as asynchronous
Define manager for each entity deriving from the DomainService base class
Set or update value of entity object using manager.
