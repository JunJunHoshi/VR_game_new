using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigBullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] ParticleSystem hitParticlePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        var velocity = speed * transform.forward;
        var rigidbody = GetComponent<Rigidbody>(); //rigidbodyコンポーネントを取得

        rigidbody.AddForce(velocity, ForceMode.VelocityChange); //velocityに相当した力を加える
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        //衝突したらOnHitBulletという関数を起動
        other.SendMessage("OnHitBullet");
        

        //着弾点に演出も追加
        Instantiate(hitParticlePrefab, transform.position, transform.rotation);
        
    }
}