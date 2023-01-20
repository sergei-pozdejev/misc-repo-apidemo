# Product API demo
Product api demo is NET 6 API project that provides user 
with endpoints to Add, Update, Delete, Get and search Products.
Product has Name, Code and ExpirationDate, of which Code should be unique.

## Requirements
* NET6 Runtime
* Sql Server DB

## Structure
### ProductApiDemo
Main Application project
### ProductApiDemo.Data
Data layer project with migrations
### ProductApiDemo.Test
XUnit tests

## Endpoints
* GET		/Product/{id:guid}
* POST		/Product/{id:guid}
* PUT		/Product
* DELETE	/Product/{id:guid}
* GET		/Product/Search?page={pagenumber:int}&term={searchterm:string}&showExpired={showExpired:bool}

Descriptions are available in Swagger
* /swagger/index.html

## Notes
* appsettings.json Connection string should be set corresponding to DB location
* Authentification was skipped for now
* Unit tests not covering all cases
* Solution structre missing Core/Infrastructure project since it is very simple solution