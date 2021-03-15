
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;
using UniRx.Async;
using System;
using BLDKEscapeOut.IController;
using UnityEngine.SceneManagement;
using BLDKEscapeOut.Entity;
using Qitz.ArchitectureCore.UI;
using BLDKEscapeOut.DataStore;
using BLDKEscapeOut.View;

namespace BLDKEscapeOut.Controller
{
    public class EscapeOutController : BaseController, IEscapeOutController
    {
        public void SetUserName(string name)
        {
            Repository.SetUserName(name);
        }

        public void SetUserGUID()
        {
            Repository.SetUserGUID();
        }

        public void AddPossessionItems(int itemID)
        {
            Repository.AddPossessionItems(itemID);
        }

        //現在のしあわせポイントをセットする
        public void SetCurrentHappynessPoint(int happynessPoint)
        {
            Repository.SetCurrentHappynessPoint(happynessPoint);
        }
        public void AddHappynessPoint(int addPoint)
        {
            Repository.SetCurrentHappynessPoint(Repository.CurrentHappynessPoint+addPoint);
        }

        public void OneTimeConsumeHappypointAndTurnGacha()
        {
            Transmitter.GachaTrunUseCase.OneTimeConsumeHappypointAndTurn();
        }

        public void OneTimeTrunGacha()
        {
            Transmitter.GachaTrunUseCase.OneTimeTrunGacha();
        }

        public void ContinuousConsumeHappypointAndTurn(int count,int sKakuteiCount = 0)
        {
            Transmitter.GachaTrunUseCase.ContinuousConsumeHappypointAndTurn(count, sKakuteiCount);
        }

        public void ContinuousTrunGacha(int count, int sKakuteiCount = 0)
        {
            Transmitter.GachaTrunUseCase.ContinuousTrunGacha(count, sKakuteiCount);
        }

        public void SetIsFirstLanch(bool isFirstLanch)
        {
            Repository.SetIsFirstLanch(isFirstLanch);
        }

        public void PlaySE(Entity.AudioType audioType)
        {
            Transmitter.AudioPlayUseCase.PlaySE(audioType);
        }

        public void PlayBGM(Entity.AudioType audioType)
        {
            Transmitter.AudioPlayUseCase.PlayBGM(audioType);
        }

        public void SceneLoadWithTween(string sceneName)
        {
            SceneLoaderWithTween.LoadScene(sceneName);
        }


        public void AddManpuku(int addManpukuPoint)
        {
            var addedAfterValue = Repository.CurrentFullness + addManpukuPoint;
            if(Repository.GameSettings.MaxFullness <= addedAfterValue)
            {
                addedAfterValue = Repository.GameSettings.MaxFullness;
            }
            Repository.SetCurrentFullness(addedAfterValue);
        }

        public void FullRecoverManpuku()
        {
            Repository.SetCurrentFullness(Repository.GameSettings.MaxFullness);
        }

        public void PostAttendance(string description, byte[] image)
        {
            Transmitter.PostAttendUseCase.PostAttendance(description, image);
        }

        public void CreateInvoiceRequest()
        {
            Transmitter.CreateInvoiceUseCase.CreateInvoiceRequest();
        }

        public void GetCalenderInformation(int year, int month)
        {
            Transmitter.GetCalenderInformationUseCase.GetCalenderInformation(year, month);
        }

        public void ChangeCalenderInformationRequest(int year, int month, int day, string title, string description, int startHours, int endHours)
        {
            Transmitter.AddCalenderScheduleUseCase.ChangeCalenderInformationRequest(year, month, day, title, description, startHours, endHours);
        }
    }
}
