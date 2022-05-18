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
		public float AvailableVolume { get; protected set; }
		public BaseObject(Guid boxGuid, float width, float height, float depth)
		{
			Guid = boxGuid;
			Width = width;
			Height = height;
			Height = height;
			Depth = depth;
			AvailableVolume = Volume = height * width * depth;

		}
	}
}