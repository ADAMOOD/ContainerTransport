using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ContainerTransport.Models
{

	public class Ship
	{
		public static List<string> NamesOfShips = new List<string>();
		public List<Container> containersInside { get; }
		public string ShipName { get; set; }

		public Ship()
		{
			ShipName = GetShipName();
			containersInside = new List<Container>();
		}

		public string GetShipName()
		{
			var chars = "abcdefghijklmnopqrstuvwxyz";
			var stringChars = new char[3];
			var random = new Random();

			for (int i = 0; i < stringChars.Length; i++)
			{
				stringChars[i] = chars[random.Next(chars.Length)];
			}
			var name = new String(stringChars);
			NamesOfShips.Add(name);
			return name;
		}
		public bool AddContainer(Container container)
		{

			if (containersInside.Contains(container))
			{
				return false;
			}
			containersInside.Add(container);
			return true;
		}
	}
}