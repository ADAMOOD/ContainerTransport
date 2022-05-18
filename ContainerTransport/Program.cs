using System;
using System.Collections.Generic;
using System.Globalization;
using ContainerTransport.Models;

namespace ContainerTransport
{
	internal class Program
	{
		public const int AmountOfBoxes=100;
		public static List<Box> ListOfBoxes = new List<Box>();
		public static List<Container> ListOfContainers = new List<Container>();

		static void Main(string[] args)
		{
			var container = GetRandomContainer();
			container.PrintInfoAboutFreeSpace();
			AddBoxesIntoContainer(container, AmountOfBoxes);

		}

		public static void AddBoxesIntoContainer(Container container, int remainingBoxes)
		{
			for (int i = 0; i < AmountOfBoxes; i++)
			{
				var box = GetRandomBox();
				ListOfBoxes.Add(box);
				Console.WriteLine(box);
				if (container.CheckIfBoxFitsInContainer(ListOfBoxes[i]))
				{
					container.Volume -= box.Volume;
					
				}
				else
				{
					ListOfContainers.Add(container);
					var newContainer = GetRandomContainer();
					Console.ForegroundColor= ConsoleColor.Red;
					Console.WriteLine("container is full");
					Console.ResetColor();
					AddBoxesIntoContainer(newContainer,remainingBoxes-i);
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
            int width = GetRandomInt(50,150);
            int height = GetRandomInt(50, 150);
            int depth = GetRandomInt(50, 150);
	        int weight=GetRandomInt(1, 20);
	        Guid guid = Guid.NewGuid();
	        return new Box(guid, width, height, depth, weight);
        }
	}
}
