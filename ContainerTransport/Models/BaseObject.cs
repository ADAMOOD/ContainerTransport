using System;

namespace ContainerTransport.Models
{
	public abstract class BaseObject
	{
		public Guid Guid { get; private set; }
		public float Width { get; private set; }
		public float Height { get; private set; }
		public float Depth { get; private set; }
		public float Volume { get; private set; }
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