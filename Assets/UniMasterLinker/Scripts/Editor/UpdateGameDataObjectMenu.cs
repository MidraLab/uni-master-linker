#if UNITY_EDITOR

using System.Threading;
using Cysharp.Threading.Tasks;
using UniMasterLinker.Util;
using UnityEditor;

namespace UniMasterLinker.Editor
{
    /// <summary>
    ///     ゲームデータオブジェクトの更新
    /// </summary>
    public class UpdateGameDataObjectMenu : EditorWindow
    {
        private static CancellationTokenSource _cancellationTokenSource;

        /// <summary>
        ///     ゲームデータオブジェクトの更新
        /// </summary>
        [MenuItem("UniMasterLinker/ゲームデータオブジェクトの更新")]
        private static void UpdateDataObject()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            UpdateGameDataObject.UpdateDataObject(_cancellationTokenSource.Token).Forget();
        }
    }
}
#endif