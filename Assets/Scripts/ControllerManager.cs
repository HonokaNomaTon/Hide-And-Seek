using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager instance;

    void Awake()
    {
        CheckInstance();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }

    /// <summary>
    /// インスタンスが存在してるかのチェック
    /// </summary>
    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Sceneの切り替え
    /// </summary>
    public void ChangeScene()
    {
        SceneManager.LoadScene("Stage2");
    }
}
