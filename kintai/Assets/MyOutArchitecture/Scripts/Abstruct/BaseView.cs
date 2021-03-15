using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.IPresenter;
using BLDKEscapeOut.Presenter;
using UnityEngine;

namespace BLDKEscapeOut.View
{

    public abstract class BaseView : MonoBehaviour
    {
        //魔法の力でPresenterを取得する
        protected IEscapeOutPresenter Presenter => this.GetPresenter();
    }

    public static class BaseViewExtensions
    {

        static IEscapeOutPresenter presenter;

        public static IEscapeOutPresenter GetPresenter(this BaseView view
        )
        {
            if (presenter == null)
            {
                presenter = Object.FindObjectOfType<EscapeOutPresenter>();
            }
            return presenter;
        }


    }

}