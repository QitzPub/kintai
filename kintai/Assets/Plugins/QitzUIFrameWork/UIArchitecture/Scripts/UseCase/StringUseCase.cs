using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Qitz.ArchitectureCore.UI;
using System.Linq;

namespace Qitz.UISystem
{
    public interface IStringUseCase: IStringDataStore
    {
        string GetSelectedLanguageTextFromJapaneseKeyText(string japaneseText);
    }

    public class StringUseCase : AUIUseCase, IStringUseCase
    {
        IStringDataStore stringDataStore;

        public StringUseCase(IStringDataStore stringDataStore)
        {
            this.stringDataStore = stringDataStore;
        }

        public Language SelectedLanguage => stringDataStore.SelectedLanguage;
        public List<StringRowVO> StringRowVOs => stringDataStore.StringRowVOs;

        public string GetSelectedLanguageTextFromJapaneseKeyText(string japaneseText)
        {
            var targetStringVO = StringRowVOs.FirstOrDefault(sr => sr.JapaneseText == japaneseText);
            if (targetStringVO == null) return japaneseText;
            return targetStringVO.GetTextFromLanguage(SelectedLanguage);
        }


    }
}
