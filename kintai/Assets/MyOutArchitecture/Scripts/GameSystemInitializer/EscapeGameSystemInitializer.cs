using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qitz.ArchitectureCore.UI;

namespace Qitz.EscapeFramework
{
    public class EscapeGameSystemInitializer 
    {

        [RuntimeInitializeOnLoadMethod]
        public static void GameSystemInitialize()
        {
            //var _controller = Object.FindObjectOfType<EscapeGameController>();
            //if(_controller != null)
            //{
            //    Object.Destroy(_controller.gameObject);
            //    ViewExtensions.CashClear();
            //}
#if UNITY_EDITOR
            var ga = new GameObject();
            var controller = PrefabFolder.ResourcesLoadInstantiateTo("BLDKOutGameModules", ga.transform.parent);
            //var itemWindow = PrefabFolder.ResourcesLoadInstantiateTo("ItemWindowView", ga.transform.parent);
            Object.Destroy(ga);
            Object.DontDestroyOnLoad(controller);
#endif
            //Object.DontDestroyOnLoad(itemWindow);
        }

    }
}