#pragma warning disable 8625

using HananokiLib;
using ImageMagick;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Tulip {
	public partial class MainForm : Form {

		/////////////////////////////////////////
		void RollbackWindowLocation() {
			Location = new Point( m_config.x, m_config.y );
			Width = m_config.width;
			Height = m_config.height;
		}


		/////////////////////////////////////////
		void BackupWindowLocation() {
			m_config.x = Location.X;
			m_config.y = Location.Y;
			m_config.width = Width;
			m_config.height = Height;
		}


		/////////////////////////////////////////
		void UpdateEnvironmentPath() {
			shell.SetProcessEnvironmentPath(
				string.Join( ";", config.toolPaths.Select( x => x.GetDirectoryName() ).ToArray() ) );
		}


		/////////////////////////////////////////
		void EnablePanel(Panel panel) {
			panelRoot.Visible = false;
			panelSettings.Visible = false;

			panel.Visible = true;
		}

		/////////////////////////////////////////
		void OpenFolder( string folderPath ) {
			if( !folderPath.IsExistsDirectory() ) return;
			var files = DirectoryUtils.GetFiles( folderPath, "*.cue" );
			RegisterFiles( files );
		}


		/////////////////////////////////////////
		void RegisterFiles( string[] files ) {
			listView_Files.ClearItems();

			foreach( var f in files ) {
				var item = new ListViewItem_Files( f );
				listView_Files.m_items.Add( item );
			}
			listView_Files.ApplyVirtualListSize();

			foreach( ColumnHeader ch in listView_Files.Columns ) {
				ch.Width = -1;
			}
		}


		/////////////////////////////////////////
		void SetCueFile( ListViewItem_Files cueItem ) {
			listView_cueSheetRow.ClearItems();

			if( cueItem != null ) {
				listView_cueSheetRow.Set( cueItem );
				pictureBox_CoverArt.ImageLocation = cueItem.coverArtFilePath;
				myAppSettings.cue = cueItem.cueSheet;
				propertyGrid1.Refresh();
			}
			else {
				pictureBox_CoverArt.ImageLocation = "";
				myAppSettings.cue = null;
				propertyGrid1.Refresh();
			}

			listView_cueSheetRow.ApplyVirtualListSize();
		}
	}
}
