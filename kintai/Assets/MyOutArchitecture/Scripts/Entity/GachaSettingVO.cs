using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BLDKEscapeOut.View;

namespace BLDKEscapeOut.Entity
{
    [Serializable]
    public class GachaSettingVO : BaseEntity
    {
        [SerializeField]
        int no;
        public int No => no;
        [SerializeField]
        string 演出名;
        public ProductionName ProductionName => (ProductionName)Enum.Parse(typeof(ProductionName), 演出名);
        [SerializeField]
        int 発生レート;
        public int Ratio => 発生レート;
        [SerializeField]
        string 演出発生条件;
        public OccurrenceCondition OccurrenceCondition
        {
            get
            {
                return (OccurrenceCondition)Enum.Parse(typeof(OccurrenceCondition), 演出発生条件);
            }
        }
    }

    //public class InteriourRefiningElementEntity
    //{
    //    public NewInteriorEntity InteriorItem { get; private set; }
    //    public int PointValue { get; private set; }
    //    public GameItemEffectName GameItemEffectName { get; private set; }

    //    public InteriourRefiningElementEntity(NewInteriorEntity interiorItem,int point, GameItemEffectName gameItemEffectName)
    //    {
    //        this.InteriorItem = interiorItem;
    //        this.PointValue = point;
    //        this.GameItemEffectName = gameItemEffectName;
    //    }
    //}

    public enum ProductionName
    {
        NONE,
        通常ガチャ排出,
        SRフェイクワニ1,
        SRフェイクワニ2,
        通常ガチャ_フェイクノーマル降格失敗,
        SR確定UFO,
        SRフェイクUFO,
        SRフェイクUFOノーマル降格失敗,
        SR確定ワニ1,
        SR確定ワニ2,
        桜ふぶき,
        桜ふぶき降格失敗,
        ひよこ横断,
        ひよこ横断降格失敗,
    }

    public enum OccurrenceCondition
    {
        NONE,
        常時,
        SRの数が1,
        R_SRが含まれない,
        SRの数が1以上,
        RかSRが1,

    }


}