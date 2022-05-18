using System;

namespace ContainerTransport.Models
{
    public abstract class BaseObject
    {
        public Guid Guid { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }
        public float Volume { get; set; }
        public BaseObject(Guid boxGuid,float width,float height,float depth)
        {
            Guid=boxGuid;
            Width=width;
            Height=height;
            Height = height;
            Depth = depth;
            Volume = height * width * depth;
        }
    }
}