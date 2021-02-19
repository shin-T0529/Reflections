using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
public class ExPortData : MonoBehaviour
{

    public int HighScoreData = 8;
    void Start()
    {
    }

    void Update()
    {
        
    }

    public static void SaveText(string filePath, string fileName, string textToSave)
    {
        var combinedPath = Path.Combine(filePath, fileName);
        using (var streamWriter = new StreamWriter(combinedPath))
        {
            streamWriter.WriteLine(textToSave);
        }
    }

    public static void Loadtext(string filePath, string fileName, string str,ref int returni)
    {
        var combinedPath = Path.Combine(filePath, fileName);

        if (File.Exists(combinedPath))
        {
            Debug.Log("読込を行います。" + fileName);
            using (var streamReader = new StreamReader(combinedPath))
            {
                str = streamReader.ReadToEnd();
                returni = int.Parse(str);
                streamReader.Close();
            }
        }
        else
        {
            Debug.Log("defaultを代入します。" + fileName + "は存在しません。\n default：0");
            returni = 0;
        }
        Debug.Log(returni);
    }
    public static string GetInternalStoragePath()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            using (var currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
            using (var getFilesDir = currentActivity.Call<AndroidJavaObject>("getFilesDir"))
            {
                string secureDataPath = getFilesDir.Call<string>("getCanonicalPath");
                return secureDataPath;
            }
#else
        Debug.Log(UnityEngine.Application.persistentDataPath);
        return Application.persistentDataPath;
#endif
    }
}
