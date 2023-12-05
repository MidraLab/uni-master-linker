using UnityEditor;
using UnityEngine;

namespace UniMasterLinker.Editor
{
    /// <summary>
    ///     ゲームマスターのAPIクラスを更新するエディタ拡張
    /// </summary>
    public class UpdateAPIClassMenu : EditorWindow
    {
        /// <summary>
        ///     APIクラスの更新
        /// </summary>
        [MenuItem("UniMasterLinker/APIクラスの更新")]
        private static async void UpdateAPIClassFile()
        {
            // 実装例
            // var playerGameInfo = GoogleSheetUtil.GetGameInfo(Constant.Constant.GameMasterSheetURL,
            //     Constant.Constant.PlayerSheetName);
            //
            // var (playerPramJson) =
            //     await UniTask.WhenAll(playerGameInfo);
            //
            // // プレイヤーの初期パラメータAPIクラスを生成
            // CreateParamAPIClassFile(playerPramJson, Constant.Constant.PlayerSheetName);
            
            // データオブジェクトクラスも存在していない場合は、作成する
            // CreateDataObjectClass.CreateDataObjectClasses("test", "test2");
        }
    }
}