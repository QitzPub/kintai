using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UniRx;
using UniRx.Async;
using UnityEngine.SceneManagement;
//using BLDKEscapeOut.Presenter;
//using BLDKEscapeOut.Controller;
//using BLDKEscapeOut.Entity;
//using BLDKEscapeOut.Repository;

public class QitzDebugManager : MonoBehaviour
    {

        [SerializeField]
        GameObject debugDisplay;

        void Start()
        {
            if (UnityEngine.Debug.isDebugBuild)
            {
                SRDebug.Init();
                SceneManager.sceneLoaded += SceneLoaded;
                debugDisplay.SetActive(true);
            }
            else
            {
                debugDisplay.SetActive(false);
            }
        }
        // イベントハンドラー（イベント発生時に動かしたい処理）
        void SceneLoaded(Scene nextScene, LoadSceneMode mode)
        {
        }

    }

public partial class SROptions
{
    //EscapeOutController outGameController => (EscapeOutController)Transform.FindObjectOfType(typeof(EscapeOutController));
    //EscapeOutPresenter presenter => (EscapeOutPresenter)Transform.FindObjectOfType(typeof(EscapeOutPresenter));
    //EscapeOutRepository repository => (EscapeOutRepository)Transform.FindObjectOfType(typeof(EscapeOutRepository));


    //public void しあわせポイントを1000増やす()
    //{
    //    outGameController.SetCurrentHappynessPoint(presenter.CurrentHappynessPoint+1000);
    //}
    //public void しあわせポイントを10000増やす()
    //{
    //    outGameController.SetCurrentHappynessPoint(presenter.CurrentHappynessPoint + 10000);
    //}
    //public void まんぷくどを全回復()
    //{
    //    repository.SetCurrentFullness(10);
    //}

    //public void アイテムを全て手に入れる()
    //{
    //    foreach (var gi in presenter.AllGameItems)
    //    {
    //        repository.AddPossessionItems(gi.ID);
    //    }
    //}

    public void ゲームセーブデータを削除()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    //public void 英熟語問題を全問正解にする()
    //{
    //    foreach (var item in repository.EnglishPhraseQuizSets)
    //    {
    //        SetRightQuizElements(item);
    //    }
    //}
    //public void 数学問題を全問正解にする()
    //{
    //    foreach (var item in repository.ArithmeticQuizSets)
    //    {
    //        SetRightQuizElements(item);
    //    }
    //}
    //public void 社会問題を全問正解にする()
    //{
    //    foreach (var item in repository.SocietyQuizSets)
    //    {
    //        SetRightQuizElements(item);
    //    }
    //}
    //public void 国語問題を全問正解にする()
    //{
    //    foreach (var item in repository.JapaneseQuizSets)
    //    {
    //        SetRightQuizElements(item);
    //    }
    //}
    //public void 理科問題を全問正解にする()
    //{
    //    foreach (var item in repository.ScienceQuizSets)
    //    {
    //        SetRightQuizElements(item);
    //    }
    //}
    //string newLine = "\n";
    //private const string MAIL_ADRESS = "ikauka456@gmail.com";

    //public void 英単語問題の解答状況をDump出力してメール送信()
    //{
    //    string subject = $"英単語問題の解答状況をDump出力してメール送信";
    //    string body = newLine;

    //    foreach (var quizSet in repository.EnglishQuizSets)
    //    {
    //        var rightAndWrong = outGameController.OutGameRepository.UserVO.GetRightAndWrongSet(quizSet.QuizElements.FirstOrDefault());
    //        if (rightAndWrong != null)
    //        {
    //            foreach (var rw in rightAndWrong.RightAndWrongElements)
    //            {
    //                var problemState = rw.IsRight == 1 ? "正解" : "不正解";
    //                body += rw.QuizElement.ID + "," + rw.QuizElement.ProblemLevel + "," + rw.QuizElement.SetNumber + "," + problemState + newLine;
    //            }
    //        }
    //        else
    //        {
    //            foreach (var q in quizSet.QuizElements)
    //            {
    //                var problemState = "未解答";
    //                body += q.ID + "," + q.ProblemLevel + "," + q.SetNumber + "," + problemState + newLine;
    //            }
    //        }
    //    }

    //    //エスケープ処理
    //    body = System.Uri.EscapeDataString(body);
    //    subject = System.Uri.EscapeDataString(subject);
    //    Application.OpenURL("mailto:" + MAIL_ADRESS + "?subject=" + subject + "&body=" + body);

