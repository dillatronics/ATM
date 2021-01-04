using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "OKC1234";
            int bill = 0;
            double balance = 500;

            loginMenu:
            Console.WriteLine("1-Card Transactions\n2-Cardless Transactions");
            string login = Console.ReadLine();

            switch (login)
            {
                case "1":
                    string cardPassword = null;
                    int right = 0;
                    while (cardPassword != password && right < 3)
                    {
                        right++;
                        Console.WriteLine("Please enter the card password:");
                        cardPassword = Console.ReadLine();
                        if (cardPassword != password)
                        {
                            Console.WriteLine("Password is incorrect. Please try again!!");
                        }
                    }
                    if (cardPassword == password)
                    {
                        mainMenu:
                        Console.WriteLine("Welcome to the Main Menu\n1-Withdraw money\n2-Deposit money\n3-Money Transfer\n4-Loan payments\n5-Other Payments\n6-Information Update");
                        string menuSelection = Console.ReadLine();

                        switch (menuSelection)
                        {
                            case "1":
                                withdraw:
                                Console.WriteLine("Enter the amount you want to withdraw:");
                                double amountWithdraw = Convert.ToDouble(Console.ReadLine());
                                if (amountWithdraw % 10 == 0)
                                {
                                    if (balance >= amountWithdraw)
                                    {
                                        balance = balance - amountWithdraw;
                                        Console.WriteLine("Wihtdrawn amount:{0}\nNew Balance:{1}", amountWithdraw, balance);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insufficient Balance");
                                        Console.WriteLine("For New Balance Entry");
                                        Console.WriteLine("9-Main Menu\nPress any key to exit.");
                                        string selectionBalance = Console.ReadLine();
                                        if (selectionBalance == "9")
                                            goto mainMenu;
                                        else if (selectionBalance == "1")
                                            goto withdraw;
                                        else
                                            Console.WriteLine("Good Bye!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Please enter multiples of 10: ");
                                    goto withdraw;
                                }
                                break;

                            case "2":
                                deposit:
                                Console.WriteLine("1- Deposit to credit card\n2- Deposit to account\n9-Main Menu\n0-Exit");
                                string selectionDeposit = Console.ReadLine();
                                if (selectionDeposit == "1")
                                {
                                    cardNumber:
                                    Console.WriteLine("Please enter at least 12-digit card number:");
                                    long creditCardNumber = Convert.ToInt64(Console.ReadLine());
                                    if (creditCardNumber >= 10000000000 && creditCardNumber <= 999999999999)
                                    {
                                        Console.WriteLine("Amount to be deposited on credit card:");
                                        double amountToBeDeposited = Convert.ToDouble(Console.ReadLine());
                                        if (balance >= amountToBeDeposited)
                                        {
                                            balance = balance - amountToBeDeposited;
                                            Console.WriteLine("1-Withdrawn amount:{0}\nNew Balance:{1}", amountToBeDeposited, balance);
                                        }
                                        else
                                        {
                                            Console.WriteLine("You entered the card number incompletely or incorrectly.");
                                            Console.WriteLine("1-Re-enter the credit card number.");
                                            Console.WriteLine("9-Main Menu\nPress any key to exit.");
                                            string selectionNewCreditCardNumber = Console.ReadLine();
                                            if (selectionNewCreditCardNumber == "9")
                                                goto mainMenu;
                                            else if (selectionNewCreditCardNumber == "1")
                                                goto cardNumber;
                                            else
                                                Console.WriteLine("Good Bye!");
                                        }
                                    }
                                    else if (selectionDeposit == "2")
                                        Console.WriteLine();
                                    else if (selectionDeposit == "9")
                                        goto mainMenu;
                                    else if (selectionDeposit == "0")
                                        break;
                                    else
                                    {
                                        Console.WriteLine("Incorrect Selection!");
                                        goto deposit;
                                    }
                                }
                                else if (selectionDeposit == "2")
                                {
                                    Console.WriteLine("Amount to be deposited:");
                                    balance += Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("New Balance:" + balance);
                                }
                                else
                                {
                                    Console.WriteLine("You made the wrong selection.");
                                    Console.WriteLine("9-Main Menu\nPress any key to exit.");
                                    if (Console.ReadLine() == "9")
                                        goto mainMenu;

                                    else
                                        Console.WriteLine("Good Bye");
                                    break;
                                }
                                break;

                            case "3":
                                Console.WriteLine("Money Transfer Menu\n1-EFT\n2-Transfer");
                                int selection = Convert.ToInt32(Console.ReadLine());

                                if (selection == 1)
                                {
                                    EFT:
                                    Console.WriteLine("Enter the account number of the person you want to deposit money into:");
                                    long accountNumber = Convert.ToInt64(Console.ReadLine());

                                    if (accountNumber >= 10000000000 && accountNumber <= 999999999999)
                                    {
                                        amount:
                                        Console.WriteLine("The amount to be EFT:");
                                        double amount = Convert.ToDouble(Console.ReadLine());
                                        if (balance >= amount)
                                        {
                                            balance = balance - amount;
                                            Console.WriteLine(amount + "pounds have been sent to the" + accountNumber + "account number.");
                                            Console.WriteLine("New balance:" + balance);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Insufficient balance. Please re-enter.\n Available balance: " + balance);
                                            goto amount;
                                        }
                                    }

                                    else
                                    {
                                        Console.WriteLine("You entered the account number incomplete / incorrect");
                                        Console.WriteLine("Please re - enter the account number: ");
                                        Console.WriteLine("9-Main Menu\nPress any key to exit.");
                                        int selectionAccount = Convert.ToInt32(Console.ReadLine());
                                        if (selectionAccount == 9)
                                            goto mainMenu;
                                        else if (selectionAccount == 1)
                                            goto EFT;
                                        else
                                            Console.WriteLine("Good Bye");
                                    }
                                }
                                else if (selection == 2)
                                {
                                    transfer:
                                    Console.WriteLine("Enter the account number to be transferred:");
                                    long accountNumber1 = Convert.ToInt64(Console.ReadLine());
                                    if (accountNumber1 >= 10000000000 && accountNumber1 <= 999999999999)
                                    {
                                        amount:
                                        Console.WriteLine("The amount to be transferred:");
                                        double amount = Convert.ToDouble(Console.ReadLine());
                                        if (balance >= amount)
                                        {
                                            balance = balance - amount;
                                            Console.WriteLine(amount + "pounds have been sent to the" + accountNumber1 + "account number.");
                                            Console.WriteLine("New balance:" + balance);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Insufficient balance. Please re-enter.\n Available balance: " + balance);
                                            goto amount;
                                        }
                                    }
                                    else
                                    {

                                        Console.WriteLine("You entered the account number incomplete / incorrect");
                                        Console.WriteLine("Please re - enter the account number: ");
                                        Console.WriteLine("9-Main Menu\nPress any key to exit.");
                                        string selectionAccount = Console.ReadLine();
                                        if (selectionAccount == "9")
                                            goto mainMenu;
                                        else if (selectionAccount == "1")
                                            goto deposit;
                                        else
                                            Console.WriteLine("Good Bye");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You made the wrong selection.");
                                    Console.WriteLine("9-Main Menu\nPress any key to exit.");
                                    if (Console.ReadLine() == "9")

                                        goto mainMenu;
                                    else
                                        Console.WriteLine("Good Bye");
                                    break;
                                }
                                break;
                           
                            case "4":
                                Console.WriteLine("The loan payments area is defective! Please try again later.");
                                break;

                            case "5":
                                bill:
                                Console.WriteLine("Payments");
                                Console.WriteLine("1-Electricity bill");
                                Console.WriteLine("2-Phone bill");
                                Console.WriteLine("3-Water bill");
                                Console.WriteLine("4-Internet bill");
                                Console.WriteLine("5-Road fine bill");
                                Console.WriteLine("9-Main Menu");
                                string payment = Console.ReadLine();
                                switch (payment)
                                {
                                    case "1":
                                        Console.WriteLine("Enter the Electricity Bill Number:");
                                        bill = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Bill : 50.00");
                                        Console.WriteLine("Would you like to pay? (Y / N)");
                                        string answer = Console.ReadLine().ToLower();
                                        if (answer == "y" || answer == "yes")
                                        { 
                                            if (balance >= bill)
                                            {
                                                balance -= bill;
                                                Console.WriteLine("New balance:" + balance);
                                                Console.WriteLine("9-Main Menu\nPress any key to exit.");
                                                string selectionBill = Console.ReadLine();
                                                if (selectionBill == "9")
                                                {
                                                    goto mainMenu;
                                                }

                                                else if (selectionBill == "1")
                                                {
                                                    goto bill;
                                                }

                                                else
                                                {
                                                    Console.WriteLine("Insufficient Balance");
                                                }

                                            }
                                        }
                                        break;
                                    
                                    case "2":
                                        break;
                                    case "3":
                                        break;
                                    case "4":
                                        break;
                                    case "5":
                                        break;
                                    case "9":
                                        goto mainMenu;
                                    default:
                                        break;
                                }
                                break;


                            case "6":
                                Console.WriteLine("Password Change Screen");
                                Console.WriteLine("Old Password: ");
                                string oldPassword = Console.ReadLine();
                                if (oldPassword.Equals(password)) //new password == OKC
                                { 
                                    string password1, password2;
                                    Console.WriteLine("New password: ");
                                    password1 = Console.ReadLine();
                                    Console.WriteLine("Re enter new passwprd: ");
                                    password2 = Console.ReadLine();
                                    if (password1 == password2)
                                    {
                                        Console.WriteLine("Your password has been changed");
                                        password = password1;
                                        goto loginMenu;
                                    }
                                    else
                                        Console.WriteLine("Error");
                                }

                                break;
                            default:
                                Console.WriteLine("You made an incorrect selection from the main menu.");
                                Console.WriteLine("9-Main Menu\nPress any key to exit.");
                                if (Console.ReadLine() == "9")
                                    goto mainMenu;
                                else
                                    Console.WriteLine("Good Bye");
                                break;
                        }
                        Console.WriteLine("Do You Have Any Other Transactions? (Y / N)");
                        string turn = Console.ReadLine().ToLower();
                        if (turn == "y" || turn == "yes")
                            goto mainMenu;
                        else
                            Console.WriteLine("Good Bye");
                    }

                    else
                    {
                        Console.WriteLine("Your right is done.");
                        Environment.Exit(0);
                    }
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("You made the wrong selection.");
                    goto loginMenu;
            }
                 Console.ReadKey();
            }
        }
    }