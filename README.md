## Instructions

The implementation was carried out according to the suggested model standard.

There were some questions regarding the rules, such as whether the ModifySale could also change the item data, and some other issues like this.

All the sales CRUD functionalities were implemented.

The cancellation of the sales item was implemented as a rule to recalculate the items and also the total sale.

Redus was implemented in SaleCreate with log and SaleModified, SaleCancelled, ItemCancelled Event with log.

A basic screen was created that lists sales and also records the sale.

## Instructions for running

# Run with DOCKER

# Run Backend:
* Step 1: go to ambev-sale\src\backend
* Step 2: open terminal
* Step 3: run script	
    * docker compose up --build

# Run Migration:
* Step 1: go to ambev-sale\src\backend\src\Ambev.Sale.Infrastructure
* Step 2: open terminal
* Step 3: run scripts
    * dotnet ef migrations add InitialCreate
	* dotnet ef database update
* Step 4: run Docker container Ambev.WebApi.Sale
* Step 5: Run API endpoints: access in browser 
http://localhost:5000/swagger/index.html

# Run FrontEnd:
* Step 1: go to ambev-sale\src\frontend\AppClientSale
* Step 2: open terminal
* Step 3: run script to create image
    * docker build --build-arg ENVIRONMENT=production -t app-client-sale .
* Step 4: run image app-client-sale
    * docker run -d --name app-client-sale -p 4200:80 app-client-sale
* Step 5: Run cliente http://localhost:4200/




