using System;
using System.Xml.Linq;

namespace Lab2_v2;

public class DataSource
{
    public static List<Product> Stock { get; } = new();

    public DataSource()
    {
        Stock.AddRange(new[]
        {
            new Product { Id = 1, Name = "T-shirt", Price = 299.99, Qty = 1 },
            new Product { Id = 2, Name = "Jeans", Price = 1429.12, Qty = 1 },
            new Product { Id = 3, Name = "Keps", Price = 123.45, Qty = 1 },
        });
    }
}