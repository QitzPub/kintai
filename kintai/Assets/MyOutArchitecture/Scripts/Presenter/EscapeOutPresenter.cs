using System;
using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.DataStore;
using BLDKEscapeOut.Entity;
using BLDKEscapeOut.IPresenter;
using BLDKEscapeOut.Repository;
using UniRx;
using UniRx.Async;
using UnityEngine;

namespace BLDKEscapeOut.Presenter
{
    public class EscapeOutPresenter : BasePresenter, IEscapeOutPresenter
    {
        public bool IsFirstLanch => Repository.IsFirstLanch;

        //public IObservable<BuyItemResultEntity> BuyItemResult => Transmitter.BuyItemResult;

        //public IObservable<List<BillingEntity>> DonationInfomations => Transmitter.DonationInfomations;

        //public IReadOnlyReactiveProperty<int> CurrentInGameTime => Transmitter.InGameManage.CurrentInGameTime;

        //public IReadOnlyReactiveProperty<int> HappinessPoint => Transmitter.InGameManage.HappinessPoint;

        //public IReadOnlyReactiveProperty<int> RemainingTime => Transmitter.InGameManage.RemainingTime;

        //public IObservable<GameResultEntity> GameEnd => Transmitter.InGameManage.GameEnd;

        //public List<ShopItemVO> ShopItems => Repository.ShopItems;

        //public ShopItemVO SelectedShopItem => Repository.SelectedShopItem;

        //public List<GameResultEntity> BestGameResultList => Repository.BestGameResultList;

        public string UserName => Repository.UserName;

        public string UserGUID => Repository.UserGUID;

        public List<GameItemVO> AllGameItems => Repository.GameItems;

        public List<GameItemVO> PossessionGameItems => Repository.PossessionGameItems;

        //public List<InteriorEntity> RoomInteriorItems => Repository.RoomInteriorItems;

        public int CurrentFullness => Repository.CurrentFullness;

        public int MaxFullness => Repository.MaxFullness;

        //public bool ShowableRewardAd => Repository.ShowAbleRewardVideo;

        //public IObservable<Unit> RewardEndTrigger => Transmitter.RewardAdUseCase.RewardEndTrigger;

        //public IObservable<Unit> EditoreDummyDisplayTigger => Transmitter.RewardAdUseCase.EditoreDummyDisplayTigger;

        //public bool CanBeDispalyHappynessIncreaseAD => Repository.CanBeDispalyHappynessIncreaseAD;

        //public bool AdIncreaseHappynessFlag => Repository.AdIncreaseHappynessFlag;

        //public int GetGradeFromAmount(int amount)
        //{
        //    return Repository.GetGraveGrade(amount);
        //}

        //現在所持のしあわせポイント
        public int CurrentHappynessPoint => Repository.CurrentHappynessPoint;
        //ガチャ結果を取得
        public IObservable<GachaResultEntity> GachaResultTrigger => Transmitter.GachaTrunUseCase.GachaResultTrigger;
        //連続ガチャ結果を取得
        public IObservable<List<GachaResultEntity>> ContinuousGachaResultTrigger => Transmitter.GachaTrunUseCase.ContinuousGachaResultTrigger;

        public GameSettingDataStore GameSettings => Repository.GameSettings;

        //public bool CanBeAdGachaTrun => Repository.CanBeAdGachaTrun;

        //TODO 暫定でTrueを返しているが切り替える
        //public bool ShowableRewardAD => true;

        //public bool PullAbleOmikuziFlag => Repository.PullAbleOmikuziFlag;

        //public IObservable<OmikuziVO> OmikuziResultTrigger => Transmitter.PullOmikuziUseCase.OmikuziResultTrigger;

        //public GameResultEntity GameResult => Repository.CurrentGameResult;

        //public GameItemVO SelectedWanistaPhoto => Repository.SelectedWanistaPhoto;

        //public int AdRecoverFullnessCount => Repository.AdRecoverFullnessCount;

        //public bool CanBeAdManpuku => Repository.CanBeAdManpuku;

        //public IObservable<Unit> AdManpukuTrigger => Repository.AdManpukuTrigger;

        //public bool ShopBillingIncreaseHappynessFlag => Repository.ShopBillingIncreaseHappynessFlag;

        //public bool ShopFullnessRecoverTwice => Repository.ShopFullnessRecoverTwice;

        //public bool RemoveAdFlag => Repository.RemoveAdFlag;

        //public bool ShopTwiceMaxManpukuFlag => Repository.ShopTwiceMaxManpukuFlag;

        //[SerializeField]
        //AdfurikunInterstitialUtility adfurikunInterstitialUtility;
        //Subject<Unit> closeInterStitialSubject = new Subject<Unit>();
        //public IObservable<Unit> CloseInterstitialADTrigger => closeInterStitialSubject;

        //public bool ShowEggFlag => Repository.ShowEggFlag;

        //public bool IsEggGrowing => Repository.IsEggGrowing;

        //public int NecessaryDiscoveryManpukuPoint => Repository.GameSettings.EggDiscoveryConsumeManpukuPoint;

        public GachaDataStore GachaDataStore => Repository.GachaDataStore;

        public bool ThisMonthSubmitted => Repository.ThisMonthSubmitted;


        IObservable<CommunicationResult> IEscapeOutPresenter.AttenancePostResult => Transmitter.PostAttendUseCase.AttenancePostResult;

        IObservable<CommunicationResult> IEscapeOutPresenter.InvoiceCreateResult => Transmitter.CreateInvoiceUseCase.InvoiceCreateResult;

        IObservable<CalenderMonthEntity> IEscapeOutPresenter.CalenderInformationResult => Transmitter.GetCalenderInformationUseCase.CalenderInformationResult;

        IObservable<CommunicationResult> IEscapeOutPresenter.ChangeCalenderScheduleResult => Transmitter.AddCalenderScheduleUseCase.ChangeCalenderScheduleResult;

        //public List<NewInteriorEntity> NewRoomInteriorItems => Repository.NewRoomInteriorItems;

        //public bool ExistFriend => Repository.ExistFriend;

        //public WaniState CurrentWaniState => Repository.CurrentWaniState;

        //ここのトリガーをホーム中で参照する！！
        //public IObservable<InteriourRefiningElementEntity> HomeInteriourRefiningTrigger => Repository.HomeHouchiLooper.InteriourRefiningTrigger;

        //public UniTask<List<RanckingEntity>> GetRanckingData(GameType gameType)
        //{
        //    return Transmitter.RanckingServer.GetRanckingData(gameType);
        //}


    }
}
