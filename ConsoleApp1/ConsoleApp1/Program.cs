using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Witaj jak masz na imię?");
            string name = Console.ReadLine();
            Console.Clear();
            

            bool canPlay = CheckAge(); // checking age of user.

            if (canPlay == true)
            {
                Console.Clear();
                long coins = Coins();
                Console.Clear();
                coins = ChooseGame(coins);
                Console.Clear();
                Console.WriteLine($"Dziękuję za gre {name} TWOJE COINSY: {coins}");
            }
        }


        static bool CheckAge() // check user age
        {
            bool isAge = false; // isAge = > number? False.
            int age=0;          
            bool canPlay = true; // can play default by true

            
            Console.WriteLine("A ile masz lat?");
              // asking about age until it's not number
            
                age = CheckNumber(Console.ReadLine());
          
            if(age<18) // checking is age 18 or more
            {
                string message = "Niestety ta gra jest od 18 lat! Nie możesz w nią zagrać.";
                Message(ConsoleColor.Red, message);
                canPlay = false;
            }

            return canPlay;
            
        }

        static void Message(ConsoleColor color, string message) // function to color message in console
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);
            Console.ResetColor();
        }
        static int CheckNumber(string check) // Check, string is number INT?
        {
            int number = 0;
            bool isNumber = int.TryParse(check, out number);
            
            while (!isNumber)
            { 
                isNumber = int.TryParse(check, out number);
                if (isNumber == false)
                {
                    string message = "Wpisz liczbę";
                    Message(ConsoleColor.Red, message);
                    check = Console.ReadLine();
                }


            }

            return number;
        }

        static long Coins() // Change Coins Amount 
        {
            string message="error";
            long mincoins = 1;          //minimum amount coins to get
            long maxcoins = 10000;      //maximum amount coins to get
            long takencoins = 0;
            Console.WriteLine($"Na ile mam ustawić twoje coinsy? twój zakres to od {mincoins} do {maxcoins}.");
            takencoins = CheckNumber(Console.ReadLine());
            while (takencoins < mincoins || takencoins > maxcoins)
            {
                if (takencoins < mincoins)
                    message = $"{takencoins} to za malo! twoj zakres jest od {mincoins} do {maxcoins}.";
                if (takencoins > maxcoins)
                    message = $"{takencoins} to za duzo! twoj zakres jest od {mincoins} do {maxcoins}.";
                Message(ConsoleColor.Red, message);

                takencoins = CheckNumber(Console.ReadLine());
            }

            return takencoins;
        }
        static long ChooseGame(long coins)  // ChooseGame Function
        {

            string didplay = "t";

            while (didplay != "N")
            {

                Console.Clear();
            Message(ConsoleColor.Green, "1. Roulette");
            Message(ConsoleColor.Green, "2. Coin Flip");
            Message(ConsoleColor.Green, "3. Zmień ilość coinsów");
            Message(ConsoleColor.Blue, "Wybierz numer: 1/2/3");
            int choose = CheckNumber(Console.ReadLine());
            if (choose > 0 && choose < 4)
            switch (choose)
                {
                    case 1:
                        Console.Clear();
                        coins = Roulette(coins);

                        break;
                    case 2:
                        Console.Clear();
                        coins = CoinFlip(coins);

                        break;
                    case 3:
                        Console.Clear();
                        Message(ConsoleColor.DarkBlue, $"aktualnie masz {coins} coinsów!");
                        coins = Coins();

                        break;


                }
                Console.Clear();
                Message(ConsoleColor.DarkBlue, $"Posiadasz {coins} coinsow.");
                Message(ConsoleColor.DarkBlue, $"Chcesz wybrać gierke (T) czy wyjść (N)");
                Message(ConsoleColor.DarkBlue, $"Wybrać => T");
                Message(ConsoleColor.DarkBlue, $"Wyjść => N");
                didplay = Console.ReadLine();
                didplay = didplay.ToUpper();

                while (didplay != "T" && didplay != "N")
                {
                    Message(ConsoleColor.Red, $"T / N ");
                    didplay = Console.ReadLine();
                    didplay = didplay.ToUpper();

                }
            }

            return coins;
        }

        // You choose (GAME)  message
        static void ChooseMsg(string name)
        {
            Message(ConsoleColor.DarkBlue, $"Witaj wybraleś tryb {name}!");
        }
        

        // Roulette

        static long Roulette(long coins)
        {
            string didplay="t";

            while (didplay != "N")
            {
                ChooseMsg("Ruletka");

                System.Threading.Thread.Sleep(700);
                Console.Clear();
                long bamount = BetAmount(coins);
                string betColor = Bet(bamount);
                Console.Clear();
                Message(ConsoleColor.Green, $"Postawiłeś {bamount} na {betColor} Ciekawe czy sie uda!");
                System.Threading.Thread.Sleep(1500);

                string roll = Roll(betColor, bamount);
                if (roll == "Win14")
                {
                    bamount = Win(bamount);
                }
                else if (roll == "Win")
                {
                    bamount = Win(bamount);
                }
                else if (roll == "Lose")
                {
                    bamount = Lose(bamount);
                }
                coins = coins + bamount;

                Message(ConsoleColor.DarkBlue, $"Posiadasz {coins} coinsow.");
                Message(ConsoleColor.DarkBlue, $"Grasz dalej?");
                Message(ConsoleColor.DarkBlue, $"TAK => T");
                Message(ConsoleColor.DarkBlue, $"NIE => N");
                didplay = Console.ReadLine();
                didplay = didplay.ToUpper();

                while (didplay != "T" && didplay != "N")
                {
                    Message(ConsoleColor.Red, $"T / N ");
                    didplay = Console.ReadLine();
                    didplay = didplay.ToUpper();

                }
            }
            return coins;
        }
        // Beting amount function 
        static long BetAmount(long coins)
        {
            Message(ConsoleColor.Yellow, $"Posiadasz {coins} coinsów");
            Message(ConsoleColor.DarkBlue, $"Ile chcesz postawić?");
            int bcoins = CheckNumber(Console.ReadLine());
            while(bcoins < 0 || bcoins > coins)
            {
                if (bcoins<0)
                Message(ConsoleColor.Red, $"nie możesz postawić liczby ujemnej!");
                if (bcoins > coins)
                Message(ConsoleColor.Red, $"Masz za malo coinsow na tego beta!");

                bcoins = CheckNumber(Console.ReadLine());

            }
            Console.Clear();
            return (bcoins);
        }

        // Beting color choosing Function
        static string Bet(long bcoins)
        {
            string betColor;
            Message(ConsoleColor.Magenta, $"{bcoins} stawiasz na!");
            Message(ConsoleColor.Red, $"1. Czerwony");
            Message(ConsoleColor.Gray, $"2. Czarny");
            Message(ConsoleColor.Green, $"3. Zielony");
            int choose = CheckNumber(Console.ReadLine());
            while (choose < 1 || choose > 3)
            {
                Message(ConsoleColor.Red, $"Masz do wyboru: 1, 2, 3!");
                choose = CheckNumber(Console.ReadLine());

            }
            if (choose == 1)
                betColor = "red";
            else if (choose == 2)
                betColor = "black";
            else if (choose == 3)
                betColor = "green";
            else
                betColor = "none";

            return betColor;
        }

        // Roll function ( take 1 random number )
        static string Roll(string color, long bcoins)
        {
            Random rnd = new Random();
            string wins;
            int whoWin = rnd.Next(0, 33);
            if (whoWin == 0)
            {
                
                wins = "green";
                Message(ConsoleColor.Green, $"Wylosowano kolor ZIELONY");

            }
            else if (whoWin%2 == 0)
            {
                wins = "black";
                Message(ConsoleColor.Gray, $"Wylosowano kolor CZARNY");
            }
            else
            {
                wins = "red";
                Message(ConsoleColor.Red, $"Wylosowano kolor CZERWONY");
            }
            System.Threading.Thread.Sleep(500);
            if (color == wins && color == "green")
            {
                return "Win14";
            }
            else if (color == wins)
            {
                return "Win";
            }
            else
                return "Lose";


        }
        
        // Coin Flip
        static long CoinFlip(long coins)
        {
            ChooseMsg("Coin Flip"); // welcome message
            string didplay = "t";

            while (didplay != "N")
            {

                long betamount=BetAmount(coins);

            
            Message(ConsoleColor.DarkBlue, $"Orzeł czy reszka?");
            Message(ConsoleColor.DarkBlue, $"1 < --- Orzeł");
            Message(ConsoleColor.DarkBlue, $"2 < --- Reszka");
            int choose = CheckNumber(Console.ReadLine()); // checking is input number
            while (choose != 1 & choose !=2)
            {
                Message(ConsoleColor.Red, $"Wybierz 1 ALBO 2");
                choose = CheckNumber(Console.ReadLine());       // checking is input number
                }    
            int flip = Flip();      // Flip coin
            if (choose == flip)     // Check is choose == what flip return
            {
                betamount = Win(betamount); // If win
            }
            else if(choose != flip)
            {
                betamount = Lose(betamount); // If lose
            }
                coins = coins + betamount;  // update coins value





                Message(ConsoleColor.DarkBlue, $"Posiadasz {coins} coinsow.");
                Message(ConsoleColor.DarkBlue, $"Grasz dalej?");
                Message(ConsoleColor.DarkBlue, $"TAK => T");
                Message(ConsoleColor.DarkBlue, $"NIE => N");
                didplay = Console.ReadLine();
                didplay = didplay.ToUpper();

                while (didplay != "T" && didplay != "N")
                {
                    Message(ConsoleColor.Red, $"T / N ");
                    didplay = Console.ReadLine();
                    didplay = didplay.ToUpper();

                }
            }
            return coins;
        }

        // random 0-1 (coinflip function)
        static int Flip()
        {
            Random rnd = new Random();
            int whoWin = rnd.Next(0, 2);

            return whoWin;
        }




        // Win / Lose
        // Win 14 = green win and sending 
        static long Win14(long bamount)
        {

            Message(ConsoleColor.Green, $"BRAWO! Wygrałeś {bamount * 14}");
            System.Threading.Thread.Sleep(2500);

            return bamount*13;


        }

        // Win Black / Red / coinflip
        static long Win(long bamount)
        {
            Message(ConsoleColor.Green, $"BRAWO! Wygrałeś {bamount * 2}");
            System.Threading.Thread.Sleep(2500);
            return bamount;
        }

        // Lose Function
        static long Lose(long bamount)
        {
            Message(ConsoleColor.Green, $"Niestety! przegrales... {bamount}");
            System.Threading.Thread.Sleep(2500);
            return -bamount;
        }










    }
}
