using System;
using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.Entity;
using BLDKEscapeOut.UseCase;
using UnityEngine;
using UniRx;
using System.Linq;
using UniRx.Async;
using BLDKEscapeOut.IPresenter;
//using BLDKEscapeOut.ETC;

namespace BLDKEscapeOut.Actore
{
    public class StubGetCalenderInformationActore : BaseActore, GetCalenderInformationUseCase
    {
        Subject<CalenderMonthEntity> processResult = new Subject<CalenderMonthEntity>();
        public IObservable<CalenderMonthEntity> CalenderInformationResult => processResult;

        public async void GetCalenderInformation(int year, int month)
        {
            await UniTask.Delay(2000);
            processResult.OnNext(new CalenderMonthEntity());
        }
    }
}