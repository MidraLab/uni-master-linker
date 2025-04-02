using UniMasterLinker.Util;
using UnityEngine.Networking;

namespace UniMasterLinker.Extensions
{
    /// <summary>
    ///    UnityWebRequestの拡張メソッド
    /// </summary>
    public static class UnityWebRequestExtensions
    {
        public static UnityWebRequestAsyncOperationAwaiter GetAwaiter(this UnityWebRequestAsyncOperation asyncOperation)
        {
            return new UnityWebRequestAsyncOperationAwaiter(asyncOperation);
        }
    }
}