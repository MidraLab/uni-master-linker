<!-- TOC -->
* [UniMasterLinker](#unimasterlinker)
  * [インポート方法](#インポート方法)
  * [使い方](#使い方)
  * [サポートされるプラットフォーム](#サポートされるプラットフォーム)
  * [ライセンス](#ライセンス)
<!-- TOC -->

# UniMasterLinker
UniMasterLinkerは、Google SheetsとUnity間でマスターデータを同期し、自動的にAPIクラスを生成するUnityエディタ拡張機能です。

Unityでのゲーム開発用に設計されており、純粋なC#を使用してマスターデータの管理とAPIクラスの生成を行います。

## インポート方法
このライブラリはUnityPackageとして提供されています。[the release page](https://github.com/MidraLab/uni-master-liker/releases) から最新の.unitypackageファイルをダウンロードし、プロジェクトにインポートしてください。

## 使い方
Google Driveに[MasterSheet](https://docs.google.com/spreadsheets/d/1KezPMdD_5XwFlmQP_AXGpJaX7qSl1HaiPVhfu0qiP48/edit?usp=sharing)からGoogle Sheetのマスターデータをコピーします。

エディタウィンドウを使用してGoogle Sheetsからデータを取得し、動的にAPIクラスを生成します。使用例は以下の通りです：

```csharp
[MenuItem("UniMasterLinker/Update API Classes")]
private static async void UpdateAPIClassFile()
{
// 実装をここに追加
}
```

## サポートされるプラットフォーム
UniMasterLinkerは純粋なC#で書かれているため、Unityがサポートするすべてのプラットフォームがサポートされています。

## ライセンス
[MIT License](https://github.com/MidraLab/uni-master-liker/blob/main/LICENSE)