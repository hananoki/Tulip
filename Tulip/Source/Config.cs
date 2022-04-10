#pragma warning disable 8618

using HananokiLib;
using System.Collections.Generic;

namespace Tulip {

	enum Tool {
		NeroDigitalAudio,
		Mp3Gain,
		SHNTool,
		Flac,
		SevenZip,
		Foobar2000,
		Max,
	}

	public class Config {
		public int width = 800;
		public int height = 600;
		public int x;
		public int y;

		public string lastOpenFolderPath;

		public List<string> toolPaths;
		public string seStart;
		public string seFinish;


		/////////////////////////////////////////
		public static Config Load() {
			var config = new Config();
			Helper.ReadJson( ref config, Helper.configPath );
			if( config.toolPaths == null ) {
				config.toolPaths = new List<string>();
			}
			while( config.toolPaths.Count < (int) Tool.Max ) {
				config.toolPaths.Add( "" );
			}

			return config;
		}


		/////////////////////////////////////////
		public void Save() {
			Helper.WriteJson( this );
		}
	}
}
