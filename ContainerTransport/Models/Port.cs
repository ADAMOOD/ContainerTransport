using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using BetterConsoleTables;

namespace ContainerTransport.Models
{
	public class Port
	{

		public static int AmountOfShips { get; set; }
		public int[] Distances { get; set; }
		public List<Ship> Ships { get; }

		public void PrintInfoAbotContainers()
		{
			int i = 0;
			foreach (var ship in Ships)
			{
				var ShipTable = new Table("ship","container","number of Containers");
				ShipTable.Config = TableConfiguration.UnicodeAlt();
				ShipTable.AddRow($"{Ships[i]}", $"{Ships[i].containersInside}");
				foreach (var con in Ships[i].containersInside)
				{
					ShipTable.AddRow( $"{con.IdNumber.IdNumber}");
				}
				//Console.WriteLine($"ship {i} has {ship.containersInside.Count} containers");
				i++;
				Console.Write(ShipTable);
			}
		}
		public Port(int amountOfShips)
		{
			AmountOfShips = amountOfShips;
			Ships = new List<Ship>();
			Distances = GetDistances();
		}

		public void AddShips()
		{
			for (int i = 0; i < AmountOfShips; i++)
				Ships.Add(new Ship());
		}

		public int[] GetDistances()
		{
			Distances = new int[AmountOfShips - 1];
			for (int i = 0; i < Distances.Length; i++)
			{
				Distances[i] = Helpers.GetRandomInt(100, 451);
			}
			return Distances;
		}

		//Dostaneš jenom ID
		//user input
		//1.vypsani všech kontejneru
		//2. presouvani kontejneru
		//3. vylodeni kontejneru
		public void MoveContainer(int container, int from, int to)
		{
			Console.WriteLine($"Moving container {container} from ship {from} to ship {to}");
			MovingContainerSleeping(from, to);
			Ships[from].containersInside.Remove(Ships[from].containersInside[container]);
			Ships[to].AddContainer(Ships[from].containersInside[container]);
		}

		public void MovingContainerSleeping(int ship1, int ship2)
		{
			int sleeping = 0;
			for (int i = ship1; i < ship2; i++)
			{
				sleeping += Distances[i];
			}

			Console.WriteLine($"This move will take {sleeping}ms");
			Thread.Sleep(sleeping);
		}
	}

}