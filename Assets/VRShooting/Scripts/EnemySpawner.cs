using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemyPrefabs;
    Enemy enemy; //出現中の敵はまず保持
    

    public void Spawn()
    {
        //出現していなければ出現させる。
        if (enemy == null)
        {
            //ランダムに敵をprefabから選ぶ
            var index = Random.Range(0, enemyPrefabs.Length);
            //選んだ敵のインスタンスを作成
            enemy = Instantiate(enemyPrefabs[index], transform.position, transform.rotation);
        }
        
    }
    
    


}
