using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;

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
    [SerializeField] Sprite BackJudgeSprite;
    [SerializeField] SpriteRenderer judgeSpriteRenderer;
    [SerializeField] SpriteRenderer BackJudgeSpriteRebderer;
    [SerializeField] SpriteRenderer tongullkunSpriteRenderer;

    private TONGULL_STATE _state;

    void Start()
    {
        _state = TONGULL_STATE.HIDDEN;
    }

    
    void Update()
    {
        switch (_state)
        {
            case TONGULL_STATE.HIDDEN:
                ChangeColor(1);
                break;
            case TONGULL_STATE.SELECT:
                ChangeColor(0.65f);
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
        if(this.tag == "Target")
        {
            SEManager.Instance.Play(SEPath.OK);
        }
        else if (this.tag == "Fake")
        {
            SEManager.Instance.Play(SEPath.NG);
        }
        ShowJudgeSprite();

    }

    // トンガルくんが見つかっていない状態・隠れている状態の時
    public void Hidden()
    {
        _state = TONGULL_STATE.HIDDEN;
        ChangeColor(1);
    }

    /// <summary>
    /// 判定用のSpriteを表示
    /// </summary>
    private void ShowJudgeSprite()
    {
        judgeSpriteRenderer.sprite = judgeSprite;
        BackJudgeSpriteRebderer.sprite = BackJudgeSprite;
        this.tag = "Finish";
        ChangeColor(1);
    }

    /// <summary>
    /// トンガルくんSpriteの色変更
    /// </summary>
    private void ChangeColor(float colorValue)
    {
        tongullkunSpriteRenderer.color = new Color(colorValue, colorValue, colorValue);
    }

}
