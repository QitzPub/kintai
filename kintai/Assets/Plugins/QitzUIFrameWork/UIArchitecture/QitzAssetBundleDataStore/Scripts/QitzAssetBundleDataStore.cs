using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;
using UnityEngine.Networking;

namespace Qitz.UISystem
{
    public interface IQitzAssetBundleDataStore
    {
        Sprite GetSpriteFromAssetBundle(string assetName);
        Texture2D GetTexture2DFromAssetBundle(string assetName);
        List<String> CachedAssetFullNameList { get; }
        void ClearAllCashe();
    }
    public class QitzAssetBundleDataStore: IQitzAssetBundleDataStore
    {
        List<AssetBundle> assetBundleCacheList = new List<AssetBundle>();
        public List<String> CachedAssetFullNameList => assetBundleCacheList.SelectMany(ab => ab.GetAllAssetNames()).ToList();
        public List<String> CachedAssetNameList => CachedAssetFullNameList.Select(af=>Path.GetFileName(af)).ToList();
        public List<String> CachedAssetBaseNameList => CachedAssetNameList.Select(af => Path.GetFileNameWithoutExtension(af)).ToList();
        public bool IsLoadedAssetBundles => assetBundleCacheList.Count != 0;

        List<Sprite> cachedSpriteList;
        public List<Sprite> CachedSpriteList
        {
            get
            {
                if (cachedSpriteList == null)
                {
                    cachedSpriteList = CachedAssetNameList.Where(an => an.IndexOf(".png") != -1).Select(an => GetSpriteFromAssetBundle(an)).ToList();
                }
                return cachedSpriteList;
            }
        }
        List<AudioClip> cachedAudioClipList;
        public List<AudioClip> CachedAudioClipList
        {
            get
            {
                if (cachedAudioClipList == null)
                {
                    cachedAudioClipList = CachedAssetNameList.Where(an => an.IndexOf(".mp3") != -1).Select(an => GetAudioClipFromAssetBundle(an)).ToList();
                }
                return cachedAudioClipList;
            }
        }

        public QitzAssetBundleDataStore(bool loadFromAssetsFolder = true)
        {
            Caching.ClearCache();
            AssetBundle.UnloadAllAssetBundles(true);
            if (loadFromAssetsFolder)
            {
                CacheAllAssetBundlesInFolder();
            }
        }

        public QitzAssetBundleDataStore(string assetBundleSavedFolderPath)
        {

            Caching.ClearCache();
            AssetBundle.UnloadAllAssetBundles(true);
            CacheAssetBundlesFromFolderPath(Application.streamingAssetsPath+"/"+ assetBundleSavedFolderPath);
            CacheAssetBundlesFromFolderPath(Application.persistentDataPath + "/" + assetBundleSavedFolderPath);
        }

        public bool ExistAssetInCashe(string assetName)
        {
            return CachedAssetBaseNameList.Contains(assetName);
        }

        public bool Contains(string assetBundleName)
        {
            return assetBundleCacheList.Select(ac => ac.name == assetBundleName).Count() >= 1;
        }

        public void ClearAllCashe()
        {
            assetBundleCacheList = null;
            cachedSpriteList = null;

        }

        public bool ExistAssetBundleInAssetsFolder(string assetBundleName)
        {
            DirectoryInfo di_1 = new System.IO.DirectoryInfo(Application.streamingAssetsPath);
            FileInfo[] files_1 = di_1.GetFiles("*.unity3d", System.IO.SearchOption.AllDirectories);
            DirectoryInfo di_2 = new System.IO.DirectoryInfo(Application.persistentDataPath);
            FileInfo[] files_2 = di_2.GetFiles("*.unity3d", System.IO.SearchOption.AllDirectories);
            var _list = files_1.ToList();
            _list.AddRange(files_2.ToList());
            assetBundleName = Path.GetFileNameWithoutExtension(assetBundleName);
            return _list.Select(f => Path.GetFileNameWithoutExtension(f.Name)).ToList().Contains(assetBundleName);
        }


        //void ChasheAssetBundleFromAssetBundleName(string assetBundleName)
        //{
        //    ChasheAssetBundleFromAssetBundleName(assetBundleName, Application.streamingAssetsPath);
        //    if (Contains(assetBundleName)) return;
        //    ChasheAssetBundleFromAssetBundleName(assetBundleName, Application.persistentDataPath);
        //    Debug.Assert(!Contains(assetBundleName), "指定フォルダ以下にデータが存在しません");
        //}


