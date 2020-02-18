using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Black_Jack.BlackJackClasses;

namespace Black_Jack.UI
{
    public class BlackJackUI
    {
            public string IsNullAndStringOnly(string input)
            {
            while ( string.IsNullOrWhiteSpace(input)|| input.Any(char.IsLetter) || input.Any(char.IsSymbol)|| input.Any(char.IsPunctuation))
                if(string.IsNullOrEmpty(input)|| input.Any(char.IsSymbol)|| input.Any(char.IsPunctuation))
                {
                Console.WriteLine("Must input Numbers only");
                    input = Console.ReadLine();
                }
                else if (input.Any(char.IsLetter))
                {
                    Console.WriteLine("Only Numbers");
                    input = Console.ReadLine();
                }
            return input;
            }

        public void Run()
        {
            RunMenu();
        }
        public void RunMenu()
        {
            bool isRunning = true;
            Console.ForegroundColor = ConsoleColor.Green;


            while (isRunning)
            {

                Console.WriteLine("Welcome To Black Jack. Whould You Like To Play?\n\n" +
                    "1) Yes \n" +
                    "2) No");
                string userInput = IsNullAndStringOnly(Console.ReadLine());
                if (userInput == "1")
                {
                    RunGame();
                }
                else if(userInput == "2")
                    { isRunning = false; }
                else if (userInput != "1" && userInput != "2")
                {
                    Console.WriteLine("Please Enter 1 or 2");
                }

            }
        }
        public void RunGame()
        {
            Console.Clear();
            Player _player = new Player();
            Dealer _dealer = new Dealer();
            Deck _deck = new Deck();
            _dealer.GetDealerHand();
            _player.GetHand();


            bool isPlaying = true;
            bool inRound = true;
            int round = 0;
            while (isPlaying)
            {
                string userInput = "";
                if (round != 0)
                {
                Console.Clear();
                    Console.WriteLine("Do You Want To Continue?\n" +
                        "1) Yes\n2) No");
                    userInput = IsNullAndStringOnly(Console.ReadLine());
                    if (userInput == "1")
                    {
                        round= 0;
                        _player.Hand.Clear();
                        _dealer._dealerHand.Clear();
                        _dealer.GetDealerHand();
                        _player.GetHand();
                        continue;
                    }
                    else
                    {
                        isPlaying = false;
                        break;
                    }
                    
                }

                Console.WriteLine($"Your Money: ${_player.Money}");
                Console.WriteLine("Place Your Bet:");
                userInput = IsNullAndStringOnly(Console.ReadLine());
                _player.SetBet(Int32.Parse(userInput));
                Console.WriteLine($"You Bet: ${_player.Bet}\nYour New Balance: ${_player.Money}\n");
                while (inRound)
                {
                    if (_player.GetCardValue() > 21)
                    {
                        Console.WriteLine("You Lost");
                        Console.WriteLine($"Dealer Hand:{_dealer.GetDealerCardValue()}\nPlayer Points:{_player.GetCardValue()}");
                        Console.WriteLine("You Won");
                        Console.WriteLine($"Money Lost: ${_player.WinBet()}\nYour Remaining Money: ${_player.Money}");
                        Console.ReadKey();
                        inRound = true;
                        round++;
                        break;
                    }
                    Console.WriteLine("\n1) Hit \n2) Stay");
                    userInput = IsNullAndStringOnly(Console.ReadLine());
                    Console.WriteLine();

                    if (userInput == "1")
                    {
                        _player.GetHit();
                        foreach (var s in _player.Hand)
                        {
                            Console.WriteLine(s);
                        }
                       Console.WriteLine(_player.GetCardValue());
                            Console.WriteLine();
                    }
                    if (userInput == "2")
                    {
                        inRound = false;
                    }
                }
                if (userInput == "2")
                {
                    while (_dealer.GetDealerCardValue() < 17 || _dealer.GetDealerCardValue() >= 17)
                    {

                        if (_dealer.GetDealerCardValue() < 17)
                        {
                            _dealer.DealerGetHit();
                        }
                        else if (_dealer.GetDealerCardValue() > 21)
                        {
                            Console.WriteLine("Dealer Busted.");
                            Console.WriteLine($"Dealer Hand:{_dealer.GetDealerCardValue()}\nPlayer Points:{_player.GetCardValue()}");
                            Console.WriteLine("You Won");
                            Console.WriteLine($"Money Won: ${_player.WinBet()}\nYour New Balance: ${_player.Money}");
                            Console.ReadKey();
                            round++;
                            inRound = true;
                            break;
                        }
                        else if (_dealer.GetDealerCardValue() > _player.GetCardValue())
                        {
                            Console.WriteLine($"Dealer Points:{_dealer.GetDealerCardValue()}\nPlayer Points:{_player.GetCardValue()}");
                            Console.WriteLine("Dealer Won");
                            Console.WriteLine($"Money Lost: ${_player.LoseBet()}\nRemaining Money: ${_player.Money}");
                            Console.ReadKey();
                            inRound = true;
                            round++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Dealer Points:{_dealer.GetDealerCardValue()}\nPlayer Points:{_player.GetCardValue()}");
                            Console.WriteLine("You Won");
                            Console.WriteLine($"Money Won: ${_player.WinBet()}\nYour New balance: ${_player.Money}");
                            Console.ReadKey();
                            inRound = true;
                            round++;
                            break;
                        }

                    }

                }
                Console.WriteLine(_player.GetCardValue());

            }


        }

    }
}
