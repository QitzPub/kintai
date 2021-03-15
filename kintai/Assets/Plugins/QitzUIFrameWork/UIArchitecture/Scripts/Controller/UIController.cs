
using UnityEngine;
using Qitz.ArchitectureCore.UI;

namespace Qitz.UISystem
{
    public class UIController : AController<UIRepository>
    {
        [SerializeField]
        UIRepository repository;
        [SerializeField]
        string assetBundleSavedFolderPath;

        protected override UIRepository Repository { get { return repository; } }
        StringUseCase stringUseCase;
        public IStringUseCase StringUseCase => stringUseCase;
        SpriteUseCase spriteUseCase;
        public ISpriteUseCase SpriteUseCase => spriteUseCase;

        private void Awake()
        {
            repository.Initialize(assetBundleSavedFolderPath);
            stringUseCase = new StringUseCase(repository.StringDataStore);
            spriteUseCase = new SpriteUseCase(repository.QitzAssetBundleDataStore);
        }
        [ContextMenu("アセットバンドル名をDump")]
        void DebugDumpAssetBundleFileName()
        {
            Repository.QitzAssetBundleDataStore.CachedAssetFullNameList.ForEach(na=>Debug.Log(na));
        }

    }
}