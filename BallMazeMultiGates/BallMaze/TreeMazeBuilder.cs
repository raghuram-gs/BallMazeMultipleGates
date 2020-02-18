using System;
using System.Collections.Generic;

namespace BallMaze
{
	class TreeMazeBuilder
	{
		private int mazeLevel;
		private int noOfGates;


		internal TreeMazeBuilder(int level, int gates)
		{
			mazeLevel = level;
			noOfGates = gates;
		}

		public Passage Build()
		{
			List<Passage> mazeList = new List<Passage>();

			double noOfPassages = GetNoOfPassages();
			double noOfContainers = Math.Pow(noOfGates, mazeLevel);

			// Creation of passages 
			// e.g. level 4 will have (2 pow 4 - 1) = 15 passages
			for (int i = 1; i <= noOfPassages; i++)
			{
				mazeList.Add(new Passage(i, GetDirection()));
			}

			Console.WriteLine();

			List<Container> containers = new List<Container>();
			char nameStart = 'A';

			// Creation of containers
			// for e.g for Level 4 => (2 pow 4) * 2 => 16 * 2 = 32 (start 16 to end 32) named (A to P)
			int conainerStartNumber = (int)(noOfPassages - noOfContainers);
			for (int i = 1; i <= noOfContainers; i++)
			{
				containers.Add(new Container(conainerStartNumber++, nameStart++.ToString()));
			}

			Console.WriteLine();

			List<IPassage> combinedList = new List<IPassage>();
			combinedList.AddRange(mazeList);
			combinedList.AddRange(containers);

			// Linking of passages and containers
			//			       1(0)
			//		  2(1)				  3(2)
			//	4(3)		5(4)	6(5)		7(6)
			foreach (Passage item in mazeList)
			{
				for (int i = 0; i < noOfGates; i++)
				{   // index = itemNo * noOfGates - (noOfGates - 2) - 1 + i 
					item.AddPassage(combinedList[(item.No * noOfGates) - (noOfGates - 2) - 1 + i]);
				}
			}

			// return the root node
			return mazeList[0];
		}

		private double GetNoOfPassages()
		{
			double noOfPassages = 0;
			for (int i = 0; i < mazeLevel; i++)
			{
				noOfPassages += Math.Pow(noOfGates, i);
			}

			return noOfPassages;
		}

		private int GetDirection()
		{
			Random random = new Random();
			return random.Next(1, noOfGates);
		}
	}
}