    //}
    //public void 英熟語問題の解答状況をDump出力してメール送信()
    //{
    //    string subject = $"英熟語問題の解答状況をDump出力してメール送信";
    //    string body = newLine;

    //    foreach (var quizSet in repository.EnglishPhraseQuizSets)
    //    {
    //        var rightAndWrong = outGameController.OutGameRepository.UserVO.GetRightAndWrongSet(quizSet.QuizElements.FirstOrDefault());
    //        if (rightAndWrong != null)
    //        {
    //            foreach (var rw in rightAndWrong.RightAndWrongElements)
    //            {
    //                var problemState = rw.IsRight == 1 ? "正解" : "不正解";
    //                body += rw.QuizElement.ID + "," + rw.QuizElement.ProblemLevel + "," + rw.QuizElement.SetNumber + "," + problemState + newLine;
    //            }
    //        }
    //        else
    //        {
    //            foreach (var q in quizSet.QuizElements)
    //            {
    //                var problemState = "未解答";
    //                body += q.ID + "," + q.ProblemLevel + "," + q.SetNumber + "," + problemState + newLine;
    //            }
    //        }
    //    }

    //    //エスケープ処理
    //    body = System.Uri.EscapeDataString(body);
    //    subject = System.Uri.EscapeDataString(subject);
    //    Application.OpenURL("mailto:" + MAIL_ADRESS + "?subject=" + subject + "&body=" + body);

    //}

    //public void 理科問題の解答状況をDump出力してメール送信()
    //{
    //    string subject = $"理科問題の解答状況をDump出力してメール送信";
    //    string body = newLine;

    //    foreach (var quizSet in repository.ScienceQuizSets)
    //    {
    //        var rightAndWrong = outGameController.OutGameRepository.UserVO.GetRightAndWrongSet(quizSet.QuizElements.FirstOrDefault());
    //        if(rightAndWrong != null)
    //        {
    //            foreach (var rw in rightAndWrong.RightAndWrongElements)
    //            {
    //                var problemState = rw.IsRight == 1 ? "正解" : "不正解";
    //                body += rw.QuizElement.ID + "," + rw.QuizElement.ProblemLevel + "," + rw.QuizElement.SetNumber + "," + problemState + newLine;
    //            }
    //        }
    //        else
    //        {
    //            foreach (var q in quizSet.QuizElements)
    //            {
    //                var problemState = "未解答";
    //                body += q.ID + "," + q.ProblemLevel + "," + q.SetNumber + "," + problemState + newLine;
    //            }
    //        }
    //    }

    //    //エスケープ処理
    //    body = System.Uri.EscapeDataString(body);
    //    subject = System.Uri.EscapeDataString(subject);
    //    Application.OpenURL("mailto:" + MAIL_ADRESS + "?subject=" + subject + "&body=" + body);

    //}
    //public void 国語問題の解答状況をDump出力してメール送信()
    //{
    //    string subject = $"国語問題の解答状況をDump出力してメール送信";
    //    string body = newLine;

    //    foreach (var quizSet in repository.JapaneseQuizSets)
    //    {
    //        var rightAndWrong = outGameController.OutGameRepository.UserVO.GetRightAndWrongSet(quizSet.QuizElements.FirstOrDefault());
    //        if (rightAndWrong != null)
    //        {
    //            foreach (var rw in rightAndWrong.RightAndWrongElements)
    //            {
    //                var problemState = rw.IsRight == 1 ? "正解" : "不正解";
    //                body += rw.QuizElement.ID + "," + rw.QuizElement.ProblemLevel + "," + rw.QuizElement.SetNumber + "," + problemState + newLine;
    //            }
    //        }
    //        else
    //        {
    //            foreach (var q in quizSet.QuizElements)
    //            {
    //                var problemState = "未解答";
    //                body += q.ID + "," + q.ProblemLevel + "," + q.SetNumber + "," + problemState + newLine;
    //            }
    //        }
    //    }

    //    //エスケープ処理
    //    body = System.Uri.EscapeDataString(body);
    //    subject = System.Uri.EscapeDataString(subject);
    //    Application.OpenURL("mailto:" + MAIL_ADRESS + "?subject=" + subject + "&body=" + body);

    //}
    //public void 社会問題の解答状況をDump出力してメール送信()
    //{
    //    string subject = $"社会問題の解答状況をDump出力してメール送信";
    //    string body = newLine;

