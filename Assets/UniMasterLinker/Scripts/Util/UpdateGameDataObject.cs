#if UNITY_EDITOR
using System.Threading;
using Cysharp.Threading.Tasks;
using UniMasterLinker.API;
using UniMasterLinker.DataObject;
using UnityEditor;

namespace UniMasterLinker.Util
{
    /// <summary>
    ///     ゲームデータオブジェクトの更新
    /// </summary>
    public class UpdateGameDataObject
    {
        /// <summary>
        ///     ゲームデータオブジェクトの更新(外部から呼び出し用)
        /// </summary>
        /// <param name="token"></param>
        public static async UniTask UpdateDataObject(CancellationToken token)
        {
            // 実装例

            // ゲームデータオブジェクトの更新
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        /// <summary>
        ///     ゲームデータオブジェクトの更新
        /// </summary>
        /// <param name="responseBase"></param>
        /// <typeparam name="T"></typeparam>
        private static DataObjectBase<T> UpdateDataObject<T>(ResponseBase<T> responseBase)
        {
            var data = AssetDatabase.LoadAssetAtPath<DataObjectBase<T>>(Constant.Constant.DataObjectPath +
                                                                        GetDataObjectName(responseBase));
            data.SetData(responseBase.gameInfo);

            EditorUtility.SetDirty(data);
            return data;
        }

        /// <summary>
        ///     レスポンスクラス名からデータオブジェクト名を取得する
        /// </summary>
        /// <param name="responseClassName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static string GetDataObjectName<T>(T responseClassName)
        {
            return responseClassName.GetType().Name.Replace("Response", "DataObject.asset");
        }
    }
}
#endif