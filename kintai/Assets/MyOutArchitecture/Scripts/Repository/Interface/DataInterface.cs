using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLDKEscapeOut.DataStore;
using BLDKEscapeOut.Entity;
using System;
using UniRx;
using BLDKEscapeOut.Repository;

namespace BLDKEscapeOut.IRepository
{
    //TODO 保持している値を10つくらいまで分割(なんのインターフェイスかわからないので)

    public interface IEscapeOutRepository
    {
        bool IsFirstLanch { get; }
        void SetIsFirstLanch(bool isFirstLanch);

        bool ThisMonthSubmitted { get; }

        string UserGUID { get; }
        void SetUserGUID();

        void SetUserName(string name);
        string UserName { get; }


        GameSettingDataStore GameSettings { get; }
        GachaDataStore GachaDataStore { get; }
        //=====================================
        List<GameItemVO> GameItems { get; }
        List<int> PossessionItems { get; }
        List<GameItemVO> PossessionGameItems { get; }


        void AddPossessionItems(int itemID);

        //=========================================
        DateTimeEntity CurrentDate { get; }
        //=========================================

        int CurrentFullness { get; }
        void SetCurrentFullness(int currentFullness);
        int MaxFullness { get; }

        void SetCurrentHappynessPoint(int happynessPoint);
        int CurrentHappynessPoint { get; }
    }
}
