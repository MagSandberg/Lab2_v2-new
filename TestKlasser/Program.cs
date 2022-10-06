using Lab2_v2;
using System.IO;

var db = new DataSource(); //Produkt-"databas"
Login userLogin = new Login(); //Loggar in en användare

//Tillåtna tangenttryckningar i programmet
System.ConsoleKey[] cK = { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6, ConsoleKey.Q };
var keyPress = new ConsoleKeyInfo(); //Switch-navigering
var keyPressMenuShop = new ConsoleKeyInfo();
var keyPressProd = new ConsoleKeyInfo();

//Programmet körs tills användaren avlsutar
while (true)
{
    while (Bool.LoginMenu)
    {
        LoginMenu(); //Verifierar användaren
    }
    while (Bool.StoreMenu)
    {
        StoreMenu(); //Lägg till eller ta bort produkter, kundvagn, kassa
    }
}
//KOM P ÅETT SÄTT ATT RENSA KUNDVAGNEN OM EN ANNAN ANVÄNDARE LOGGAR IN
void LoginMenu()
{

    Console.WriteLine("1: Logga in | 2: Registrera ny kund | Q: Stäng program");
    keyPress = Console.ReadKey();
    Console.CursorLeft = 0;

    System.ConsoleKey[] cK = { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.Q };
    if (keyPress.Key != cK[0] & keyPress.Key != cK[1] & keyPress.Key != cK[3])
    {
        Console.Write("\nFel inmatning: ");
        ChangeTextColorLogin("Red");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nVänligen välj mellan 1, 2 eller Q för att avsluta.\n");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    else
    {
        switch (keyPress.Key)
        {
            case ConsoleKey.D1:

                ChangeTextColorLogin("Green.Login");
                userLogin.LoginFields();
                userLogin.CheckIfUserExists();
                break;

            case ConsoleKey.D2:

                ChangeTextColorLogin("Green.Register");
                userLogin.LoginFields(); //Name, Password
                userLogin.userList.Add(new Customer(userLogin.Name, userLogin.Password)); //Spara till lista
                break;

            case ConsoleKey.Q:

                ChangeTextColorLogin("Green.Quit");
                Login.VerifyQuit();
                Console.Clear();
                break;
        }
    }
} //IF loginMenu = true
void StoreMenu()
{
    while (Bool.WrongKey)
    {
        Console.WriteLine("1: Handla | 2: Kundvagn | 3: Till kassan | Q: Logga ut");
        keyPressMenuShop = Console.ReadKey();
        Console.CursorLeft = 0;

        if (keyPressMenuShop.Key != cK[0] & keyPressMenuShop.Key != cK[1] &
            keyPressMenuShop.Key != cK[2] & keyPressMenuShop.Key != cK[6])
        {
            Console.Clear();
            Console.WriteLine("1: Handla | 2: Kundvagn | 3: Till kassan | Q: Logga ut\n");
            Console.Write("Fel inmatning: ");
            ChangeTextColorMenuShop("Red");
            Console.WriteLine("\nVänligen välj 1, 2, 3 eller Q för att logga ut.\n");
            keyPressMenuShop = Console.ReadKey();
        }
        else
        {
            Console.Clear();
            Bool.WrongKey = false;
        }
    }
    Bool.WrongKey = true;
    switch (keyPressMenuShop.Key)
    {
        case ConsoleKey.D1:
            while (Bool.WrongKeyProd)
            {
                Console.Clear();
                Console.WriteLine("1: Handla | 2: Kundvagn | 3: Till kassan | Q: Logga ut");
                ChangeTextColorMenuShop("Green.Handla");

                StoreMethod.ProductDisplay();

                keyPressProd = Console.ReadKey();
                if (keyPressProd.Key != cK[0] & keyPressProd.Key != cK[1] & keyPressProd.Key != cK[2] &
                    keyPressProd.Key != cK[3] & keyPressProd.Key != cK[4] & keyPressProd.Key != cK[5] &
                    keyPressProd.Key != cK[6])
                {
                    Console.Clear();
                    Console.Write("Fel inmatning: ");
                    ChangeTextColorProducts("Red");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nVänligen välj med tangenterna 1-6 eller Q.\n");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    StoreMethod.ProductDisplay();

                    keyPressProd = Console.ReadKey();
                }
                else
                {
                    var productId = 0;
                    switch (keyPressProd.Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            productId = 1;
                            StoreMethod.AddToCart(productId);
                            break;
                        case ConsoleKey.D2:
                            Console.Clear();
                            productId = 1;
                            StoreMethod.RemoveFromCart(productId);
                            break;
                        case ConsoleKey.D3:
                            Console.Clear();
                            productId = 2;
                            StoreMethod.AddToCart(productId);
                            break;
                        case ConsoleKey.D4:
                            Console.Clear();
                            productId = 2;
                            StoreMethod.RemoveFromCart(productId);
                            break;
                        case ConsoleKey.D5:
                            Console.Clear();
                            productId = 3;
                            StoreMethod.AddToCart(productId);
                            break;
                        case ConsoleKey.D6:
                            Console.Clear();
                            productId = 3;
                            StoreMethod.RemoveFromCart(productId);
                            break;
                        case ConsoleKey.Q:
                            Bool.WrongKeyProd = false;
                            Console.Clear();
                            break;
                    }
                }
            }
            break;

        case ConsoleKey.D2:
            while (Bool.WrongKey)
            {
                Console.Clear();
                Console.WriteLine("1: Handla | 2: Kundvagn | 3: Till kassan | Q: Logga ut");
                ChangeTextColorMenuShop("Green.Kundvagn");

                StoreMethod.PrintCart();

                keyPressMenuShop = Console.ReadKey();
                if (keyPressMenuShop.Key != cK[0] & keyPressMenuShop.Key != cK[1] &
                    keyPressMenuShop.Key != cK[2] & keyPressMenuShop.Key != cK[6])
                {
                    Console.Clear();
                    Console.Write("Fel inmatning: ");
                    ChangeTextColorProducts("Red");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nVänligen välj med tangenterna 1-6 eller Q.\n");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    StoreMethod.PrintCart();

                    keyPressMenuShop = Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Bool.WrongKeyProd = true;
                    Bool.WrongKey = false;
                }
            }
            break;
        case ConsoleKey.Q:
            StoreMethod.VerifyLogout();
            break;
    }
} //IF storeMenu = true

void ChangeTextColorLogin(string color)
{
    switch (color)
    {
        case "Red":
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(keyPress.KeyChar);
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        case "Green.Login":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   -------- ");
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        case "Green.Register":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("              --------------------- ");
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        case "Green.Quit":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                      -----------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
    }
}
void ChangeTextColorMenuShop(string color)
{
    switch (color)
    {
        case "Red":
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(keyPressMenuShop.KeyChar);
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        case "Green.Handla":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   ------");
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        case "Green.Kundvagn":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("            -----------");
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        case "Green.Quit":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                      -----------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
    }
}
void ChangeTextColorProducts(string color)
{
    switch (color)
    {
        case "Red":
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(keyPressProd.KeyChar);
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
    }
}