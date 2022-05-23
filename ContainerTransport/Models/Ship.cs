using System.Collections.Generic;
using System.Reflection;

namespace ContainerTransport.Models
{

	public class Ship
	{

	public List<Container> containersInside { get; }
	//public string ShipName { get; set; }

		public Ship(string name)
		{
			//ShipName = name;
			containersInside=new List<Container>();
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