using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab; //　出現させる敵のプレハブ

    Enemy enemy; //出現中の敵はまず保持

    public void Spawn()
    {
        //出現していなければ出現させる。
        if (enemy == null) {
            enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
                }
    }
        
    
}
