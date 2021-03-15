using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using BLDKEscapeOut.DataStore;
using BLDKEscapeOut.Repository;

namespace BLDKEscapeOut.Entity
{
    [Serializable]
    public class UserSaveEntity : BaseEntity
    {

        public UserSaveEntity(GameItemDataStore gameItemDataStore)
        {
            this.possessionItems = gameItemDataStore.GameItems.Where(g => g.DefaultPossession).Select(g => g.ID).ToList();
            //this.roomInteriorItems = gameSettingDataStore.DefaultRoomInteriorItems;
        }

        //[SerializeField]
        //int currentChapter = 1;
        //public int CurrentChapter => currentChapter;
        //[SerializeField]
        //int currentSection = 1;
        //public int CurrentSection => currentSection;
        //======================================
        [SerializeField]
        bool isFirstLanch=true;
        public bool IsFirstLanch => isFirstLanch;
        public void SetIsFirstLanch(bool isFirstLanch)
        {
            this.isFirstLanch = isFirstLanch;
        }

        //[SerializeField]
        //public FriendCommingState FriendCommingState = new FriendCommingState(false,0,0);

        [SerializeField]
        int currentFullness;
        public int CurrentFullness => currentFullness;
        public void SetCurrentFullness(int currentFullness)
        {
            this.currentFullness = currentFullness;
        }

        [SerializeField]
        int happynessPoint;
        public int CurrentHappynessPoint => happynessPoint;
        public void SetCurrentHappynessPoint(int happynessPoint)
        {
            this.happynessPoint = happynessPoint;
        }

        //[SerializeField]
        //bool adIncreaseHappynessFlag = false;
        //public bool AdIncreaseHappynessFlag => adIncreaseHappynessFlag;
        //public void SetAdIncreaseHappynessFlag(bool adIncreaseHappynessFlag)
        //{
        //    this.adIncreaseHappynessFlag = adIncreaseHappynessFlag;
        //}
        //[SerializeField]
        //double adHappynessTwiceTime;
        //public double AdHappynessTwiceTime => adHappynessTwiceTime;
        //public void SetAdHappynessTwiceTime(double adHappynessTwiceTime)
        //{
        //    this.adHappynessTwiceTime = adHappynessTwiceTime;
        //}

        //==ShopFlags==============================================

        //[SerializeField]
        //bool shopBillingIncreaseHappynessFlag = false;
        //public bool ShopBillingIncreaseHappynessFlag => shopBillingIncreaseHappynessFlag;
        //public void SetShopBillingIncreaseHappynessFlag(bool shopBillingIncreaseHappynessFlag)
        //{
        //    this.shopBillingIncreaseHappynessFlag = shopBillingIncreaseHappynessFlag;
        //}

        //[SerializeField]
        //bool shopFullnessRecoverTwice = false;
        //public bool ShopFullnessRecoverTwice => shopFullnessRecoverTwice;
        //public void SetShopFullnessRecoverTwice(bool shopFullnessRecoverTwice)
        //{
        //    this.shopFullnessRecoverTwice = shopFullnessRecoverTwice;
        //}

        //[SerializeField]
        //bool removeAdFlag = false;
        //public bool RemoveAdFlag => removeAdFlag;
        //public void SetRemoveAdFlag(bool removeAdFlag)
        //{
        //    this.removeAdFlag = removeAdFlag;
        //}

        //[SerializeField]
        //bool shopTwiceMaxManpukuFlag = false;
        //public bool ShopTwiceMaxManpukuFlag => shopTwiceMaxManpukuFlag;
        //public void SetShopTwiceMaxManpukuFlag(bool shopTwiceMaxManpukuFlag)
        //{
        //    this.shopTwiceMaxManpukuFlag = shopTwiceMaxManpukuFlag;
        //}

        //============================================================

        //時間経過で回復したタイム
        [SerializeField]
        double recoverFullnessTime;
        public double RecoverFullnessTime => recoverFullnessTime;
        public void SetRecoverFullnessTime(double recoverFullnessTime)
        {
            this.recoverFullnessTime = recoverFullnessTime;
        }

        //[SerializeField]
        //double adRecoverFullnessTime;
        //public double AdRecoverFullnessTime => adRecoverFullnessTime;
        //public void SetAdRecoverFullnessTime(double adRecoverFullnessTime)
        //{
        //    this.adRecoverFullnessTime = adRecoverFullnessTime;
        //}
        //[SerializeField]
        //int adRecoverFullnessCount;
        //public int AdRecoverFullnessCount => adRecoverFullnessCount;
        //public void SetAdRecoverFullnessCount(int adRecoverFullnessCount)
        //{
        //    this.adRecoverFullnessCount = adRecoverFullnessCount;
        //}

        //[SerializeField]
        //bool adManpukuFlag;
        //public bool AdManpukuFlag => adManpukuFlag;
        //public void SetAdManpukuFlag(bool adManpukuFlag)
        //{
        //    this.adManpukuFlag = adManpukuFlag;
        //}

        //====================================================

        ////時間経過で回復したタイム
        //[SerializeField]
        //double homeNeglectTime;
        //public double HomeNeglectTime => homeNeglectTime;
        //public void SetHomeNeglectTime(double homeNeglectTime)
        //{
        //    this.homeNeglectTime = homeNeglectTime;
        //}

        //=======================================================

