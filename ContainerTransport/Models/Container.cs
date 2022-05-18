using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContainerTransport.Models
{
	internal class Container : BaseObject
	{
		private List<Box> ContainedBoxes { get; set; }

		public Container(Guid cGuid, float cWidth, float cHeight, float cDepth) : base(
			cGuid, cWidth, cHeight, cDepth)
		{
			ContainedBoxes = new List<Box>();
		}

		public List<Box> GetContent()
		{
			return ContainedBoxes.ToList();
		}
		public bool CheckIfBoxFitsInContainer(Box box)
		{
			return box.AvailableVolume < this.AvailableVolume;

		}

		public void AddBox(Box box)
		{
			AvailableVolume -= box.Volume;
			ContainedBoxes.Add(box);
		}

		public void RemoveBox(Box box)
		{
			AvailableVolume += box.Volume;
		}

		public string GetInfoAboutFreeSpace()
		{
			return $"Container has {this.AvailableVolume} cm3 of free space";
		}

	}
}