        //void ChasheAssetBundleFromAssetBundleName(string assetBundleName, string folderPath)
        //{
        //    if (Contains(assetBundleName))
        //    {
        //        Debug.Log("指定のアセットバンドルはすでにキャッシュされています");
        //        return;
        //    }

        //    DirectoryInfo di = new System.IO.DirectoryInfo(folderPath);
        //    FileInfo[] files = di.GetFiles(assetBundleName + ".unity3d", System.IO.SearchOption.AllDirectories);
        //    bool existFile = files != null && files.Length >= 1;
        //    if (existFile)
        //    {
        //        assetBundleCacheList.Add(AssetBundle.LoadFromFile(files.FirstOrDefault().FullName));
        //        return;
        //    }
        //}

        public Sprite GetSpriteFromAssetBundle(string assetName)
        {

            var assetBundleCache = assetBundleCacheList.FirstOrDefault(ab => ab.Contains(assetName));
            if (assetBundleCache == null) { Debug.LogError("該当データがありません"); }
            if (assetName.IndexOf(".png") == -1)
            {
                assetName = string.Format("{0}.png", assetName);
            }
            try
            {
                var sprite = assetBundleCache.LoadAsset<Sprite>(assetName);
                return sprite;
            }
            catch (NullReferenceException e)
            {
                Debug.LogError(e.ToString());
                return null;
            }
        }

        public Texture GetTextureFromAssetBundle(string assetName)
        {
            var assetBundleCache = assetBundleCacheList.FirstOrDefault(ab => ab.Contains(assetName));
            if (assetBundleCache == null) { Debug.LogError("該当データがありません"); }
            if (assetName.IndexOf(".png") == -1)
            {
                assetName = string.Format("{0}.png", assetName);
            }
            try
            {
                var asset = assetBundleCache.LoadAsset<Texture>(assetName);
                return asset;
            }
            catch (NullReferenceException e)
            {
                Debug.LogError(e.ToString());
                return null;
            }
        }

        public Texture2D GetTexture2DFromAssetBundle(string assetName)
        {
            var assetBundleCache = assetBundleCacheList.FirstOrDefault(ab => ab.Contains(assetName));
            if (assetBundleCache == null) { Debug.LogError("該当データがありません"); }
            if (assetName.IndexOf(".png") == -1)
            {
                assetName = string.Format("{0}.png", assetName);
            }
            try
            {
                var asset = assetBundleCache.LoadAsset<Texture2D>(assetName);
                return asset;
            }
            catch (NullReferenceException e)
            {
                Debug.LogError(e.ToString());
                return null;
            }
        }

        public AudioClip GetAudioClipFromAssetBundle(string assetName)
        {
            var assetBundleCache = assetBundleCacheList.FirstOrDefault(ab => ab.Contains(assetName));
            if (assetBundleCache == null) { Debug.LogError("該当データがありません="+ assetName); }
            if (assetName.IndexOf(".mp3") == -1)
            {
                assetName = string.Format("{0}.mp3", assetName);
            }
            try
            {
                var asset = assetBundleCache.LoadAsset<AudioClip>(assetName);
                return asset;
            }
            catch (NullReferenceException e)
            {
                Debug.LogError(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// 対象フォルダ以下のAssetbundleデータをキャッシュする
        /// AndroidはstreamingAssetsからは読み込まれないので注意！
        /// </summary>
        void CacheAllAssetBundlesInFolder()
        {
            assetBundleCacheList.Clear();
            //androidの場合
            CacheAssetBundlesFromFolderPath(Application.streamingAssetsPath);
            CacheAssetBundlesFromFolderPath(Application.persistentDataPath);
        }

        void CacheAssetBundlesFromFolderPath(string folderPath)
        {

            DirectoryInfo di = new System.IO.DirectoryInfo(folderPath);
            if (!Directory.Exists(folderPath))
            {
                Debug.Log("フォルダ作成=" + folderPath);
                di.Create();
            }
            Debug.Log("読み込み開始:"+ di.FullName);
            FileInfo[] files = null;
            try
            {
                files = di.GetFiles("*.unity3d", System.IO.SearchOption.AllDirectories);
            }
            catch (Exception e)
            {
                Debug.LogError(e.ToString());
            }
            foreach (var f in files)
            {
                assetBundleCacheList.Add(AssetBundle.LoadFromFile(f.FullName));
            }
        }

    }
}
