using System.Collections.Generic;

namespace ContainerTransport.Models
{
	public class IDNumber
	{
		
		public int FirstNumber { get; set; }
		public int SecondNumber { get; set; }
		public int ThirdNumber { get; set; }
		public string IdNumber { get; protected set; }

		public IDNumber()
		{
			FirstNumber = Program.GetRandomInt(0,10);
			SecondNumber = Program.GetRandomInt(0,10);
			ThirdNumber = Program.GetRandomInt(0,10);
			IdNumber = $"{FirstNumber}-{SecondNumber}{ThirdNumber}";
		}
	
}
}