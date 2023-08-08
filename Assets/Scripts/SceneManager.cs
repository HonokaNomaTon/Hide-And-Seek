using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    public static SceneManager instance;
    [SerializeField]
    private GameObject _oVRCameraController;

    /// <summary>
    /// ステージの種類
    /// </summary>
    enum STAGE_NAME
    {
        Stage1,
        Stage2,
        Stage3
    }

    /// <summary>
    /// cameraの初期位置
    /// </summary>
    private Vector3 _initCameraPos = new Vector3(0,1,0);

    private string _nextStageName;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //_oVRCameraController.transform.position = _initCameraPos;
    }

    void Update()
    {

    }

    /// <summary>
    /// Sceneの切り替え
    /// </summary>
    public void ChangeScene()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Stage2");
        Debug.Log("Scene読み込み");

        
        switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
        {
            case "Stage1":
                _nextStageName = STAGE_NAME.Stage2.ToString();
                break;
            case "Stage2":
                _nextStageName = STAGE_NAME.Stage3.ToString();
                break;
            case "Stage3":
                _nextStageName = STAGE_NAME.Stage1.ToString(); // 一旦Stage1に戻らせる
                break;
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene(_nextStageName);
        
    }
}
