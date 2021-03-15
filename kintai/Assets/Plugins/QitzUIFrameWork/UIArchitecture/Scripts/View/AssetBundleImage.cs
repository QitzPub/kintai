using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using Qitz.ArchitectureCore.UI;

namespace Qitz.UISystem
{

    public class AssetBundleImage : Image, IView
    {
        [SerializeField]
        public string sourceImageName;
        [SerializeField]
        bool loadAssetbundleRequest = false;

        protected override void Start()
        {
            base.Start();

            if (loadAssetbundleRequest)
            {
                var spriteUseCase = this.GetController<UIController>().SpriteUseCase;
                Debug.Assert(spriteUseCase != null, "該当スプライトがありません");
                this.sprite = spriteUseCase.GetSpriteFromAssetBundle(sourceImageName);
            }
        }

        bool removedReference = false;
        public void RemoveImageReference()
        {
            this.removedReference = true;
            this.sprite = null;
        }
        

        void OnValidate()
        {
            if (!removedReference && sprite != null)
            {
                this.sourceImageName = this.sprite.name;
            }
            this.removedReference = false;
            this.enabled = false;
            this.enabled = true;
            //this.SetNativeSize();
        }

    }
}
