using System.Collections.Generic;
using UnityEngine;
using Qitz.ArchitectureCore.UI;
using System.Linq;

namespace Qitz.UISystem
{

    public interface IStringDataStore
    {
        Language SelectedLanguage { get; }
        List<StringRowVO> StringRowVOs { get; }
    }
    //[CreateAssetMenu(menuName = "Example/StringDataStore")]
    public class StringDataStore : ADataStore, IStringDataStore
    {
        [SerializeField]
        Font japanesFont;
        [SerializeField]
        Font englishFont;
        [SerializeField]
        Font chineseFont;

        [SerializeField]
        Language selectedLanguage;
        public Language SelectedLanguage => selectedLanguage;

        public Font GetFontFromSelectedLanguage()
        {
            switch (selectedLanguage)
            {
                case Language.JAPANESE:
                    return japanesFont;
                case Language.ENGLISH:
                    return englishFont;
                case Language.CHINESE:
                    return chineseFont;
                default:
                    throw new System.Exception("想定されていない形式です");
            }
        }

        [SerializeField]
        TextAsset stringCSV;
        [SerializeField]
        List<StringRowVO> stringRowVOs = new List<StringRowVO>();
        public List<StringRowVO> StringRowVOs => stringRowVOs.Concat(CSVParser.GetTeargetTypeDataFromLocalCSV<StringRowVO>(stringCSV.text)).ToList();

    }
}