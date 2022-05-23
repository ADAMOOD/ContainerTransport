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
		public const int AmountOfShips = 3;
		public static List<Box> ListOfBoxes = new List<Box>();
		public static List<Container> ListOfContainers = new List<Container>();


		static void Main(string[] args)
		{
			AddBoxesIntoContainer(AmountOfBoxes, null);
			var port = new Port(AmountOfShips);
			Console.WriteLine(port.Distances[0]);
			Console.WriteLine(port.Distances[1]);
			port.AddShips();
			Console.ForegroundColor = ConsoleColor.Green;
			var table = new Table("index", "Generated Id", "Container Guid", "Number Of Boxes", "Boxes Weighs");
			table.Config = TableConfiguration.UnicodeAlt();

			int i = 1;
			foreach (var con in ListOfContainers)
			{
				port.Ships[0].AddContainer(con);
				table.AddRow($"{i}", $"{con.IdNumber.IdNumber}", $"{con.Guid}", $"{con.GetContent().Count}", $"{con.Weight} kg");
				i++;


			}
			Console.Write(table.ToString());
			Console.ResetColor();
			port.PrintInfoAbotContainers();
			port.MoveContainer(0, 0, 2);
			port.PrintInfoAbotContainers();
		}

		public static void AddBoxesIntoContainer(int remainingBoxes, Box inputBox)
		{
			var container = GetRandomContainer();
			//	Console.WriteLine(container.GetInfoAboutFreeSpace());
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
				//Console.WriteLine(i);
				if (container.CheckIfBoxFitsInContainer(ListOfBoxes[i]))
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					//Console.WriteLine(box);
					Console.ResetColor();
					container.AddBox(box);
					container.AddBoxesWeight(box);
					inputBox = null;
				}
				else
				{
					//Console.WriteLine(box.GetfailureinfoAbotBox());
					var remainedBox = box;
					Console.ForegroundColor = ConsoleColor.Red;
					//Console.WriteLine("container is full");
					Console.ResetColor();
					AddBoxesIntoContainer(remainingBoxes - i, remainedBox);
					break;
				}
				//Console.WriteLine(container.GetInfoAboutFreeSpace());
			}
		}


		public static int GetRandomInt(int min, int max)
		{
			Random rnd = new Random();
			int num = rnd.Next(min, max);
			return num;
		}

		public static Container GetRandomContainer()
		{
			int width = GetRandomInt(200, 500);
			int height = GetRandomInt(200, 500);
			int depth = GetRandomInt(200, 500);
			int weight = 0;
			Guid guid = Guid.NewGuid();
			return new Container(guid, width, height, depth, weight);
		}
		public static Box GetRandomBox()
		{
			int width = GetRandomInt(50, 150);
			int height = GetRandomInt(50, 150);
			int depth = GetRandomInt(50, 150);
			int weight = GetRandomInt(1, 20);
			Guid guid = Guid.NewGuid();
			return new Box(guid, width, height, depth, weight);
		}
	}
}
