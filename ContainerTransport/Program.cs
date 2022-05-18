using System;
using System.Collections.Generic;
using System.Globalization;
using ContainerTransport.Models;

namespace ContainerTransport
{
	internal class Program
	{
		public const int AmountOfBoxes = 4;
		public static List<Box> ListOfBoxes = new List<Box>();
		public static List<Container> ListOfContainers = new List<Container>();

		static void Main(string[] args)
		{
			//var container = GetRandomContainer();
			var container = new Container(new Guid(), 100, 100, 100);
			container.PrintInfoAboutFreeSpace();

			AddBoxesIntoContainer(container, AmountOfBoxes);
			Console.ForegroundColor = ConsoleColor.Yellow;
			foreach (var con in ListOfContainers)
			{
				Console.WriteLine(con.ContainedBoxes.Count);
			}
			Console.ResetColor();
		}

		public static void AddBoxesIntoContainer(Container container, int remainingBoxes)
		{
			for (int i = 0; i < remainingBoxes; i++)
			{
				//var box = GetRandomBox();
				var box = new Box(new Guid(), 70, 70, 70, 5);
				ListOfBoxes.Add(box);
				Console.WriteLine(box);
				//Console.WriteLine(i);
				if (container.CheckIfBoxFitsInContainer(ListOfBoxes[i]))
				{
					container.AddBox(box);
					container.ContainedBoxes.Add(box);
					
				}
				else
				{
					//var newContainer = GetRandomContainer();
					var newContainer = new Container(new Guid(), 100, 100, 100);
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("container is full");
					Console.ResetColor();
					ListOfContainers.Add(container);
					AddBoxesIntoContainer(newContainer, remainingBoxes - i);
					ListOfContainers.Add(newContainer);
					break;
				}
				
				container.PrintInfoAboutFreeSpace();
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
			Guid guid = Guid.NewGuid();
			return new Container(guid, width, height, depth);
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
