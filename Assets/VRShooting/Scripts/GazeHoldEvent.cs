using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

//ポインターがUI領域を一定時間指していたら自動タップ(Invoke)するプログラム

public class GazeHoldEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //ボタン管理をタップする時間
    [SerializeField] private float gazeTapTime = 2f;
    //ボタンをタップしたときのイベント
    [SerializeField] private UnityEvent onGazeHold;

    float timer;  //ポインターがUI領域上にある時間
    bool isHover; //ポインターがUI領域上にあるか？
    
    //ポインターがUI領域に入った時のイベント処理
    public void OnPointerEnter(PointerEventData eventData)
    {
        //タイマーを0に
        timer = 0.0f;
        
        //Hover状態へ
        isHover = true;
    }
    //ポインターがUI領域から出た時のイベント処理
    public void OnPointerExit(PointerEventData eventData)
    {
        //Hover状態を解除
        isHover = false;
        
    }

    public void Update()
    {
        //Hover状態でなければ処理は行わない
        if (!isHover)
        {
            return;
        }
        //経過時間が予定以上経った場合
        timer += Time.deltaTime;
        if (timer > gazeTapTime)
        {
            //イベント実行
            onGazeHold.Invoke();
            //Hover状態の解除
            isHover = false;
        }
    }


}
