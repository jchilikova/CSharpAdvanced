using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NumberWars
{
    class Program
    {
        private static Queue<KeyValuePair<int, char>> playerOneDeck;
        private static Queue<KeyValuePair<int, char>> playerTwoDeck;

        static void Main(string[] args)
        {
            bool hasWinner = false;
            InitDeck(ref playerOneDeck);
            InitDeck(ref playerTwoDeck);

            var turns = 0;
            while (playerOneDeck.Count > 0 && playerTwoDeck.Count > 0 && turns < 1_000_000 && !hasWinner)
            {
                turns++;
                var currentPlayerOneCard = playerOneDeck.Dequeue();
                var currentPlayerTwoCard = playerTwoDeck.Dequeue();

                if (currentPlayerOneCard.Key > currentPlayerTwoCard.Key)
                {
                    playerOneDeck.Enqueue(currentPlayerOneCard);
                    playerOneDeck.Enqueue(currentPlayerTwoCard);

                }
                else if (currentPlayerTwoCard.Key > currentPlayerOneCard.Key)
                {
                    playerTwoDeck.Enqueue(currentPlayerTwoCard);
                    playerTwoDeck.Enqueue(currentPlayerOneCard);
                }
                else
                {
                    var list = new List<KeyValuePair<int, char>> {currentPlayerOneCard, currentPlayerTwoCard};
                    while (!hasWinner)
                    {
                        if (playerOneDeck.Count>= 3 && playerTwoDeck.Count >= 3)
                        {
                            var playerOneSum = 0;
                            var playerTwoSum = 0;

                            for (int i = 0; i < 3; i++)
                            {
                                playerOneSum += (char.ToUpper(GetCard(playerOneDeck,list).Value) - 64);
                                playerTwoSum += (char.ToUpper(GetCard(playerTwoDeck,list).Value) - 64);
                            }
                            
                            if (playerOneSum > playerTwoSum)
                            {
                                TransferCards(playerOneDeck, list);
                                break;
                            }
                            else if (playerTwoSum > playerOneSum)
                            {
                                TransferCards(playerTwoDeck, list);
                                break;
                            }
                        }
                        else
                        {
                            hasWinner = true;
                        }
                    }

                }
               

            }

            if (playerOneDeck.Count == playerTwoDeck.Count)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else if (playerOneDeck.Count < playerTwoDeck.Count)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            else if (playerTwoDeck.Count < playerOneDeck.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
        }

        private static void TransferCards(Queue<KeyValuePair<int, char>> queue, List<KeyValuePair<int,char>> list)
        {
            var orderedBoard = list.OrderByDescending(x => x.Key).ThenByDescending(x => x.Value);
            foreach (var card in orderedBoard)
            {
                queue.Enqueue(card);
            }
        }

        private static KeyValuePair<int, char> GetCard(Queue<KeyValuePair<int, char>> deck, List<KeyValuePair<int, char>> list)
        {
            var card = deck.Dequeue();
            list.Add(card);

            return card;
        }

        private static void InitDeck(ref Queue<KeyValuePair<int, char>> deck)
        {
            deck = new Queue<KeyValuePair<int, char>>();

            var data = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var reg = new Regex(@"(?<number>\d+)(?<card>\w+)");

            foreach (var item in data)
            {
                var match = reg.Match(item);

                var number = int.Parse(match.Groups["number"].Value);
                var card = match.Groups["card"].Value[0];

                var kvp = new KeyValuePair<int, char>(number, card);

                deck.Enqueue(kvp);
            }
        }
    }
}
