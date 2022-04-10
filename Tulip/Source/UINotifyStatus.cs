
using HananokiLib;

namespace Tulip {
	public static class UINotifyStatus {
		public static void Info( string text, int interval = 5000 ) {
			MainForm.instance.m_statusBarMessage.setNotifyText( text, StatusBarMessage.NotifyType.Info, interval );
		}

		public static void Warning( string text ) {
			MainForm.instance.m_statusBarMessage.setNotifyText( text, StatusBarMessage.NotifyType.Warning, 10000 );
		}

		public static void Error( string text ) {
			MainForm.instance.m_statusBarMessage.setNotifyText( text, StatusBarMessage.NotifyType.Error, 10000 );
		}
	}
}
