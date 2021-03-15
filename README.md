# QitzのUnityアプリスケルトン的なブツVer0.1

## これはなんぞ？？

こちら、クリーンアーキテクチャベースのUnityプロジェクトの雛形的な物です

## 使い方のサンプル

![画像](https://i.gyazo.com/31845196720b075a385175971dc0be8c.png "スクショ")
<br>
Assets/MyOutArchitecture/Demo/Scenes<br>
を開く！！！！！！<br>
<br>

### シーンの中身を観察する！！

![画像](https://i.gyazo.com/7a71c2ec1efeb1a91ad80231ea4ece97.png "スクショ")
<br>
<br>
#### ManpukuGaugeView
ソシャゲのスタミナ的なぶつを表示するためのやつです
(ViewなのでPresenterと通信可能です)

#### ConsumeStaminaRecepter
スタミナを消費する的なサンプルです
(RecepterなのでControllerと通信可能です)

#### SceneLoadRecepter
シーン遷移処理を叩くサンプル
(RecepterなのでControllerと通信可能です)

## ViewのScriptの作り方！！！！！
![画像](https://i.gyazo.com/c32df779014a763a0084fbc8ad879f91.png "スクショ")
<br>
<br>
プロジェクト中で右クリック -> Create -> QutzScripts -> Qitz.View
<br>
 を選択！！！！

## RecepterのScriptの作り方！！！！！
![画像](https://i.gyazo.com/f2d64d28cb2db5a0d252444a7a410a80.png "スクショ")
<br>
<br>
プロジェクト中で右クリック -> Create -> QutzScripts -> Qitz.Recepter
<br>
 を選択！！！！
 
 
