using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 各トンガルくんPrefab
    [SerializeField]
    private GameObject _targetTongullkunPrefab;
    [SerializeField]
    private GameObject _fakeTongullkunPrefab;

    // 各トンガルくんの生成数
    [SerializeField]
    private int _generateTargetTongullkunCount;
    [SerializeField]
    private int _generateFakeTongullkunCount;

    // 各トンガルくんを管理する配列
    private List<GameObject> _targetTongullkuns = new List<GameObject>();
    public List<GameObject> TargetTongullkuns
    {
        get { return _targetTongullkuns; }
    }
    private List<GameObject> _fakeTongullkuns = new List<GameObject>();
    public List<GameObject> FakeTongullkuns
    {
        get { return _fakeTongullkuns; }
    }

    [SerializeField]
    private Text _clearText;

    [SerializeField]
    private NumberOfRemaining _numberOfRemaining;

    private GameObject targetObj, fakeObj;

    void Start()
    {
        GenerateTongullkun();
    }

    void Update()
    {
        
    }


    /// <summary>
    /// 各トンガルくんを生成
    /// </summary>
    void GenerateTongullkun()
    {
        for (int i = 0; i < _generateTargetTongullkunCount; i++)
        {
            targetObj = Instantiate(_targetTongullkunPrefab, new Vector3(2f,1.3f,6f), Quaternion.identity);
            _targetTongullkuns.Add(targetObj);
        }

        for (int i = 0; i < _generateFakeTongullkunCount; i++)
        {
            fakeObj = Instantiate(_fakeTongullkunPrefab, new Vector3(-2f, 1.3f, 6f), Quaternion.identity);
            _fakeTongullkuns.Add(fakeObj);
        }

        _numberOfRemaining.SetTongullkunCount();
    }

    /// <summary>
    /// ゲームクリア時の処理
    /// </summary>
    public void GameClear()
    {
        _clearText.text = "ゲームクリア！";
        Invoke(nameof(NextStage), 2.0f);
    }

    /// <summary>
    /// 次のステージへ遷移
    /// </summary>
    void NextStage()
    {
        SceneManager.Instance.ChangeScene();
    }
}
