using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BLDKEscapeOut.Entity
{

    [Serializable]
    public abstract class AEntity
    {
        [SerializeField]
        protected string id;
        public string ID => id;
    }

    [System.Serializable]
    public class GachaResultEntity : AEntity
    {
        public GameItemVO GameItem { get; private set; }
        public bool IsSuffer { get; private set; }

        [SerializeField]
        ProductionName productionName = ProductionName.通常ガチャ排出;

        public ProductionName ProductionName {
            get
            {
                return productionName;
            }
            private set
            {
                productionName = value;
            }
        }
        
        //public GachaResultEntity SetProduction(ProductionName productionName)
        //{
        //    this.ProductionName = productionName;
        //    return this;
        //}

        public GachaResultEntity(GachaResultEntity gr, ProductionName productionName)
        {
            this.GameItem = gr.GameItem;
            this.IsSuffer = gr.IsSuffer;
            this.productionName = productionName;
        }

        public GachaResultEntity(GameItemVO gameItem, bool isSuffer)
        {
            this.GameItem = gameItem;
            this.IsSuffer = isSuffer;
        }
    }
}