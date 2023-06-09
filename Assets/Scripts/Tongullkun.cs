using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongullkun : MonoBehaviour
{
    // トンガルくんのState管理
    enum TONGULL_STATE
    {
        HIDDEN, // 隠れてる状態
        SELECT, // 選択状態
        FOUND  // 見つかった状態
    }

    // 判定用sprite
    [SerializeField] Sprite judgeSprite;
    [SerializeField] SpriteRenderer judgeSpriteRenderer;
    [SerializeField] SpriteRenderer tongullkunSpriteRenderer;

    private TONGULL_STATE _state;

    void Start()
    {

    }

    
    void Update()
    {
        switch (_state)
        {
            case TONGULL_STATE.HIDDEN:
                ChangeColor(255);
                break;
            case TONGULL_STATE.SELECT:
                ChangeColor(176);
                break;
        }
    }

    /// <summary>
    /// トンガルくんが選択されている時
    /// </summary>
    public void Select()
    {
        _state = TONGULL_STATE.SELECT;
    }

    /// <summary>
    /// トンガルくんを見つけた時
    /// </summary>
    public void Found()
    {
        _state = TONGULL_STATE.FOUND;
        ShowJudgeSprite();

    }

    /// <summary>
    /// 判定用のSpriteを表示
    /// </summary>
    private void ShowJudgeSprite()
    {
        judgeSpriteRenderer.sprite = judgeSprite;
        this.tag = "Finish";
    }

    /// <summary>
    /// トンガルくんSpriteの色変更
    /// </summary>
    private void ChangeColor(int colorValue)
    {
        tongullkunSpriteRenderer.color = new Color(colorValue, colorValue, colorValue);
    }

}
