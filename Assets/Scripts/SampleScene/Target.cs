using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Sprite[] judgeSpriteList;
    [SerializeField] SpriteRenderer judgeSpriteRenderer;

    void Start()
    {
        judgeSpriteRenderer.sprite = null;
    }

    
    void Update()
    {
        
    }

    /// <summary>
    /// 判定用のSpriteを表示
    /// </summary>
    public void ShowJudgeSprite()
    {
        if (this.gameObject.CompareTag("Fake"))
        {
            //ばつマークを表示
            judgeSpriteRenderer.sprite = judgeSpriteList[0];
        }
        else if (this.gameObject.CompareTag("Target"))
        {
            //まるマークを表示
            judgeSpriteRenderer.sprite = judgeSpriteList[1];
        }
    }
}
