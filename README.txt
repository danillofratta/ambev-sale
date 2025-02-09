Steps to run app

# run Docker

# Step 1: go to ambev-sale\src\backend
# Step 2: open terminal
# Step 3: run script
docker compose up --build

#run migration
# Step 1: go to ambev-sale\src\backend\src\Ambev.Sale.Infrastructure
# Step 2: open terminal
# Step 3: run scripts
dotnet ef migrations add InitialCreate
dotnet ef database update

#Run API endpoints: acess in browser 
https://localhost:5001/swagger/index.html