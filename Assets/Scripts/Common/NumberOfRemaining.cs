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
    private GameObject[] _tongullkunObjects;

    // 見つけていないトンガルくんの数
    private int _remainingNumberOfTongullkun;

    private bool _isGameClear;


    void Start()
    {
        _tongullkunObjects = GameObject.FindGameObjectsWithTag("Target");
        _remainingNumberOfTongullkun = _tongullkunObjects.Length + 1;
    }

    void Update()
    {
        /*
        for(int i=0; i < _tongullkunObjects.Length; i++)
        {
            if (_tongullkunObjects[i].CompareTag("Target"))
            {
                _remainingNumberOfTongullkun = i;
            }
        }
        */

        
        NumberObRemaining.text = "あと" + _remainingNumberOfTongullkun + "人隠れてるよ";

        // 見つかっていないトンガルくんが0体かつ、_isGameClearがfalseの場合はクリア
        float a = float.Parse(_tongullkunObjects.Length.ToString());
        if (a < 1 && !_isGameClear)
        {
            _isGameClear = true;
            _gameManager.GetComponent<GameManager>().GameClear();
        }
    }
}
