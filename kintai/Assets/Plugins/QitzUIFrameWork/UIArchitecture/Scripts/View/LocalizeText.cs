using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Qitz.ArchitectureCore.UI;
using UnityEditor;

namespace Qitz.UISystem
{
    public class LocalizeText : Text,IView
    {
        [SerializeField]
        bool useLocalize;

        protected override void Start()
        {
            base.Start();
            if (!useLocalize) return;
#if UNITY_EDITOR
            if (!EditorApplication.isPlaying) return;
#endif

            var stringUseCase = this.GetController<UIController>().StringUseCase;
            this.text = stringUseCase.GetSelectedLanguageTextFromJapaneseKeyText(this.text);
        }

    }
}
