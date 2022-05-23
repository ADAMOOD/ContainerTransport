using System;

namespace ContainerTransport.Models
{
	public abstract class BaseObject
	{
		public Guid Guid { get; }
		public float Width { get; }
		public float Height { get; }
		public float Depth { get; }
		public float Volume { get; }
		public float Weight { get; set; }

		public BaseObject(Guid boxGuid, float width, float height, float depth, float weight)
		{
			Guid = boxGuid;
			Width = width;
			Height = height;
			Height = height;
			Depth = depth;
			Weight = weight;
			Volume = height * width * depth;

		}
	}
}