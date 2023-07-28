using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Linq;

public class NumberOfRemaining : MonoBehaviour
{
    public Text NumberObRemaining;
    [SerializeField]
    private GameManager _gameManager;

    // エリア内にいるトンガルくんの個数を保持する配列
    private List<GameObject> _tongullkunObjects;

    // 見つけていないトンガルくんの数
    private int _remainingNumberOfTongullkun;

    private bool _isGameClear = false;


    void Start()
    {

    }

    void Update()
    {

    }

    public void SetTongullkunCount()
    {
        _tongullkunObjects = _gameManager.TargetTongullkuns;
        _remainingNumberOfTongullkun = _tongullkunObjects.Count;

        NumberObRemaining.text = "あと" + _remainingNumberOfTongullkun + "匹隠れてるよ";

    }

    public void UpdateTongullkunCount()
    {
        _remainingNumberOfTongullkun -= 1;
        NumberObRemaining.text = "あと" + _remainingNumberOfTongullkun + "匹隠れてるよ";


        // 見つかっていないトンガルくんが0匹かつ、_isGameClearがfalseの場合はクリア
        if (_remainingNumberOfTongullkun < 1 && !_isGameClear)
        {
            _isGameClear = true;
            _gameManager.GetComponent<GameManager>().GameClear();
        }
    }
}
