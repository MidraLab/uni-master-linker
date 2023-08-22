using System.Collections.Generic;
using UnityEngine;

namespace UniMasterLinker.DataObject
{
    /// <summary>
    ///     Unity向けのマスターデータのデータオブジェクトのベースクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataObjectBase<T> : ScriptableObject
    {
        [SerializeField] private List<T> data;

        /// <summary>
        ///     データの設定
        /// </summary>
        /// <param name="value"></param>
        public void SetData(List<T> value)
        {
            data = value;
        }

        /// <summary>
        ///     データの取得
        /// </summary>
        public List<T> Data => data;
    }
}