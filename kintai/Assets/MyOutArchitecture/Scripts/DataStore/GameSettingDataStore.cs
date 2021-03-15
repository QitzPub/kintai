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

namespace BLDKEscapeOut.DataStore
{
    public class GameSettingDataStore : BaseDataStore
    {


        [SerializeField]
        GameSettingEntity gameSettingEntity;

        public int MaxFullness => gameSettingEntity.MaxFullness;
        public int FullnessRecoverMinute => gameSettingEntity.FullnessRecoverMinute;
        //[SerializeField, HeaderAttribute("しあわせガチャ１回あたりの必要ポイント")]
        //int requestHappyPointToGacha = 1000;
        public int RequestHappyPointToGacha => gameSettingEntity.RequestHappyPointToGacha;

        public int ContinuousConsumeHappypoint => gameSettingEntity.ContinuousConsumeHappypoint;

        //public const string SHOP_HAPPY_TWICE_ID= "100wani.happy";
        //public const int SHOP_HAPPY_TWICE_MAGNIFICATION = 2;
        //public const string SHOP_MANPUKU_MAX_TWICE_ID = "100wani.manpukumax";
        //public const string SHOP_MANPUKU_RECOVER_SPEED_TWICE_ID = "100wani.manpukuspeed";
        //public const string SHOP_REMOVE_AD_ID = "100wani.noad";

        //[SerializeField]
        //string googleSpreadSheetUrl;

        //[ContextMenu("サーバーからデータを読み込む")]
        //public IObservable<Unit> LoadDataFromServer()
        //{
        //    var ga = new GameObject();
        //    var referrer = ga.AddComponent<StartCorutinReferrer>();
        //    var sub = new Subject<Unit>();
        //    referrer.StartCoroutine(JsonFromGoogleSpreadSheet.GetJsonArrayFromGoogleSpreadSheetUrl(googleSpreadSheetUrl, (jsonArry) =>
        //    {
        //        var data = jsonArry.Select(j => JsonUtility.FromJson<GameSettingEntity>(j)).ToList();
        //        this.gameSettingEntity = data.FirstOrDefault(d=>d.Version== data.Max(_d=>_d.Version));

        //        referrer.StartCoroutine(JsonFromGoogleSpreadSheet.GetJsonArrayFromGoogleSpreadSheetUrl(interiourEffectServerUrl, (_jsonArry) =>
        //        {
        //            //var replaceData = _jsonArry.Select(j => j.Replace("\r", "¥n").Replace("\n", "¥n"));
        //            this.InteriourEffectVOs = _jsonArry.Select(j => JsonUtility.FromJson<InteriourEffectVO>(j)).ToList();
        //            DestroyImmediate(ga);
        //            sub.OnNext(Unit.Default);
        //            //Destroy(ga);
        //        }));
        //        //Destroy(ga);
        //    }));
        //    return sub;
        //}

//        public string GetGoogleLeaderBordID(GameType gameType)
//        {

//#if UNITY_ANDROID
//            if(gameType == GameType.RUN)
//            {
//                return googleLeaderBordBikeID;
//            }
//            else if(gameType == GameType.BASKET)
//            {
//                return googleLeaderBordBaskeID;
//            }
//#else
//            if(gameType == GameType.RUN)
//            {
//                return gamecenterBikeID;
//            }
//            else if(gameType == GameType.BASKET)
//            {
//                return gamecenterBaskeID;
//            }

//#endif
//            throw new System.Exception("未定義の形式です："+ gameType);
//        }

    }

    [Serializable]
    public class GameSettingEntity
    {
        [SerializeField]
        int version;
        public int Version=> version;

        //[SerializeField]
        //int maxInGameTime;
        //public int MaxInGameTime => maxInGameTime;

        [SerializeField, HeaderAttribute("最大まんぷく度")]
        int maxFullness;
        public int MaxFullness => maxFullness;

        [SerializeField, HeaderAttribute("まんぷく度回復分(単位は分)")]
        int fullnessRecoverMinute;
        public int FullnessRecoverMinute => fullnessRecoverMinute;

        //[SerializeField, HeaderAttribute("広告幸せリトライ時間(単位は分)")]
        //int addHappynessMagniRecoverMinute;
        //public int AddHappynessMagniRecoverMinute => addHappynessMagniRecoverMinute;

        //[SerializeField, HeaderAttribute("広告を見て幸せポイントX倍")]
        //float addHappynessMagnification = 2;
        //public float AddHappynessMagnification => addHappynessMagnification;

        //[SerializeField, HeaderAttribute("ゲーム結果画面でReword広告みて幸せポイントX倍")]
        //float gameResultRewordHappynessMagnification = 2;
        //public float GameResultRewordHappynessMagnification => gameResultRewordHappynessMagnification;

        [SerializeField, HeaderAttribute("しあわせガチャ１回あたりの必要ポイント")]
        int requestHappyPointToGacha = 1000;
        public int RequestHappyPointToGacha => requestHappyPointToGacha;

        [SerializeField, HeaderAttribute("しあわせ連続ガチャ１回あたりの必要ポイント")]
        int continuousConsumeHappypoint=900;
        public int ContinuousConsumeHappypoint => continuousConsumeHappypoint;

        [SerializeField, HeaderAttribute("しあわせガチャが被った時に変換獲得できるしあわせポイント")]
        int sufferGachaItemToHappyPoint = 100;
        public int SufferGachaItemToHappyPoint => sufferGachaItemToHappyPoint;

        //[SerializeField, HeaderAttribute("ゲーム１プレイに必要な満腹ポイント")]
        //int consumeGamePlayManpukuPoint = 1;
        //public int ConsumeGamePlayManpukuPoint => consumeGamePlayManpukuPoint;

        //[SerializeField, HeaderAttribute("広告を見て満腹アップボーナス最大回数")]
        //int adManpukuBounsMaxCount = 6;
        //public int AdManpukuBounsMaxCount => adManpukuBounsMaxCount;

        //[SerializeField, HeaderAttribute("広告を見て満腹アップボーナス限定アイテムID")]
        //int adManpukuBounsLimitedItemID = 11;
        //public int AdManpukuBounsLimitedItemID => adManpukuBounsLimitedItemID;

        //[SerializeField, HeaderAttribute("卵羽化時間(単位は分)")]
        //int eggGrowingMinute;
        //public int EggGrowingMinute => eggGrowingMinute;

        //[SerializeField, HeaderAttribute("卵モンスター発見時増加しあわせポイント")]
        //int addMonsterDiscoveryHappynessPoint;
        //public int AddMonsterDiscoveryHappynessPoint => addMonsterDiscoveryHappynessPoint;

        //[SerializeField, HeaderAttribute("卵探索に必要なまんぷくポイント")]
        //int eggDiscoveryConsumeManpukuPoint;
        //public int EggDiscoveryConsumeManpukuPoint => eggDiscoveryConsumeManpukuPoint;

    }
}