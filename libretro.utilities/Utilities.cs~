using System;

namespace libretro.utilities
{
	public static class Utilities
	{
		public static void AddEnvironmentPaths(string paths)
		{
			string path = Environment.GetEnvironmentVariable("PATH") ?? string.Empty;
			path += ";" + string.Join(";", paths);
			
			Environment.SetEnvironmentVariable("PATH", path);
		}
	
	}
}

