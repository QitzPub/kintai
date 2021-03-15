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
    public class GameItemDataStore : BaseDataStore
    {
        [SerializeField]
        string loadingServerUrl;

        [SerializeField]
        List<GameItemVO> gameItems;
        public List<GameItemVO> GameItems => gameItems;

        [ContextMenu("サーバーからデータを読み込む")]
        public IObservable<Unit> LoadDataFromServer()
        {
            var ga = new GameObject();
            var referrer = ga.AddComponent<StartCorutinReferrer>();
            var sub = new Subject<Unit>();
            referrer.StartCoroutine(JsonFromGoogleSpreadSheet.GetJsonArrayFromGoogleSpreadSheetUrl(loadingServerUrl, (jsonArry) =>
            {
                List<GameItemVO> parsedItemVos = jsonArry.Select(j => JsonUtility.FromJson<GameItemVO>(j)).ToList();
                foreach (var g in gameItems)
                {
                    foreach (var pi in parsedItemVos)
                    {
                        if(pi.ID == g.ID)
                        {
                            pi.SetSprite(g.Sprite);
                            //pi.InteriourAnimationView = g.InteriourAnimationView;
                        }
                    }
                }

                gameItems = parsedItemVos;
                gameItems.ForEach(gi=>gi.Initialize());
                DestroyImmediate(ga);
                sub.OnNext(Unit.Default);
                //保存する
                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssets();
                //Destroy(ga);
            }));
            return sub;
        }
    }
}