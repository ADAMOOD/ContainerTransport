using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using BetterConsoleTables;

namespace ContainerTransport.Models
{
	public class Port
	{

		public static int AmountOfPlaces { get; set; }
		public List<int> Distances { get; set; }
		public List<Ship> Ships { get; }
		public Dictionary<int, Ship> ParkingPlace { get; set; }
		public List<Container> Dock { get; set; }

		public Port(int amountOfPlaces)
		{
			AmountOfPlaces = amountOfPlaces;
			Ships = new List<Ship>();
			Distances = GetDistances();
				ParkingPlace = new Dictionary<int, Ship>();
			Dock = new List<Container>();
		}
		public void PrintInfoAboutContainers()
		{
			var ShipTable = new Table("Parking place", "Ship", "Number of Containers");
			ShipTable.Config = TableConfiguration.UnicodeAlt();
			foreach (var item in ParkingPlace)
			{
				ShipTable.AddRow($"{item.Key}", $"{item.Value.ShipName}", $"{item.Value.containersInside.Count}");
			}
			Console.Write(ShipTable);

		}

		public int GetRandomShipKey()
		{
			Random random = new Random();
			return ParkingPlace.ElementAt(random.Next(0, ParkingPlace.Count)).Key;
		}

		public void AddShips()
		{
			for (int i = 0; i < AmountOfPlaces; i++)
			{
				int random = GetRandomParkingPlaceKey();
				var ship = new Ship();
				ParkingPlace.Add(random, ship);
				Ships.Add(ship);
			}
		}

		public int GetRandomParkingPlaceKey()
		{
			do
			{
				int random = Helpers.GetRandomInt(0, 11);
				if (!ParkingPlace.ContainsKey(random))
				{
					return random;
				}
			} while (true);

		}

		public int[] GetDistances()
		{
			Distances = new List<int>(AmountOfPlaces - 1);
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
		public void MoveContainerOnLand(IDNumber id)
		{

			if (CheckIfIdExist(id))
			{

			}
			else
			{
				Console.WriteLine("bandbs");
			}

		}

		private bool CheckIfIdExist(IDNumber id)
		{
			foreach (var item in Ships)
			{
				foreach (var container in item.containersInside)
				{
					return Container.IDs.Contains(id);
				}
			}
			return false;
		}

		public void MoveContainer(IDNumber id, int to)
		{
			//Console.WriteLine($"Moving container {id.IdNumber} from ship {from} to ship {to}");
			//	MovingContainerSleeping(from, to);
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