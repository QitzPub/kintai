using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BLDKEscapeOut.Recepter
{
    public class ConsumeStaminaRecepter : BaseRecepter
    {
        [SerializeField]
        Button button;

        void Start()
        {
            button.onClick.AddListener(()=> {
                Controller.AddManpuku(-1);
            });
        }
    }
}