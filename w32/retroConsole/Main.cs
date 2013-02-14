using System;
using libretro.mono;
using libretro.utilities;

    
namespace RetroConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            string path="..\\..\\..\\..\\..\\cores\\x86_64\\";
            //string path = "..\\..\\..\\..\\..\\cores\\x86\\";
            
			
            Utilities.AddEnvironmentPaths(path);
			Wrapper.Init();
			Console.WriteLine("Press any key to start...");
			Console.ReadKey();
			Wrapper.Run();
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
            
		}
	}
}
