#if UNITY_EDITOR

using System.Threading;
using Cysharp.Threading.Tasks;
using UniMasterLinker.Util;
using UnityEditor;

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
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            // 実装例
            // var baseWeapon = GoogleSheetUtil.GetGameInfo(Constant.Constant.GameMasterSheetURL,
            //     Constant.Constant.BaseWeapon, tokenSource.Token);
            // var materialWeapon = GoogleSheetUtil.GetGameInfo(
            //     Constant.Constant.GameMasterSheetURL, Constant.Constant.MaterialWeapon, tokenSource.Token);
            //
            //
            // var (baseWeaponPramJson, materialWeaponParamJson) =
            //     await UniTask.WhenAll(baseWeapon, materialWeapon;
            //
            // // プレイヤーの初期パラメータAPIクラスを生成
            // UpdateGameMasterAPIClass.CreateParamAPIClassFile(baseWeaponPramJson, Constant.Constant.BaseWeapon);
            // UpdateGameMasterAPIClass.CreateParamAPIClassFile(materialWeaponParamJson, Constant.Constant.MaterialWeapon);
            //
            // //データオブジェクトクラスも存在していない場合は、作成する
            // CreateDataObjectClass.CreateDataObjectClasses(Constant.Constant.BaseWeapon, Constant.Constant.MaterialWeapon,Constant.Constant.Enemy,Constant.Constant.AlchemyTable,Constant.Constant.Element);
            //
            // // データオブジェクト(ScriptableObject)が存在しない場合は作成する
            // CreateDataObject.CreateDataObjectFiles(Constant.Constant.BaseWeapon, Constant.Constant.MaterialWeapon,Constant.Constant.Enemy,Constant.Constant.AlchemyTable,Constant.Constant.Element);
        }
    }
}
#endif
