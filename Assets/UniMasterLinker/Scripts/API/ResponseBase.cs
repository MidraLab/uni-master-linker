using System;
using System.Collections.Generic;

namespace UniMasterLinker.API
{
    /// <summary>
    ///     マスターデータから取得する際にレスポンスBaseクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class ResponseBase<T>
    {
        public List<T> gameInfo;
    }
}