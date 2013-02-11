using System;
using libretro.mono;
using libretro.utilities;

namespace RetroConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Utilities.AddEnvironmentPaths("..\\..\\..\\cores\\");
			Wrapper.Init();
			Wrapper.Run();
			Console.WriteLine("Press any key...");
            
		}
	}
}