    //    foreach (var quizSet in repository.SocietyQuizSets)
    //    {
    //        var rightAndWrong = outGameController.OutGameRepository.UserVO.GetRightAndWrongSet(quizSet.QuizElements.FirstOrDefault());
    //        if (rightAndWrong != null)
    //        {
    //            foreach (var rw in rightAndWrong.RightAndWrongElements)
    //            {
    //                var problemState = rw.IsRight == 1 ? "正解" : "不正解";
    //                body += rw.QuizElement.ID + "," + rw.QuizElement.ProblemLevel + "," + rw.QuizElement.SetNumber + "," + problemState + newLine;
    //            }
    //        }
    //        else
    //        {
    //            foreach (var q in quizSet.QuizElements)
    //            {
    //                var problemState = "未解答";
    //                body += q.ID + "," + q.ProblemLevel + "," + q.SetNumber + "," + problemState + newLine;
    //            }
    //        }
    //    }

    //    //エスケープ処理
    //    body = System.Uri.EscapeDataString(body);
    //    subject = System.Uri.EscapeDataString(subject);
    //    Application.OpenURL("mailto:" + MAIL_ADRESS + "?subject=" + subject + "&body=" + body);

    //}

    //public void 数学問題の解答状況をDump出力してメール送信()
    //{
    //    string subject = $"数学問題の解答状況をDump出力してメール送信";
    //    string body = newLine;

    //    foreach (var quizSet in repository.ArithmeticQuizSets)
    //    {
    //        var rightAndWrong = outGameController.OutGameRepository.UserVO.GetRightAndWrongSet(quizSet.QuizElements.FirstOrDefault());
    //        if (rightAndWrong != null)
    //        {
    //            foreach (var rw in rightAndWrong.RightAndWrongElements)
    //            {
    //                var problemState = rw.IsRight == 1 ? "正解" : "不正解";
    //                body += rw.QuizElement.ID + "," + rw.QuizElement.ProblemLevel + "," + rw.QuizElement.SetNumber + "," + problemState + newLine;
    //            }
    //        }
    //        else
    //        {
    //            foreach (var q in quizSet.QuizElements)
    //            {
    //                var problemState = "未解答";
    //                body += q.ID + "," + q.ProblemLevel + "," + q.SetNumber + "," + problemState + newLine;
    //            }
    //        }
    //    }

    //    //エスケープ処理
    //    body = System.Uri.EscapeDataString(body);
    //    subject = System.Uri.EscapeDataString(subject);
    //    Application.OpenURL("mailto:" + MAIL_ADRESS + "?subject=" + subject + "&body=" + body);

    //}

    //public void 破損アセットがないかDumpしてチェックする()
    //{
    //    //var ga = new GameObject();
    //    //var gamecontrollerObject = PrefabFolder.ResourcesLoadInstantiateTo("GameController", ga.transform.parent);
    //    //var gameController = gamecontrollerObject.GetComponent<OutGameController>();
    //    var targetQuizSet = new List<List<IQuizSetVO>>() {
    //            outGameController.OutGameRepository.EnglishQuizSets,
    //            outGameController.OutGameRepository.EnglishPhraseQuizSets,
    //            outGameController.OutGameRepository.ArithmeticQuizSets,
    //            outGameController.OutGameRepository.JapaneseQuizSets,
    //            outGameController.OutGameRepository.SocietyQuizSets,
    //            outGameController.OutGameRepository.ScienceQuizSets,
    //        };
    //    var quizElements = targetQuizSet.SelectMany(qsl => qsl).SelectMany(qs => qs.QuizElements).Where(q=>q.ExistPicture);

    //    foreach (var q in quizElements)
    //    {
    //        Debug.Log(outGameController.GetSpriteFromQuizElemnt(q).name);
    //    }


    //}


    //private bool showCollect = false;
    //public bool ShowQuizCorrectAnswor
    //{
    //    get { return showCollect; }
    //    set { showCollect = value; }
    //}
    //private bool emulateIphoneX = false;
    //public bool EmulateIphoneX
    //{
    //    get { return emulateIphoneX; }
    //    set { emulateIphoneX = value; }
    //}

    //void SetRightQuizElements(IQuizSetVO quizSetVO)
    //{
    //    List<RightAndWrongElement> elements = new List<RightAndWrongElement>();
    //    for (int i = 0; i < quizSetVO.QuizElements.Count; i++)
    //    {
    //        int isRight = 1;
    //        var rightAndWrongElement = new RightAndWrongElement(isRight, quizSetVO.QuizElements[i]);
    //        elements.Add(rightAndWrongElement);
    //    }

    //    RightAndWrongSet rightAndWrongSets = new RightAndWrongSet(elements);
    //    //ここでユーザーデータの更新を行う：正解数などの更新
    //    repository.SetRightAndWrongSets(rightAndWrongSets);
    //}

}
