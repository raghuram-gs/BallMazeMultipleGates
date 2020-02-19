using System.Collections.Generic;

namespace BallMaze
{
    interface IPassage
    {
        int No { get; }
        string ReceiveBall(Ball ball);
        bool HasBall { get; }
        string TraverseGateInOppositeDirection();
        string TraverseForBallNo(int ballNo);
        List<IPassage> GetChildren();
    }
}
