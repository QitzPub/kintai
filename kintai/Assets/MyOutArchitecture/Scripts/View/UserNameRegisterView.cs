using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System.Linq;
using BLDKEscapeOut.Entity;

namespace BLDKEscapeOut.View
{
    public class UserNameRegisterView : BaseView
    {
        [SerializeField]
        InputField userNameInput;
        [SerializeField]
        Button gotoNextButton;

        // Start is called before the first frame update
        void Start()
        {
            gotoNextButton.interactable = false;
            userNameInput.onValueChanged.AddListener((userName) =>
            {
                gotoNextButton.interactable = !string.IsNullOrEmpty(userName);

            });

        }
    }
}