using System.Collections.Generic;
using System.Reflection;

namespace ContainerTransport.Models
{
	public class Ship
	{
		public List<Container> containersInside { get; }
		// jemno public string name	{}

		public Ship()
		{
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