using System.Collections.Generic;

namespace BallMaze
{
    interface IPassage
    {
        int No { get; }
        string ReceiveBall(Ball ball);
        bool HasBall { get; }
        string TraverseNextGate();
        string TraverseForBallNo(decimal ballNo);
        List<IPassage> GetChildren();
    }
}