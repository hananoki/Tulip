#pragma warning disable 8618

using System.ComponentModel;


namespace Tulip {

	public class PropertyCueSheetHeader {

		public CueSheet cue;

		[Category( "Header" )]
		public string TITLE {
			get {
				if( cue == null ) return "";
				return cue.TITLE;
			}
			set {
				if( cue == null ) return;
				cue.TITLE = value;
			}
		}

		[Category( "Header" )]
		public string PERFORMER {
			get {
				if( cue == null ) return "";
				return cue.PERFORMER;
			}
			set {
				if( cue == null ) return;
				cue.PERFORMER = value;
			}
		}

		[Category( "Header" )]
		public string CATALOG {
			get {
				if( cue == null ) return "";
				return cue.CATALOG;
			}
			set {
				if( cue == null ) return;
				cue.CATALOG = value;
			}
		}
	}

}
