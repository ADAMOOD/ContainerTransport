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

		public void AddShip(Ship ship, int place)
		{
			ParkingPlace.Add(place, ship);
			Ships.Add(ship);
		}


		public int GetRandomParkingPlaceKey()
		{
			do
			{
				int random = Helpers.GetRandomInt(1, AmountOfPlaces + 1);
				if (!ParkingPlace.ContainsKey(random))
				{
					return random;
				}
			} while (true);

		}

		public List<int> GetDistances()
		{
			Distances = new List<int>(AmountOfPlaces - 1);
			for (int i = 0; i < AmountOfPlaces - 1; i++)
			{
				Distances.Add(Helpers.GetRandomInt(100, 451));
			}
			return Distances;
		}

		//Dostaneš jenom ID
		//user input
		//1.vypsani všech kontejneru
		//2. presouvani kontejneru
		//3. vylodeni kontejneru
		public void MovingContainersBetweenShips(IDNumber idContainer, string shipName)
		{
			if (CheckIfIdExist(idContainer))
			{
				throw new ArgumentOutOfRangeException(nameof(idContainer), "Does not exists");
			}
			if (CheckIfShipNameExist(shipName))
			{
				throw new ArgumentOutOfRangeException(nameof(shipName), "Does not exists");
			}
		
	}
		public void MoveContainerOnLand(IDNumber id)
		{
			if (CheckIfIdExist(id))
			{
				throw new ArgumentOutOfRangeException(nameof(id), "Does not exists");
			}

			var container = getContainer(id);
			Dock.Add(container);
		}

		private Container getContainer(IDNumber id)
		{
			foreach (var ship in Ships)
			{
				foreach (var container in ship.containersInside)
				{
					if (container.IdNumber.IdNumber.Equals(id))
					{
						ship.containersInside.Remove(container);
						return container;
					}
						
				}
			}
			return null;
		}

		private bool CheckIfShipNameExist(string name)
		{
			return Ship.NamesOfShips.Contains(name);
		}

		private bool CheckIfIdExist(IDNumber id)
		{
			return Container.IDs.Contains(id);
		}

		public void MoveContainer(IDNumber id, int to)
		{
			//Console.WriteLine($"Moving container {id.IdNumber} from ship {from} to ship {to}");
			//	MovingContainerSleeping(from, to);
			//	Ships[from].containersInside.Remove(Ships[from].containersInside[id.IdNumber]);
			//Ships[to].AddContainer(Ships[from].containersInside[container]);
		}

		public int CalculateDistanceBetweenPlaces(int from, int to)
		{
			if ((from < 1) || (from > Distances.Count))
				throw new ArgumentOutOfRangeException(nameof(from), "must be bigger than 0 or smaller than 10");
			if ((to < 1) || (to > Distances.Count))
				throw new ArgumentOutOfRangeException(nameof(to), "must be bigger than 0 or smaller than 10");
			if (from == to)
				throw new ArgumentNullException(nameof(to), $"Can not be same as from: {from}");

			from--;
			to--;
			int distance = 0;
			if (from > to)
			{
				for (int i = from ; i >= to; i--)
				{
					distance += Distances[i];
				}
			}
			else
			{
				for (int i = from ; i < to; i++)
				{
					distance += Distances[i];
				}
			}

			return distance;
		}

	}

}