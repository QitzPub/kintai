using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BLDKEscapeOut.View;
using System.Linq;

namespace BLDKEscapeOut.Entity
{
    public enum ItemType
    {
        NONE,
        WALL,
        WALL_HANGING,
        FLOOR,
        PHOTO,
    }

    public enum Rarity
    {
        N,
        R,
        S,
        SS,
    }

    [Serializable]
    public class GameItemVO : BaseEntity
    {
        [SerializeField]
        int id;
        public int ID => id;

        [SerializeField]
        string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        [SerializeField]
        Sprite sprite;
        public Sprite Sprite => sprite;
        const int BLOCK_ONE_SIDE_LENGTH = 128;

        public Vector2Int BlockShape
        {
            get
            {
                int x = sprite.texture.width / BLOCK_ONE_SIDE_LENGTH;
                int y = sprite.texture.height / BLOCK_ONE_SIDE_LENGTH;
                return new Vector2Int(x,y);
            }
        }

        public void SetSprite(Sprite sprite)
        {
            this.sprite = sprite;
        }

        [SerializeField]
        int ratio;
        public int Ratio => ratio;

        [SerializeField]
        string itemType = "FLOOR";
        public ItemType ItemType
        {
            get
            {
                ItemType it;
                Enum.TryParse(itemType, out it);
                if(!Enum.IsDefined(typeof(ItemType), it))
                {
                    throw new Exception("未定義の値です="+ name);
                }
                return it;
            }
        }
        [SerializeField]
        ItemAttribute itemAttribute;
        public ItemAttribute ItemAttribute => itemAttribute;

        [SerializeField]
        string rarity ="N";
        public Rarity Rarity
        {
            get
            {
                Rarity r;
                Enum.TryParse(rarity, out r);
                if (!Enum.IsDefined(typeof(Rarity), r))
                {
                    throw new Exception("未定義の値です=" + name);
                }
                return r;
            }
        }

        [SerializeField]
        float scaleX, scaleY;
        //[SerializeField]
        //float scaleY;

        //[SerializeField]
        //Vector2 itemScale = Vector2.one;
        public Vector2 ItemScale => new Vector2(scaleX, scaleY);

        [SerializeField]
        string containStory = "FALSE";
        public bool ContainStory => containStory == "TRUE";

        [SerializeField]
        string belongToGacha = "FALSE";
        public bool BelongToGacha => belongToGacha == "TRUE";

        [SerializeField]
        string defaultPossession = "FALSE";
        public bool DefaultPossession => defaultPossession == "TRUE";

        [SerializeField]
        int numberOfStories;
        public int NumberOfStories => numberOfStories;

        //[SerializeField]
        //string isSpecialItem= "FALSE";
        //public bool IsSpecialItem => isSpecialItem == "TRUE";

        //[SerializeField]
        //string 使用可能 = "FALSE";
        //public bool UseAble => 使用可能 == "TRUE";
        //[SerializeField]
        //string 閲覧可能 = "FALSE";
        //public bool WatchAble => 閲覧可能 == "TRUE";
        //[SerializeField]
        //string 友達と遊べる = "FALSE";
        //public bool PlayableWithFriends => 友達と遊べる == "TRUE";

        //[SerializeField]
        //string 模様替え効果ID1;
        //[SerializeField]
        //GameItemEffectName itemEffectOne;
        //public GameItemEffectName PrimaryGameItemEffect => itemEffectOne;

        //[SerializeField]
        //int 値1X;
        //public int PrimaryXValue => 値1X;
        //public int PrimaryXSeconds => 値1X * 60;

        //[SerializeField]
        //int 値1Y;
        //public int PrimaryYValue => 値1Y;
        //public bool PrimaryEffectIsTimeProcessing => JudgeTimeLapseProcessing(PrimaryGameItemEffect);

        //public string PrimaryInteriourDiscription
        //{
        //    get
        //    {
        //        if (itemEffectOne == GameItemEffectName.NONE) return "";
        //        string disc = Repository.GameSettings.InteriourEffectVOs.FirstOrDefault(ie => ie.ID == (int)itemEffectOne).Discription;
        //        disc = disc.Replace("{X}", 値1X+"").Replace("{Y}", 値1Y + "");
        //        return disc;
        //    }
        //}

