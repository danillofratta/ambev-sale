# Imagem base para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Imagem de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["backend/src/Ambev.Sale.WebApi/Ambev.Sale.WebApi.csproj", "Ambev.Sale.WebApi/"]
COPY ["backend/src/Ambev.Sale.Core.Domain/Ambev.Sale.Core.Domain.csproj", "Ambev.Sale.Core.Domain/"]
COPY ["backend/src/Ambev.Sale.Common/Ambev.Sale.Common.csproj", "Ambev.Sale.Common/"]
COPY ["backend/src/Ambev.Sale.Core.Application/Ambev.Sale.Core.Application.csproj", "Ambev.Sale.Core.Application/"]
COPY ["backend/src/Ambev.Sale.Infrastructure/Ambev.Sale.Infrastructure.csproj", "Ambev.Sale.Infrastructure/"]
	       
RUN dotnet restore "Ambev.Sale.WebApi/Ambev.Sale.WebApi.csproj"

#COPY . .
COPY backend/src/Ambev.Sale.WebApi/ Ambev.Sale.WebApi/
COPY backend/src/Ambev.Sale.Common/ Ambev.Sale.Common/
COPY backend/src/Ambev.Sale.Core.Application/ Ambev.Sale.Core.Application/
COPY backend/src/Ambev.Sale.Core.Domain/ Ambev.Sale.Core.Domain/
COPY backend/src/Ambev.Sale.Infrastructure/ Ambev.Sale.Infrastructure/

WORKDIR "/src/Ambev.Sale.WebApi"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ambev.Sale.WebApi.dll"]