#pragma warning disable 8600
#pragma warning disable 8602
#pragma warning disable 8603
#pragma warning disable 8605 // null の可能性がある値をボックス化解除しています。
#pragma warning disable 8618

using HananokiLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tulip {

	public static class Utils {

		public static void PlaySoundJobStart() => sound.play( "start" );
		public static void PlaySoundJobFinish() => sound.play( "finish" );

		/////////////////////////////////////////
		async public static Task<int> ExecCDArcive( ListViewItem_Files[] cues ) {

			var progress = new ProgressForm();
			progress.SetCenterLocation( MainForm.instance );
			progress.Show();
			progress.Setup( "CDアーカイブ", cues.Length + 1 );

			var result = await Task.Run<int>( () => {
				int r = 0;
				int num = 0;
				Parallel.For( 0, cues.Length, Helper.s_parallelOptions, i => {
					num++;
					int r2 = InternalExecCDArcive( cues[ i ] );
					if( r2 != 0 ) {
						r = r2;
					}
				} );
				return r;
			} );

			Thread.Sleep( 1000 );

			if( result != 0 ) {
				if( 0 < result ) {
					UINotifyStatus.Info( "処理をキャンセルしました" );
				}
				else {
					UINotifyStatus.Error( "致命的なエラーが発生しました" );
				}

				ProgressForm.CloseProgress();
				return result;
			}

			var dir = cues[ 0 ].cueSheet.filePath.GetDirectoryName();
			Environment.CurrentDirectory = dir;

			var baseName = cues[ 0 ].cueSheet.filePath.GetBaseName();

			baseName = baseName.replace( @"(\s?\[?Disc.*)", "" );
			List<string> files = new List<string>();

			foreach( var c in cues ) {
				var ff = Directory.GetFiles( c.cueSheet.filePath.GetDirectoryName(), "*", System.IO.SearchOption.TopDirectoryOnly )
					.Where( a => a.Contains( c.cueSheet.filePath.GetBaseName() ) )
					.Where( a => !a.Contains( ".wav" ) )
					.ToArray();

				files.AddRange( ff );
			}

			foreach( var a in ( new string[] { "DVD", "特典DVD", "ブックレット" } ) ) {
				if( Directory.Exists( a ) ) {
					files.Add( a );
				}
			}

			var str = string.Join( "\n", files.Select( a => "> " + a.GetFileName() ).ToArray() );

			DialogResult dr = MessageBox.Show(
						string.Format( "アーカイブ対象 (*.flac)\n\n" + str + "\nよろしいですか？" ),
						"確認",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question );
			if( dr == DialogResult.No ) {
				ProgressForm.CloseProgress();
				return -2;
			}

			var zipfile = baseName + ".zip";
			//UINotifyStatus.Info( "zip圧縮中... " + zipfile );
			ProgressForm.SetMessage( $"zip圧縮中... {zipfile}" );

			var s = new StringBuilder();
			s.Append( $"a -y -mx=0 {zipfile.Quote()} {string.Join( " ", files.Select( a => a.Quote() ).ToArray() )}" );

			await Task.Run( () => {
				shell.startProcess( "7z", s.ToString() );
				ProgressForm.PerformStep();
			} );

			//UINotifyStatus.Info( @"「複数DiscPack」が完了しました" );

			ProgressForm.SetMessage( $"CDアーカイブ: 完了しました" );
			Thread.Sleep( 1000 );
			ProgressForm.CloseProgress();

			return 0;
		}


		/////////////////////////////////////////
		static int InternalExecCDArcive( ListViewItem_Files c ) {

			var wavFilePath = c.cueSheet.filePath.ChangeExtension( ".wav" );
			var dir = wavFilePath.GetDirectoryName();
			Environment.CurrentDirectory = dir;

			var fname = wavFilePath.GetBaseName();
			var cueFile = wavFilePath.ChangeExtension( ".cue" );

			var outputDir = dir.ChangeShortPath();

			string newfilepath = wavFilePath.ChangeExtension( ".flac" );

			//{
			var zfile = newfilepath.ChangeExtension( ".zip" );
			if( File.Exists( zfile ) ) {
				File.Delete( zfile );
			}
			//}

			var logFile = fname + ".log";
			var jpgFile = c.coverArtFilePath;//fname + ".jpg";
			var jpgOpt = $"--picture={jpgFile.Quote()}";

			if( !jpgFile.IsExistsFile() ) {
				DialogResult dialogResult = MessageBox.Show(
					String.Format( "coverArtFilePath が見つかりませんでした。\n画像の埋め込み「なし」で継続しますがよろしいですか？" ),
					"Info",
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question );
				if( dialogResult == DialogResult.No ) {
					return 1;
				}
				jpgOpt = "";
				jpgFile = "";
			}

			ProgressForm.SetMessage( $"flacでエンコード中... [{wavFilePath.GetFileName()}]" );

			var cueOpt = $"--tag-from-file=\"CUESHEET={fname}.cue\"";
			var opt = $"-8 --replay-gain {jpgOpt} {cueOpt} \"{fname}.wav\" -o {newfilepath.Quote()}";

			try {
				shell.startProcess( "flac", opt );
			}
			catch( Exception e ) {
				Debug.Exception( e );
				Debug.Error( $"flac {opt}" );
				return -1;
			}

			ProgressForm.PerformStep();

#if false
				var s = new StringBuilder();
				s.Append( "a -y -mx=0 {0} {1}".format( newfilepath.changeExt( "zip" ).quote(), newfilepath.quote() ) );

				//string[] addFile = { logFile, jpgFile, cueFile.getFileName() };

				var addFile = ( new string[] { logFile, jpgFile, cueFile.getFileName() } )
					.Where( a => !string.IsNullOrEmpty( a ) )
					.Where( a => File.Exists( a ) )
					.Select( a => a.quote() )
					.ToArray()
					;

				s.Append( " " );
				s.Append( string.Join( " ", addFile ) );

				string[] addFolder = { "DVD", "特典DVD", "ブックレット" };
				foreach( var a in addFolder ) {
					if( Directory.Exists( a ) ) {
						s.Append( " " );
						s.Append( a.quote() );
					}
				}
				Utils.setNotifyText( $"zip圧縮中... [{zfile.getFileName()}]" );
				shell.startProcess( "7z", s.ToString() );
#endif
			return 0;
		}


		/////////////////////////////////////////
		async public static Task<int> ExecConv( CueSheet cueSheet ) {
			var progress = new ProgressForm();
			progress.SetCenterLocation( MainForm.instance );

			progress.Show();
			progress.Setup( cueSheet.filePath.GetFileName().ChangeExtension( ".wav" ), cueSheet.Count + 1 );
			var filepath = cueSheet.filePath;

			return await Task.Run<int>( () => {
				var wavFilePath = filepath.ChangeExtension( ".wav" );
				var dir = wavFilePath.GetDirectoryName();
				Environment.CurrentDirectory = dir;


				var outputDir = dir.ChangeShortPath();
				var wavdir = outputDir + "\\" + filepath.GetBaseName() + "_WAV";


				ProgressForm.SetMessage( $"結合wavをcueで分割する" );

				// 結合wavをcueで分割する
				SplitWav( wavdir, wavFilePath );

				ProgressForm.PerformStep();

				// 分割WavをCueSheetを元にリネーム
				ApplyWavDirCueSheet( wavdir, wavFilePath );

				var fdirM4A = $@"{outputDir}\{filepath.GetBaseName()}";
				fs.mkDir( fdirM4A );

				if( File.Exists( filepath.ChangeExtension( "jpg" ) ) ) {
					File.Copy( filepath.ChangeExtension( "jpg" ), fdirM4A + "\\cover.jpg", true );
					File.Copy( filepath.ChangeExtension( "jpg" ), wavdir + "\\cover.jpg", true );
				}

				ProgressForm.SetMessage( $"エンコードを開始します..." );
				Thread.Sleep( 100 );

				string[] m4a = Directory.GetFiles( fdirM4A, "*.m4a", SearchOption.TopDirectoryOnly );
				if( m4a.Length == 0 ) {
					string[] files2 = Directory.GetFiles( wavdir, "*.wav", SearchOption.TopDirectoryOnly );
					int now = 0;
					Parallel.For( 0, files2.Length, Helper.s_parallelOptions, i => {
						//num++;
						//UINotifyStatus.Info( $"エンコード処理中... ({num}/{files2.Length})", interval: 0 );
						//ProgressForm.SetMessage( $"エンコード処理中... ({num}/{files2.Length})" );

						string output = fdirM4A + "\\" + files2[ i ].GetFileName().ChangeExtension( "m4a" );
						shell.startProcess(
							"neroAacEnc",
							$"-lc -q 1.00 -if {files2[ i ].Quote()} -of {output.Quote()}" );
						shell.startProcess( "mp3gain", $"/r /c /p {output.Quote()}" );

						Interlocked.Increment( ref now );
						ProgressForm.PerformStep();
						ProgressForm.SetMessage( $"エンコード処理中... ({now}/{files2.Length})" );
					} );
				}
				else {
					for( int i = 0; i < m4a.Length; i++ ) ProgressForm.PerformStep();
				}

				//UINotifyStatus.Info( $"トラック毎に変換: 完了しました" );
				ProgressForm.SetMessage( $"トラック毎に変換: 完了しました" );
				Thread.Sleep( 1000 );

				shell.start( "foobar2000" );
				shell.startProcess( "foobar2000", $"\"/command:New playlist\"" );
				//var cue = (CueSheet) treeView1.SelectedNode.Tag;
				//var m4aFolder = $@"{cue.filePath.getDirectoryName()}\{cue.filePath.getBaseName()}";
				shell.startProcess( "foobar2000", $"/add {fdirM4A.Quote()}" );

				ProgressForm.CloseProgress();

				return 0;
			} );
		}



		/// <summary>
		/// 結合wavをcueで分割する
		/// </summary>
		static void SplitWav( string outputDir, string filepath ) {

			var fdir = outputDir;

			fs.mkDir( fdir );

			var fname = filepath.GetFileName();

			string[] files = Directory.GetFiles( fdir, "*.wav", System.IO.SearchOption.TopDirectoryOnly );

			// フォルダ内にwavが存在していた場合は事前分割とみなす
			if( 1 <= files.Length ) {
				Debug.Warning( $"フォルダ内にwavが存在していた場合は事前分割とみなす: {filepath}" );
				return;
			}

			var command3 = "split -O never -d {0} -f {1} -o wav {2}".Format(
				fdir.Quote(),
				fname.ChangeExtension( "cue" ).Quote(),
				fname.Quote() );

			shell.startProcess( "shntool", command3 );
			//StartProcess( "shntool", command3 );
		}


		/// <summary>
		/// 分割WavをCueSheetを元にリネーム
		/// </summary>
		/// <param name="filepath"></param>z
		static void ApplyWavDirCueSheet( string outputDir, string filepath ) {
			var fdir = outputDir;

			var cue = new CueSheet();
			cue.Read( filepath.ChangeExtension( "cue" ) );

			string[] wavs = Directory.GetFiles( fdir, "*.wav", System.IO.SearchOption.TopDirectoryOnly );

			// split-track00
			// CDによっては分割時に出てくる（隠しトラックとかかも）
			// これを込みでCDDBに投げると取得ミスするので間引く
			wavs = wavs.Where( a => !a.Contains( "split-track00" ) ).ToArray();

			//bool allow = false;
			if( 0 == wavs.Length || 0 == cue.Count ) {
				//allow = true;

				//MessageProcessStatus( "分割" );
				return;
			}
			if( wavs.Length != cue.Count ) {
				//MessageProcessComplete( "error" );
				return;
			}

			// リネーム用のリストがない場合は終了
			if( cue.Count == 0 ) return;

			foreach( var f in wavs ) {

				foreach( Match match in Regex.Matches( f, "(split-track)([0-9]+)" ) ) {
					try {
						int i = int.Parse( match.Groups[ 2 ].Value );
						var track = cue[ i - 1 ];
						string title = track.TITLE;
						title = title.Replace( "/", "／" );
						title = title.Replace( "?", "？" );
						title = title.Replace( "\\", "￥" );
						title = title.Replace( "*", "＊" );
						title = title.Replace( ":", "：" );
						title = title.Replace( "\"", "”" );
						title = title.Replace( "<", "＜" );
						title = title.Replace( ">", "＞" );
						title = title.Replace( "|", "｜" );

						//try {
						//	TagInfo tag1 = Tsukikage.DllPInvoke.MP3Tag.MP3Infp.LoadTag( f );
						//	tag1.Album = cue.m_title;
						//	tag1.Artist = track.performer;
						//	tag1.Title = track.title;
						//	tag1.Genre = cue.m_genre;
						//	tag1.CreationDate = cue.m_date;
						//	tag1.TrackNumber = i.ToString();
						//	Tsukikage.DllPInvoke.MP3Tag.MP3Infp.SaveTagInfoUnicode( tag1 );
						//}
						//catch( Exception e ) {
						//	MainWindowHelper.SetExceptionLog( e );
						//}

						var ss = Regex.Replace( f, "(split-track[0-9]+)", match.Groups[ 2 ].Value + " " + title );
						//	println( titleList[i-1] );
						//	var invalidChars = Path.GetInvalidFileNameChars();
						//	var removed = string.Concat(original.Where(c => !invalidChars.Contains(c)));
						File.Move( f, ss );
					}
					catch( Exception e ) {
						//MainWindowHelper.SetExceptionLog( e );
						Debug.Exception( e );
					}
				}
			}
		}


		public static void startFilePath( string filepath ) {
			if( string.IsNullOrEmpty( filepath ) ) return;

			System.Diagnostics.Process.Start( $"{filepath.Quote()}" );
		}
	}
}



