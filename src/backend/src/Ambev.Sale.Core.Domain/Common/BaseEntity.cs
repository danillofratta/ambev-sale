namespace Ambev.Sale.Core.Domain.Common;

public class BaseEntity 
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
