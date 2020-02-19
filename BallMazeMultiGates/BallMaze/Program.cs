using System;
using System.Collections.Generic;
using System.Linq;

namespace BallMaze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******************* Welcome to Ball Maze *******************");

            AddSpace();

            while (true)
            {
                int? level = InputInteger("level of the maze");
                if (level == 0)
                {
                    break;
                }
                else if (level == null)
                {
                    continue;
                }

                int? noOfGates = InputInteger("no of gates in each level");
                if (noOfGates == 0)
                {
                    break;
                }
                else if (noOfGates == null)
                {
                    continue;
                }

                BuildMaze((int)level, (int)noOfGates);
            }
        }

        private static int? InputInteger(string dataName)
        {
            Console.WriteLine("**************** Menu ****************");
            AddSpace();
            Console.WriteLine($"Enter a <number> for {dataName}");
            Console.WriteLine($"Enter 0 to exit");

            AddSpace();
            Console.WriteLine("************************************");

            int? value = null;
            try
            {
                value = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid integer...");
            }
            catch (OverflowException)
            {
                Console.WriteLine("We can't process that....");
            }

            AddSpace();

            return value;
        }

        private static void AddSpace()
        {
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void BuildMaze(int level, int gates)
        {
            int noOfGates = gates;
                       
            TreeMazeBuilder mazeBuilder = new TreeMazeBuilder(level, noOfGates);
            IPassage maze = mazeBuilder.Build();

            string containerPrediction = maze.TraverseGateInOppositeDirection();

            Dictionary<int, string> ballPredictions = new Dictionary<int, string>();

            Console.WriteLine($"~~~~~~~~~~~ Abracadabra - My prediction ~~~~~~~~~~~~~");

            AddSpace();
            Console.WriteLine($"Container {containerPrediction} will not receive a ball");

            double noOfBalls = Math.Pow(noOfGates, level) - 1;

            for (int i = 1; i <= noOfBalls; i++)
            {
                string containerName = maze.TraverseForBallNo(i);
                ballPredictions.Add(i, containerName);
                Console.WriteLine($"Ball {i} will be placed in contaier {containerName}");
            }

            AddSpace();
            Console.WriteLine($"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            AddSpace();
            Console.WriteLine("Press any key to continue the game ....");
            Console.ReadLine();
            AddSpace();
            
            Dictionary<int, string> ballResult = new Dictionary<int, string>();

            for (int i = 1; i <= noOfBalls; i++)
            {
                Ball ball = new Ball(i);
                ballResult.Add(i, maze.ReceiveBall(ball));
            }

            IEnumerable<Container> containersWithoutBall = maze.GetChildren().OfType<Container>().Where(x => x.HasBall == false);


            Console.WriteLine("###################### Outcome ########################");
            Console.WriteLine();
            AddSpace();

            foreach (var item in containersWithoutBall)
            {
                Console.WriteLine($"Container {item.Name} did not receive a ball");
            }

            for (int i = 1; i <= noOfBalls; i++)
            {
                Console.WriteLine($"Ball {i} was placed in contaier {ballResult[i]}");
            }

            AddSpace();

            Console.WriteLine("######################################################");

            AddSpace();

            Console.WriteLine("********************** Result ************************");

            if (containersWithoutBall.FirstOrDefault(x => x.Name == containerPrediction) != null &&
                ballPredictions.SequenceEqual(ballResult))
            {
                AddSpace();
                Console.WriteLine($"Prediction matched the outcome");
                AddSpace();
                Console.WriteLine("**************************************************");
            }
            else
            {
                AddSpace();
                Console.WriteLine($"Prediction did not match the outcome");
                AddSpace();
                Console.WriteLine("######################################################");
            }

            AddSpace();
            Console.WriteLine("~~~~~~~~~~~~******************* Game over *******************~~~~~~~~~~~~~");
            AddSpace();

            Console.WriteLine("Press any key to retry....");
            Console.ReadLine();
        }
    }
}
