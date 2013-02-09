using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace libretro.mono
{
	
	public static class Wrapper
	{

		//private const string corefile = "libretro-0926-mednafen-psx-x86.dll";
		private const string corefile = "libretro-089-bsnes-compat-x86.dll";


		[DllImport(corefile)]
		private static extern int retro_api_version();
		
		[DllImport(corefile)]
		private static extern void retro_init();
		
		[DllImport(corefile)]
		private static extern void retro_get_system_info(ref retro_system_info info);

		[DllImport(corefile)]
		private static extern void retro_set_environment(RetroEnvironmentDelegate r);

		[DllImport(corefile)]
		private static extern void retro_load_game(ref retro_game_info game);

		[DllImport(corefile)]
		private static extern void retro_run();

		unsafe delegate bool RetroEnvironmentDelegate(byte cmd, void *data);
		
		[StructLayout(LayoutKind.Sequential)]
		private unsafe struct retro_game_info
		{
			public string path; // Path to game, UTF-8 encoded. Usually used as a reference.
			// May be NULL if rom was loaded from stdin or similar.
			// retro_system_info::need_fullpath guaranteed that this path is valid.
			public void *data; // Memory buffer of loaded game. Will be NULL if need_fullpath was set.
			//size_t size; // Size of memory buffer.
			public char *meta; // String of implementation specific meta-data.
		};
		
		[StructLayout(LayoutKind.Sequential)]
		private unsafe struct retro_system_info
		{

			public char* library_name;
			public char* library_version;
			public char* valid_extensions;
			
			[MarshalAs (UnmanagedType.U1)]
			public bool need_fullpath;
			[MarshalAs(UnmanagedType.U1)]
			public bool block_extract;
		}

		static RetroEnvironmentDelegate environ_cb;



		public unsafe static void Init ()
		{
			int _apiVersion = retro_api_version();
			retro_system_info info = new retro_system_info();
			retro_get_system_info(ref info);
	
			string _coreName = Marshal.PtrToStringAnsi((IntPtr)info.library_name);
			string _coreVersion = Marshal.PtrToStringAnsi((IntPtr)info.library_version);
			string _validExtensions = Marshal.PtrToStringAnsi((IntPtr)info.valid_extensions);
			bool _requiresFullPath = info.need_fullpath;
			bool _blockExtract = info.block_extract;

			Console.WriteLine("API Version: " + _apiVersion);
			Console.WriteLine("Core Name: " + _coreName);
			Console.WriteLine("Core Version: " + _coreVersion);
			Console.WriteLine("Valid Extensions: " + _validExtensions);
			Console.WriteLine("Block Extraction: " + _blockExtract);
			Console.WriteLine("Requires Full Path: " + _requiresFullPath);

			retro_game_info gameInfo = new retro_game_info();
			gameInfo.path = "Y:\\mmx.sfc";



			retro_set_environment(environ_cb);

			//retro_init();
			retro_load_game(ref gameInfo);

			
		}
		public static void Run()
		{
			retro_run ();
		}
	}
}

