using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerTransport
{
  internal class Helpers
  {
	  public static void ClearCurrentConsoleLine(int top)
	  {
		  Console.SetCursorPosition(0, top);
		  for (int i = 0; i < 50; i++)
		  {
			  Console.Write(new string(' ', Console.WindowWidth));
		  }
		  Console.SetCursorPosition(0, 0);
		  Console.SetCursorPosition(0, top);
	  }

	  public static int GetRandomInt(int min, int max)
	  {
		  Random rnd = new Random();
		  int num = rnd.Next(min, max);
		  return num;
	  }
  }
}
