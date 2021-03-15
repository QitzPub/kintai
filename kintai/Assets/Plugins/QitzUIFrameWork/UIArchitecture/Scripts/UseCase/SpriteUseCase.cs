using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qitz.ArchitectureCore.UI;

namespace Qitz.UISystem
{
    public interface ISpriteUseCase
    {
        Sprite GetSpriteFromAssetBundle(string assetName);
    }

    public class SpriteUseCase: AUIUseCase, ISpriteUseCase
    {
        IQitzAssetBundleDataStore dataStore;
        public SpriteUseCase(IQitzAssetBundleDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public Sprite GetSpriteFromAssetBundle(string assetName)
        {
            return dataStore.GetSpriteFromAssetBundle(assetName);
        }
    }
}
