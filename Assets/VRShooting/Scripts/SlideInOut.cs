using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(RectTransform))]
public class SlideInOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     //RectTransformのコンポーネントを取得し行列を作成
     var rectTransform = GetComponent<RectTransform>();
     var sequence = DOTween.Sequence();
     
     //画面からスライドインし、左からスライドアウトさせる
     sequence.Append(rectTransform.DOMoveX(0.0f, 1.0f));
     sequence.Append(rectTransform.DOMoveX(-1400.0f, 0.8f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
