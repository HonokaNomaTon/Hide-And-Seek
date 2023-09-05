using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeStageButton : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.Instance.MenuSecene();
    }

    public void NextStage()
    {
        SceneManager.Instance.ChangeScene();
    }

}
