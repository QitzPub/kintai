using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qitz.ArchitectureCore.UI;

namespace Qitz.UISystem
{
    public abstract class ABaseView : AView
    {
        protected UIController uIGameController => this.GetController<UIController>();
    }
}
