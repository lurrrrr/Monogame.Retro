using System;
using libretro.mono;
using libretro.utilities;

namespace RetroConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
#if _WIN64 
			Utilities.AddEnvironmentPaths("..\\..\\..\\cores\\x86_64\\");
#else
			Utilities.AddEnvironmentPaths("..\\..\\..\\cores\\x86\\");
#endif

			Wrapper.Init();
			Console.WriteLine("Press any key to start...");
			Console.ReadKey();
			Wrapper.Run();
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
            
		}
	}
}
