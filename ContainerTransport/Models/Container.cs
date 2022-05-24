using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContainerTransport.Models
{
	public  class Container : BaseObject
	{
		public static List<IDNumber> IDs = new List<IDNumber>();
		private List<Box> ContainedBoxes { get; set; }
		public float AvailableVolume { get; protected set; }
		public IDNumber IdNumber { get; }

		public Container(Guid cGuid, float cWidth, float cHeight, float cDepth, float weight) : base(
			cGuid, cWidth, cHeight, cDepth, weight)
		{
			ContainedBoxes = new List<Box>();
			AvailableVolume = Volume;
			IdNumber = GetIdNumber(null);
			
		}

		public IDNumber GetIdNumber(IDNumber id)
		{
			if (id == null)
			{
				id = new IDNumber();
			}
			if (CheckIfIdExists(id))
			{
				id = new IDNumber();
			}
			IDs.Add(id);
			return id;
		}

		private bool CheckIfIdExists(IDNumber id)
		{
			if (IDs.Count == null)
			{
				return false;
			}
			return (IDs.Contains(id));
		}

		public List<Box> GetContent()
		{
			return ContainedBoxes.ToList();
		}
		public bool CheckIfBoxFitsInContainer(Box box)
		{
			return box.Volume < this.AvailableVolume;
		}

		public bool AddBox(Box box)
		{
			if (this.AvailableVolume > box.Volume)
			{
				AvailableVolume -= box.Volume;
				ContainedBoxes.Add(box);
				return true;
			}
			return false;
		}

		public bool RemoveBox(Box box)
		{
			if (!ContainedBoxes.Contains(box))
				return false;

			AvailableVolume += box.Volume;
			ContainedBoxes.Remove(box);
			return true;


		}

		public string GetIDNumber()
		{
			return $"{Helpers.GetRandomInt(1, 9)}-{Helpers.GetRandomInt(1, 9)}{Helpers.GetRandomInt(1, 9)})";
		}

		public string GetInfoAboutFreeSpace()
		{
			return $"Container has {this.AvailableVolume} cm3 of free space";
		}

		public void AddBoxesWeight(Box box)
		{
			this.Weight += box.Weight;
		}


	}
}
