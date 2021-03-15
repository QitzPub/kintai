using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BLDKEscapeOut.View;

namespace BLDKEscapeOut.Entity
{

    public enum GameItemEffectName
    {
        NONE=0,
        時間経過幸せドロップ=1,
        時間経過タップ=2,
        植物系アイテムの時間経過ドロップポイント増加=3,
        友達訪問UP=4,
        アイテム使用しあわせドロップ=5,
        時間経過まんぷくドロップ=6,
        アイテム使用まんぷくドロップ=7,
        時間経過まんぷくタップ = 8,
        植物系時間ドロップUP = 9,
        本系時間ドロップUP = 10,
        ゲーム系時間ドロップUP = 11,
        食べ物系時間ドロップUP = 12,
        植物系ドロップ時間短縮 = 13,
        本系ドロップ時間短縮 = 14,
        ゲーム系ドロップ時間短縮 = 15,
        食べ物系ドロップ時間短縮 = 16,

    }

    public enum InteriourType
    {
        NONE,
        植物,
        本,
        ゲーム,
        食べ物,
    }

}