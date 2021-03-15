using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BLDKEscapeOut.Controller;
using BLDKEscapeOut.IController;

namespace BLDKEscapeOut.Recepter
{
    public class BaseRecepter : MonoBehaviour
    {
        //魔法の力でControllerを取得する
        protected IEscapeOutController Controller => this.GetController();
    }

    public static class BaseRecepterExtensions
    {

        static IEscapeOutController controller;

        public static IEscapeOutController GetController(this BaseRecepter recepter)
        {
            if (controller == null)
            {
                controller = Object.FindObjectOfType<EscapeOutController>();
            }
            return controller;
        }
    }
}