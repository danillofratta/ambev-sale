Steps to run app

# run docker
docker compose up --build

#run migration
dotnet ef migrations add InitialCreate
dotnet ef database update

https://localhost:5001/swagger/index.html