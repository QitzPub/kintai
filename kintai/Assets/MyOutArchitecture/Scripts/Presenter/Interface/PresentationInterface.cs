using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLDKEscapeOut.Actore;
using UniRx;
using System;
using BLDKEscapeOut.Entity;
using UniRx.Async;
using BLDKEscapeOut.DataStore;
using BLDKEscapeOut.Repository;

namespace BLDKEscapeOut.IPresenter
{
    public enum CommunicationResult
    {
        NONE,
        SUCCESS,
        FAILD,
    }

    public interface IEscapeOutPresenter
    {
        //shop
        //IObservable<BuyItemResultEntity> BuyItemResult { get; }
        //IObservable<List<BillingEntity>> DonationInfomations { get; }
        //ShopItemVO SelectedShopItem { get; }
        //GameResultEntity GameResult { get; }
        //List<GameResultEntity> BestGameResultList { get; }
        string UserName { get; }
        string UserGUID { get; }



        //勤怠結果subject
        IObservable<CommunicationResult> AttenancePostResult { get; }
        //当月に勤怠を送信済みかどうか？
        bool ThisMonthSubmitted { get; }
        //請求書を作成結果subject
        IObservable<CommunicationResult> InvoiceCreateResult { get; }
        //カレンダーサーバー情報結果Subject
        IObservable<CalenderMonthEntity> CalenderInformationResult { get; }
        //カレンダーサーバー変更結果Subject
        IObservable<CommunicationResult> ChangeCalenderScheduleResult { get; }

        bool IsFirstLanch { get; }
        //Game設定
        GameSettingDataStore GameSettings { get; }
        GachaDataStore GachaDataStore { get; }

        //Items
        List<GameItemVO> AllGameItems { get; }
        List<GameItemVO> PossessionGameItems { get; }

        //まんぷく度
        int CurrentFullness { get; }
        //最大まんぷく度
        int MaxFullness { get; }
        //現在のしあわせポイント
        int CurrentHappynessPoint { get; }

        //ガチャ結果を取得
        IObservable<GachaResultEntity> GachaResultTrigger { get; }
        IObservable<List<GachaResultEntity>> ContinuousGachaResultTrigger { get; }

        ////ゲーム結果画面のコメントなど
        //GameResultCommentEntity GetComment(GameType gameType, int score);
        ////たまごっち
        //bool ShowEggFlag { get; }
        //bool IsEggGrowing { get; }
        //int NecessaryDiscoveryManpukuPoint { get; }

        ////Shopフラグ
        //bool ShopBillingIncreaseHappynessFlag { get; }
        //bool ShopFullnessRecoverTwice { get; }
        //bool RemoveAdFlag { get; }
        //bool ShopTwiceMaxManpukuFlag { get; }
        //IObservable<Unit> CloseInterstitialADTrigger { get; }
        ////=====================
        //bool ExistFriend { get; }
        //WaniState CurrentWaniState { get; }
        ////幸せポイント排出時
        //IObservable<InteriourRefiningElementEntity> HomeInteriourRefiningTrigger { get; }
    }
}