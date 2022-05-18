using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerTransport.Models
{
	internal class Container : BaseObject
	{
		public List<Box> ContainedBoxes { get; set; }

		public Container(Guid cGuid, float cWidth, float cHeight, float cDepth) : base(
			cGuid, cWidth, cHeight, cDepth)
		{
			ContainedBoxes = new List<Box>();
		}

		public bool CheckIfBoxFitsInContainer(Box box)
		{
			if (box.AvailableVolume < this.AvailableVolume)
			{
				return true;
			}
			return false;
		}

		public void AddBox(Box box)
		{
			this.AvailableVolume-= box.Volume;
		}

		public void RemoveBox(Box box)
		{
			this.AvailableVolume += box.Volume;
		}

		public void PrintInfoAboutFreeSpace()
		{
			Console.WriteLine($"Container has {this.AvailableVolume} cm3 of free space");
		}
	
}
}
