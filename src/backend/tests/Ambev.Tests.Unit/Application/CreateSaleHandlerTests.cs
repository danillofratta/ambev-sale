using Xunit;
using Moq;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Rebus.Bus;
using Ambev.Sale.Core.Application.Sales.Create;
using Ambev.Sale.Core.Domain.Entities;
using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.Core.Domain.Service;
using Ambev.Tests.Unit.Data;
using Ambev.Sale.Core.Domain.Common;
using Ambev.Sale.Core.Domain;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using Ambev.Sale.Infrastructure.Common;
using NSubstitute;

namespace Ambev.Tests.Unit.Application;

public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _repository;
    private readonly Mock<ISaleRepository> _repositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<IBus> _busMock;
    private readonly SaleDiscountService _discountService;
    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTests()
    {
     
        _repositoryMock = new Mock<ISaleRepository>();
        _mapperMock = new Mock<IMapper>();
        _mediatorMock = new Mock<IMediator>();
        _busMock = new Mock<IBus>();
        _discountService = new SaleDiscountService();

        _handler = new CreateSaleHandler(
            _busMock.Object,
            _mediatorMock.Object,
            _discountService,
            _repositoryMock.Object,
            _mapperMock.Object
        );
    }

    [Fact]
    public async Task Handle_Should_Create_Sale_Successfully()
    {               
        var command = CreateSaleHandlerTestData.GenerateValidCommand();

        var createSaleResult = new CreateSaleResult();
        var validationResult = new ValidationResult();

        _mapperMock.Setup(m => m.Map<Ambev.Sale.Core.Domain.Entities.Sale>(command));

        var result = await _handler.Handle(command, CancellationToken.None);        

        var resultget = await _repository.Received(1).GetByIdAsync(result.Id, Arg.Any<CancellationToken>());
        Assert.NotNull(resultget);
    }


    [Fact]
    public void ValidateQuantity_Should_Throw_Exception_When_Exceeding_Max_Quantity()
    {
        // Arrange
        var service = new SaleDiscountService();

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => service.ValidateQuantity(25));
        Assert.Equal("Cannot sell more than 20 identical items", exception.Message);
    }
}
