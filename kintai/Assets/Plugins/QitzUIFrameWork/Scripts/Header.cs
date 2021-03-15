using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class Header : MonoBehaviour {

    [SerializeField]
    Text title;
    [SerializeField]
    Button returnButton;

    void Start()
    {

    }

    public void GotoHome()
    {
        SceneLoaderWithTween.LoadScene("Top");
    }
    public void GotoMenu()
    {
        SceneLoaderWithTween.LoadScene("Settings");
    }
}
