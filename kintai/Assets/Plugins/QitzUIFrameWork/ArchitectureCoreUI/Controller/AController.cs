using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qitz.ArchitectureCore.UI
{
    public abstract class AController<T> : MonoBehaviour, IController where T : IRepository
    {

        protected abstract T Repository { get; }

    }
}
