#pragma warning disable 8600
#pragma warning disable 8602
#pragma warning disable 8604
#pragma warning disable 8618

using HananokiLib;
using PropertyGridExtensionHacks;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Tulip {
	public partial class MainForm : Form {
		public static MainForm instance;

		public Config m_config;

		public StatusBarMessage m_statusBarMessage;

		PropertyCueSheetHeader myAppSettings;


		public static Config config => instance.m_config;


		/////////////////////////////////////////
		///
		public MainForm() {
			InitializeComponent();
			instance = this;
		}

		//////////////////////////////////////////////////////////////////////////////////
		#region MainForm

		/////////////////////////////////////////
		void MainForm_Load( object sender, EventArgs e ) {
			//Font = SystemFonts.IconTitleFont;
			Text = $"{Text} {Helper.version}";
			pictureBox_CoverArt.AllowDrop = true;

			m_statusBarMessage = new StatusBarMessage( this, toolStripStatusLabel1 );

			m_config = Config.Load();
			RollbackWindowLocation();

			EnablePanel( panelRoot );

			var msgTxtBox = "ファイル名を入力するか、ファイルをD&Dしてください";
			var txtBox = new TextBoxGuide[] {
				textBox_neroAacEnc,
				textBox_mp3gain,
				textBox_shntool,
				textBox_flac,
				textBox_7z,
				textBox_foobar2000,
				};
			for( int i = 0; i < txtBox.Length; i++ ) {
				txtBox[ i ].Tag = i;
				txtBox[ i ].Init( msgTxtBox, ( self, inTxt ) => {
					config.toolPaths[ (int) self.Tag ] = inTxt;
					return inTxt;
				} );
				txtBox[ i ].SetText( config.toolPaths[ i ] );
			}

			UpdateEnvironmentPath();

			myAppSettings = new PropertyCueSheetHeader();
			propertyGrid1.SelectedObject = myAppSettings;

			int splitterPosition = propertyGrid1.GetInternalLabelWidth();
			propertyGrid1.MoveSplitterTo( 100 );

			sound.addData( "start", config.seStart );
			sound.addData( "finish", config.seFinish );

			OpenFolder( config.lastOpenFolderPath );
		}


		/////////////////////////////////////////
		void MainForm_FormClosing( object sender, FormClosingEventArgs e ) {
			BackupWindowLocation();

			m_config.Save();
		}


		/////////////////////////////////////////
		void MainForm_KeyUp( object sender, KeyEventArgs e ) {
			if( e.KeyCode == Keys.F5 ) {
				OpenFolder( config.lastOpenFolderPath );
			}
			if( e.KeyCode == Keys.F11 ) {
				LogWindow.Visible = !LogWindow.Visible;
			}
		}

		#endregion



		//////////////////////////////////////////////////////////////////////////////////
		#region pictureBox_CoverArt

		/////////////////////////////////////////
		void pictureBox_CoverArt_DragEnter( object sender, DragEventArgs e ) {
			if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) {
				// ドラッグ中のファイルやディレクトリの取得
				var drags = (string[]) e.Data.GetData( DataFormats.FileDrop );

				e.Effect = DragDropEffects.None;

				foreach( var d in drags ) {
					if( !File.Exists( d ) ) return;
					var ext = d.GetExtension();
					if( ext != ".jpg" && ext != ".png" && ext != ".bmp" && ext != ".webp" ) return;
				}

				e.Effect = DragDropEffects.Link;
			}
		}


		/////////////////////////////////////////
		void pictureBox_CoverArt_DragDrop( object sender, DragEventArgs e ) {

			if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) {
				string[] files = (string[]) e.Data.GetData( DataFormats.FileDrop );

				var col = listView_Files.SelectedIndices;
				if( col.Count == 0 ) {
				}
				else if( col.Count == 1 ) {
					var a = listView_Files.m_items[ col[ 0 ] ];

					if( files[ 0 ].GetExtension() == ".webp" ) {
						using( var img = new ImageMagick.MagickImage( files[ 0 ] ) ) {
							img.Write( a.cueSheet.filePath.ChangeExtension( ".jpg" ) );
						}
					}
					else {
						fs.mv( files[ 0 ], a.cueSheet.filePath.ChangeExtension( ".jpg" ) );
					}
					a.coverArtFilePath = a.cueSheet.filePath.ChangeExtension( ".jpg" );
					pictureBox_CoverArt.ImageLocation = a.coverArtFilePath;
				}
				else {
				}
			}
		}

		#endregion



		//////////////////////////////////////////////////////////////////////////////////
		#region listView_Files

		/////////////////////////////////////////
		void listView_Files_DragEnter( object sender, DragEventArgs e ) {
			if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) {
				// ドラッグ中のファイルやディレクトリの取得
				var drags = (string[]) e.Data.GetData( DataFormats.FileDrop );

				e.Effect = DragDropEffects.None;

				var paths = drags.Select( x => $@"{x.GetDirectoryName()}\{x.GetBaseName()}" ).Distinct().ToList();

				foreach( var d in paths ) {
					var cueFile = $@"{d}.cue";
					var wavFile = $@"{d}.wav";
					if( !cueFile.IsExistsFile() ) continue;
					if( !wavFile.IsExistsFile() ) continue;
				}

				if( e.KeyState.Has( 0x4 ) ) {
					e.Effect = DragDropEffects.Copy;
				}
				else {
					e.Effect = DragDropEffects.Link;
				}
			}
		}


		/////////////////////////////////////////
		void listView_Files_DragDrop( object sender, DragEventArgs e ) {
			if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) {
				string[] drags = (string[]) e.Data.GetData( DataFormats.FileDrop );

				OpenFolder( drags[ 0 ].GetDirectoryName() );
				config.lastOpenFolderPath = drags[ 0 ].GetDirectoryName();

				listView_Files.m_items[ 0 ].Selected = true;
				SetCueFile( listView_Files.m_items[ 0 ] );
			}
		}


		/////////////////////////////////////////
		void listView_Files_AfterLabelEdit( object sender, LabelEditEventArgs e ) {
			if( e.Label.IsEmpty() ) {
				e.CancelEdit = true;
				return;
			}
			var files = listView_Files.GetSelectItem().GetFiles();
			foreach( var f in files ) {
				fs.mv( f, $@"{f.GetDirectoryName()}\{e.Label}{f.GetExtension()}" );
			}

			OpenFolder( config.lastOpenFolderPath );
		}


		/////////////////////////////////////////
		void listView_Files_SelectedIndexChanged( object sender, EventArgs e ) {
			var lstView = (ListView) sender;

			var col = lstView.SelectedIndices;
			if( col.Count == 0 ) {
			}
			else if( col.Count == 1 ) {
				var a = listView_Files.m_items[ col[ 0 ] ];
				SetCueFile( a );
			}
			else {
			}
		}

		#endregion



		//////////////////////////////////////////////////////////////////////////////////
		#region toolStrip

		/////////////////////////////////////////
		async void toolStripButton_CDArcive_Click( object sender, EventArgs e ) {
			using( new ScopeSound() ) {
				await Utils.ExecCDArcive( listView_Files.GetSelectItems() );
			}
		}


		/////////////////////////////////////////
		async void toolStripButton_ConvM4A_Click( object sender, EventArgs e ) {
			if( listView_Files.SelectedIndices.Count == 0 ) {
				UINotifyStatus.Warning( "ファイルを選択してください" );
				return;
			}
			using( new ScopeSound() ) {
				var c = listView_Files.m_items[ listView_Files.SelectedIndices[ 0 ] ].cueSheet;
				await Utils.ExecConv( c );
			}
		}


		/////////////////////////////////////////
		void toolStripButton_Refresh_Click( object sender, EventArgs e ) {
			OpenFolder( config.lastOpenFolderPath );
		}


		/////////////////////////////////////////
		void toolStripButton3_Click( object sender, EventArgs e ) {
			EnablePanel( panelSettings );
		}


		/////////////////////////////////////////
		void toolStripButton2_Click( object sender, EventArgs e ) {
			EnablePanel( panelRoot );
			UpdateEnvironmentPath();
		}


		#endregion


		/////////////////////////////////////////
		/// <summary>
		/// Googleで検索
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Search_ToolStripMenuItem_Click( object sender, EventArgs e ) {
			//Application.op
			var item = listView_Files.GetSelectItem();
			//var ss = item.Text.Split( " " );
			string urlEnc = Uri.EscapeDataString( item.Text );
			//foreach(var s in ss)
			Debug.Log( urlEnc );
			var pi = new System.Diagnostics.ProcessStartInfo() {
				FileName = $"https://www.google.com/search?q={urlEnc }",
				UseShellExecute = true,
			};

			System.Diagnostics.Process.Start( pi );
		}
	}
}
