using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BLDKEscapeOut.Recepter
{
    public class SceneLoadRecepter : BaseRecepter
    {
        [SerializeField]
        Button button;
        [SerializeField]
        string sceneName;

        void Start()
        {
            button.onClick.AddListener(()=> {
                Controller.SceneLoadWithTween(sceneName);
            });
        }
    }
}