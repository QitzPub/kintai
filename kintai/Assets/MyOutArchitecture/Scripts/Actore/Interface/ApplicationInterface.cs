using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UniRx;
using BLDKEscapeOut.Entity;
using UniRx.Async;
using BLDKEscapeOut.IPresenter;

namespace BLDKEscapeOut.UseCase
{


    public interface GachaTrunUseCase
    {
        IObservable<GachaResultEntity> GachaResultTrigger { get; }
        void OneTimeConsumeHappypointAndTurn();
        void OneTimeTrunGacha();

        IObservable<List<GachaResultEntity>> ContinuousGachaResultTrigger { get; }
        void ContinuousConsumeHappypointAndTurn(int count, int sKakuteiCount = 0);
        void ContinuousTrunGacha(int count, int sKakuteiCount = 0);

    }

    public interface AudioPlayUseCase
    {
        void PlaySE(BLDKEscapeOut.Entity.AudioType audioType);
        void PlayBGM(BLDKEscapeOut.Entity.AudioType audioType);
    }

    public interface CreateInvoiceUseCase
    {
        //請求書作成
        void CreateInvoiceRequest();
        //請求書を作成結果subject
        IObservable<CommunicationResult> InvoiceCreateResult { get; }
    }

    public interface PostAttendUseCase
    {
        //Post勤怠
        void PostAttendance(string description, byte[] image);
        //勤怠結果subject
        IObservable<CommunicationResult> AttenancePostResult { get; }
    }

    public interface GetCalenderInformationUseCase
    {
        //カレンダーサーバー情報結果Subject
        IObservable<CalenderMonthEntity> CalenderInformationResult { get; }
        //カレンダー情報取得
        void GetCalenderInformation(int year, int month);
    }

    public interface AddCalenderScheduleUseCase
    {
        //カレンダーサーバー変更結果Subject
        IObservable<CommunicationResult> ChangeCalenderScheduleResult { get; }
        //カレンダー情報変更
        void ChangeCalenderInformationRequest(int year, int month, int day, string title, string description, int startHours, int endHours);
    }


}

