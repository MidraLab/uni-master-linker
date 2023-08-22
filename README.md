
# UniMasterLinker
UniMasterLinker is a Unity editor extension that synchronizes master data between Google Sheets and Unity and automatically generates API classes.

Designed for game development in Unity, it offers management of master data and generation of API classes using pure C#.

## Import Method
This library is provided as a UnityPackage. Download the latest `.unitypackage` file from [the release page](https://github.com/MidraLab/uni-master-liker/releases) and import it into your project.

## How to Use
1. Copy Master Data for Google Sheet from [MasterSheet](https://docs.google.com/spreadsheets/d/1KezPMdD_5XwFlmQP_AXGpJaX7qSl1HaiPVhfu0qiP48/edit?usp=sharing) to your Google Drive.

2.  Use the editor window to retrieve data from Google Sheets and dynamically generate API classes. A sample usage is as follows:

```csharp
[MenuItem("UniMasterLinker/Update API Classes")]
private static async void UpdateAPIClassFile()
{
    // Add implementation here
}
```

## Supported Platforms
All platforms supported by Unity are supported, as UniMasterLinker is written in pure C#.

## License
[MIT License](https://github.com/MidraLab/uni-master-liker/blob/main/LICENSE)