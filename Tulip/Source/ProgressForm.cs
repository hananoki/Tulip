using System;
using System.Windows.Forms;


namespace Tulip {
	public partial class ProgressForm : Form {

		public static ProgressForm instance;

		public ProgressForm() {
			InitializeComponent();
			instance = this;
		}

		private void button1_Click( object sender, EventArgs e ) {
			Close();
		}

		public void Setup( string title, int size ) {
			progressBar1.Minimum = 0;
			progressBar1.Maximum = 100000;
			progressBar1.Value = 0;
			progressBar1.Step = (int) ( ( 100000.0f / size ) + 0.5f );
			//m_size = size;
			this.Text = title;
		}

		//async void ProgressStart() {
		//	await Task.Run( () => {
		//		for( int i = 0; i < 10; i++ ) {
		//			Thread.Sleep( 100 );
		//			SetMessage($"process {i}");
		//			Invoke( new Action( () => {
		//				progressBar1.PerformStep();
		//			} ) );
		//		}
		//		Thread.Sleep( 1000 );
		//	} );
		//	Close();
		//}

		public static void CloseProgress() {
			instance.Invoke( new Action( () => {
				instance.Close();
			} ) );
		}

		public static void PerformStep() {
			instance.Invoke( new Action( () => {
				instance.progressBar1.PerformStep();
			} ) );
		}

		public static void SetMessage( string msg ) {
			instance.Invoke( new Action( () => {
				instance.label1.Text = msg;
			} ) );
		}
	}
}