        //[SerializeField]
        //bool adGachaTrunFlag = false;
        //public bool AdGachaTrunFlag => adGachaTrunFlag;
        //public void SetAdGachaTrunFlag(bool adGachaTrunFlag)
        //{
        //    this.adGachaTrunFlag = adGachaTrunFlag;
        //}

        //[SerializeField]
        //double adGachaTrunTime;
        //public double AdGachaTrunTime => adGachaTrunTime;
        //public void SetAdGachaTrunTime(double adGachaTrunTime)
        //{
        //    this.adGachaTrunTime = adGachaTrunTime;
        //}

        //=====================================

        //[SerializeField]
        //bool pullOmikuziFlag = false;
        //public bool PullOmikuziFlag => pullOmikuziFlag;
        //public void SetPullOmikuziFlag(bool pullOmikuziFlag)
        //{
        //    this.pullOmikuziFlag = pullOmikuziFlag;
        //}

        //[SerializeField]
        //double pullOmikuziTime;
        //public double PullOmikuziTime => pullOmikuziTime;
        //public void SetPullOmikuziTime(double pullOmikuziTime)
        //{
        //    this.pullOmikuziTime = pullOmikuziTime;
        //}

        //====たまごっち============================


        //[SerializeField]
        //bool showEggFlag = false;
        //public bool ShowEggFlag => showEggFlag;
        //public void SetShowEggFlag(bool showEggFlag)
        //{
        //    this.showEggFlag = showEggFlag;
        //}

        //[SerializeField]
        //double discoveryEggTime;
        //public double DiscoveryEggTime => discoveryEggTime;
        //public void SetDiscoveryEggTime(double discoveryEggTime)
        //{
        //    this.discoveryEggTime = discoveryEggTime;
        //}

        //=======================================================

        //ここの型をintからstringに変える！
        [SerializeField]
        string userAge = "";
        public string UserAge => userAge;

        //[SerializeField]
        //List<GameResultEntity> bestGameResultList = new List<GameResultEntity>();
        //public List<GameResultEntity> BestGameResultList => bestGameResultList;

        //[SerializeField]
        //List<GameResultEntity> sendedBestGameResultList = new List<GameResultEntity>();
        //public List<GameResultEntity> SendedBestGameResultList => sendedBestGameResultList;

        //[SerializeField]
        //List<InteriorEntity> roomInteriorItems = new List<InteriorEntity>() {};
        //public List<InteriorEntity> RoomInteriorItems => roomInteriorItems;

        //[SerializeField]
        //List<NewInteriorEntity> newRoomInteriorItems = new List<NewInteriorEntity>();
        //public List<NewInteriorEntity> NewRoomInteriorItems => newRoomInteriorItems;

        [SerializeField]
        List<int> possessionItems = new List<int>();
        public List<int> PossessionItems => possessionItems;

        //[SerializeField]
        //int currentArrengementNumber = 0;
        //public int CurrentArrengementNumber => currentArrengementNumber;
        //public void IncrementArrengementNumber()
        //{
        //    currentArrengementNumber++;
        //}

        //public void UpdateBestGameRecord(GameResultEntity newRecord)
        //{
        //    var oldRecord = bestGameResultList.FirstOrDefault(br => br.GameType == newRecord.GameType);
        //    if(oldRecord == null)
        //    {
        //        bestGameResultList.Add(newRecord);
        //    }
        //    else if(oldRecord.Score < newRecord.Score)
        //    {
        //        bestGameResultList.Remove(oldRecord);
        //        bestGameResultList.Add(newRecord);
        //    }
        //}
        //public void UpdateSendedBestGameRecord(GameResultEntity newRecord)
        //{
        //    var oldRecord = sendedBestGameResultList.FirstOrDefault(br => br.GameType == newRecord.GameType);
        //    if (oldRecord == null)
        //    {
        //        sendedBestGameResultList.Add(newRecord);
        //    }
        //    else if (oldRecord.Score < newRecord.Score)
        //    {
        //        sendedBestGameResultList.Remove(oldRecord);
        //        sendedBestGameResultList.Add(newRecord);
        //    }
        //}

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
        [SerializeField]
        string userName;

        public string UserName => userName;
        public void SetUserName(string userName)
        {
            this.userName = userName;
        }

        //[SerializeField]
        //List<int> playedGames = new List<int>();
        //public List<GameType> PlayedGames => playedGames.Select(p => (GameType)p).ToList();
        //public void AddPlayedGame(GameType game)
        //{
        //    playedGames.Add((int)game);
        //}

        //public void SetCurrentChapter(int chapter)
        //{
        //    currentChapter = chapter;
        //}

        //public void SetCurrentSection(int section)
        //{
        //    currentSection = section;
        //}
        //public void SetUserAge(string age)
        //{
        //    userAge = age;
        //}
        [SerializeField]
        string userGUID;
        public string UserGUID => userGUID;
        public void SetUserGUID()
        {
            userGUID = Guid.NewGuid().ToString();
        }

    }

    //[Serializable]
    //public class GameResultEntity : BaseEntity
    //{
    //    [SerializeField]
    //    int gameType;
    //    public GameType GameType => (GameType)gameType;
    //    [SerializeField]
    //    int score;
    //    public int Score => score;

    //    public GameResultEntity(GameType gameType,int score)
    //    {
    //        this.gameType = (int)gameType;
    //        this.score = score;
    //    }

    //}

}