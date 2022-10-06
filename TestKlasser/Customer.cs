
namespace Lab2_v2;

public class Customer
{
    public string Name { get; private set; }

    public string Password { get; private set; }

    private static List<Product> _cart;
    public static List<Product> Cart { get { return _cart; } }

    public Customer(string name, string password)
    {
        Name = name;
        Password = password;
        _cart = new List<Product>();
    }

    public override string ToString()
    {
        var customerCart = string.Empty;
        foreach (var p in _cart)
        {
            customerCart += $"[{p.Name}] | ".ToString();
            customerCart += $"{p.Qty}".ToString();
        }
        return $"Namn: {Name} | Lösenord: {Password} | Kundvagn: {customerCart}";
    }
}