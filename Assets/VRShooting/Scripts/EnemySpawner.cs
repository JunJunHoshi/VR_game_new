using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab; //　出現させる敵のプレハブ
    [SerializeField] float speed;
    
    Enemy enemy; //出現中の敵はまず保持
    float turntime = 1.0f;
    float timer = 0.0f;


    public void Spawn()
    {
        //出現していなければ出現させる。
        if (enemy == null)
        {
            enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
        
    }
    void Update(){
        if (enemy != null)
        {
            Vector3 velocity = enemy.transform.rotation * new Vector3(0,0,speed);
            enemy.transform.position += velocity * 0.15f;
            timer += Time.deltaTime;
            if (timer > turntime)
            {
                enemy.transform.Rotate(0.0f, Random.Range(0,180), 0.0f);
               timer = 0.0f;

            }
        }
    }


}
