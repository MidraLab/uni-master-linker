namespace UniMasterLinker.Scripts.Util
{
    /// <summary>
    /// データオブジェクトのクラスを作成するクラス
    /// </summary>
    public class CreateDataObjectClass
    {
        /// <summary>
        /// データオブジェクトのクラスの作成パス
        /// </summary>
        private const string DataRootPath = "/UniMasterLinker/Scripts/DataObject/";

        /// <summary>
        /// データオブジェクトのクラスを作成する
        /// </summary>
        public static void CreateDataObjectClasses(params string[] classNameList)
        {
            foreach (var className in classNameList)
            {
                if (IsExistDataObjectClass(className)) continue;
                CrateDataObjectClass(className);
            }
        }

        /// <summary>
        /// データオブジェクトのクラスが存在するか
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private static bool IsExistDataObjectClass(string className)
        {
            return GenerateClassUtil.IsExistClass(className, DataRootPath);
        }

        /// <summary>
        /// データオブジェクトのクラスを作成
        /// </summary>
        /// <param name="className"></param>
        private static void CrateDataObjectClass(string className)
        {
            var scriptContent = CreateDataObjectScriptContent(className);
            var createFileName = GetCreateFileName(className);
            GenerateClassUtil.CreateScript(createFileName, scriptContent, DataRootPath);
        }
        
        /// <summary>
        /// データオブジェクトのクラス名を取得
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private static string GetCreateFileName(string className)
        {
            return className + "DataObject";
        }

        /// <summary>
        /// データオブジェクトのクラス内容を作成
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        private static string CreateDataObjectScriptContent(string className)
        {
            return $@"using API;
using UnityEngine;

namespace UniMasterLinker.DataObject
{{
    [CreateAssetMenu(fileName = ""{className}"", menuName = ""UniMasterLinker/{className}"", order = 0)]
    public class {className}DataObject : DataObjectBase<{className}Data>
    {{
        
    }}
}}";
        }
    }
}