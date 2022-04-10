#pragma warning disable 8600
#pragma warning disable 8602
#pragma warning disable 8618

using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HananokiLib;


namespace Tulip {
	public class CueSheet {
		public class Track {
			public string TRACK;
			public string TITLE;
			public string PERFORMER;
			public string ISRC;
			public int min = 0;
			public int sec = 0;
			public int frm = 0;
		}

		public string filePath = "";

		public string GENRE = "";
		public string DATE = "";
		public string DISCID = "";


		public string CATALOG = "";
		public string TITLE = "";
		public string PERFORMER = "";
		public string FILE = "";

		public Track[] tracks;


		public Track this[ int i ] => this.tracks[ i ];

		public int Count => tracks.Length;


		/////////////////////////////////////////
		public CueSheet() { }


		/////////////////////////////////////////
		public CueSheet( string filePath ) => Read( filePath );


		/////////////////////////////////////////
		public void Read( string filePath ) {
#if NET6_0_OR_GREATER
			Encoding.RegisterProvider( CodePagesEncodingProvider.Instance );
#endif
			Read( filePath, Encoding.GetEncoding( "shift_jis" ) );
		}


		/////////////////////////////////////////
		public void Read( string filePath, Encoding encoding ) {
			if( !filePath.IsExistsFile() ) throw new FileNotFoundException( "FileNotFound", filePath );

			this.filePath = filePath;

			var lst = new List<Track>();

			Track currentTrack = null;

			foreach( var s in File.ReadAllLines( filePath, encoding ) ) {
				if( s.StartsWith( "REM" ) ) {
					if( s.match( "^REM GENRE +(.*)", ( m ) => {
						GENRE = m[ 1 ].Value;
					} ) ) continue;
					if( s.match( "^REM DATE +(.*)", ( m ) => {
						DATE = m[ 1 ].Value;
					} ) ) continue;
					if( s.match( "^REM DISCID +(.*)", ( m ) => {
						DISCID = m[ 1 ].Value;
					} ) ) continue;
				}

				if( s.match( "^TITLE \"(.*)\"", ( m ) => {
					TITLE = m[ 1 ].Value;
				} ) ) continue;
				if( s.match( "^FILE \"(.*)\"", ( m ) => {
					FILE = m[ 1 ].Value;
				} ) ) continue;
				if( s.match( "^PERFORMER +\"(.*)\"", ( m ) => {
					PERFORMER = m[ 1 ].Value;
				} ) ) continue;
				if( s.match( "^CATALOG (.*)", ( m ) => {
					CATALOG = m[ 1 ].Value;
				} ) ) continue;


				if( s.match( "^  TRACK ([0-9][0-9])", ( m ) => {
					currentTrack = new Track();
					lst.Add( currentTrack );
					currentTrack.TRACK = m[ 1 ].Value;
					currentTrack.PERFORMER = PERFORMER;
				} ) ) continue;
				if( s.match( "^    TITLE +\"(.*)\"", ( m ) => {
					currentTrack.TITLE = m[ 1 ].Value;
				} ) ) continue;
				if( s.match( "^    PERFORMER +\"(.*)\"", ( m ) => {
					currentTrack.PERFORMER = m[ 1 ].Value;
				} ) ) continue;
				if( s.match( "^    ISRC +(.*)", ( m ) => {
					currentTrack.ISRC = m[ 1 ].Value;
				} ) ) continue;

			}
			tracks = lst.ToArray();
		}


		/////////////////////////////////////////
		public bool IsValid() {
			if( tracks == null ) return false;
			if( Count == 0 ) return false;

			return true;
		}


		/////////////////////////////////////////
		public void setAudioInfo( int n, string min, string sec, string frm ) {
			if( tracks[ n ] == null ) {
				tracks[ n ] = new Track();
			}
			var t = tracks[ n ];
			t.min = Convert.ToInt32( min );
			t.sec = Convert.ToInt32( sec );
			t.frm = Convert.ToInt32( frm );
		}


		/////////////////////////////////////////
		public void makeFormat() {
			for( int i = 1; i < tracks.Length; ++i ) {
				var ms1 = tracks[ i ].frm;
				var ms2 = tracks[ i - 1 ].frm;
				var ss1 = tracks[ i ].sec;
				var ss2 = tracks[ i - 1 ].sec;
				var mm1 = tracks[ i ].min;
				var mm2 = tracks[ i - 1 ].min;
				var ms3 = ms1 + ms2;
				if( 100 <= ms3 ) {
					ms3 -= 100;
					ss2 += 1;
				}
				var ss3 = ss1 + ss2;
				if( 60 <= ss3 ) {
					ss3 -= 60;
					mm2 += 1;
				}
				var mm3 = mm1 + mm2;
				//console.log( "+  {0}:{1}:{2} ", m1, m2, m3 );
				tracks[ i ].min = mm3;
				tracks[ i ].sec = ss3;
				tracks[ i ].frm = ms3;
			}
			for( int i = tracks.Length - 1; 1 <= i; --i ) {
				tracks[ i ] = tracks[ i - 1 ];
			}
			tracks[ 0 ] = new Track();
		}


		/////////////////////////////////////////
		public void write( string filename ) {
			using( var w = new StreamWriter( filename, false, Encoding.GetEncoding( "shift_jis" ) ) ) {
				if( GENRE != "" ) {
					w.WriteLine( "REM GENRE {0}", GENRE );
				}
				if( GENRE != "" ) {
					w.WriteLine( "REM DATE {0}", DATE );
				}
				w.WriteLine( "PERFORMER \"{0}\"", PERFORMER );
				w.WriteLine( "TITLE \"{0}\"", TITLE );
				w.WriteLine( "FILE \"{0}\" WAVE", filename.GetFileName().ChangeExtension( "wav" ) );
				foreach( var t in tracks.Select( ( v, i ) => new { v, i } ) ) {
					int min = 0;
					int sec = 0;
					int frm = 0;
					min = t.v.min;
					sec = t.v.sec;
					frm = (int) ( (float) t.v.frm * 0.75f );
					if( 75 <= frm ) {
						frm = 0;
						sec += 1;
					}
					if( 60 <= sec ) {
						sec = 0;
						min += 1;
					}
					w.WriteLine( "  TRACK {0:D2} AUDIO", t.i + 1 );
					if( t.v.TITLE.Contains( "\"" ) ) {
						w.WriteLine( "    TITLE {0}".Format( t.v.TITLE ) );
					}
					else {
						w.WriteLine( "    TITLE \"{0}\"".Format( t.v.TITLE ) );
					}
					w.WriteLine( "    PERFORMER \"{0}\"".Format( t.v.PERFORMER ) );
					w.WriteLine( "    INDEX 01 {0:D2}:{1:D2}:{2:D2}", min, sec, frm );
				}
			}
		}
	}
}
