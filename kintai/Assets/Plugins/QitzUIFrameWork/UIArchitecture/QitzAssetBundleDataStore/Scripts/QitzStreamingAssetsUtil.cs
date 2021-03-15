using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Qitz.UISystem
{
    public class QitzStreamingAssetsUtil 
    {
        public IEnumerator CopyStreamingAssetsFilesToPersistentDataPath(List<string>fileNameList,Action onEndCallBack)
        {
            foreach (var file in fileNameList)
            {
                yield return SaveAssetBundleFromUrl($"{Application.streamingAssetsPath}/{file}", Application.persistentDataPath);
            }
            onEndCallBack?.Invoke();
            yield return null;
        }

        //urlから指定フォルダへファイルをコピーする
        IEnumerator SaveAssetBundleFromUrl(string url, string saveFolderPath)
        {
            string fileName = Path.GetFileName(url);
            var www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();
            var _byte = www.downloadHandler.data;
            if (www != null && www.error != null && www.error != "")
            {
                Debug.Log(www.error);
            }
            try
            {
                Debug.Log("ファイル書き込み処理:" + saveFolderPath);
                if (!Directory.Exists(saveFolderPath))
                {
                    //DirectoryInfoオブジェクトを作成する
                    Debug.Log("フォルダ作成=" + saveFolderPath);
                    DirectoryInfo di = new DirectoryInfo(saveFolderPath);
                    di.Create();

                }

                Debug.Log("ファイル書き込み:" + saveFolderPath + "/" + fileName);
                File.WriteAllBytes(saveFolderPath + "/" + fileName, _byte);

                if (www != null)
                {
                    www.Dispose();
                }
                www = null;
                System.GC.Collect();
                Resources.UnloadUnusedAssets();
                //ガベコレやっときたい
            }
            catch (Exception e)
            {
                Debug.Log("ファイル解凍失敗=" + e);
            }
            yield return null;
        }

    }
}