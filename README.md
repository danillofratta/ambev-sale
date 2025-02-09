## Instructions

Implementation was carried out according to the suggested template standard. There were some questions about business rules such as whether the sale's modify endpoint could also change the items.

All sales CRUD functionalities were implemented. The sale item cancellation and get endpoints were implemented. During cancellation, the discount recalculation of the sale items and also of the total sale was implemented.

Redus was implemented in SaleCreate with log and SaleModified, SaleCancelled, ItemCancelled Event with log.

A basic screen was created that lists the sales and also registers the sale.

## Instructions for running

# RUN with DOCKER

# Run Backend:
* Step 1: go to ambev-sale\src\backend
* Step 2: open terminal
* Step 3: run script	
          docker compose up --build

# Run migration:
* Step 1: go to ambev-sale\src\backend\src\Ambev.Sale.Infrastructure
* Step 2: open terminal
* Step 3: run scripts
	  dotnet ef migrations add InitialCreate
	  dotnet ef database update
* Step 4: run Docker container Ambev.WebApi.Sale
* Step 5: Run API endpoints: access in browser 
http://localhost:5000/swagger/index.html

# Run FrontEnd:
* Step 1: go to ambev-sale\src\frontend\AppClientSale
* Step 2: open terminal
* Step 3: run script to create image
          docker build --build-arg ENVIRONMENT=production -t app-client-sale .
* Step 4: run image app-client-sale
          docker run -d --name app-client-sale -p 4200:80 app-client-sale
* Step 5: Run cliente http://localhost:4200/




