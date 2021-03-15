using System;
using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.Entity;
using BLDKEscapeOut.UseCase;
using UnityEngine;
using UniRx;
using System.Linq;
using UniRx.Async;
//using BLDKEscapeOut.ETC;

namespace BLDKEscapeOut.Actore
{
    public class GachaTrunActore : BaseActore, GachaTrunUseCase
    {
        Subject<GachaResultEntity> gachaResultSubject = new Subject<GachaResultEntity>();
        public IObservable<GachaResultEntity> GachaResultTrigger => gachaResultSubject;
        Subject<List<GachaResultEntity>> continuousGachaResultSubject = new Subject<List<GachaResultEntity>>();
        public IObservable<List<GachaResultEntity>> ContinuousGachaResultTrigger => continuousGachaResultSubject;

        public void OneTimeConsumeHappypointAndTurn()
        {
            //しあわせポイントを消費する

            var currentHappyPoint = Repository.CurrentHappynessPoint;
            var consumeHappypoint = Repository.GameSettings.RequestHappyPointToGacha;
            if(currentHappyPoint< consumeHappypoint)
            {
                throw new Exception("ガチャを回すためのしあわせポイントが足りません");
            }
            Repository.SetCurrentHappynessPoint(currentHappyPoint- consumeHappypoint);

            //===================================================================

            //ガチャを回す
            OneTimeTrunGacha();

        }

        public void OneTimeTrunGacha()
        {
            var result = GetGachaResult();

            gachaResultSubject.OnNext(result);
        }

        GachaResultEntity GetGachaResult()
        {
            var allGameItem = Repository.GameItems.Where(g => g.BelongToGacha);
            int maxRatio = Repository.GameItems.Select(g => g.Ratio).Sum();
            int lotteryRatio = UnityEngine.Random.Range(0, maxRatio + 1);

            int currentRatio = 0;
            int nextRatio = currentRatio;
            foreach (var g in allGameItem)
            {
                nextRatio = currentRatio + g.Ratio;

                if (currentRatio <= lotteryRatio && nextRatio > lotteryRatio)
                {
                    var isSuffer = Repository.PossessionItems.Contains(g.ID);
                    //被りの場合はしあわせポイントを規定値増やす
                    Repository.AddPossessionItems(g.ID);
                    return new GachaResultEntity(g, isSuffer);
                }
                currentRatio = nextRatio;
            }

            return new GachaResultEntity(Repository.GameItems.FirstOrDefault(), true);
        }

        public void ContinuousConsumeHappypointAndTurn(int count, int sKakuteiCount = 0)
        {
            var currentHappyPoint = Repository.CurrentHappynessPoint;
            var consumeHappypoint = Repository.GameSettings.ContinuousConsumeHappypoint*count;
            if (currentHappyPoint < consumeHappypoint)
            {
                throw new Exception("ガチャを回すためのしあわせポイントが足りません");
            }
            Repository.SetCurrentHappynessPoint(currentHappyPoint - consumeHappypoint);

            ContinuousTrunGacha(count, sKakuteiCount);

        }

        public void ContinuousTrunGacha(int count, int sKakuteiCount = 0)
        {
            List<GachaResultEntity> gachaResults = new List<GachaResultEntity>();
            for (int i = 0; i < count; i++)
            {
                var result = GetGachaResult();
                if(result.GameItem.ID == 1)
                {
                    Debug.LogError("初期テレビが入ってます！！");
                }
                gachaResults.Add(result);
            }
            //S確定の数だけSを増やす
            var srGameItems = Repository.GameItems.Where(g => g.BelongToGacha && (g.Rarity == Rarity.S || g.Rarity == Rarity.SS)).OrderBy(g => Guid.NewGuid()).Take(sKakuteiCount).Select(g =>
            {
                var isSuffer = Repository.PossessionItems.Contains(g.ID);
                return new GachaResultEntity(g, isSuffer);
            });
            foreach (var si in srGameItems)
            {
                Repository.AddPossessionItems(si.GameItem.ID);
            }
            gachaResults = gachaResults.Concat(srGameItems).ToList();
            continuousGachaResultSubject.OnNext(gachaResults);
        }

        public GachaTrunActore()
        {

        }
    }
}