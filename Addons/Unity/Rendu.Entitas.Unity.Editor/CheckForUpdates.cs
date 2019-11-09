using System;
using Entitas;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Rendu.Entitas.Unity.Editor
{
    public static class CheckForUpdates
    {
        private const string URL_GITHUB_API_LATEST_RELEASE = "https://api.github.com/repos/sschmid/Entitas-CSharp/releases/latest";
        private const string URL_GITHUB_RELEASES = "https://github.com/sschmid/Entitas-CSharp/releases";
        private const string URL_ASSET_STORE = "http://u3d.as/NuJ";

        [MenuItem("Tools/Entitas/Check for Updates...", false, 10)]
        public static void DisplayUpdates()
        {
            CheckForUpdates.displayUpdateInfo(CheckForUpdates.GetUpdateInfo());
        }

        public static UpdateInfo GetUpdateInfo()
        {
            return new UpdateInfo(CheckForUpdates.GetLocalVersion(), CheckForUpdates.GetRemoteVersion());
        }

        public static string GetLocalVersion()
        {
            return EntitasResources.GetVersion();
        }

        public static string GetRemoteVersion()
        {
            try
            {
                return JsonUtility.FromJson<CheckForUpdates.ResponseData>(CheckForUpdates.requestLatestRelease()).tag_name;
            }
            catch (Exception ex)
            {
            }

            return string.Empty;
        }

        private static string requestLatestRelease()
        {
            string str = string.Empty;
            using (UnityWebRequest unityWebRequest = UnityWebRequest.Get("https://api.github.com/repos/sschmid/Entitas-CSharp/releases/latest"))
            {
                UnityWebRequestAsyncOperation requestAsyncOperation = unityWebRequest.SendWebRequest();
                do
                    ;
                while (!requestAsyncOperation.isDone);
                if (!unityWebRequest.isNetworkError)
                {
                    if (!unityWebRequest.isHttpError)
                        str = requestAsyncOperation.webRequest.downloadHandler.text;
                }
            }

            return str;
        }

        private static void displayUpdateInfo(UpdateInfo info)
        {
            switch (info.updateState)
            {
                case UpdateState.UpToDate:
                    EditorUtility.DisplayDialog("Entitas Update", "Entitas is up to date (" + info.localVersionString + ")", "Ok");
                    break;
                case UpdateState.UpdateAvailable:
                    if (!EditorUtility.DisplayDialog("Entitas Update",
                        string.Format("A newer version of Entitas is available!\n\nCurrently installed version: {0}\nNew version: {1}", (object) info.localVersionString,
                            (object) info.remoteVersionString), "Show in Unity Asset Store", "Cancel"))
                        break;
                    Application.OpenURL("http://u3d.as/NuJ");
                    break;
                case UpdateState.AheadOfLatestRelease:
                    if (!EditorUtility.DisplayDialog("Entitas Update",
                        string.Format("Your Entitas version seems to be newer than the latest release?!?\n\nCurrently installed version: {0}\nLatest release: {1}",
                            (object) info.localVersionString, (object) info.remoteVersionString), "Show in Unity Asset Store", "Cancel"))
                        break;
                    Application.OpenURL("http://u3d.as/NuJ");
                    break;
                case UpdateState.NoConnection:
                    if (!EditorUtility.DisplayDialog("Entitas Update", "Could not request latest Entitas version!\n\nMake sure that you are connected to the internet.\n",
                        "Try again", "Cancel"))
                        break;
                    CheckForUpdates.DisplayUpdates();
                    break;
            }
        }

        private struct ResponseData
        {
            public string tag_name;
        }
    }
}