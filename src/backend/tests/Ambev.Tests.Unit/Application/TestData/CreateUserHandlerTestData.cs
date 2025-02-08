using Ambev.Sale.Core.Application.Sales.Create;
using Ambev.Sale.Core.Application.Sales.Dto;
using Ambev.Sale.Core.Domain.Enum;
using Bogus;

namespace Ambev.Tests.Unit.Data;

public static class CreateSaleHandlerTestData
{

    private static readonly Faker<CreateSaleItemDto> SaleItemFaker = new Faker<CreateSaleItemDto>()
        .CustomInstantiator(f => new CreateSaleItemDto(
            f.Random.Guid().ToString(), // ProductId
            f.Commerce.ProductName(), // ProductName
            f.Random.Int(1, 5), // Quantity
            f.Random.Decimal(1, 100), // UnitPrice
            f.Random.Decimal(0, 20), // Discount
            f.Random.Decimal(10, 500), // TotalPrice
            SaleStatus.NotCancelled // Default value for Status
        ));

    private static readonly Faker<CreateSaleCommand> CreateSaleCommandFaker = new Faker<CreateSaleCommand>()
    .RuleFor(u => u.CustomerId, f => f.Random.Guid().ToString())
    .RuleFor(u => u.CustomerName, f => f.Person.UserName)
    .RuleFor(u => u.BranchId, f => f.Random.Guid().ToString())
    .RuleFor(u => u.BranchName, f => f.Person.UserName)
    .RuleFor(u => u.SaleItems, f => SaleItemFaker.Generate(f.Random.Int(1, 5))); // genera 1 / 5 itens

    public static CreateSaleCommand GenerateValidCommand()
    {
        return CreateSaleCommandFaker.Generate();
    }
}
