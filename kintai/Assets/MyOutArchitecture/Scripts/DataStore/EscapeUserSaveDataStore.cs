using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.Entity;
using UnityEngine;
using System.Linq;
using BLDKEscapeOut.Repository;

namespace BLDKEscapeOut.DataStore
{
    [System.Serializable]
    public class EscapeUserSaveDataStore 
    {
        [SerializeField]
        UserSaveEntity userSaveEntity;
        const string SAVE_DATA_KEY = "UserSaveDataStoreKey";
        bool isInitialized = false;
        GameItemDataStore gameItemDataStore;
        GameSettingDataStore gameSettingDataStore;
        public EscapeUserSaveDataStore(GameItemDataStore gameItemDataStore,GameSettingDataStore gameSettingDataStore)
        {
            this.gameItemDataStore = gameItemDataStore;
            this.gameSettingDataStore = gameSettingDataStore;
        }

        public void Initialize()
        {
            isInitialized = true;
            Load();
        }

        public bool IsFirstLanch => userSaveEntity.IsFirstLanch;
        public void SetIsFirstLanch(bool isFirstLanch)
        {
            userSaveEntity.SetIsFirstLanch(isFirstLanch);
            Save();
        }

        public List<int> PossessionItems => userSaveEntity.PossessionItems;


        public void AddPossessionItems(int itemID)
        {
            PossessionItems.Add(itemID);
            Save();
        }

        //=====================================
        public double RecoverFullnessTime => userSaveEntity.RecoverFullnessTime;
        public void SetRecoverFullnessTime(double recoverFullnessTime)
        {
            userSaveEntity.SetRecoverFullnessTime(recoverFullnessTime);
            Save();
        }

        public int CurrentFullness => userSaveEntity.CurrentFullness;
        public void SetCurrentFullness(int currentFullness)
        {
            userSaveEntity.SetCurrentFullness(currentFullness);
            Save();
        }

        public int CurrentHappynessPoint => userSaveEntity.CurrentHappynessPoint;
        public void SetCurrentHappynessPoint(int happynessPoint)
        {
            userSaveEntity.SetCurrentHappynessPoint(happynessPoint);
            Save();
        }





        public string UserGUID => userSaveEntity.UserGUID;
        public void SetUserGUID()
        {
            userSaveEntity.SetUserGUID();
            Save();
        }

        public string UserName => userSaveEntity.UserName;

        public void SetUserName(string userName)
        {
            userSaveEntity.SetUserName(userName);
            Save();
        }



        public void Save()
        {
            if (!isInitialized) throw new System.Exception("DataStoreが初期化されていません。");

            PlayerPrefs.SetString(SAVE_DATA_KEY, userSaveEntity.ToJson());
        }
        void Load()
        {
            if (!isInitialized) throw new System.Exception("DataStoreが初期化されていません。");

            string jsonData = PlayerPrefs.GetString(SAVE_DATA_KEY);
            if(jsonData == "")
            {
                userSaveEntity = new UserSaveEntity(gameItemDataStore);
            }
            else
            {
                userSaveEntity = JsonUtility.FromJson<UserSaveEntity>(jsonData);
            }
        }

    }
}