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
			var port = new Port(AmountOfShips);
			port.AddShips();
			Console.WriteLine("'1'->Print Containers Table\n'2'->Moving Containers Between Ships\n'3'->Land container\n'4'->Exit Application");
			ContainersToRandomShipPlacement(port);
			while (true)
			{
				char choice = Console.ReadKey().KeyChar;
				Helpers.ClearCurrentConsoleLine(6);

				Console.WriteLine();
				switch (choice)
				{
					case '1':
						{
							//CreateAdnPrintTableAboutContainers();
								port.PrintInfoAboutContainers();
							break;
						}
					case '2':
						{
							Console.WriteLine("Give me an ID of container");
							string id = Console.ReadLine();
							Console.WriteLine($"Give me name of Ship you wanna container {id} move into ");
							string shipName = Console.ReadLine();
							break;
						}
					case '3':
						{
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

		public static void ContainersToRandomShipPlacement(Port port)
		{
			foreach (var container in Program.ListOfContainers)
			{
				port.ParkingPlace[GetRandomShipKey(port)].containersInside.Add(container);
			}
		}
		public static int GetRandomShipKey(Port port)
		{
			Random random = new Random();
			return random.Next(port.ParkingPlace.Keys.Count);
		}

		private static void CreateAdnPrintTableAboutContainers()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			var table = new Table("index", "Generated Id", "Container Guid", "Number Of Boxes", "Boxes Weighs");
			table.Config = TableConfiguration.UnicodeAlt();

			int i = 1;
			foreach (var con in ListOfContainers)
			{
				table.AddRow($"{i}", $"{con.IdNumber.IdNumber}", $"{con.Guid}", $"{con.GetContent().Count}",
					$"{con.Weight} kg");
				i++;
			}

			Console.Write(table.ToString());
			Console.ResetColor();
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
			return new Container(guid, width, height, depth, weight);
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
