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
			gate.Direction = GetNextGate();
		}

		private int GetNextGate()
		{
			int nextGateIndex = gate.Direction + 1;
			return nextGateIndex > passages.Count ? (nextGateIndex % passages.Count) : nextGateIndex;
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

		public string TraverseNextGate()
		{
			return passages[GetNextGate() - 1].TraverseNextGate();
		}

		public string TraverseForBallNo(decimal ballNumber)
		{
			int passageIndex = GetGatePositionFor(ballNumber) - 1;
			decimal ballsPassedToNextPassage = Math.Ceiling(ballNumber / passages.Count);
			return passages[passageIndex].TraverseForBallNo(ballsPassedToNextPassage);
		}

		private int GetGatePositionFor(decimal ballNumber)
		{
			return ((int)ballNumber + passages.Count - gate.Direction) % passages.Count + 1;
			//return (int)(ballNumber - ((int)Math.Floor((ballNumber / gate.Direction) * ballNumber)) + gate.Direction - 1);

			//int nextGateIndex = gate.Direction + (int)ballNumber - 1;
			//return nextGateIndex > passages.Count ? (nextGateIndex % passages.Count) : nextGateIndex;

			//int gatePositionAfterBallNumber = (gate.Direction + (int)ballNumber - 1) % passages.Count + (passages.Count - gate.Direction);

			//if(gatePositionAfterBallNumber == 0)
			//{
			//	return gate.Direction;
			//}

			//return gatePositionAfterBallNumber;
		}
	}
}
