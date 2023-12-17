#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace UniMasterLinker.Util
{
    /// <summary>
    /// データオブジェクトを作成するクラス
    /// </summary>
    public static class CreateDataObject
    {
        /// <summary>
        /// データオブジェクトのクラスの作成パス
        /// </summary>
        private const string DataRootPath = "/UniMasterLinker/DataObject/";

        /// <summary>
        /// データオブジェクトのクラスを作成する
        /// </summary>
        public static void CreateDataObjectFiles(params string[] dataObjectNameList)
        {
            foreach (var dataObjectName in dataObjectNameList)
            {
                var objectName = dataObjectName + "DataObject";
                if (IsExistDataObject(objectName)) continue;
                CrateDataObject(objectName);
            }
        }

        /// <summary>
        /// データオブジェクトを作成
        /// </summary>
        /// <param name="dataObjectName"></param>
        private static void CrateDataObject(string dataObjectName)
        {
            var obj = ScriptableObject.CreateInstance(dataObjectName);
            var path = "Assets" + DataRootPath + dataObjectName + ".asset";
            AssetDatabase.CreateAsset(obj, path);
        }
        
        /// <summary>
        /// データオブジェクトが存在するか
        /// </summary>
        /// <param name="dataObjectName"></param>
        private static bool IsExistDataObject(string dataObjectName)
        {
            var path = Application.dataPath + DataRootPath + dataObjectName + ".asset";
            return System.IO.File.Exists(path);
        }
    }
}
#endif