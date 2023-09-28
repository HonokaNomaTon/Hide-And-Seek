using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
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

    // トンガルくんの生成位置を管理するリスト
    [SerializeField]
    private List<Transform> TongullPositionList;
    private List<Vector3> RemainingTongullkunPositionList = new List<Vector3>();
    private int _beforePosIndex = 0;
    private int _nowPosIndex = 0;

    [SerializeField]
    private Text _clearText;
    [SerializeField]
    private GameObject _MenuButton;
    [SerializeField]
    private GameObject _NextStageButton;

    [SerializeField]
    private NumberOfRemaining _numberOfRemaining;

    private GameObject targetObj, fakeObj;

    void Start()
    {
        RemainingTongullkunPosSet();
        GenerateTongullkun();
    }

    /// <summary>
    /// 各トンガルくんを生成
    /// </summary>
    void GenerateTongullkun()
    {
        for (int i = 0; i < _generateTargetTongullkunCount; i++)
        {
            Transform t = GetTransform();
            targetObj = Instantiate(_targetTongullkunPrefab,t.position ,t.rotation);

            _targetTongullkuns.Add(targetObj);
        }

        for (int i = 0; i < _generateFakeTongullkunCount; i++)
        {
            Transform t = GetTransform();
            targetObj = Instantiate(_fakeTongullkunPrefab, t.position, t.rotation);

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
        _MenuButton.SetActive(true);
        _NextStageButton.SetActive(true);
        //Invoke(nameof(NextStage), 2.0f);
    }

    /// <summary>
    /// 次のステージへ遷移
    /// </summary>
    public void NextStage()
    {
        SceneManager.Instance.ChangeScene();
    }

    /// <summary>
    /// トンガルくん生成位置を取得
    /// </summary>
    Transform GetTransform()
    {
        int pos = Random.Range(0, TongullPositionList.Count);

        //トンガルくんの生成位置リストが0の時
        if (TongullPositionList.Count == 0)
        {
            while (_beforePosIndex == _nowPosIndex)
            {
                _nowPosIndex = Random.Range(0, RemainingTongullkunPositionList.Count);
                Debug.Log("_nowPosIndex: " + _nowPosIndex);
                Debug.Log("_beforePosIndex: " + _beforePosIndex);
            }

            transform.position = RemainingTongullkunPositionList[_nowPosIndex];
            _beforePosIndex = _nowPosIndex;
            return transform;
        }

        Transform t = TongullPositionList[pos];
        DeletePosition(pos);
        return t;
    }

    /// <summary>
    /// トンガルくん生成位置リストから削除
    /// </summary>
    private void DeletePosition(int num)
    {
        TongullPositionList.RemoveAt(num);
    }

    /// <summary>
    /// 生成位置がないトンガルくん用の生成位置リストをセット
    /// </summary>
    private void RemainingTongullkunPosSet()
    {
        RemainingTongullkunPositionList.Add(new Vector3(0, 1, 5));
        RemainingTongullkunPositionList.Add(new Vector3(5, 1, 10));
        RemainingTongullkunPositionList.Add(new Vector3(10, 1, 20));
    }
}
