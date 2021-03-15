
using Qitz.ArchitectureCore.UI;
using UnityEditor;
using UnityEngine;

namespace Qitz.UISystem
{

    public interface IUIRepository
    {
        IStringDataStore StringDataStore { get; }
        IQitzAssetBundleDataStore QitzAssetBundleDataStore { get; }
    }

    //[CreateAssetMenu(menuName = "Example/UIRepository")]
    public class UIRepository : ARepository, IUIRepository
    {
        [SerializeField]
        StringDataStore stringDataStore;
        public IStringDataStore StringDataStore => stringDataStore;

        QitzAssetBundleDataStore qitzAssetBundleDataStore;
        public IQitzAssetBundleDataStore QitzAssetBundleDataStore => qitzAssetBundleDataStore;

        public void Initialize(string assetBundleSavedFolderPath)
        {
            qitzAssetBundleDataStore = new QitzAssetBundleDataStore(assetBundleSavedFolderPath);
        }
    }

}