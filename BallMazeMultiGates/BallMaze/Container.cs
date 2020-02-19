using System;
using System.Collections.Generic;
using System.Text;

namespace BallMaze
{
    class Container : IPassage
    {
        public int No { get; }

        internal Container(int number, string name)
        {
            No = number;
            Name = name;
            // Console.WriteLine($"Container {No} got added with a name {Name}");
        }

        public string Name { get; }
        
        public bool HasBall { get; private set; }


        public string ReceiveBall(Ball ball)
        {
            HasBall = true;
            //string result = $"Container {Name} received ball no {ball.No}";
            //Console.WriteLine("---------------------------------------------");
            //Console.WriteLine(result);
            //Console.WriteLine("---------------------------------------------");
            return Name;
        }

        public List<IPassage> GetChildren()
        {               
            return new List<IPassage>() { this };
        }

        public string TraverseGateInOppositeDirection()
        {
            return Name;
        }

        public string TraverseForBallNo(int ballNo)
        {
            return Name;
        }
    }
}
