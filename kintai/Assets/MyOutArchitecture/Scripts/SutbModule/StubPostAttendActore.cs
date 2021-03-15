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
    public class StubPostAttendActore : BaseActore, PostAttendUseCase
    {
        Subject<CommunicationResult> processResult = new Subject<CommunicationResult>();
        public IObservable<CommunicationResult> AttenancePostResult => processResult;

        public async void PostAttendance(string description, byte[] image)
        {
            await UniTask.Delay(2000);
            int rand = UnityEngine.Random.Range(1, 3);
            processResult.OnNext((CommunicationResult)rand);
        }
    }
}