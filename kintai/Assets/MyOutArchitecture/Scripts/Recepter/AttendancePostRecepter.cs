using System.Collections;
using System.Collections.Generic;
using BLDKEscapeOut.Recepter;
using UnityEngine;
using UnityEngine.UI;

public class AttendancePostRecepter : BaseRecepter
{
    [SerializeField]
    Button button;
    [SerializeField]
    InputField workDetailInputField;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            Controller.PostAttendance(workDetailInputField.text, null);
        });
    }
}
