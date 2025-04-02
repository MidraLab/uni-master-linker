using System;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;

namespace UniMasterLinker.Util
{
    /// <summary>
    /// UnityWebRequestAsyncOperationのawaiter
    /// </summary>
    public class UnityWebRequestAsyncOperationAwaiter : INotifyCompletion
    {
        /// <summary>
        /// UnityWebRequestAsyncOperation
        /// </summary>
        private readonly UnityWebRequestAsyncOperation _asyncOperation;

        /// <summary>
        /// 完了したかどうか
        /// </summary>
        public bool IsCompleted => _asyncOperation.isDone;

        public UnityWebRequestAsyncOperationAwaiter(UnityWebRequestAsyncOperation asyncOperation)
        {
            _asyncOperation = asyncOperation;
        }

        public void GetResult()
        {
            // NOTE: 結果はUnityWebRequestからアクセスできるので、ここで返す必要性は無い
        }

        public void OnCompleted(Action continuation)
        {
            _asyncOperation.completed += _ => { continuation(); };
        }
    }
}