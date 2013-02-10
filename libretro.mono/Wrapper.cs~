using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace libretro.mono
{
	
	public static class Wrapper
	{
		const uint RETRO_ENVIRONMENT_SET_ROTATION=1;
		const uint RETRO_ENVIRONMENT_GET_OVERSCAN=2;
		const uint RETRO_ENVIRONMENT_GET_CAN_DUPE=3;
		const uint RETRO_ENVIRONMENT_GET_VARIABLE=4;
		const uint RETRO_ENVIRONMENT_SET_VARIABLES=5;
		const uint RETRO_ENVIRONMENT_SET_MESSAGE=6;
		const uint RETRO_ENVIRONMENT_SHUTDOWN=7;
		const uint RETRO_ENVIRONMENT_SET_PERFORMANCE_LEVEL=8;
		const uint RETRO_ENVIRONMENT_GET_SYSTEM_DIRECTORY=9;
		const uint RETRO_ENVIRONMENT_SET_PIXEL_FORMAT=10;
		const uint RETRO_ENVIRONMENT_SET_INPUT_DESCRIPTORS=11;
		const uint RETRO_ENVIRONMENT_SET_KEYBOARD_CALLBACK=12;


		//public const string corefile = "libretro-0926-mednafen-psx-x86.dll";
		//public const string corefile = "libretro-089-bsnes-compat-x86.dll";
        //public const string corefile = "libretro-test-lex-x86_64.dll";
		public const string corefile = "retro.dll";

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct retro_variable
		{
			public char *key; 
			public char *value; 
		};
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct retro_message
		{
			public char *msg; 
			public uint frames; 
		};

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct retro_game_info
		{
			public char* path; 
			public void *data; 
			byte size; 
			public char* meta; 
		}
		
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct retro_system_info
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
		public struct retro_game_geometry
		{
			public byte base_width; 
			public byte base_height;
			public byte max_width;
			public byte max_height;
			
			public float aspect_ratio; 
		}
		
		[StructLayout(LayoutKind.Sequential)]
		public struct retro_system_timing
		{
			public double fps;
			public double sample_rate; 
		}
		
		[StructLayout(LayoutKind.Sequential)]
		public struct retro_system_av_info
		{
			public retro_game_geometry geometry;
			public retro_system_timing timing;
		}

		//typedef void (*retro_video_refresh_t)(const void *data, unsigned width, unsigned height, size_t pitch);
		public unsafe delegate void RetroVideoRefresh(void *data, uint width, uint  height, uint pitch);

		public unsafe static void RetroVideoRefreshDelegate(void *data, uint width, uint  height, uint pitch)
		{
			return;
		}

		//typedef void (*retro_audio_sample_t)(int16_t left, int16_t right);
		public unsafe delegate void RetroAudioSample(Int16 left, Int16 right);

		public unsafe static void RetroAudioSampleDelegate(Int16 left, Int16 right)
		{
			return;
		}

		//typedef size_t (*retro_audio_sample_batch_t)(const int16_t *data, size_t frames);
		public unsafe delegate void RetroAudioSampleBatch(Int16 *data, uint frames);

		public unsafe static void RetroAudioSampleBatchDelegate(Int16 *data, uint frames)
		{
			return;
		}

		//typedef void (*retro_input_poll_t)(void);
		public unsafe delegate void RetroInputPoll();

		public unsafe static void RetroInputPollDelegate()
		{
			return;
		}

		//typedef int16_t (*retro_input_state_t)(unsigned port, unsigned device, unsigned index, unsigned id);
		public unsafe delegate Int16 RetroInputState(uint port, uint device, uint index, uint id);

		public unsafe static Int16 RetroInputStateDelegate(uint port, uint device, uint index, uint id)
		{
			return 0;
		}

		//typedef bool (*retro_environment_t)(unsigned cmd, void *data);
		public unsafe delegate bool RetroEnvironment(uint cmd, void *data);

		public unsafe static bool RetroEnvironmentDelegate(uint cmd, void *data)
		{	
			switch (cmd)
			{
			case RETRO_ENVIRONMENT_GET_OVERSCAN:
				break;
			case RETRO_ENVIRONMENT_GET_VARIABLE:
				break;
			case RETRO_ENVIRONMENT_SET_VARIABLES:
				break;
			case RETRO_ENVIRONMENT_SET_MESSAGE:
				break;
			case RETRO_ENVIRONMENT_SET_ROTATION:
				break;
			case RETRO_ENVIRONMENT_SHUTDOWN:
				break;
			case RETRO_ENVIRONMENT_SET_PERFORMANCE_LEVEL:
				break;
			case RETRO_ENVIRONMENT_GET_SYSTEM_DIRECTORY:
				break;
			case RETRO_ENVIRONMENT_SET_PIXEL_FORMAT:
				break;
			case RETRO_ENVIRONMENT_SET_INPUT_DESCRIPTORS:
				break;
			case RETRO_ENVIRONMENT_SET_KEYBOARD_CALLBACK:
				break;
			default:
				return false;
			}
			return true;
		}

		[DllImport(corefile)]
		public static extern int retro_api_version();
		
		[DllImport(corefile)]
		public static extern void retro_init();
		
		[DllImport(corefile)]
		public static extern void retro_get_system_info(ref retro_system_info info);

        [DllImport(corefile)]
        public static extern void retro_get_system_av_info(ref retro_system_av_info info);
		
		[DllImport(corefile)]
		public static extern bool retro_load_game(ref retro_game_info game);

		[DllImport(corefile)]
		public static extern void retro_set_video_refresh(RetroVideoRefresh r);

		[DllImport(corefile)]
		public static extern void retro_set_audio_sample(RetroAudioSample r);

		[DllImport(corefile)]
		public static extern void retro_set_audio_sample_batch(RetroAudioSampleBatch r);

		[DllImport(corefile)]
		public static extern void retro_set_input_poll(RetroInputPoll r);

		[DllImport(corefile)]
		public static extern void retro_set_input_state(RetroInputState r);

		[DllImport(corefile)]
		public static extern void retro_set_environment(RetroEnvironment r);

		[DllImport(corefile)]
		public static extern void retro_run();				



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

			RetroEnvironment _environment = new RetroEnvironment(RetroEnvironmentDelegate);
			RetroVideoRefresh _videoRefresh = new RetroVideoRefresh(RetroVideoRefreshDelegate);
			RetroAudioSample _audioSample = new RetroAudioSample(RetroAudioSampleDelegate);
			RetroAudioSampleBatch _audioSampleBatch = new RetroAudioSampleBatch(RetroAudioSampleBatchDelegate);
			RetroInputPoll _inputPoll = new RetroInputPoll(RetroInputPollDelegate);
			RetroInputState _inputState = new RetroInputState(RetroInputStateDelegate);
			retro_set_environment(_environment);
			retro_set_video_refresh(_videoRefresh);
			retro_set_audio_sample(_audioSample);
			retro_set_audio_sample_batch(_audioSampleBatch);
			retro_set_input_poll(_inputPoll);
			retro_set_input_state(_inputState);

            retro_init();
			retro_game_info gameInfo = new retro_game_info();
            retro_load_game(ref gameInfo);



			retro_system_av_info av = new retro_system_av_info();
			retro_get_system_av_info(ref av);

            
		}
		public static void Run()
		{
			//retro_run();
		}
	}
}

