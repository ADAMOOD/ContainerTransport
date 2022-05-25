using System.Collections.Generic;

namespace ContainerTransport.Models
{
	public class IDNumber
	{

		public int FirstNumber { get; set; }
		public int SecondNumber { get; set; }
		public int ThirdNumber { get; set; }
		public string IdNumber { get;  }

		public IDNumber()
		{
			FirstNumber = Helpers.GetRandomInt(0, 10);
			SecondNumber = Helpers.GetRandomInt(0, 10);
			ThirdNumber = Helpers.GetRandomInt(0, 10);
			IdNumber = $"{FirstNumber}-{SecondNumber}{ThirdNumber}";
		}

		public IDNumber(string id)
		{
			IdNumber= id;
		}

	}
}