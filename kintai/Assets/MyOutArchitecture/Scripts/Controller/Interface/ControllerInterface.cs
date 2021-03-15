using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLDKEscapeOut.Actore;
using System;
using UniRx.Async;
using BLDKEscapeOut.Entity;

namespace BLDKEscapeOut.IController
{
    public interface IEscapeOutController: IUserDataSetter, IItemManage, IGachTurn, IAudioManage
    {
        void SceneLoadWithTween(string sceneName);
        //平田追加
        //Post勤怠
        void PostAttendance(string description,byte[] image);
        //請求書作成
        void CreateInvoiceRequest();
        //カレンダー情報取得
        void GetCalenderInformation(int year,int month);
        //カレンダー情報変更
        void ChangeCalenderInformationRequest(int year, int month,int day,string title,string description,int startHours,int endHours);

    }

    public interface IAudioManage
    {
        void PlaySE(Entity.AudioType audioType);
        void PlayBGM(Entity.AudioType audioType);
    }

    public interface IGachTurn
    {
        //しあわせポイントを消費してガチャを回す
        void OneTimeConsumeHappypointAndTurnGacha();
        //しあわせポイントを消費せずガチャを回す
        void OneTimeTrunGacha();
        //しあわせポイントを消費して連続で回す
        void ContinuousConsumeHappypointAndTurn(int count, int sKakuteiCount = 0);
        //しあわせポイントを消費せず連続で回す
        void ContinuousTrunGacha(int count, int sKakuteiCount = 0);
    }

    public interface IItemManage
    {
        //items
        void AddPossessionItems(int itemID);
    }

    public interface IUserDataSetter
    {
        void SetUserName(string name);
        void SetUserGUID();
        //まんぷくポイントを増やす
        void AddManpuku(int addManpukuPoint);
        //満腹度を全回復
        void FullRecoverManpuku();

        //現在のしあわせポイントをセットする
        void SetCurrentHappynessPoint(int happynessPoint);
        //現在のしあわせポイントを加算する
        void AddHappynessPoint(int addPoint);
        //アプリ初回起動フラグをセットする
        void SetIsFirstLanch(bool isFirstLanch);
    }


}
