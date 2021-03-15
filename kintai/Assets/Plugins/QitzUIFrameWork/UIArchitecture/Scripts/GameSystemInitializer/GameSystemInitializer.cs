using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qitz.ArchitectureCore.UI;

namespace Qitz.UISystem
{
    public class GameSystemInitializer : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod()]
        static void GameSystemInitialize()
        {
            Debug.Log("OnRuntimeMethodLoad");
            //var ga = new GameObject();
            var obj = PrefabFolder.ResourcesLoadInstantiateTo("UIController");
            Object.DontDestroyOnLoad(obj);
        }
    }
}
