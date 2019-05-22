using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]

public class RemainTimer : MonoBehaviour
{
    [SerializeField] float gameTime = 30.0f;
    Text uiText;
    // Start is called before the first frame update]
    float currentTime;
    void Start()
    {
        uiText = GetComponent<Text>();
        currentTime = gameTime;

        
    }

    // Update is called once per frame
    void Update()
    {
        //残り時間を計算
        currentTime -= Time.deltaTime;

        //0秒以下にはならない

        if (currentTime <= 0)
        {
            currentTime = 0.0f;
        }

        //残り時間のテキストを更新
        uiText.text = string.Format("残り時間 : {0:F}秒", currentTime);

    }

    public bool IsCountingDown()
    {
        //カウンターが0でなければカウント中
        return currentTime > 0.0f;

    }
}
