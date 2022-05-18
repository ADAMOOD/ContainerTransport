using System;
using System.Runtime.InteropServices.ComTypes;

namespace ContainerTransport.Models
{
    public class Box:BaseObject
    {
        public float BWeight { get; set; }
        public Box(Guid bGuid, float bWidth,float bHeight, float bDepth,float bWeight) : base(
            bGuid, bWidth, bHeight,  bDepth)
        {
            BWeight=bWeight;
        }

        public override string ToString()
        {
	        return ($"Box width: {Width} height: {Height} depth: {Depth} it has {Volume} cm3");
        }
    }
}