
using System;


namespace Tulip {
	public class ScopeSound : IDisposable {
		private bool disposedValue;

		public ScopeSound(  ) {
			Utils.PlaySoundJobStart();
		}

		protected virtual void Dispose( bool disposing ) {
			if( !disposedValue ) {
				if( disposing ) {
					// TODO: マネージド状態を破棄します (マネージド オブジェクト)
				}

				// TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
				// TODO: 大きなフィールドを null に設定します
				disposedValue = true;
				Utils.PlaySoundJobFinish();
			}
		}

		// // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
		// ~CueItem()
		// {
		//     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
		//     Dispose(disposing: false);
		// }

		void IDisposable.Dispose() {
			// このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
			Dispose( disposing: true );
			GC.SuppressFinalize( this );
		}
	}
}
