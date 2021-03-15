using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qitz.ArchitectureCore.UI
{
    public interface IRepository
    {
    }

    public abstract class ARepository : ScriptableObject, IRepository
    {
    }
}
