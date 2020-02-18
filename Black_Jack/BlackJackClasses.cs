using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Jack
{
    public class BlackJackClasses
    {
        public class Deck
        {
            /*public Dictionary<string, int> deck = new Dictionary<string, int>()
            {
                { "Ace", 1 },
                { "Two", 2 },
                { "Three", 3 },
                { "Four", 4 },
                { "Five", 5 },
                { "Six", 6 },
                { "Seven", 7 },
                { "Eight", 8 },
                { "Nine", 9 },
                { "Ten", 10 },
                { "Jack", 10 },
                { "Queen", 10 },
                { "King", 10},
            };
            public string GetCards()
            {
                int randNum;
                Random rand = new Random();
                List<string> dictKey = new List<string>(deck.Keys);
                randNum = rand.Next(0, 12);               
                            
            }*/
            public List<string> deckAsList = new List<string>()
                {
                { "Ace"},
                { "Two"},
                { "Three"},
                { "Four"},
                { "Five"},
                { "Six"},
                { "Seven"},
                { "Eight"},
                { "Nine"},
                { "Ten"},
                { "Jack"},
                { "Queen"},
                { "King"},
                };
            public string RandCard()
            {
                Random rand = new Random();
                int card = rand.Next(0, 12);
                return deckAsList[card];
            }
        }
        public class Player
        {
            Deck deck = new Deck();
            public int Money { get; set; } = 100;
            public int Bet { get; set; }
            public List<string> Hand = new List<string>();
            public void SetBet(int bet)
            {
                while(bet > Money)
                {
                    Console.WriteLine("\nYou Can't Bet More Money Than You Have");
                    Console.WriteLine("Put In A Smaller Bet");
                    bet = (Int32.Parse(Console.ReadLine()));
                }
                Bet += bet;
                Money -= bet;
            }
            public void ClearBet()
            {
                Bet = 0;

            }
            public int WinBet()
            {
                int moneyWon = Bet * 2;
                Money += moneyWon;
                ClearBet();
                return moneyWon;
            }
            public int LoseBet()
            {
                int moneyLost = Bet;
                ClearBet();
                return moneyLost;
            }
            public int GetCardValue()
               
            {
                int pointTotal = 0;
                foreach (string s in Hand)
                {
                    string cardValue = s;

                    switch (cardValue)
                    {
                        case "Ace":
                            cardValue = "1";
                            break;
                        case "Two":
                            cardValue = "2";
                            break;
                        case "Three":
                            cardValue = "3";
                            break;
                        case "Four":
                            cardValue = "4";
                            break;
                        case "Five":
                            cardValue = "5";
                            break;
                        case "Six":
                            cardValue = "6";
                            break;
                        case "Seven":
                            cardValue = "7";
                            break;
                        case "Eight":
                            cardValue = "8";
                            break;
                        case "Nine":
                            cardValue = "9";
                            break;
                        case "Ten":
                        case "Jack":
                        case "Queen":
                        case "King":
                            cardValue = "10";
                            break;
                    }
                    pointTotal += Int32.Parse(cardValue);
                }
                return pointTotal;
            }
            public string Card1()
            {

                string card1;
                Random rand1 = new Random();
                int card = rand1.Next(0, 12);
                card1 = deck.deckAsList[card];
                return card1;

            }
            public string Card2()
            {
                string card2;

                Random rand2 = new Random();
                int card = rand2.Next(0, 12);
                card = rand2.Next(0, 12);
                card = rand2.Next(0, 12);
                card2 = deck.deckAsList[card];
                return card2;

            }
            public List<string> GetHand()
            {

                var card1 = Card1();
                var card2 = Card2();
                Hand.Add(card1);
                Hand.Add(card2);
                Console.WriteLine($"Your cards: \n{ card1}\n{card2}\nPoint Total: {GetCardValue()}\n");
                return Hand;
            }
            public List<string> GetHit()
            {

                var card2 = Card2();
                Hand.Add(card2);
                return Hand;
            }


        };
        public class Dealer
        {
            Player _player = new Player();
            public List<string> _dealerHand = new List<string>();
            public List<string> GetDealerHand()
            {
                var card1 = _player.Card1();
                var card2 = _player.Card2();
                _dealerHand.Add(card1);
                _dealerHand.Add(card2);
                Console.WriteLine($"Dealer Cards: { card1} and Hidden Card\n");
                return _dealerHand;
            }

            public List<string> DealerGetHit()
            {

                var card2 = _player.Card2();
                _dealerHand.Add(card2);
                return _dealerHand;
            }
            public int GetDealerCardValue()

            {
                int pointTotal = 0;
                foreach (string s in _dealerHand)
                {
                    string cardValue = s;
                    switch (cardValue)
                    {
                        case "Ace":
                            cardValue = "1";
                            break;
                        case "Two":
                            cardValue = "2";
                            break;
                        case "Three":
                            cardValue = "3";
                            break;
                        case "Four":
                            cardValue = "4";
                            break;
                        case "Five":
                            cardValue = "5";
                            break;
                        case "Six":
                            cardValue = "6";
                            break;
                        case "Seven":
                            cardValue = "7";
                            break;
                        case "Eight":
                            cardValue = "8";
                            break;
                        case "Nine":
                            cardValue = "9";
                            break;
                        case "Ten":
                        case "Jack":
                        case "Queen":
                        case "King":
                            cardValue = "10";
                            break;
                    }
                    pointTotal += Int32.Parse(cardValue);
                }
                return pointTotal;
            }
        }
    }
}
