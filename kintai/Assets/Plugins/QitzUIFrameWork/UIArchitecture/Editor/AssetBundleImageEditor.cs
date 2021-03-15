using UnityEngine;
using UnityEditor;
using UnityEditor.UI;
using System.Collections;
using System;
using UnityEngine.UI;
//using UnityEngine.UI;


namespace Qitz.UISystem
{
    [CustomEditor(typeof(Image))]
    public class ImageEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }

    [CustomEditor(typeof(AssetBundleImage))]
    public class AssetBundleImageEditor : Editor
    {
        /// <summary>
        ///  ImageEditerExpanded
        /// </summary>
        public override void OnInspectorGUI()
        {
            var bh = target as AssetBundleImage;
            EditorGUILayout.LabelField("sourceImageName");
            EditorGUILayout.BeginHorizontal();
            bh.sourceImageName = EditorGUILayout.TextField(bh.sourceImageName, GUILayout.Width(200));
            //chara.maxHp     = EditorGUILayout.IntField( chara.maxHp, GUILayout.Width(48) );
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("SetNativeSize"))
            {
                //OK
                bh.SetNativeSize();
            }
            //----------------

            base.OnInspectorGUI();
        }

        [MenuItem("Qitzソフトツール/GitサーバーにPush #t", false, 12)]
        static void UpLoadData()
        {
            //var output = DoBashCommand("echo hello");
            //UnityEngine.Debug.Log(output);
            DoBashCommand("cd "+ Application.dataPath);
            DoBashCommand("git add .");
            DoBashCommand("git commit -m update");
            DoBashCommand("git push");
            Debug.Log("GitサーバーにPush完了");
        }

        static string DoBashCommand(string cmd)
        {
            var p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "/bin/bash";
            p.StartInfo.Arguments = "-c \" " + cmd + " \"";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();

            var output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();

            return output;
        }

        [MenuItem("Qitzソフトツール/セーブデータを削除 #t", false, 12)]
        static void DeleatSaveData()
        {
            PlayerPrefs.DeleteAll();
        }

        [MenuItem("Qitzソフトツール/アセバンイメージの参照を取り除く #t", false, 12)]
        static void RemoveAssetBundleImageReference()
        {
            var guids = AssetDatabase.FindAssets("t:prefab");
            RemoveAssetBundleImageReferenceFromGuids(guids);
            //---------------
            EachScene("アセバンイメージの参照を取り除く", (path) =>
            {
                return RemoveAssetBundleImageSpriteReference();
            });
        }

        [MenuItem("Qitzソフトツール/ImageをAssetBundleImageに差し替える #t", false, 12)]
        static void RePlaceAssetBundleImageReference()
        {
            var guids = AssetDatabase.FindAssets("t:prefab");
            ReplaceAssetBundleImagesInPrefabs(guids);
            //---------------
            EachScene("ImageをAssetBundleImageに差し替える", (path) =>
            {
                return ReplaceAssetBundleImageSpriteReference();
            });
        }

        static bool ReplaceAssetBundleImageSpriteReference()
        {
            Image[] _images = UnityEngine.Object.FindObjectsOfType(typeof(Image)) as Image[];
            if (_images.Length == 0)
                return false;
            foreach (Image _image in _images)
            {
                var gameObj = _image.gameObject;
                //if(!AssetBundleImage.Equals(_image.GetType())){
                var sourceImage = _image.sprite;
                var imageType = _image.type;
                var imageColor = _image.color;
                DestroyImmediate(gameObj.GetComponent<Image>());
                var _assetBundleImage = gameObj.AddComponent<AssetBundleImage>();

                if (_assetBundleImage != null)
                {
                    _assetBundleImage.sprite = sourceImage;
                    _assetBundleImage.type = imageType;
                    _assetBundleImage.color = imageColor;
                    //_assetBundleImage.sourceImageName = sourceImage.name;
                }
                //}
            }
            return true;
        }

        //--------------------------------

        static void ReplaceAssetBundleImagesInPrefabs(string[] guids)
        {
            foreach (var guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                var _gameObject = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                if (_gameObject != null)
                {
                    ReplaceImageToAssetBundleImage(_gameObject.GetComponent<Image>());

                    GetAllGameObjectInPrefab(_gameObject.transform, (gameObj) =>
                    {
                        var _image = gameObj.GetComponent<Image>();
                        ReplaceImageToAssetBundleImage(_image);
                    });

                }
            }
        }

        static void ReplaceImageToAssetBundleImage(Image _image)
        {
            if (_image != null)
            {
                var gameObj = _image.gameObject;
                var sourceImage = _image.sprite;
                var imageType = _image.type;
                var imageColor = _image.color;
                DestroyImmediate(gameObj.GetComponent<Image>(), true);
                var _assetBundleImage = gameObj.AddComponent<AssetBundleImage>();
                if(_assetBundleImage != null)
                {
                    _assetBundleImage.sprite = sourceImage;
                    _assetBundleImage.type = imageType;
                    _assetBundleImage.color = imageColor;
                }


                //_assetBundleImage.sourceImageName = _assetBundleImage.sprite.name;
            }
        }

        static void RemoveAssetBundleImageReferenceFromGuids(string[] guids)
        {
            foreach (var guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                var _gameObject = AssetDatabase.LoadAssetAtPath<GameObject>(path);
                if (_gameObject != null)
                {

                    GetAllGameObjectInPrefab(_gameObject.transform, (gameObj) =>
                    {
                        var assetBundleImage = gameObj.GetComponent<AssetBundleImage>();
                        if (assetBundleImage != null)
                        {
                            Debug.Log("RemoveSpriteReference=" + assetBundleImage.name);
                            assetBundleImage.RemoveImageReference();
                        }
                    });

                }
            }
        }

        static void GetAllGameObjectInPrefab(Transform target, Action<GameObject> action)
        {
            foreach (Transform child in target)
            {
                GetAllGameObjectInPrefab(child, action);
                action(child.gameObject);
                Debug.Log("GameObjectName=" + child.name);
            }
        }

        //-----------------------------------------------
        static bool RemoveAssetBundleImageSpriteReference()
        {
            AssetBundleImage[] labels = UnityEngine.Object.FindObjectsOfType(typeof(AssetBundleImage)) as AssetBundleImage[];
            if (labels.Length == 0)
                return false;
            foreach (AssetBundleImage label in labels)
            {
                Debug.Log("SceneGameObject=" + label.gameObject.name);
                label.sprite = null;
            }
            return true;
        }

        //---------------全てのシーンを順に開いてなにかするメソッド
        delegate bool OnScene(string path);
        static void EachScene(string title, OnScene onScene)
        {
            string currentScene = EditorApplication.currentScene;
            string[] sceneGuids = AssetDatabase.FindAssets("t:Scene");
            for (int i = 0; i < sceneGuids.Length; ++i)
            {
                string guid = sceneGuids[i];
                string path = AssetDatabase.GUIDToAssetPath(guid);
                EditorUtility.DisplayProgressBar(title, path, (float)i / (float)sceneGuids.Length);
                EditorApplication.OpenScene(path);
                if (onScene(path))
                    EditorApplication.SaveScene();
            }
            EditorUtility.ClearProgressBar();
            if (!string.IsNullOrEmpty(currentScene))
                EditorApplication.OpenScene(currentScene);
        }
        //-----------------------------


    }
}