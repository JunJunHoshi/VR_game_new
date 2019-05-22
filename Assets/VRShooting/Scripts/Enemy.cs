using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))] //Getcomponentで必要になる。

public class Enemy : MonoBehaviour
{
    [SerializeField] AudioClip spawnClip; //出現時の音
    [SerializeField] AudioClip hitClip; //球命中の音

    // 倒されたに無効化する際のコライダーやレンダラーを設定
    [SerializeField] Collider enemyCollider; //コライダー
    [SerializeField] Renderer enemyRenderer; //レンダラー
    [SerializeField] int point = 1;
    Score score;

    AudioSource audioSource; //再生する用のAudioSource

    // Start is called before the first frame update
    void Start()
    {
        //AudioSourceコンポーネントを取得しておく。
        audioSource = GetComponent<AudioSource>();

        //出現時の音再生
        audioSource.PlayOneShot(spawnClip);

        //ゲームオブジェクトを検索する
        var gameObj = GameObject.FindWithTag("Score");

        //game objectに含まれるScoreコンポネントを取得
        score = gameObj.GetComponent<Score>();

    }

    // Update is called once per frame
    void OnHitBullet()
    {   //命中時に音を再生
        audioSource.PlayOneShot(hitClip);

        //死亡処理
        GoDown();

    }
    //死亡処理
    void GoDown()
    {   //スコアを加算
        score.AddScore(point);

        //当たり判定と表示を消す
        enemyCollider.enabled = false;
        enemyRenderer.enabled = false;

        //自信のオブジェクトを一定時間後に破棄。これにより死亡時も音が鳴り終わってからオブジェクトがなくなる。
        Destroy(gameObject, 1f);


    }

}
