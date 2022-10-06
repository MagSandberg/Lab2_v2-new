using System.Collections.Generic;
using System.Xml.Linq;

namespace Lab2_v2;

public class Login
{
    //Field
    public string Name { get; set; }
    public string Password { get; set; }

    public List<Customer> userList = new()
    {
        new Customer("Knatte", "123"),
        new Customer("Fnatte", "321"),
        new Customer("Tjatte", "213")
    };

    //Method

    public void LoginFields()
    {
        Console.Write("Fyll i namn: ");
        Name = Console.ReadLine();

        Console.Write("Fyll i lösenord: ");
        Password = Console.ReadLine();

        Console.Clear();
    }
    public bool CheckIfUserExists()
    {
        foreach (var user in userList)
        {
            if (CheckIfUserNameExists(user.Name))
            {
                if (CheckIfUserPasswordExists(user.Password))
                {
                    Bool.LoginMenu = false;
                    Bool.StoreMenu = true;
                    return true;
                }
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Fel lösenord! Vänligen försök igen.\n");
                    LoginFields(); //Name, Password
                    if (CheckIfUserPasswordExists(user.Password))
                    {
                        Bool.LoginMenu = false;
                        Bool.StoreMenu = true;
                        return true;
                    }
                }
            }
        }

        if (CheckIfUserNameExists(Name))
        {
            Console.WriteLine("Användarnamnet kunde inte hittas. Vill du registrera dig?\n");
            Console.WriteLine("Tryck J för att registrera dig eller valfri tangent för att återgå till menyn.");
            var keyPress = Console.ReadKey();
            if (keyPress.Key == ConsoleKey.J)
            {
                Console.Clear();
                Console.WriteLine("* Registrera ny kund *\n");
                LoginFields(); //Name, Password
                userList.Add(new Customer(Name, Password)); //Spara till lista
            }
            else if (keyPress.Key != ConsoleKey.J)
            {
                Console.Clear();
            }
        }
        return false;
    }

    private bool CheckIfUserPasswordExists(string userPassword)
    {
        return userPassword.Equals(Password);
    }

    public bool CheckIfUserNameExists(string name)
    {
        return name.Equals(Name);
    }

    public static void VerifyQuit()
    {
        Console.WriteLine("Avsluta, är du säker?\nTryck J för att avsluta eller valfri tangent för att gå tillbaka\n");
        var verifyQuit = Console.ReadKey();
        if (verifyQuit.Key == ConsoleKey.J)
        {
            Console.Clear();
            Environment.Exit(0);
        }
    }
}