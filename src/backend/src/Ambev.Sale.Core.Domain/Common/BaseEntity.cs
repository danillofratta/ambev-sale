namespace Ambev.Sale.Core.Domain.Common;

/// <summary>
/// All entities "must" inherit to generate id and creation date
/// </summary>
public class BaseEntity 
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
