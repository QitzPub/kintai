
using UnityEngine;
using Qitz.ArchitectureCore.UI;
using System;

namespace Qitz.UISystem
{
    //public interface IStringVO
    //{
    //    Language Language { get; }
    //    string Text { get; }
    //}
    //[Serializable]
    //public class StringVO : AVO, IStringVO
    //{
    //    public Language Language => throw new System.NotImplementedException();
    //    public string Text => throw new System.NotImplementedException();
    //}
    public interface IStringRowVO
    {
        string JapaneseText { get; }
        string EnglishText { get; }
        string ChineseText { get; }
        string GetTextFromLanguage(Language language);
    }

    [Serializable]
    public class StringRowVO:AVO, IStringRowVO
    {
        [SerializeField]
        string japaneseText;
        public string JapaneseText=> japaneseText;

        [SerializeField]
        string englishText;
        public string EnglishText=> englishText;

        [SerializeField]
        string chineseText;
        public string ChineseText => chineseText;

        public string GetTextFromLanguage(Language language)
        {
            switch (language)
            {
                case Language.JAPANESE:
                    return JapaneseText;
                case Language.ENGLISH:
                    return EnglishText;
                case Language.CHINESE:
                    return ChineseText;
                default:
                    throw new Exception("想定されていない形式です。");
            }
        }

    }

}
