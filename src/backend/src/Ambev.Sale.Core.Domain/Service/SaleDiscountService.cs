using Ambev.Sale.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.Sale.Core.Domain.Service
{
    public class SaleDiscountService
    {
        private const int MIN_DISCOUNT_QUANTITY = 4;
        private const int MID_DISCOUNT_QUANTITY = 10;
        private const int MAX_QUANTITY = 20;
        private const decimal BASIC_DISCOUNT = 0.10m;
        private const decimal BULK_DISCOUNT = 0.20m;
        public bool IsValid = true;

        public decimal CalculateItemDiscount(int quantity, decimal unitPrice)
        {
            ValidateQuantity(quantity);

            if (quantity < MIN_DISCOUNT_QUANTITY)
                return 0;

            var totalPrice = quantity * unitPrice;
            var discountPercentage = quantity >= MID_DISCOUNT_QUANTITY ? BULK_DISCOUNT : BASIC_DISCOUNT;

            return totalPrice * discountPercentage;
        }

        public void ValidateQuantity(int quantity)
        {
            if (quantity > MAX_QUANTITY)
            {
                this.IsValid = false;                
                throw new InvalidOperationException($"Cannot sell more than {MAX_QUANTITY} identical items");
            }
        }

        public void ValidateSaleItems(IEnumerable<SaleItem> items)
        {
            var groupedItems = items.GroupBy(x => x.ProductId);

            foreach (var group in groupedItems)
            {
                var totalQuantity = group.Sum(x => x.Quantity);
                ValidateQuantity(totalQuantity);

                foreach (var item in group)
                {
                    var discount = CalculateItemDiscount(item.Quantity, item.UnitPrice);
                    item.Discount = discount;
                    item.TotalPrice = (item.Quantity * item.UnitPrice) - discount;
                }
            }
        }
    }
}
