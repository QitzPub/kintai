using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx.Async;

namespace BLDKEscapeOut.Recepter
{
    [RequireComponent(typeof(Button))]
    public class SetUserGUIDRecepter : BaseRecepter
    {
        // Start is called before the first frame update
        void Start()
        {
            this.GetComponent<Button>().onClick.AddListener(() =>
            {
                Controller.SetUserGUID();
            });
        }

    }
}