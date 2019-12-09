# .NET Application Evolent Exercise

This is the project to demonstarate storage of contact information

Frameworks Used :
ASP.Net MVC
AngularJS
MSSQL

Deployment Environment:
Azure SQL
Azure Virtual Machine

Demo Link : http://52.142.39.169/views/Index.html

This application implements n-tier architecture with following layers

API : Rest API's implemented for operations on contact information 
<br><br>DBMapper : Communicates with database using Entity Framework. Code-first approch is implemented with Fluent API for mapping the data tables
           Singleton pattern is implemented for instance connectivity to database
<br><br>Logging : Loggin library to log exceptions, entity type error fetching to identify and log errors on table property level
<br><br>Portal : Application portal implemented in AngularJS. Communicates with API to perform operations. Bootstrap utlized for table and form design
<br><br>Portal Library : Helper library consisting of operations performed on contact information. This layer will hold business logic for application. API's rely on this layer to get information

Execution of Application :

1. Database script is uploaded to generate database
2. Web.config is the only place where connection string for database is to be updated.
3. Index.html is the listing page of all the contacts in system. Add button is provided to add new contact information. Each row is provided with edit button for editing that specific record.
4. AddUpdate.html is the page to perform add and update on contact information. 

<br><br>Note : Demo link is hosted on Azure Virtual Machine. These resources are created using free subscription of Azure, hence link will not work after certain days



