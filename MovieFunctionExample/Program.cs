using System.Net.Sockets;
using System.Xml.Linq;

namespace MovieFunctionExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = AskName();
            int age = AskAge();
            int ticketType = AskTicketType();

            //determinating the ticket type and price
            string ticket = GetTicketName(ticketType);
            int ticketPrice = GetTicketPrice(ticketType);

            bool hasDicount = CheckIfUserHasDiscount();

            double discountAmount = 0;

            if (hasDicount)
            {
                discountAmount = DeterminateDiscount();
            }

            double totalPriceOfTicket = CalculateFinalPrice(ticketPrice, discountAmount);

            PrintUserFinalTicketInfo(name, ticket, ticketPrice, totalPriceOfTicket);
        }

        /// <summary>
        /// Ask user name
        /// </summary>
        /// <returns>Returns user name</returns>
        static string AskName()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            return name;
        }

        static int AskAge()
        {
            Console.WriteLine("Please enter your age");

            int age = 0;
            bool isAgeValid = false;

            while (isAgeValid == false)
            {
                string ageString = Console.ReadLine();

                //tries to parse ageString to a number and if it succeeds
                //puts value to the age variable
                isAgeValid = int.TryParse(ageString, out age);

                if (isAgeValid == false)
                {
                    Console.WriteLine("Please input valid age");
                }
            }

            return age;
        }

        /// <summary>
        /// Asks user for what ticket type it wants
        /// </summary>
        /// <returns>Returns the selected ticket type</returns>
        static int AskTicketType()
        {
            Console.WriteLine("Choose ticket type");
            Console.WriteLine("1: Child ticket");
            Console.WriteLine("2: Adult ticket");
            Console.WriteLine("3: Senior ticket");

            int ticketType = 0;
            bool isTicketTypeValid = false;

            while (isTicketTypeValid == false)
            {
                string ticketString = Console.ReadLine();
                isTicketTypeValid = int.TryParse(ticketString, out ticketType) && ticketType <= 3;

                if (isTicketTypeValid == false)
                {
                    Console.WriteLine("Please input valid age");
                }
            }

            return ticketType;
        }

        static int GetTicketPrice(int ticket)
        {
            int ticketPrice = 0;

            if (ticket == 1)
            {
                ticketPrice = 5;
            }
            else if (ticket == 2)
            {
                ticketPrice = 10;
            }
            else if (ticket == 3)
            {
                ticketPrice = 7;
            }

            return ticketPrice;
        }

        static string GetTicketName(int ticket)
        {
            string ticketName = "";

            if (ticket == 1)
            {
                ticketName = "child ticket";
            }
            else if (ticket == 2)
            {
                ticketName = "child ticket";
            }
            else if (ticket == 3)
            {
                ticketName = "child ticket";
            }

            return ticketName;
        }

        static void PrintUserFinalTicketInfo(string name, string ticketType, 
            double ticketPrice, double totalPriceOfTicket)
        {
            Console.WriteLine($"{name}, you chose {ticketType}. Original price {ticketPrice}€" +
               $" and the discounted price is {totalPriceOfTicket}");
        }

        private static double CalculateFinalPrice(int ticketPrice, double discountAmount)
        {
            double totalPriceOfTicket = 0;

            if (discountAmount > 0)
            {
                totalPriceOfTicket = ticketPrice * discountAmount;
            }

            return totalPriceOfTicket;
        }

        static double DeterminateDiscount()
        {
            double discountAmount = 0;
            bool hasValidCode = false;

            Console.WriteLine("Please input your discount code");

            while (hasValidCode == false)
            {
                string code = Console.ReadLine();

                if (code.ToLower() == "ale20")
                {
                    discountAmount = 0.80;
                    hasValidCode = true;
                }
                else if (code.ToLower() == "ale30")
                {
                    discountAmount = 0.70;
                    hasValidCode = true;
                }
                else
                {
                    Console.WriteLine("Invalid code");
                }
            }

            return discountAmount;
        }

        static bool CheckIfUserHasDiscount()
        {
            Console.WriteLine("Do you have discount code y/n");

            bool hasDicount = Console.ReadLine().ToLower() == "y";
            return hasDicount;
        }
    }
}
