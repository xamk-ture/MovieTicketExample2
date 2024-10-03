namespace MovieTicketExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

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

            //determinating the ticket type and price
            string ticket = "";
            int ticketPrice = 0;

            if (ticketType == 1)
            {
                ticket = "Child ticket";
                ticketPrice = 5;
            }
            else if (ticketType == 2)
            {
                ticket = "Adult ticket";
                ticketPrice = 10;
            }
            else if (ticketType == 3)
            {
                ticket = "Senior ticket";
                ticketPrice = 7;
            }


            //discount logic

            Console.WriteLine("Do you have discount code y/n");

            bool hasDicount = Console.ReadLine().ToLower() == "y";

            //the code line above does this in one line
            //string discountString = "";

            //if(discountString == "y")
            //{
            //    hasDicount = true;
            //}
            double discountAmount = 0;

            if (hasDicount)
            {
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
            }

            double totalPriceOfTicket = ticketPrice;

            if (discountAmount > 0)
            {
                totalPriceOfTicket = ticketPrice * discountAmount;
            }

            Console.WriteLine($"{name}, you chose {ticketType}. Original price {ticketPrice}€" +
                $" and the discounted price is {totalPriceOfTicket}");

        }
    }
}
