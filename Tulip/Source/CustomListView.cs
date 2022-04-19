#pragma warning disable 8618

using HananokiLib;
using System.Linq;
using System.Windows.Forms;


namespace Tulip {
	//////////////////////////////////////////////////////////////////////////////////
	public class ListView_Files : HListView<ListViewItem_Files> {

	}


	//////////////////////////////////////////////////////////////////////////////////
	public class ListViewItem_Files : ListViewItem {
		public ListViewItem_Files( string fullpath ) : base( fullpath.GetBaseName() ) {
			cueSheet = new CueSheet( fullpath );
			if( fullpath.ChangeExtension( ".jpg" ).IsExistsFile() ) {
				coverArtFilePath = fullpath.ChangeExtension( ".jpg" );
			}
		}

		public CueSheet cueSheet;
		public string coverArtFilePath;

		public string[] GetFiles() {
			var files = DirectoryUtils.GetFiles( cueSheet.filePath.GetDirectoryName(), "*" );
			return files.Where( x => x.GetBaseName() == cueSheet.filePath.GetBaseName() ).ToArray();
		}
	}


	//////////////////////////////////////////////////////////////////////////////////
	public class ListView_CueSheetRow : HListView<ListViewItem> {
		public void Set( ListViewItem_Files item ) {
			m_items = item.cueSheet.tracks
				.Select( x =>
					new ListViewItem( new string[] { x.TRACK, x.TITLE, x.PERFORMER } ) )
				.ToList();
		}
	}
	//public class ListViewItem_CueSheetRow : ListViewItem {
	//}

}
