using System;
using System.Runtime.InteropServices.ComTypes;

namespace ContainerTransport.Models
{
	public class Box : BaseObject
	{
		

		public Box(Guid bGuid, float bWidth, float bHeight, float bDepth, float bWeight) : base(
			bGuid, bWidth, bHeight, bDepth,bWeight)
		{
			
		}

		public override string ToString()
		{
			return $"Box width: {Width} height: {Height} depth: {Depth} weight:{Weight} it has {Volume} cm3";
		}

		public string GetfailureinfoAbotBox()
		{
			return $"{this.ToString()} CANNOT BE PLACED IN A CONTAINER!";
		}
	}
}