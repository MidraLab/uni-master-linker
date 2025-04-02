using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UniMasterLinker.Extensions;
using UnityEngine;
using UnityEngine.Networking;

namespace UniMasterLinker.Util
{
    /// <summary>
    ///    GoogleSheet(GAS)のユーティリティ
    /// </summary>
    public static class GoogleSheetUtil
    {
        /// <summary>
        ///     ゲーム情報をスプレッドシートから取得
        /// </summary>
        /// <param name="url"></param>
        /// <param name="sheetName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<T> GetGameInfo<T>(string url, string sheetName, CancellationToken token)
        {
            var request = UnityWebRequest.Get($"{url}?sheetName={sheetName}");
            await request.SendWebRequest();
            if (token.IsCancellationRequested)
            {
                request.Abort();
                throw new OperationCanceledException(token);
            }

            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError
                or UnityWebRequest.Result.DataProcessingError)
            {
                Debug.Log("Fail to get card info from Google Sheet");
            }
            else
            {
                var json = request.downloadHandler.text;
                return ConvertGameInfo<T>(json);
            }

            return default;
        }

        /// <summary>
        ///     ゲーム情報をスプレッドシートから取得してstringを返す
        /// </summary>
        /// <param name="url"></param>
        /// <param name="sheetName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<string> GetGameInfo(string url, string sheetName, CancellationToken token)
        {
            var request = UnityWebRequest.Get($"{url}?sheetName={sheetName}");

            await using var registration = token.Register(() => request.Abort(), useSynchronizationContext: false);
            await request.SendWebRequest();

            if (token.IsCancellationRequested)
            {
                // 操作がキャンセルされた場合
                token.ThrowIfCancellationRequested();
            }

            if (request.result == UnityWebRequest.Result.ConnectionError
                || request.result == UnityWebRequest.Result.ProtocolError
                || request.result == UnityWebRequest.Result.DataProcessingError)
            {
                if (request.result == UnityWebRequest.Result.ConnectionError && request.error == "Request aborted")
                {
                    // リクエストがキャンセルされた場合
                    token.ThrowIfCancellationRequested();
                }

                // その他のエラーを処理
                Debug.LogError($"Googleシートからカード情報の取得に失敗しました: {request.error}");
                return default;
            }
            else
            {
                var json = request.downloadHandler.text;
                Debug.Log($"データ取得成功: {json}");
                return json;
            }
        }

        /// <summary>
        ///     マスターデータのキーの文字列を取得
        /// </summary>
        /// <returns></returns>
        public static List<string> GetParameterKeyList(string paramJsonStr)
        {
            var parseJson = JObject.Parse(paramJsonStr);
            var gameInfoArray = (JArray)parseJson["gameInfo"];
            var gameInfo = (JObject)gameInfoArray?[0];

            return gameInfo?.Properties().Select(key => key.Name).ToList();
        }

        /// <summary>
        ///     マスターデータのパラメータのタイプの取得
        /// </summary>
        /// <param name="paramJsonStr"></param>
        /// <returns></returns>
        public static List<string> GetParameterTypeList(string paramJsonStr)
        {
            var parseJson = JObject.Parse(paramJsonStr);
            var gameInfoArray = (JArray)parseJson["gameInfo"];
            var gameInfo = (JObject)gameInfoArray?[0];

            return gameInfo?.Properties().Select(prop => (string)prop.Value["type"]).ToList();
        }

        /// <summary>
        ///     マスターデータのパラメータの説明の取得
        /// </summary>
        /// <param name="paramJsonStr"></param>
        /// <returns></returns>
        public static List<string> GetParameterDescriptionList(string paramJsonStr)
        {
            var parseJson = JObject.Parse(paramJsonStr);
            var gameInfoArray = (JArray)parseJson["gameInfo"];
            var gameInfo = (JObject)gameInfoArray?[0];

            return gameInfo?.Properties().Select(prop => (string)prop.Value["description"]).ToList();
        }

        /// <summary>
        ///     マスタデータのjsonをAPIをScriptableObjectに変換できる形に変換する
        /// </summary>
        /// <param name="paramJsonStr"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T ConvertGameInfo<T>(string paramJsonStr)
        {
            var parsedJson = JObject.Parse(paramJsonStr);
            var gameInfoArray = (JArray)parsedJson["gameInfo"];

            if (gameInfoArray == null)
            {
                throw new NullReferenceException("gameInfoArray is null");
            }

            // Create a new JSON array to hold the converted objects
            var finalArray = new JArray();

            foreach (var gameInfo in gameInfoArray)
            {
                var convertedJson = new JObject();
                foreach (var prop in ((JObject)gameInfo).Properties())
                {
                    convertedJson[prop.Name] = prop.Value["value"];
                }

                // Add the converted object to the final array
                finalArray.Add(convertedJson);
            }

            var finalJson = new JObject
            {
                ["gameInfo"] = finalArray
            };

            // Convert the new JSON object to the desired type
            return JsonUtility.FromJson<T>(finalJson.ToString());
        }
    }
}