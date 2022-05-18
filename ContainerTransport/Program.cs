using System;
using System.Collections.Generic;
using System.Globalization;
using ContainerTransport.Models;

namespace ContainerTransport
{
	internal class Program
	{
		public const int AmountOfBoxes = 100;
		public static List<Box> ListOfBoxes = new List<Box>();
		public static List<Container> ListOfContainers = new List<Container>();

		static void Main(string[] args)
		{
			AddBoxesIntoContainer(AmountOfBoxes, null);
			Console.ForegroundColor = ConsoleColor.Yellow;
			foreach (var con in ListOfContainers)
			{
				Console.WriteLine(con.GetContent().Count);
			}
			Console.ResetColor();
		}

		public static void AddBoxesIntoContainer(int remainingBoxes, Box inputBox)
		{
			//var container = new Container(new Guid(), 100, 100, 100);
			var container = GetRandomContainer();
			Console.WriteLine(container.GetInfoAboutFreeSpace());
			ListOfContainers.Add(container);
			for (int i = 0; i < remainingBoxes; i++)
			{
				Box box;
				if (inputBox == null)
				{
					box = GetRandomBox();
					//box = new Box(new Guid(), 70, 70, 70, 5);
				}
				else
				{
					box = inputBox;
				}
				ListOfBoxes.Add(box);
				Console.WriteLine(i);
				if (container.CheckIfBoxFitsInContainer(ListOfBoxes[i]))
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine(box);
					Console.ResetColor();
					container.AddBox(box);
					inputBox = null;
				}
				else
				{
					//var newContainer = new Container(new Guid(), 100, 100, 100);
					Console.WriteLine($"{box} CANNOT BE PLACED IN A CONTAINER!");
					var remainedBox = box;
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("container is full");
					Console.ResetColor();
					AddBoxesIntoContainer(remainingBoxes - i, remainedBox);
					//ListOfContainers.Add(container);
					break;
				}
				Console.WriteLine(container.GetInfoAboutFreeSpace()); ;
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
