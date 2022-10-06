namespace Lab2_v2;

public class StoreMethod
{
    public static void AddToCart(int prodId)
    {

        if (Customer.Cart.Contains(DataSource.Stock.Find(p => p.Id == prodId)))
        {
            foreach (var item in Customer.Cart.Where(item => item.Id.Equals(prodId)))
            {
                item.Qty++;
            }
        }
        else
        {
            Customer.Cart.AddRange(DataSource.Stock.FindAll(p => p.Id == prodId));
        }
    }
    public static void RemoveFromCart(int prodId)
    {
        if (Customer.Cart.Contains(DataSource.Stock.Find(p => p.Id == prodId)))
        {
            foreach (var item in Customer.Cart.Where(item => item.Id.Equals(prodId)))
            {
                if (item.Qty > 0)
                {
                    item.Qty--;
                }
            }
        }
        else
        {
            Customer.Cart.AddRange(DataSource.Stock.FindAll(p => p.Id == prodId));
        }
    }
    public static void PrintCart()
    {
        double totalSum = 0;
        foreach (var p in Customer.Cart)
        {
            Console.WriteLine($"Produkt: {p.Name} | Styckpris: {p.Price} | Antal: {p.Qty} | Totalpris: {string.Format("{0:0.00}", p.Qty * p.Price)}");
            totalSum += p.Qty * p.Price;
        }

        Console.WriteLine($"\nPris för hela kundvagnen: {string.Format("{0:0.00}", totalSum)}");
    }
    public static void ProductDisplay()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Lägg till eller ta bort en produkt i kundvagnen med tangenterna 1-6\neller Q för att gå tillbaka.\n");
        Console.ForegroundColor = ConsoleColor.Gray;
        foreach (var p in DataSource.Stock)
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
    public static void VerifyLogout()
    {
        Console.WriteLine("Logga ut, är du säker?\nTryck J för att avsluta eller valfri tangent för att gå tillbaka\n");
        var verifyQuit = Console.ReadKey();
        if (verifyQuit.Key == ConsoleKey.J)
        {
            Console.Clear();
            Bool.LoginMenu = true;
            Bool.StoreMenu = false;
        }
    }
}