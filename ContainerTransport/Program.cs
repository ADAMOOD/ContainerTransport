using System;
using System.Collections.Generic;
using System.Globalization;
using ContainerTransport.Models;
using BetterConsoleTables;
namespace ContainerTransport
{
	internal class Program
	{
		public const int AmountOfBoxes = 1000;
		public const string EnteringText = "WELCOME TO THIS [CONTAINERS-BOXES-SHIPS-AND-STUF] APLICATION";
		public const int AmountOfShips = 3;
		public static List<Box> ListOfBoxes = new List<Box>();
		public static List<Container> ListOfContainers = new List<Container>();
		static void Main(string[] args)
		{
			Console.SetCursorPosition((Console.WindowWidth - EnteringText.Length) / 2, Console.CursorTop);
			Console.WriteLine(EnteringText);
			AddBoxesIntoContainer(AmountOfBoxes, null);
			var port = new Port(10);
			AddShips(port);
			Console.WriteLine("'1'->Print Containers Table\n'2'->Moving Containers Between Ships\n'3'->Land container\n'4'->Exit Application");
			ContainersToRandomShipPlacement(port);
			while (true)
			{
				char choice = Console.ReadKey().KeyChar;
				Helpers.ClearCurrentConsoleLine(5);

				Console.WriteLine();
				switch (choice)
				{
					case '1':
						{
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Containers:");
							CreateAdnPrintTableAboutContainers();
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Ships:");
							port.PrintInfoAboutShips();
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.WriteLine("Dock:");
							port.PrintInfoAboutDock();
							Console.ResetColor();
							break;
						}
					case '2':
						{
							Console.WriteLine("Give me an ID of container");
							string input = Console.ReadLine();
							var id = new IDNumber(input);
							Console.WriteLine($"Give me name of Ship you wanna container {id.IdNumber} move into ");
							string shipName = Console.ReadLine();
							Console.WriteLine(port.MovingContainersBetweenShips(id, shipName));
							break;
						}
					case '3':
						{
							Console.WriteLine("Give me an ID of container");
							string input = Console.ReadLine();
							var id = new IDNumber(input);
							Console.WriteLine(port.MoveContainerOnLand(id));
							break;
						}
					case '4':
						{
							Environment.Exit(1);
							break;
						}
				}

			}

		}

		public static void AddShips(Port port)
		{
			for (int i = 0; i < AmountOfShips; i++)
			{
				int random = port.GetRandomParkingPlaceKey();
				var ship = new Ship();
				port.AddShip(ship, random);

			}
		}
		public static void ContainersToRandomShipPlacement(Port port)
		{
			foreach (var container in Program.ListOfContainers)
			{
				port.ParkingPlace[port.GetRandomShipKey()].containersInside.Add(container);
			}
		}



		private static void CreateAdnPrintTableAboutContainers()
		{
			
			var table = new Table("index", "Generated Id", "Container Guid", "Number Of Boxes", "Boxes Weighs", "Status");
			table.Config = TableConfiguration.UnicodeAlt();

			int i = 1;
			foreach (var con in ListOfContainers)
			{
				table.AddRow($"{i}", $"{con.Id.IdNumber}", $"{con.Guid}", $"{con.GetContent().Count}",
					$"{con.Weight} kg", $"{con.Status}");
				i++;
			}
			Console.Write(table.ToString());
			
		}

		public static void AddBoxesIntoContainer(int remainingBoxes, Box inputBox)
		{
			var container = GetRandomContainer();
			ListOfContainers.Add(container);
			for (int i = 0; i < remainingBoxes; i++)
			{
				Box box;
				if (inputBox == null)
				{
					box = GetRandomBox();

				}
				else
				{
					box = inputBox;
				}
				ListOfBoxes.Add(box);
				if (container.CheckIfBoxFitsInContainer(ListOfBoxes[i]))
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.ResetColor();
					container.AddBox(box);
					container.AddBoxesWeight(box);
					inputBox = null;
				}
				else
				{
					var remainedBox = box;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.ResetColor();
					AddBoxesIntoContainer(remainingBoxes - i, remainedBox);
					break;
				}
			}
		}
		public static Container GetRandomContainer()
		{
			int width = Helpers.GetRandomInt(200, 500);
			int height = Helpers.GetRandomInt(200, 500);
			int depth = Helpers.GetRandomInt(200, 500);
			int weight = 0;
			Guid guid = Guid.NewGuid();
			return new Container(guid, width, height, depth, weight, status.ship);
		}
		public static Box GetRandomBox()
		{
			int width = Helpers.GetRandomInt(50, 150);
			int height = Helpers.GetRandomInt(50, 150);
			int depth = Helpers.GetRandomInt(50, 150);
			int weight = Helpers.GetRandomInt(1, 20);
			Guid guid = Guid.NewGuid();
			return new Box(guid, width, height, depth, weight);
		}
	}
}