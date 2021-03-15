using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.Entity;
using UnityEngine;
using Qitz.DataUtil;
using UniRx;
using UniRx.Async;
using System.Linq;
//using BLDKEscapeOut.ETC;
using System;
using UnityEditor;

namespace BLDKEscapeOut.DataStore
{
    
    public class GachaDataStore : BaseDataStore
    {
        [SerializeField]
        string loadingServerUrl;
        [SerializeField]
        List<GachaSettingVO> gachaSettings;
        public List<GachaSettingVO> GachaSettings=> gachaSettings;

        [ContextMenu("サーバーからデータを読み込む")]
        public IObservable<Unit> LoadDataFromServer()
        {
            var ga = new GameObject();
            var referrer = ga.AddComponent<StartCorutinReferrer>();
            var sub = new Subject<Unit>();
            referrer.StartCoroutine(JsonFromGoogleSpreadSheet.GetJsonArrayFromGoogleSpreadSheetUrl(loadingServerUrl, (jsonArry) =>
            {
                gachaSettings = jsonArry.Select(j => JsonUtility.FromJson<GachaSettingVO>(j)).ToList();
                DestroyImmediate(ga);
                //保存する
                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssets();
                sub.OnNext(Unit.Default);
            }));
            return sub;
        }
    }
}