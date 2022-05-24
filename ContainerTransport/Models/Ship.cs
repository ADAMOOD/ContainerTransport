using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ContainerTransport.Models
{

	public class Ship
	{

		public List<Container> containersInside { get; }
		public string ShipName { get; set; }

		public Ship()
		{
			ShipName = GetShipName();
			containersInside = new List<Container>();
		}

		public string GetShipName()
		{
			var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var stringChars = new char[8];
			var random = new Random();

			for (int i = 0; i < stringChars.Length; i++)
			{
				stringChars[i] = chars[random.Next(chars.Length)];
			}

			return new String(stringChars);
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