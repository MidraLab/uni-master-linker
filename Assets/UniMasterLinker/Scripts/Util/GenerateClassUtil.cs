using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace UniMasterLinker.Util
{
    /// <summary>
    ///    クラスの生成を行うUtilityクラス
    /// </summary>
    public class GenerateClassUtil
    {
#if UNITY_EDITOR

        /// <summary>
        ///     スクリプトファイルを生成
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        /// <param name="dataRootPath"></param>
        public static void CreateScript(string fileName, string content, string dataRootPath)
        {
            var createPath = Application.dataPath + "/" + dataRootPath + "/" + fileName + ".cs";

            using (var writer = new StreamWriter(createPath, false))
            {
                writer.WriteLine(content);
            }

            AssetDatabase.Refresh();
        }
#endif

        /// <summary>
        /// 自動生成クラスファイルが存在するか
        /// </summary>
        /// <param name="className"></param>
        /// <param name="dataRootPath"></param>
        /// <returns></returns>
        /// <exception></exception>
        public static bool IsExistClass(string className, string dataRootPath)
        {
            var path = Application.dataPath + dataRootPath + className + "DataObject" + ".cs";
            return File.Exists(path);
        }
    }
}