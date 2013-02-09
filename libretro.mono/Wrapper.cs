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

		[StructLayout(LayoutKind.Sequential)]
		private unsafe struct retro_game_info
		{
			public string path; 
			public void *data; 
			byte size; 
			public char *meta; 
		}
		
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
		
		[StructLayout(LayoutKind.Sequential)]
		private struct retro_game_geometry
		{
			public byte base_width; 
			public byte base_height;
			public byte max_width;
			public byte max_height;
			
			public float aspect_ratio; 
		}
		
		[StructLayout(LayoutKind.Sequential)]
		private struct retro_system_timing
		{
			public double fps;
			public double sample_rate; 
		}
		
		[StructLayout(LayoutKind.Sequential)]
		private struct retro_system_av_info
		{
			public retro_game_geometry geometry;
			public retro_system_timing timing;
		}

		//typedef void (*retro_video_refresh_t)(const void *data, unsigned width, unsigned height, size_t pitch);
		unsafe delegate void RetroVideoRefresh(void *data, uint width, uint  height, uint pitch);

		public unsafe static void RetroVideoRefreshDelegate(void *data, uint width, uint  height, uint pitch)
		{
			return;
		}

		//typedef void (*retro_audio_sample_t)(int16_t left, int16_t right);
		unsafe delegate void RetroAudioSample(Int16 left, Int16 right);

		public unsafe static void RetroAudioSampleDelegate(Int16 left, Int16 right)
		{
			return;
		}

		//typedef size_t (*retro_audio_sample_batch_t)(const int16_t *data, size_t frames);
		unsafe delegate void RetroAudioSampleBatch(Int16 *data, uint frames);

		public unsafe static void RetroAudioSampleBatchDelegate(Int16 *data, uint frames)
		{
			return;
		}

		//typedef void (*retro_input_poll_t)(void);
		unsafe delegate void RetroInputPoll();

		public unsafe static void RetroInputPollDelegate()
		{
			return;
		}

		//typedef int16_t (*retro_input_state_t)(unsigned port, unsigned device, unsigned index, unsigned id);
		unsafe delegate Int16 RetroInputState(uint port, uint device, uint index, uint id);

		public unsafe static Int16 RetroInputStateDelegate(uint port, uint device, uint index, uint id)
		{
			return 0;
		}

		[DllImport(corefile)]
		private static extern int retro_api_version();
		
		[DllImport(corefile)]
		private static extern void retro_init();
		
		[DllImport(corefile)]
		private static extern void retro_get_system_info(ref retro_system_info info);

        [DllImport(corefile)]
        private static extern void retro_get_system_av_info(ref retro_system_av_info info);
		
		[DllImport(corefile)]
		private static extern void retro_load_game(ref retro_game_info game);

		[DllImport(corefile)]
		private static extern void retro_set_video_refresh(RetroVideoRefresh r);

		[DllImport(corefile)]
		private static extern void retro_set_audio_sample(RetroAudioSample r);

		[DllImport(corefile)]
		private static extern void retro_set_audio_sample_batch(RetroAudioSampleBatch r);

		[DllImport(corefile)]
		private static extern void retro_set_input_poll(RetroInputPoll r);

		[DllImport(corefile)]
		private static extern void retro_set_input_state(RetroInputState r);

		[DllImport(corefile)]
		private static extern void retro_run();				



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

			RetroVideoRefresh _videoRefresh = new RetroVideoRefresh(RetroVideoRefreshDelegate);
			RetroAudioSample _audioSample = new RetroAudioSample(RetroAudioSampleDelegate);
			RetroAudioSampleBatch _audioSampleBatch = new RetroAudioSampleBatch(RetroAudioSampleBatchDelegate);
			RetroInputPoll _inputPoll = new RetroInputPoll(RetroInputPollDelegate);
			RetroInputState _inputState = new RetroInputState(RetroInputStateDelegate);



			//retro_game_info gameInfo = new retro_game_info();
			//gameInfo.path = "Y:\\mm8.cue";
			//retro_load_game(ref gameInfo);
			//retro_system_av_info av = new retro_system_av_info();
			//retro_get_system_av_info(ref av);
			//retro_init();
		}
		public static void Run()
		{
			//retro_run();
		}
	}
}

