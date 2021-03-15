using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateQitzUIMenu : Editor
{

    [MenuItem("GameObject/QitzUI/AssetBundleImage", priority = 21)]
    public static void CreateAssetBundleImage()
    {
        var obj = (GameObject)Resources.Load("AssetBundleImage");
        GameObject ga = UnityEditor.PrefabUtility.InstantiatePrefab(obj) as GameObject;
        ga.transform.SetParent(Selection.gameObjects[0].transform.parent);
        ga.transform.SetSiblingIndex(Selection.gameObjects[0].transform.GetSiblingIndex() + 1);
        ga.transform.localScale = Vector3.one;
        ga.transform.localPosition = Vector3.zero;
        PrefabUtility.UnpackPrefabInstance(ga, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
    }
    [MenuItem("GameObject/QitzUI/LocalizeText", priority = 22)]
    public static void CreateLocalizeText()
    {
        var obj = (GameObject)Resources.Load("LocalizeText");
        GameObject ga = UnityEditor.PrefabUtility.InstantiatePrefab(obj) as GameObject;
        ga.transform.SetParent(Selection.gameObjects[0].transform.parent);
        ga.transform.SetSiblingIndex(Selection.gameObjects[0].transform.GetSiblingIndex() + 1);
        ga.transform.localScale = Vector3.one;
        ga.transform.localPosition = Vector3.zero;
        PrefabUtility.UnpackPrefabInstance(ga, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
    }

    [MenuItem("GameObject/QitzUI/AssetBundleButton", priority = 23)]
    public static void CreateAssetBundleButton()
    {
        var obj = (GameObject)Resources.Load("AssetBundleButton");
        GameObject ga = UnityEditor.PrefabUtility.InstantiatePrefab(obj) as GameObject;
        ga.transform.SetParent(Selection.gameObjects[0].transform.parent);
        ga.transform.SetSiblingIndex(Selection.gameObjects[0].transform.GetSiblingIndex() + 1);
        ga.transform.localScale = Vector3.one;
        ga.transform.localPosition = Vector3.zero;
        PrefabUtility.UnpackPrefabInstance(ga, PrefabUnpackMode.OutermostRoot, InteractionMode.AutomatedAction);
    }
}
