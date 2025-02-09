RUN in DOCKER

Steps to run BACKEND

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
# Step 4: run Docker container Ambev.WebApi.Sale

#Step 5: Run API endpoints: access in browser 
http://localhost:5000/swagger/index.html


Steps to run FRONTEND

#run Docker
# Step 1: go to ambev-sale\src\frontend\AppClientSale
# Step 2: open terminal
# Step 3: run script to create image
docker build --build-arg ENVIRONMENT=production -t app-client-sale .
# Step 3: run image app-client-sale
docker run -d --name app-client-sale -p 4200:80 app-client-sale

#Run client
http://localhost:4200/l
