// Em Ambev.Sale.Core.Domain/Services/SaleRecalculationService.cs
using Ambev.Sale.Core.Domain.Entities;
using Ambev.Sale.Core.Domain.Enum;
using Ambev.Sale.Core.Domain.Repository;
using Ambev.Sale.Core.Domain.Service;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Recalculates item discounts and total sales. 
/// Function called for example when canceling or adding an item to a sale
/// </summary>
public class SaleRecalculationService
{
    /// <summary>
    /// Reuse the rules to apply discounts
    /// </summary>
    private readonly SaleDiscountService _discountService;

    public SaleRecalculationService(SaleDiscountService discountService)
    {
        _discountService = discountService;
    }

    /// <summary>
    /// Recalculates the total sale
    /// </summary>
    /// <param name="sale"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public void RecalculateSale(Sale sale)
    {
        if (sale == null)
            throw new InvalidOperationException("Sale cannot be null");

        var activeItems = sale.SaleItems
            .Where(x => x.Status != SaleItemStatus.Cancelled)
            .ToList();

        _discountService.ValidateSaleItems(activeItems);

        sale.TotalAmount = activeItems.Sum(x => x.TotalPrice);
        UpdateSaleStatus(sale);
    }

    private void UpdateSaleStatus(Sale sale)
    {
        if (!sale.SaleItems.Any(x => x.Status != SaleItemStatus.Cancelled))
        {
            sale.Status = SaleStatus.Cancelled;
        }
        else if (sale.Status != SaleStatus.Cancelled)
        {
            sale.Status = SaleStatus.NotCancelled;
        }
    }
}
