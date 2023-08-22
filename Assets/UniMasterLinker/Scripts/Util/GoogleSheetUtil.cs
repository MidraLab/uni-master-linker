using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace UniMasterLinker.Util
{
    public static class GoogleSheetUtil
    {
        /// <summary>
        ///     ゲーム情報をスプレッドシートから取得
        /// </summary>
        /// <param name="url"></param>
        /// <param name="sheetName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async UniTask<T> GetGameInfo<T>(string url, string sheetName, CancellationToken token)
        {
            var request = UnityWebRequest.Get($"{url}?sheetName={sheetName}");
            await request.SendWebRequest().ToUniTask(cancellationToken: token);
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
        /// <returns></returns>
        public static async UniTask<string> GetGameInfo(string url, string sheetName)
        {
            var request = UnityWebRequest.Get($"{url}?sheetName={sheetName}");
            await request.SendWebRequest();
            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError
                or UnityWebRequest.Result.DataProcessingError)
            {
                Debug.Log("fail to get card info from google sheet");
            }
            else
            {
                var json = request.downloadHandler.text;

                Debug.Log($"data:{json}");
                return json;
            }

            return default;
        }

        /// <summary>
        ///     マスターデータのキーの文字列を取得
        /// </summary>
        /// <returns></returns>
        public static List<string> GetParameterKeyList(string json)
        {
            var parseJson = JObject.Parse(json);
            var gameInfoArray = (JArray)parseJson["gameInfo"];
            var gameInfo = (JObject)gameInfoArray?[0];

            return gameInfo?.Properties().Select(key => key.Name).ToList();
        }

        /// <summary>
        ///     マスターデータのパラメータのタイプの取得
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<string> GetParameterTypeList(string json)
        {
            var parseJson = JObject.Parse(json);
            var gameInfoArray = (JArray)parseJson["gameInfo"];
            var gameInfo = (JObject)gameInfoArray?[0];

            return gameInfo?.Properties().Select(prop => (string)prop.Value["type"]).ToList();
        }

        /// <summary>
        ///     マスターデータのパラメータの説明の取得
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<string> GetParameterDescriptionList(string json)
        {
            var parseJson = JObject.Parse(json);
            var gameInfoArray = (JArray)parseJson["gameInfo"];
            var gameInfo = (JObject)gameInfoArray?[0];

            return gameInfo?.Properties().Select(prop => (string)prop.Value["description"]).ToList();
        }

        /// <summary>
        ///     マスタデータのjsonをAPIをScriptableObjectに変換できる形に変換する
        /// </summary>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T ConvertGameInfo<T>(string json)
        {
            var parsedJson = JObject.Parse(json);
            var gameInfoArray = (JArray)parsedJson["gameInfo"];

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