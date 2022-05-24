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
		public Dictionary<int, Ship> ParkingPlace { get; set; }

		public Port(int amountOfShips)
		{
			AmountOfShips = amountOfShips;
			Ships = new List<Ship>();
			Distances = GetDistances();
			ParkingPlace = new Dictionary<int, Ship>();
		}
		public void PrintInfoAboutContainers()
		{
			var ShipTable = new Table("Parking place", "Ship", "number of Containers");
			ShipTable.Config = TableConfiguration.UnicodeAlt();
			foreach (var item in ParkingPlace)
			{
				ShipTable.AddRow($"{item.Key}", $"{item.Value}", $"{item.Value.containersInside.Count}");
			}
			Console.Write(ShipTable);

		}

		/*public static int GetRandomShipKey()
		{
			Random random = new Random();
			int key = random.Next()
		}
		*/

		public void AddShips()
		{
			for (int i = 0; i < AmountOfShips; i++)
			{
				int random = GetRandomParkingPlaceKey();
				var ship = new Ship();
				ParkingPlace.Add(random, ship);
				Ships.Add(ship);
			}
		}
		public static void ContainersToRandomShipPlacement(Port port)
		{
			foreach (var container in Program.ListOfContainers)
			{
				//port.ParkingPlace.Values
			}
		}
		public int GetRandomParkingPlaceKey()
		{
			int random = Helpers.GetRandomInt(0, 11);
			if (ParkingPlace.ContainsKey(random))
			{
				GetRandomParkingPlaceKey();
			}
			return random;
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
		public void MoveContainer(IDNumber id, int from, int to)
		{
			Console.WriteLine($"Moving container {id.IdNumber} from ship {from} to ship {to}");
			MovingContainerSleeping(from, to);
			//	Ships[from].containersInside.Remove(Ships[from].containersInside[id.IdNumber]);
			//Ships[to].AddContainer(Ships[from].containersInside[container]);
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