        //[SerializeField]
        //string 模様替え効果ID2;
        //[SerializeField]
        //GameItemEffectName itemEffectTow;
        //public GameItemEffectName SecondaryGameItemEffect => itemEffectTow;

        //[SerializeField]
        //string インテリア属性;
        //public InteriourType InteriourType
        //{
        //    get
        //    {
        //        InteriourType interiour;
        //        Enum.TryParse(インテリア属性, out interiour);
        //        if (!Enum.IsDefined(typeof(InteriourType), interiour))
        //        {
        //            throw new Exception("未定義の値です=" + インテリア属性);
        //        }
        //        return interiour;
        //    }
        //}

        //public int ItemUsingHappyPointValue
        //{
        //    get
        //    {
        //        var primary = PrimaryGameItemEffect == GameItemEffectName.アイテム使用しあわせドロップ ? PrimaryYValue : 0;
        //        var secondary = SecondaryGameItemEffect == GameItemEffectName.アイテム使用しあわせドロップ ? SecondaryYValue : 0;
        //        return primary + secondary+10;

        //    }
        //}

        //public bool SecondaryEffectIsTimeProcessing => JudgeTimeLapseProcessing(SecondaryGameItemEffect);

        //[SerializeField]
        //int 値2X;
        //public int SecondaryXValue => 値2X;
        //public int SecindaryXSeconds => 値2X * 60;

        //[SerializeField]
        //int 値2Y;
        //public int SecondaryYValue => 値2Y;

        //public string SecondaryInteriourDiscription
        //{
        //    get
        //    {
        //        if (itemEffectTow ==  GameItemEffectName.NONE) return "";
        //        string disc = Repository.GameSettings.InteriourEffectVOs.FirstOrDefault(ie => ie.ID == (int)itemEffectTow).Discription;
        //        disc = disc.Replace("{X}", 値2X + "").Replace("{Y}", 値2Y + "");
        //        return disc;
        //    }
        //}



        //[SerializeField]
        //string 家具の上における = "FALSE";
        //public bool CanBePlacedOnTop => 家具の上における == "TRUE";

        //[SerializeField]
        //string 上に物をおける = "FALSE";
        //public bool PutThingsOnTop => 上に物をおける == "TRUE";

        public int PossessionCount => Repository.PossessionGameItems.Where(pg => pg.ID == this.ID).Count();

        public void Initialize()
        {
            //Enum.TryParse(模様替え効果ID1, out itemEffectOne);
            //Enum.TryParse(模様替え効果ID2, out itemEffectTow);
        }

        bool JudgeTimeLapseProcessing(GameItemEffectName gameItemEffectName)
        {
            switch (gameItemEffectName)
            {
                case GameItemEffectName.NONE:
                    return false;
                case GameItemEffectName.時間経過幸せドロップ:
                    return true;
                case GameItemEffectName.時間経過タップ:
                    return true;
                case GameItemEffectName.植物系アイテムの時間経過ドロップポイント増加:
                    return false;
                case GameItemEffectName.友達訪問UP:
                    return false;
                case GameItemEffectName.アイテム使用しあわせドロップ:
                    return true;
                case GameItemEffectName.時間経過まんぷくドロップ:
                    return true;
                case GameItemEffectName.アイテム使用まんぷくドロップ:
                    return true;
                case GameItemEffectName.時間経過まんぷくタップ:
                    return true;
                case GameItemEffectName.植物系時間ドロップUP:
                    return false;
                case GameItemEffectName.本系時間ドロップUP:
                    return false;
                case GameItemEffectName.ゲーム系時間ドロップUP:
                    return false;
                case GameItemEffectName.食べ物系時間ドロップUP:
                    return false;
                case GameItemEffectName.植物系ドロップ時間短縮:
                    return false;
                case GameItemEffectName.本系ドロップ時間短縮:
                    return false;
                case GameItemEffectName.ゲーム系ドロップ時間短縮:
                    return false;
                case GameItemEffectName.食べ物系ドロップ時間短縮:
                    return false;
                default:
                    throw new Exception("未定義の形式です。");
            }
        }

    }

    public enum InteriourEffectRanck
    {
        NONE,
        PRIMARY,
        SECONDARY,
    }

    public enum ItemAttribute
    {
        NONE,
        GAME,
        PLANT,
        TV,
        BOOK,
        ANY_USEABLE_ITEM,
    }

}