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
			if (box.Volume < this.Volume)
			{
				return true;
			}

			return false;
		}

		public void PrintInfoAboutFreeSpace()
		{
			Console.WriteLine($"Container has {this.Volume} cm3 of free space");
		}
	
}
}
