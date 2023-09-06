using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp126
{
    class craps
    {
        private static Random randomNumbers = new Random();

        private enum Status { Continue,Won,Lost}

        private enum DiceNames
        {
            SnakeEyes = 2,
            Trey = 3,
            Seven = 7,
            Yoleven = 11,
            BoxCars = 12
        }
        static void Main(string[] args)
        {
            Status gameStatus = Status.Continue;
            int mypoint = 0;

            int sumOfDice = RollDice();

            switch ((DiceNames)sumOfDice)
            {
                case DiceNames.Seven:
                case DiceNames.Yoleven:
                    gameStatus = Status.Won;
                    break;
                case DiceNames.SnakeEyes:
                case DiceNames.Trey:
                case DiceNames.BoxCars:
                    gameStatus = Status.Lost;
                    break;

                    while (gameStatus == Status.Continue)
                    {
                        sumOfDice = RollDice();

                        if (sumOfDice == mypoint)
                        {
                            gameStatus = Status.Won;
                        }
                        else
                        {
                            if (sumOfDice == (int)DiceNames.Seven)
                            {
                                gameStatus = Status.Lost;
                            }
                        }
                    }

                    if (gameStatus == Status.Won)
                    {
                        Console.WriteLine("player wins");
                    }
                    else
                    {
                        Console.WriteLine("player loses");
                    }
            }
        }

            static int RollDice()
            {
                int die1 = randomNumbers.Next(1, 7);
                int die2 = randomNumbers.Next(1, 7);

                int sum = die1 + die2;

                Console.WriteLine($"player rolled{die1}+{die2}={sum}");
                Console.ReadLine();
                return sum;
            }
        
        }
    }

