using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLDKEscapeOut.IRepository;
using BLDKEscapeOut.DataStore;
using System.Linq;
using BLDKEscapeOut.Entity;
using System;
using UniRx;

namespace BLDKEscapeOut.Repository
{
    public class EscapeOutRepository : BaseRepository, IEscapeOutRepository
    {

        [SerializeField]
        EscapeUserSaveDataStore escapeUserSaveDataStore;

        [SerializeField]
        GameSettingDataStore gameSettingDataStore;

        [SerializeField]
        GameItemDataStore gameItemDataStore;

        [SerializeField]
        NtpServerDateGatter ntpServerDateGatter;

        QitzTimeUtil qitzTimeUtil;

        void Awake()
        {
            qitzTimeUtil = new QitzTimeUtil();

            escapeUserSaveDataStore = new EscapeUserSaveDataStore(gameItemDataStore, gameSettingDataStore);
            escapeUserSaveDataStore.Initialize();

            //まんぷく度回復処理
            Observable.Interval(TimeSpan.FromMilliseconds(1000)).Subscribe(l =>
            {

                //現在時刻が空の場合は処理を切る
                if (CurrentDate.DateTimeState == DateTimeState.EMPTY) return;

                //・現在時刻
                double currentTime = qitzTimeUtil.GetTimeStampFromDataTime(CurrentDate.Date);

                //・過去に回復が行われた時間
                var pastRecoverTime = RecoverFullnessTime;

                //満腹度回復時間
                int manpukuRecoverTime = gameSettingDataStore.FullnessRecoverMinute;

                //・回復判定用の時刻
                var recoverJudgentTime = pastRecoverTime + qitzTimeUtil.MinToSeconds(manpukuRecoverTime);

                //現在最大まんぷくの場合
                if(CurrentFullness >= MaxFullness)
                {
                    SetRecoverFullnessTime(currentTime);
                }

                //最大満腹ではない場合
                else if (currentTime > recoverJudgentTime)
                {
                    //現在まんぷくどを増やす
                    SetCurrentFullness(CurrentFullness + 1);
                    //過去に回復が行われた時間を更新
                    SetRecoverFullnessTime(recoverJudgentTime);
                }

            }).AddTo(this);

        }
        double RecoverFullnessTime => escapeUserSaveDataStore.RecoverFullnessTime;
        void SetRecoverFullnessTime(double recoverFullnessTime)
        {
            escapeUserSaveDataStore.SetRecoverFullnessTime(recoverFullnessTime);
        }

        public bool IsFirstLanch => escapeUserSaveDataStore.IsFirstLanch;
        public void SetIsFirstLanch(bool isFirstLanch)
        {
            escapeUserSaveDataStore.SetIsFirstLanch(isFirstLanch);
        }


        public List<int> PossessionItems => escapeUserSaveDataStore.PossessionItems;
        public List<GameItemVO> PossessionGameItems
        {
            get
            {
                var list = PossessionItems.Select(id => GameItems.FirstOrDefault(gi => gi.ID == id)).ToList();
                if (list.Contains(null))
                {
                    throw new System.Exception("データに不正な値が含まれています");
                }
                return list;
            }
        }

        //=====================================

        public int CurrentFullness => escapeUserSaveDataStore.CurrentFullness;
        public void SetCurrentFullness(int currentFullness)
        {
            escapeUserSaveDataStore.SetCurrentFullness(currentFullness);
        }

        //現在所持のしあわせポイント
        public int CurrentHappynessPoint => escapeUserSaveDataStore.CurrentHappynessPoint;
        //現在のしあわせポイントをセットする
        public void SetCurrentHappynessPoint(int happynessPoint)
        {
            escapeUserSaveDataStore.SetCurrentHappynessPoint(happynessPoint);
        }

        //=====================================

        public void AddPossessionItems(int itemID)
        {
            escapeUserSaveDataStore.AddPossessionItems(itemID);
        }

        public string UserName => escapeUserSaveDataStore.UserName;

        public string UserGUID => escapeUserSaveDataStore.UserGUID;

        public List<GameItemVO> GameItems => gameItemDataStore.GameItems;

        public DateTimeEntity CurrentDate
        {
            get
            {
                //エラー回数が指定回数を超えた場合は端末時間を返す
                if (ntpServerDateGatter.ExistServerError)
                {
                    return new DateTimeEntity(DateTime.Now);
                }
                return new DateTimeEntity(ntpServerDateGatter.Date);
            }
        }

        public int MaxFullness => gameSettingDataStore.MaxFullness;

        public GameSettingDataStore GameSettings => gameSettingDataStore;

        [SerializeField]
        GachaDataStore gachaDataStore;
        public GachaDataStore GachaDataStore => gachaDataStore;

        public bool ThisMonthSubmitted
        {
            get
            {
                //2分の１の確率でtrueかfalseを返す
                int rand = UnityEngine.Random.Range(0,2);
                return rand == 0;
            }
        }

        public void SetUserName(string name)
        {
            escapeUserSaveDataStore.SetUserName(name);
        }

        public void SetUserGUID()
        {
            escapeUserSaveDataStore.SetUserGUID();
        }

    }
}
