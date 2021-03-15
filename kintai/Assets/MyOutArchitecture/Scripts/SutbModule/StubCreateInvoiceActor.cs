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
    public class StubCreateInvoiceActor : BaseActore, CreateInvoiceUseCase
    {
        Subject<CommunicationResult> processResult = new Subject<CommunicationResult>();
        public IObservable<CommunicationResult> InvoiceCreateResult => processResult;

        public async void CreateInvoiceRequest()
        {
            await UniTask.Delay(2000);
            int rand = UnityEngine.Random.Range(1,3);
            processResult.OnNext((CommunicationResult)rand);
        }
    }
}