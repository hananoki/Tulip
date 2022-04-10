
using HananokiLib;
using System;
using System.Threading;
using System.Windows.Forms;


namespace Tulip {

	static class Program {

		[STAThread]
		static void Main( string[] args ) {
			using( var mutex = new Mutex( false, typeof( MainForm ).ToString() ) ) {
				if( mutex.WaitOne( 0, false ) == false ) {
					MessageBox.Show( "[Tulip] instance is already running.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
					return;
				}
				ApplicationConfiguration.Initialize();
				Helper._init();
				if( 0 < args.Length ) {
					Debug.Log( args[ 0 ] );
					Helper.s_appPath = args[ 0 ];
				}
				Application.Run( new MainForm() );
			}
		}
	}
}