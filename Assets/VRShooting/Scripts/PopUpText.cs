using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(TextMesh))]

public class PopUpText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //テキストメッシュを獲得
        var textMesh = GetComponent<TextMesh>();
        //DOTweenのシーケンスを作成
        var sequence = DOTween.Sequence();
        
        //最初に拡大
        sequence.Append(transform.DOScale(0.3f, 0.2f));
        
        //次に上に移動させる
        sequence.Append(transform.DOMoveY(3.0f, 0.3f).SetRelative());
        
        //現在の色を獲得
        var color = textMesh.color;
        
        //アルファ値を0に指定して文字を透明にする
        color.a = 0.0f;
        
        //上に移送する同時に半透明にして消えるようにする
        sequence.Join(DOTween.To(() => textMesh.color,
            c => textMesh.color = c, color, 0.3f).SetEase(Ease.InOutQuart));

        //全てのアニメーションが終わったら自分自身を削除
        sequence.OnComplete(() => Destroy(gameObject));
    }
    
}
