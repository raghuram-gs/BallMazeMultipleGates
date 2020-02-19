using System;
using System.Collections.Generic;
using System.Linq;

namespace BallMaze
{
	class Passage : IPassage
	{
		private List<IPassage> passages;
		private Gate gate;
		public int No { get; }
		public bool HasBall => false;

		internal Passage(int no, int gatePosition)
		{
			No = no;
			gate = new Gate(gatePosition);
			passages = new List<IPassage>();
			Console.WriteLine($"Passage {No} got a gate direction of {gate.Direction}");
		}

		public string ReceiveBall(Ball ball)
		{
			string result = passages[gate.Direction - 1].ReceiveBall(ball);
			SetNextGate();
			return result;
			//Console.WriteLine($"Passage {No} changed gate direction to {gate.Direction}");
		}

		private void SetNextGate()
		{
			gate.Direction = GetNextGateForward();
		}

		private int GetNextGateForward()
		{
			int nextGateIndex = gate.Direction + 1;
			return nextGateIndex > passages.Count ? (nextGateIndex % passages.Count) : nextGateIndex;
		}

		private int GetNextGateBackward()
		{
			int nextGateInOppositeDirection = gate.Direction - 1;

			if(nextGateInOppositeDirection == 0)
			{
				return passages.Count;
			}

			return nextGateInOppositeDirection;
		}

		public void AddPassage(IPassage passage)
		{
			passages.Add(passage);
		}

		public List<IPassage> GetChildren()
		{
			List<IPassage> children = new List<IPassage>();

			foreach (var item in passages)
			{
				children.AddRange(item.GetChildren());
			}

			return children;
		}

		public string TraverseGateInOppositeDirection()
		{
			return passages[GetNextGateBackward() - 1].TraverseGateInOppositeDirection();
		}

		public string TraverseForBallNo(int ballNumber)
		{
			int passageIndex = GetGatePositionAfter(ballNumber - 1) - 1;

			int ballsPassedToNextPassage = (int)Math.Ceiling(Convert.ToDecimal(ballNumber) / passages.Count);

			return passages[passageIndex].TraverseForBallNo(ballsPassedToNextPassage);
		}

		private int GetGatePositionAfter(int balls)
		{
			if(balls == 0)
			{
				return gate.Direction;
			}

			int newPosition = gate.Direction + balls;
			
			if(newPosition > passages.Count)
			{
				int correctedPosition = newPosition % passages.Count;
				return correctedPosition == 0 ?  passages.Count : correctedPosition;
			}

			return newPosition;
		}
	}
}
