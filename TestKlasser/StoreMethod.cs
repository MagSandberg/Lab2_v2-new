namespace Lab2_v2;

public class StoreMethod
{
    public static void AddToCart(int prodId, Customer customer)
    {
        var db = new DataSource();
        if (customer.Cart.Contains(db.Stock.Find(p => p.Id == prodId)))
        {
            foreach (var item in customer.Cart.Where(item => item.Id.Equals(prodId)))
            {
                item.Qty++;
            }
        }
        customer.Cart.AddRange(new[] { db.Stock.FirstOrDefault(p => p.Id == prodId) });
    }
    public static void RemoveFromCart(int prodId, Customer customer)
    {
        var db = new DataSource();
        Console.Clear();
        if (customer.Cart.Contains(db.Stock.Find(p => p.Id == prodId)))
        {
            foreach (var item in customer.Cart.Where(item => item.Id.Equals(prodId)))
            {
                if (item.Qty > 0)
                {
                    item.Qty--;
                }
            }
        }
        else
        {
            customer.Cart.AddRange(db.Stock.FindAll(p => p.Id == prodId));
        }
    }
    public static void PrintCart(Customer cust)
    {
        double totalSum = 0;
        foreach (var p in cust.Cart)
        {
            Console.WriteLine($"Produkt: {p.Name} | Styckpris: {p.Price} | Antal: {p.Qty} | Totalpris: {string.Format("{0:0.00}", p.Qty * p.Price)}");
            totalSum += p.Qty * p.Price;
        }

        Console.WriteLine($"\nPris för hela kundvagnen: {string.Format("{0:0.00}", totalSum)}");
    }
    public static void ProductDisplay()
    {
        var db = new DataSource();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Lägg till eller ta bort en produkt i kundvagnen med tangenterna 1-6\neller Q för att gå tillbaka.\n");

        Console.ForegroundColor = ConsoleColor.Gray;
        foreach (var p in db.Stock)
        {
            var addProd = String.Empty;

            if (p.Id == 1)
            {
                addProd = "(1) Lägg till | (2) Ta bort:";
            }
            else if (p.Id == 2)
            {
                addProd = "(3) Lägg till | (4) Ta bort:";
            }
            else
            {
                addProd = "(5) Lägg till | (6) Ta bort:";
            }
            Console.WriteLine($"{addProd} {p.Name} / Pris: {p.Price}");
        }
    }
}