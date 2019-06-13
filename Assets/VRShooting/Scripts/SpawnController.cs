
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] float spawnInterval = 3f;

    EnemySpawner[] spawners; //EnemySpawnerのリストを作成
    float timer= 0f; //時間測定装置

    // Start is called before the first frame update
    void Start()
    {   //子オブジェクトにたくさんあるEnemySpawnerのリストを獲得する。
        spawners = GetComponentsInChildren<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {   //タイマー更新
        timer += Time.deltaTime;

        //出現時間かどうかを測定
        if (spawnInterval < timer)
        {

            //ランダムに敵出現（敵はspawners[]に詰められていると思って！）
            var index = Random.Range(0, spawners.Length);
            spawners[index].Spawn();
            //タイマーをリセット
            timer = 0f;
        }


    }
}
