using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberOfRemaining : MonoBehaviour
{
    public Text NumberObRemaining;
    public Text ClearText;
    public ControllerManager _controllermanager;
    void Start()
    {
        
    }

    void Update()
    {
        GameObject[] tongullkunObjects = GameObject.FindGameObjectsWithTag("Target");
        NumberObRemaining.text = "あと" + tongullkunObjects.Length.ToString() +"人隠れてるよ";


        float a = float.Parse(tongullkunObjects.Length.ToString());
        if (a < 1)
        {
            ClearText.text = "ゲームクリア！";
            Invoke(nameof(nextStage), 2.0f);
        }

        void nextStage()
        {
            //まだ変わらないです！
            //一瞬しか呼ばれてないからかも！
            _controllermanager.ChangeScene();
        }
    }
}
