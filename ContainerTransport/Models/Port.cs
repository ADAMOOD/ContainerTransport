using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace ContainerTransport.Models
{
	public class Port
	{

		public static int AmountOfShips { get; set; }
		public int[] Distances { get; set; }
		public List<Ship> Ships { get; set; }

		public void PrintInfoAbotContainers()
		{
			int i=0;
			foreach (var ship in Ships)
			{
				Console.WriteLine($"ship {i} has {ship.containersInside.Count}");
				i++;
			}
		}
		public Port(int amountOfShips)
		{
			AmountOfShips = amountOfShips;
			Ships = new List<Ship>();
			Distances =GetDistances();
		}

		public void AddShips()
		{
			for (int i = 0; i < AmountOfShips; i++)
				Ships.Add(new Ship());
	}

		public int[] GetDistances()
		{
			Distances = new int[AmountOfShips - 1];
			for(int i=0; i < Distances.Length; i++)
			{
				Distances[i] = Program.GetRandomInt(100, 451);
			}
			return Distances;
		}


		public void MoveContainer(int container, int from, int to)
		{
			Console.WriteLine($"Moving container {container} from ship {from} to ship {to}");
			MovingContainerSleeping(from,to);
			Ships[from].containersInside.Remove(Ships[from].containersInside[container]);
			Ships[to].AddContainer(Ships[from].containersInside[container]);
		}

		public void MovingContainerSleeping(int ship1,int ship2)
		{
			int sleeping=0;
			for (int i = ship1; i <ship2; i++)
			{
				sleeping += Distances[i];
			}

			Console.WriteLine($"This move will take {sleeping}ms");
			Thread.Sleep(sleeping);
		}
	}

}