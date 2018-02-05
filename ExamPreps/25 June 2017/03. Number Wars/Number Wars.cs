using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03._Number_Wars
{
    class NumberWars
    // 70/100
    {
        static void Main(string[] args)
        {
            Queue firstPlayerDeck = InitializeQueue();
            Queue secondPlayerDeck = InitializeQueue();

            int counter = 0;
            List<Queue> playersDecks = new List<Queue> { firstPlayerDeck, secondPlayerDeck };
            while (firstPlayerDeck.Count != 0 && secondPlayerDeck.Count != 0 && counter < 1000000)
            {
                counter++;
                playersDecks = PlayCards(firstPlayerDeck, playersDecks[1]);
            }
            PrintOutPut(counter, firstPlayerDeck, secondPlayerDeck);
        }

        private static void PrintOutPut(int counter, Queue firstPlayerDeck, Queue secondPlayerDeck)
        {
            if (counter == 1000000)
            {
                if (firstPlayerDeck.Count > secondPlayerDeck.Count)
                {
                    Console.WriteLine($"First player wins after {counter} turns");
                }
                else if (firstPlayerDeck.Count < secondPlayerDeck.Count)
                {
                    Console.WriteLine($"Second player wins after {counter} turns");
                }
                else
                {
                    Console.WriteLine($"Draw after {counter} turns");
                }
            }
            if (firstPlayerDeck.Count == secondPlayerDeck.Count)
            {
                Console.WriteLine($"Draw after {counter} turns");
            }
            else if (firstPlayerDeck.Count == 0 && secondPlayerDeck.Count > 0)
            {
                Console.WriteLine($"Second player wins after {counter} turns");
            }
            else if (secondPlayerDeck.Count == 0 && firstPlayerDeck.Count > 0)
            {
                Console.WriteLine($"First player wins after {counter} turns");
            }
        }

        private static List<Queue> PlayCards(Queue firstPlayerDeck, Queue secondPlayerDeck)
        {
            List<Queue> newPlayersDecks = new List<Queue>();
            var firstPlayerCard = firstPlayerDeck.Dequeue().ToString();
            var seconPlayerCard = secondPlayerDeck.Dequeue().ToString();

            var firstPlayerNum = CalculateNumStrenght(firstPlayerCard);
            var secondPlayerNum = CalculateNumStrenght(seconPlayerCard);

            List<string> cardsToEnqueue = new List<string>();
            if (firstPlayerNum > secondPlayerNum)
            {
                cardsToEnqueue.Add(firstPlayerCard);
                cardsToEnqueue.Add(seconPlayerCard);
                firstPlayerDeck = EnqueNewCards(firstPlayerDeck, cardsToEnqueue);

                newPlayersDecks.Add(firstPlayerDeck);
                newPlayersDecks.Add(secondPlayerDeck);

                return newPlayersDecks;
            }
            else if (firstPlayerNum < secondPlayerNum)
            {
                cardsToEnqueue.Add(seconPlayerCard);
                cardsToEnqueue.Add(firstPlayerCard);
                secondPlayerDeck = EnqueNewCards(secondPlayerDeck, cardsToEnqueue);

                newPlayersDecks.Add(firstPlayerDeck);
                newPlayersDecks.Add(secondPlayerDeck);

                return newPlayersDecks;
            }

            newPlayersDecks = PlayVoina(firstPlayerCard, seconPlayerCard, firstPlayerDeck, secondPlayerDeck);
            return newPlayersDecks;
        }

        private static List<Queue> PlayVoina(string cardFirst, string cardSecond, Queue firstPlayerDeck, Queue secondPlayerDeck)
        {
            var firstPlayerStrength = 0;
            var secondPlayerStrenght = 0;

            List<Queue> newPlayerCards = new List<Queue>();
            List<string> cardsToEnqueue = new List<string>();

            cardsToEnqueue.Add(cardFirst);
            cardsToEnqueue.Add(cardSecond);
            do
            {
                for (int voinaCard = 0; voinaCard < 3; voinaCard++)
                {
                    if (firstPlayerDeck.Count == 0 || secondPlayerDeck.Count == 0)
                    {
                        newPlayerCards.Add(firstPlayerDeck);
                        newPlayerCards.Add(secondPlayerDeck);
                        return newPlayerCards;
                    }

                    var firstPlayerCard = firstPlayerDeck.Dequeue().ToString();
                    var secondPlayerCard = secondPlayerDeck.Dequeue().ToString();

                    firstPlayerStrength += CalculateCharStrength(firstPlayerCard);
                    secondPlayerStrenght += CalculateCharStrength(secondPlayerCard);

                    cardsToEnqueue.Add(firstPlayerCard);
                    cardsToEnqueue.Add(secondPlayerCard);
                }

            } while (firstPlayerStrength == secondPlayerStrenght);

            if (firstPlayerStrength > secondPlayerStrenght)
            {
                cardsToEnqueue = OrderCardsToEnque(cardsToEnqueue);
                firstPlayerDeck = EnqueNewCards(firstPlayerDeck, cardsToEnqueue);
                newPlayerCards.Add(firstPlayerDeck);
                newPlayerCards.Add(secondPlayerDeck);
                return newPlayerCards;
            }
            else if (firstPlayerStrength < secondPlayerStrenght)
            {
                cardsToEnqueue = OrderCardsToEnque(cardsToEnqueue);
                secondPlayerDeck = EnqueNewCards(secondPlayerDeck, cardsToEnqueue);
                newPlayerCards.Add(firstPlayerDeck);
                newPlayerCards.Add(secondPlayerDeck);
                return newPlayerCards;
            }

            cardsToEnqueue = OrderCardsToEnque(cardsToEnqueue);
            return newPlayerCards;
        }

        private static Queue EnqueNewCards(Queue deck, List<string> cardsToEnqueue)
        {
            foreach (var card in cardsToEnqueue)
            {
                deck.Enqueue(card);
            }

            return deck;
        }

        private static List<string> OrderCardsToEnque(List<string> cardsToEnqueue)
        {
            return cardsToEnqueue = cardsToEnqueue.OrderByDescending(c => c.Length).ThenByDescending(c => c).ToList();
        }

        private static int CalculateCharStrength(string firstPlayerCard)
        {
            var ch = 0;
            for (int i = firstPlayerCard.Length - 1; i >= firstPlayerCard.Length - 1; i--)
            {
                ch = firstPlayerCard[i];
            }
            return (int)ch - 96;
        }

        private static int CalculateNumStrenght(string card)
        {
            string numAsString = string.Empty;
            for (int i = 0; i < card.Length - 1; i++)
            {
                numAsString += card[i];
            }
            return int.Parse(numAsString);
        }

        private static Queue InitializeQueue()
        {
            string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Queue queue = new Queue();
            for (int i = 0; i < input.Length; i++)
            {
                queue.Enqueue(input[i]);
            }

            return queue;
        }
    }
}