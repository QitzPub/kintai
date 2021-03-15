using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BLDKEscapeOut.Recepter
{
    [RequireComponent(typeof(InputField))]

    public class UserNameChangeRecepter : BaseRecepter
    {
        // Start is called before the first frame update
        void Start()
        {
            this.GetComponent<InputField>().onValueChanged.AddListener((value) =>
            {
                Controller.SetUserName(value);
            });
        }
    }
}