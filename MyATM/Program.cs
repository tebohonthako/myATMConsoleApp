using System;
public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setfirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setlastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setPin(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3.  Show balance");
            Console.WriteLine("4.  Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdraw = Double.Parse(Console.ReadLine());
            //check if user has enough money
            if (currentUser.getBalance() > withdraw)
            {
                Console.WriteLine("Insufficient funds :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("You're good to go! Thank You :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532772818527395", 1234, "Teboho", "Tshabile", 1500.31));
        cardHolders.Add(new cardHolder("4532761841325802", 4321, "Cynthia", "Moroka", 321.13));
        cardHolders.Add(new cardHolder("5128381368581872", 9999, "Kheamo", "Motaung", 105.59));
        cardHolders.Add(new cardHolder("6011188364697109", 2468, "Zama", "Dikana", 851.84));
        cardHolders.Add(new cardHolder("3490693153147110", 4826, "Rashford", "Smith", 54.27));
    
    // Prompt user
    Console.WriteLine("Welcome to SimpleATM");
    Console.WriteLine("Please insert your debitcard: ");
    String debitCardNum = "";
    cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again."); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again."); }
        }

        Console.WriteLine("PLease enter your pin: ");
        int userOin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again."); }
            }
                catch { Console.WriteLine("Incorrect pin. Please try again."); }
            }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");
    }

}