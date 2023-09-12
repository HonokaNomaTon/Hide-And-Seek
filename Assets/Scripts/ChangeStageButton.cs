using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeStageButton : MonoBehaviour
{
    [SerializeField]
    public int index = 0;

    private bool _isOn = false;
    public bool isOn
    {
        get { return _isOn; }
    }



    public void Menu()
    {
        SceneManager.Instance.MenuSecene();
    }

    public void NextStage()
    {
        SceneManager.Instance.ChangeScene();
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// メニューボタンの選択状態を変更
    /// </summary>
    public void ChangeBtnState(bool b)
    {
        _isOn = b;
    }
}
