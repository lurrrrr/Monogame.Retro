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
			Console.WriteLine ("Hello libretro");
			Wrapper.Init();
            
		}
	}
}
